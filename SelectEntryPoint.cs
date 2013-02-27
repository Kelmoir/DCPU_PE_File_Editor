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
        private List<cListfileEntry> Entrys;
        private cListfileEntry EntryPoint;

        internal SelectEntryPoint(List<cListfileEntry> NewEntrys, cListfileEntry NewEntryPoint)
        {
            InitializeComponent();
            Entrys = NewEntrys;
            EntryPoint = NewEntryPoint;
            foreach (cListfileEntry Item in Entrys)
            {
                lbEntrys.Items.Add(Item.GetLabel());
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

        internal cListfileEntry GetEntryPoint()
        {
            return EntryPoint;
        }

    }
}
