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
    public partial class OptionsWindow : Form
    {
        private Options options;

        private OptionsWindow(Options curOptions)
        {
            DialogResult = DialogResult.Abort;
            options = curOptions;
            InitializeComponent();
            loadOptions();
        }

        //GUI
        private void btnSavepath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            folderDialog.SelectedPath = txtSavepath.Text;
            if(folderDialog.ShowDialog() == DialogResult.OK)
            {
                txtSavepath.Text = folderDialog.SelectedPath;
            }   
                     
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveOptions();
            Close();
        }
        private void btnAbort_Click(object sender, EventArgs e)
        {
            Close();
        }


        //GUI-BACKGROUND
        private void saveOptions()
        {
            options.savePath = txtSavepath.Text;
        }
        private void loadOptions()
        {
            txtSavepath.Text = options.savePath;
        }


        //FUNCTIONS
        public static Options Show(Options curOptions)
        {
            OptionsWindow window = new OptionsWindow(curOptions.Copy());

            //Show GUI
            window.ShowDialog();
            return window.options;
        } 
    }
}
