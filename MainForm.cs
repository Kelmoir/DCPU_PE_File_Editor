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
    public partial class MainForm : Form
    {
        FileManager WorkingFile;
        List<cHeaderData> AvaiableLibs;

        public MainForm()
        {
            InitializeComponent();
            WorkingFile = new FileManager();
            AvaiableLibs = new List<cHeaderData>();
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
            WorkingFile.UpdateImportList(lbImportEntrys, cbImportHeaderSelect.SelectedIndex);
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
            if (WorkingFile.RemoveImport(lbImportEntrys.SelectedIndex, cbImportHeaderSelect.SelectedIndex))
                UpdateLists();
        }
        private void btAddToImportList_Click(object sender, EventArgs e)
        {
            if (WorkingFile.AddImport(lbUnusedEntrys.SelectedIndex, cbImportHeaderSelect.SelectedIndex, lbAvaiableItemsForImport.SelectedIndex))
                UpdateLists();
        }

        private void btExportEntryUp_Click(object sender, EventArgs e)
        {
            if (WorkingFile.SwitchElements(ListName.Export, lbExportEntrys.SelectedIndex - 1, cbImportHeaderSelect.SelectedIndex))
            {
                lbExportEntrys.SelectedIndex--;
                UpdateLists();
            }
        }
        private void btExportEntryDown_Click(object sender, EventArgs e)
        {
            if (WorkingFile.SwitchElements(ListName.Export, lbExportEntrys.SelectedIndex, cbImportHeaderSelect.SelectedIndex))
            {
                lbExportEntrys.SelectedIndex++;
                UpdateLists();
            }
        }

        private void btImportListEntryUp_Click(object sender, EventArgs e)
        {
            if (WorkingFile.SwitchElements(ListName.Import, lbImportEntrys.SelectedIndex - 1, cbImportHeaderSelect.SelectedIndex))
            {
                lbImportEntrys.SelectedIndex--;
                UpdateLists();
            }
        }

        private void btImportListEntryDown_Click(object sender, EventArgs e)
        {
            if (WorkingFile.SwitchElements(ListName.Import, lbImportEntrys.SelectedIndex, cbImportHeaderSelect.SelectedIndex))
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

        private void btSelectEntryPoint_Click(object sender, EventArgs e)
        {
            WorkingFile.SelectNewEntryPoint();
            tbEntryPoint.Text = WorkingFile.GetEntyPointName();
        }

        private void btDeleteEntryPoint_Click(object sender, EventArgs e)
        {
            WorkingFile.DeleteEntryPoint();
            tbEntryPoint.Text = WorkingFile.GetEntyPointName();
        }

    }
}
