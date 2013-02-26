﻿using System;
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
        string ImportName;      //todo: check is correct that way, don't know why there are names at all
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
                if (UpperIndex < 0)
                    return false;
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
            List<ushort> MD5List = DCPU_Utilitys.cHexInterface.ConvertToUshortList(MD5);
            List<ushort> RelocationTable = CreateRelocationTable();
            ushort ExecutableOffset = (ushort)(Output.Count + 4 + ImportLabels.Count + ExportTable.Count);
            Output.Add(0x010c);     //Header
            Output.Add(0xFFFF);     //next header, for now not existant 
            Output.AddRange(MD5List);
            if (CreateOwnThread)        //RVA entry point
                Output.Add(ExecutableOffset);
            else
                Output.Add(0x0000);
            Output.Add((ushort)(Output.Count + 3));        //Import Table Adress
            Output.Add((ushort)(Output.Count + 2 + ImportLabels.Count));        //Export Table Adress
            Output.Add((ushort)(Output.Count + 1 + ImportLabels.Count + ExportTable.Count + Executable.Count));        //relocation Table Adress
            Output.Add((ushort)Executable.Count);        //Size of the Executable image 
            foreach (ushort Item in ImportTable)
                Output.Add((ushort)Item);
            foreach (ushort Item in ExportTable)
                Output.Add((ushort)Item);
            Output.AddRange(Executable);
            foreach (ushort Item in RelocationTable)
                Output.Add((ushort)Item);

            
        }

        private List<ushort> CreateRelocationTable()
        {
            List<ushort> Result = new List<ushort>();
            List<ushort> Temp;
            foreach (cListfileEntry Item in ActualReadOut)
            {
                Temp = Item.GetRefenencedLabels();
                foreach (ushort ItemUshort in Temp)     //doing ushort by ushort to make a deep copy
                    Result.Add(ItemUshort);
            }
            return Result;
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

        private List<ushort> CreateExportTable()
        {
            List<ushort> Result = new List<ushort>();
            foreach (cListfileEntry Item in ExportLabels)
                Result.Add(Item.GetAdress());
            if (Result.Count == 0)
                Result.Add(0);
            else
                Result.Add(0xFFFF);
            return Result;
        }

        private List<ushort> CreateImportTable()       //TODO: change so it actually reassembles a list of import Tables...
        {
            List<ushort> Result = new List<ushort>();
            foreach (cListfileEntry Item in ImportLabels)
                Result.Add(Item.GetAdress());
            if (Result.Count == 0)
                Result.Add(0);
            else
                Result.Add(0xFFFF);
            return Result;
        }
    }
}
