using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TycoopolisContracts
{
    public partial class ContractManager : Form
    {
        List<Contract> contracts;

        public ContractManager(List<Contract> contracts)
        {
            this.contracts = contracts;
            InitializeComponent();
            selected(false);
            refreshList();
        }

        //GUI
        private void btnAdd_Click(object sender, EventArgs e)
        {
            add();
        }

        //FUNCTIONS
        private void add()//add new contact
        {
            //search for a not assigned name
            String newName = "new";
            int number = 2;
            while(containName(newName))
            {
                newName = "new (" + number + ")";
                number++;
            }

            contracts.Add(new Contract(newName));
            refreshList();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (containName(txtContractName.Text))
                {
                    throw new Exception("contract name already exist!");
                }
                contracts[lstOverview.SelectedIndex].save(txtContractName.Text, txtPartner.Text, dtpDurationStart.Value, dtpDurationEnd.Value,
                    Convert.ToInt32(txtPeriod.Text), txtProduct.Text, Convert.ToInt32(txtQuantity.Text), txtUnit.Text, Convert.ToDouble(txtPrice.Text),
                    cmbDirection.SelectedIndex, txtDestination.Text, rtxtDescription.Text);

                int selected = lstOverview.SelectedIndex;
                refreshList();
                lstOverview.SelectedIndex = selected;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save failed!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selection = lstOverview.SelectedIndex;
            contracts.RemoveAt(selection);
            refreshList();
            if (selection == 0)
            {
                if (lstOverview.Items.Count > 0)
                {
                    lstOverview.SelectedIndex = 0;
                }
                else
                {
                    lstOverview.SelectedIndex = -1;
                }
            }
            else
            {
                lstOverview.SelectedIndex = (selection - 1);
            }
            indexChange();
        }

        //BACKGROUND FUNCTIONS
        //List
        private void refreshList()
        {
            lstOverview.Items.Clear();
            foreach(Contract c in contracts)
            {
                lstOverview.Items.Add(c.Name);
            }
        }
        private void lstOverview_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexChange();
        }
        private void indexChange()
        {
            if (lstOverview.SelectedIndex == -1)
            {
                selected(false);
            }
            else
            {
                selected(true);
                loadContract(lstOverview.SelectedIndex);
            }
        }
        private void selected(bool selected)//activate or deactivate the contract-form
        {
            if(selected)
            {
                txtContractName.Enabled = true;
                txtPartner.Enabled = true;
                dtpDurationStart.Enabled = true;
                dtpDurationEnd.Enabled = true;
                txtPeriod.Enabled = true;
                txtProduct.Enabled = true;
                txtQuantity.Enabled = true;
                txtUnit.Enabled = true;
                txtPrice.Enabled = true;
                cmbDirection.Enabled = true;
                txtDestination.Enabled = true;
                rtxtDescription.Enabled = true;
                btnSave.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                txtContractName.Enabled = false;
                txtContractName.Text = "";
                txtPartner.Enabled = false;
                txtPartner.Text = "";
                dtpDurationStart.Enabled = false;
                dtpDurationStart.Value = DateTime.Today;
                dtpDurationEnd.Enabled = false;
                dtpDurationEnd.Value = DateTime.Today;
                txtPeriod.Enabled = false;
                txtPeriod.Text = "";
                txtProduct.Enabled = false;
                txtProduct.Text = "";
                txtQuantity.Enabled = false;
                txtQuantity.Text = "";
                txtUnit.Enabled = false;
                txtUnit.Text = "";
                txtPrice.Enabled = false;
                txtPrice.Text = "";
                cmbDirection.Enabled = false;
                cmbDirection.SelectedIndex = -1;
                txtDestination.Enabled = false;
                txtDestination.Text = "";
                rtxtDescription.Enabled = false;
                rtxtDescription.Text = "";
                btnSave.Enabled = false;
                btnDelete.Enabled = false;

            }
        }

        //Contracts
        private bool containName(String name)
        {
            foreach (Contract c in contracts)
            {
                if (c.Name == name && contracts[lstOverview.SelectedIndex] != c)//if name already exist(excluded himself)
                {
                    return true;
                }
            }
            return false;
        }
        private void loadContract(int index)
        {
            Contract c = contracts[index];

            txtContractName.Text = c.Name;
            txtPartner.Text = c.Partner;
            dtpDurationStart.Value = c.Start;
            dtpDurationEnd.Value = c.End;
            txtPeriod.Text = c.Period.ToString();
            txtProduct.Text = c.Product;
            txtQuantity.Text = c.Quantity.ToString();
            txtUnit.Text = c.Unit;
            txtPrice.Text = c.Price.ToString();
            cmbDirection.SelectedIndex = c.Direction;
            txtDestination.Text = c.Destination;
            rtxtDescription.Text = c.Description;
        }  
    }
}
