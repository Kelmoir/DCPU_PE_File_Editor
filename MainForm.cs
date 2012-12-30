﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PE_File_Exporter
{
    public partial class MainForm : Form
    {
        FileManager WorkingFile;

        public MainForm()
        {
            InitializeComponent();
            WorkingFile = new FileManager();
        }

        private void openBinFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkingFile = new FileManager();
            if (WorkingFile.ReadNewListFile())
            {
                UpdateLists();
            }
        }
        private void UpdateLists()
        {
            WorkingFile.UpdateExportList(lbExportEntrys);
            WorkingFile.UpdateImportList(lbImportEntrys);
            WorkingFile.UpdateUnusedList(lbUnusedEntrys);
        }
        #region Moving entrys
        private void btAddtoExportList_Click(object sender, EventArgs e)
        {
            if (WorkingFile.MoveEntrys(ListName.Unassigned, ListName.Export, lbUnusedEntrys.SelectedIndex))
                UpdateLists();
        }
        private void btRemoveFromExportList_Click(object sender, EventArgs e)
        {
            if (WorkingFile.MoveEntrys(ListName.Export, ListName.Unassigned, lbExportEntrys.SelectedIndex))
                UpdateLists();
        }
        private void btRemoveFromImportList_Click(object sender, EventArgs e)
        {
            if (WorkingFile.MoveEntrys(ListName.Import, ListName.Unassigned, lbImportEntrys.SelectedIndex))
                UpdateLists();
        }
        private void btAddToImportList_Click(object sender, EventArgs e)
        {
            if (WorkingFile.MoveEntrys(ListName.Unassigned, ListName.Import, lbUnusedEntrys.SelectedIndex))
                UpdateLists();
        }

        private void btExportEntryUp_Click(object sender, EventArgs e)
        {
            if (WorkingFile.SwitchElements(ListName.Export, lbExportEntrys.SelectedIndex - 1))
            {
                lbExportEntrys.SelectedIndex--;
                UpdateLists();
            }
        }
        private void btExportEntryDown_Click(object sender, EventArgs e)
        {
            if (WorkingFile.SwitchElements(ListName.Export, lbExportEntrys.SelectedIndex))
            {
                lbExportEntrys.SelectedIndex++;
                UpdateLists();
            }
        }

        private void btImportListEntryUp_Click(object sender, EventArgs e)
        {
            if (WorkingFile.SwitchElements(ListName.Import, lbExportEntrys.SelectedIndex - 1))
            {
                lbImportEntrys.SelectedIndex--;
                UpdateLists();
            }
        }

        private void btImportListEntryDown_Click(object sender, EventArgs e)
        {
            if (WorkingFile.SwitchElements(ListName.Import, lbExportEntrys.SelectedIndex))
            {
                lbImportEntrys.SelectedIndex++;
                UpdateLists();
            }
        }
        #endregion

        private void exportFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WorkingFile.Export(MD5calcFromSpec.CalcMD5(tbSpecFunction.Text, tbSpecName.Text, tbSpecPublisher.Text, cbRevMaj.SelectedIndex, cbRefMin.SelectedIndex));
        }


    }
}