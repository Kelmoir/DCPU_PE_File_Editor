using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE_File_Exporter
{
    enum ListName
    {
        Unassigned = 0,
        Export = 1,
        Import = 2
    }
    internal class FileManager
    {
        List<cListfileEntry> ActualReadOut;
        List<cListfileEntry> UnassignedLabels;
        List<cListfileEntry> ExportLabels;
        List<cListfileEntry> ImportLabels;
        string HeaderName;
        string ImportName;      //todo: chack is correct that way, don't know why there are names at all
        private bool CreateOwnThread;

        internal FileManager()
        {
            ActualReadOut = new List<cListfileEntry>();
            UnassignedLabels = new List<cListfileEntry>();
            ExportLabels = new List<cListfileEntry>();
            ImportLabels = new List<cListfileEntry>();
            CreateOwnThread = false;
        }

        internal bool ReadNewListFile()
        {
            cListFileLoader Loader = new cListFileLoader();
            try
            {
                if (Loader.ReadListFile())
                {
                    ActualReadOut = Loader.GetReadout();
                    ExportLabels.Clear();
                    ImportLabels.Clear();
                    UnassignedLabels = Loader.GetLabelEntrys();
                    SolveLocalLabels(UnassignedLabels);
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Unable to read the List file.\r\n\r\n" + ex.ToString());
            }
            return false;
        }

        private void SolveLocalLabels(List<cListfileEntry> Labels)
        {
            string PreName = "";
            foreach (cListfileEntry Item in Labels)
            {
                if (Item.IsLocalLabel())      //local label
                {
                    Item.PrecendLabel(PreName);
                }
                else
                {
                    PreName = Item.GetLabel();
                }
            }
        }
        #region GetLabelLists
        internal void UpdateUnusedList(System.Windows.Forms.ListBox Box)
        {
            int Temp = Box.SelectedIndex;
            Box.SelectedIndex = -1;
            Box.Items.Clear();
            foreach (cListfileEntry Item in UnassignedLabels)
                Box.Items.Add(Item.GetLabel());
            if (Temp < Box.Items.Count)
                Box.SelectedIndex = Temp;
            else
                Box.SelectedIndex = Box.Items.Count - 1;
        }
        internal void UpdateExportList(System.Windows.Forms.ListBox Box)
        {
            int Temp = Box.SelectedIndex;
            Box.SelectedIndex = -1;
            Box.Items.Clear();
            foreach (cListfileEntry Item in ExportLabels)
                Box.Items.Add(Item.GetLabel());
            if (Temp < Box.Items.Count)
                Box.SelectedIndex = Temp;
            else
                Box.SelectedIndex = Box.Items.Count - 1;
        }
        internal void UpdateImportList(System.Windows.Forms.ListBox Box)
        {
            int Temp = Box.SelectedIndex;
            Box.SelectedIndex = -1;
            Box.Items.Clear();
            foreach (cListfileEntry Item in ImportLabels)
                Box.Items.Add(Item.GetLabel());
            if (Temp < Box.Items.Count)
                Box.SelectedIndex = Temp;
            else
                Box.SelectedIndex = Box.Items.Count - 1;
        }
        #endregion

        #region move entrys around
        internal bool MoveEntrys(ListName Source, ListName Destination, int SourceIndex)
        {
            List<cListfileEntry> SourceList;
            List<cListfileEntry> DestList;
            if (Source == ListName.Export)
                SourceList = ExportLabels;
            else if (Source == ListName.Import)
                SourceList = ImportLabels;
            else
                SourceList = UnassignedLabels;

            if (Destination == ListName.Export)
                DestList = ExportLabels;
            else if (Destination == ListName.Import)
                DestList = ImportLabels;
            else
                DestList = UnassignedLabels;

            try
            {
                DestList.Add(SourceList[SourceIndex]);
                SourceList.RemoveAt(SourceIndex);
                return true;
            }
            catch
            {
                return false;
            }
        }
        internal bool SwitchElements(ListName ListToWorkOn, int UpperIndex)
        {
            try
            {
                if (ListToWorkOn == ListName.Export)
                    ExportLabels.Reverse(UpperIndex, 2);
                else if (ListToWorkOn == ListName.Import)
                    ImportLabels.Reverse(UpperIndex, 2);
                else
                    UnassignedLabels.Reverse(UpperIndex, 2);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        internal void Export(byte[] MD5)
        {
            List<ushort> Output = new List<ushort>();
            List<ushort> ImportTable = CreateImportTable();
            List<ushort> ExportTable = CreateExportTable();
            List<ushort> Executable = ObtainExecutableImage();
            ushort ExecutableOffset = (ushort)(Output.Count + 4 + ImportLabels.Count + ExportTable.Count);
            ushort[] DataTemp;
            Output.Add(0x010c);     //Header
            Output.Add(0xFFFF);     //next header, for now not existant 
            while (this.HeaderName.Length < 20)
                HeaderName += " ";
            if (HeaderName.Length > 20)
                HeaderName = HeaderName.Substring(0, 20);
            DataTemp = DCPU_Utilitys.cHexInterface.ConverToUshortArray(HeaderName);
            foreach (ushort Item in DataTemp)
                Output.Add(Item);
            if (CreateOwnThread)        //RVA entry point
                Output.Add(ExecutableOffset);
            else
                Output.Add(0x0000);
            Output.Add((ushort)(Output.Count + 3));        //Import Table Adress
            Output.Add((ushort)(Output.Count + 2 + ImportLabels.Count));        //Export Table Adress
            Output.Add((ushort)(Output.Count + 1 + ImportLabels.Count + ExportTable.Count + Executable.Count));        //relocation Table Adress
            Output.Add((ushort)Executable.Count);        //Size of the Executable image TODO: calaculate that first
            foreach (ushort Item in ImportLabels)
                Output.Add((ushort)Item + ExecutableOffset);


            
        }

        private List<ushort> ObtainExecutableImage()
        {
            throw new NotImplementedException();
        }

        private List<ushort> CreateExportTable()
        {
            throw new NotImplementedException();
        }

        private List<ushort> CreateImportTable()
        {
            throw new NotImplementedException();
        }
    }
}
