using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PE_File_Exporter
{
    internal partial class SelectEntryPoint : Form
    {
        private List<string> Entrys;
        private string EntryPoint;

        internal SelectEntryPoint(List<string> NewEntrys)
        {
            InitializeComponent();
            Entrys = NewEntrys;
            foreach (string Item in NewEntrys)
            {
                lbEntrys.Items.Add(Item);
            }
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            try
            {
                EntryPoint = Entrys[lbEntrys.SelectedIndex];
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch
            {
                MessageBox.Show("invalid element selected");
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        internal string GetEntryPointLabel()
        {
            return EntryPoint;
        }

    }
}
