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
        cHeaderData Header;
        List<ushort> RelocationTable;               //TODO fill from somewhere :x won't calculate it
        string HeaderName;
        string ImportName;      //todo: check is correct that way, don't know why there are names at all
        cListfileEntry EntryPoint;
        private bool CreateOwnThread;

        internal FileManager()
        {
            ActualReadOut = new List<cListfileEntry>();
            Header = new cHeaderData();
            EntryPoint = null;
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
                    Header.ClearLists();
                    Header.SetUnassignedLabels(Loader.GetLabelEntrys());
                    return true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Unable to read the List file.\r\n\r\n" + ex.ToString());
            }
            return false;
        }


        #region GetLabelLists
        internal void UpdateUnusedList(System.Windows.Forms.ListBox Box)
        {
            int Temp = Box.SelectedIndex;
            Box.SelectedIndex = -1;
            Box.Items.Clear();
            List<string> Entrys = Header.GetUnassignedLabelString();
            foreach (string Item in Entrys)
                Box.Items.Add(Item);
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
            List<string> Entrys = Header.GetExportLabelString();
            foreach (string Item in Entrys)
                Box.Items.Add(Item);
            if (Temp < Box.Items.Count)
                Box.SelectedIndex = Temp;
            else
                Box.SelectedIndex = Box.Items.Count - 1;
        }
        internal void UpdateImportList(System.Windows.Forms.ListBox Box, int ImportHeaderIndex)
        {
            int Temp = Box.SelectedIndex;
            Box.SelectedIndex = -1;
            Box.Items.Clear();
            List<string> Entrys = Header.GetImportLabelString(ImportHeaderIndex);
            foreach (string Item in Entrys)
                Box.Items.Add(Item);
            if (Temp < Box.Items.Count)
                Box.SelectedIndex = Temp;
            else
                Box.SelectedIndex = Box.Items.Count - 1;
        }
        #endregion

        #region move entrys around
        internal bool MoveEntrys(ListName Source, ListName Destination, int SourceIndex, int ImportHeaderIndex)
        {
            return Header.MoveEntrys(Source, Destination, SourceIndex, ImportHeaderIndex);
        }
        internal bool SwitchElements(ListName ListToWorkOn, int UpperIndex, int ImportHeaderIndex)
        {
            return Header.SwitchElements(ListToWorkOn, UpperIndex, ImportHeaderIndex);
        }

        #endregion

        internal void Export(byte[] MD5)
        {
            List<ushort> Output = new List<ushort>();
            List<ushort> ImportTable = Header.CreateImportTable();
            List<ushort> ExportTable = Header.CreateExportTable();
            List<ushort> Executable = ObtainExecutableImage();
            List<ushort> MD5List = DCPU_Utilitys.cHexInterface.ConvertToUshortList(MD5);
            //TODO: Relocation table anyone?
            ushort ExecutableOffset = (ushort)(Output.Count + 4 + ImportTable.Count + ExportTable.Count);       //TODO determine Import Table Length
            Output.Add(0x010c);     //Header
            Output.Add(0xFFFF);     //next header, for now not existant 
            Output.AddRange(MD5List);
            if (CreateOwnThread)        //RVA entry point
                Output.Add(EntryPoint.GetAdress());
            else
                Output.Add(0x0000);
            Output.Add((ushort)(Output.Count + 3));        //Import Table Adress
            Output.Add((ushort)(Output.Count + 2 + ImportTable.Count));        //Export Table Adress
            Output.Add((ushort)(Output.Count + 1 + ImportTable.Count + ExportTable.Count + Executable.Count));        //relocation Table Adress
            Output.Add((ushort)Executable.Count);        //Size of the Executable image 
            foreach (ushort Item in ImportTable)
                Output.Add((ushort)Item);
            foreach (ushort Item in ExportTable)
                Output.Add((ushort)Item);
            Output.AddRange(Executable);
            foreach (ushort Item in RelocationTable)
                Output.Add((ushort)Item);

            
        }

        private List<ushort> ObtainExecutableImage()
        {
            List<ushort> Result = new List<ushort>();
            List<ushort> Temp;
            foreach (cListfileEntry Item in ActualReadOut)
            {
                Temp = Item.GetBinary();
                foreach (ushort ItemUshort in Temp)     //doing ushort by ushort to make a deep copy
                    Result.Add(ItemUshort);
            }
            return Result;
        }




        /// <summary>
        /// Gets the Name of the main Entry point
        /// </summary>
        /// <returns></returns>
        internal string GetEntyPointName()
        {
            if (CreateOwnThread && EntryPoint != null)
                return EntryPoint.GetLabel();
            else
                return "";
        }

        internal void SelectNewEntryPoint()
        {
            List<string> Entrys = new List<string>();
            Entrys.AddRange(Header.GetUnassignedLabelString());
            Entrys.AddRange(Header.GetExportLabelString());
            SelectEntryPoint NewPoint = new SelectEntryPoint(Entrys);
            if (NewPoint.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                EntryPoint = Header.FindEntryByName(NewPoint.GetEntryPointLabel());
                CreateOwnThread = true;
            }
        }
        internal void DeleteEntryPoint()
        {
            EntryPoint = null;
            CreateOwnThread = false;
        }
    }
}
