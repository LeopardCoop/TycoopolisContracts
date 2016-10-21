using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace TycoopolisContracts
{
    public partial class frmMain : Form
    {
        const int tycoopolisContractsVersion = 1;//verion of xml-schema

        List<Contract> contracts = new List<Contract>();
        List<int> contractLinks = new List<int>();//Give for every element in the todo-list the index of the contract
        List<int> deliveryDayIndex = new List<int>();//Give for every element in the todo-list the index of the specific deliveryDay
        bool updateMode = false;//In the updateMode nothing will be write in the contracts(need for clstTodo_ItemCheck)

        public frmMain()
        {
            loadFromData();
            InitializeComponent();
            updateTodo();
        }

        //MENUE
        private void contractsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContractManager cmanager = new ContractManager(contracts);
            cmanager.ShowDialog();
            try
            {
                saveToData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The changed datas can't be saved in a file on the harddisk. Please contact the developer with the error-informations:\n" +
                    ex.GetType().ToString() + "|" + ex.Message);
            }
            updateTodo();
        }

        //CALENDER
        private void cldCalender_DateChanged(object sender, DateRangeEventArgs e)//date choice
        {
            updateTodo();
        }

        //TODO'S
        private void updateTodo()//insert the todos of the selected day
        {
            updateMode = true;

            clstTodo.Items.Clear();
            contractLinks.Clear();
            deliveryDayIndex.Clear();

            foreach (Contract c in contracts)
            {
                if (c.getDeliveryDays().Contains(cldCalender.SelectionStart))
                {
                    String todo = "";
                    todo += c.Quantity + c.Unit + " " + c.Product;
                    if(c.Direction == 0)
                    {
                        todo += " from " + c.Partner;
                    }
                    else
                    {
                        todo += " to " + c.Destination + "(" + c.Partner + ")";
                    }

                    int spcDeliveryDayIndex = c.getDeliveryDays().IndexOf(cldCalender.SelectionStart);

                    clstTodo.Items.Add(todo, c.getDeliveryDayCheck(spcDeliveryDayIndex));
                    contractLinks.Add(contracts.IndexOf(c));
                    deliveryDayIndex.Add(spcDeliveryDayIndex);
                }
            }

            updateMode = false;
        }
        private void clstTodo_ItemCheck(object sender, ItemCheckEventArgs e)//if a item will be checked
        {
            if(updateMode)
            {
                return;
            }
            //get the new value
            bool newValue = false;
            if(e.NewValue == CheckState.Checked)
            {
                newValue = true;
            }
            contracts[contractLinks[e.Index]].setDeliveryDayCheck(deliveryDayIndex[e.Index], newValue);
            saveToData();
        }

        //BACKGROUND-FUNCTIONS
        private void saveToData()
        {
            XmlDocument data = new XmlDocument();

            //create the root
            XmlElement root = data.CreateElement("TycoopolisContracts");
            XmlAttribute version = data.CreateAttribute("version");
            version.Value = tycoopolisContractsVersion.ToString();
            root.Attributes.Append(version);

            foreach(Contract c in contracts)//each contract create his self
            {
                root.AppendChild(c.saveToXml(data));
            }

            data.AppendChild(root);//packing all into the document

            data.Save(Application.StartupPath + "\\Contracts.xml");//save on harddisk
        }
        private void loadFromData()
        {
            try
            {
                XmlDocument data = new XmlDocument();
                data.Load(Application.StartupPath + "\\Contracts.xml");
                XmlNode root = data.ChildNodes[0];


                //check the version and convert if it is necessary and possible
                int version = Convert.ToInt32(root.Attributes["version"].Value);
                if (version != tycoopolisContractsVersion)
                {
                    convertDataToCurVersion(data, version);
                    return;//abort this load-try
                }


                //load
                foreach(XmlNode xmlContract in root.ChildNodes)
                {
                    contracts.Add(Contract.load(xmlContract));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(DateTime.Today));
            }
        }
        private void convertDataToCurVersion(XmlDocument data, int version)//convert xml if it is possible
        {
            switch (version)
            {
                default:
                    data.Save(Application.StartupPath + "\\ContractsV" + version + ".xml");
                    MessageBox.Show("Sorry, the actual version of your contracts-savefile can't be load. it was backed as ContractsV" + 
                        version + ".xml and a new file (Contracts.xml) will be created with the first contract)", "Contracts loading failed!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
            }
            loadFromData();//try to load again, if the convert was possible
        }
    }
}
