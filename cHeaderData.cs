using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE_File_Exporter
{
    /// <summary>
    /// Stores all Data related to the PE Headers
    /// </summary>
    internal class cHeaderData
    {
        List<cListfileEntry> UnassignedLabels;
        List<cListfileEntry> ExportLabels;
        List<cImportHeader> ImportLibs;


        internal cHeaderData()
        {
            UnassignedLabels = new List<cListfileEntry>();
            ExportLabels = new List<cListfileEntry>();
            ImportLibs = new List<cImportHeader>();
        }

        internal void ClearLists()
        {
            UnassignedLabels.Clear();
            ExportLabels.Clear();
            ImportLibs.Clear();
        }

        internal void SetUnassignedLabels(List<cListfileEntry> Entrys)
        {
            UnassignedLabels = Entrys;
            SolveLocalLabels(UnassignedLabels);
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

        #region get Lists
        /// <summary>
        /// returns an List of the actual unassigned Labels
        /// </summary>
        /// <returns></returns>
        internal List<string> GetUnassignedLabelString()
        {
            List<string> Result = new List<string>();
            foreach (cListfileEntry Item in UnassignedLabels)
                Result.Add(Item.GetLabel());
            return Result;
        }
        /// <summary>
        /// returns an List of the actual unassigned Labels
        /// </summary>
        /// <returns></returns>
        internal List<string> GetExportLabelString()
        {
            List<string> Result = new List<string>();
            foreach (cListfileEntry Item in ExportLabels)
                Result.Add(Item.GetLabel());
            return Result;
        }
        /// <summary>
        /// returns an List of the actual Import Labels
        /// </summary>
        /// <param name="Index">the Index of the Import Header</param>
        /// <returns></returns>
        internal List<string> GetImportLabelString(int Index)
        {
            try
            {
                return ImportLibs[Index].GetLabelList();
            }
            catch
            {
                return new List<string>();
            }
        }
        #endregion


        #region move entrys around
        /// <summary>
        /// Moves the selected Entry onto the new list
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Destination"></param>
        /// <param name="SourceIndex"></param>
        /// <param name="ImportHeaderIndex"></param>
        /// <returns></returns>
        internal bool MoveEntrys(ListName Source, ListName Destination, int SourceIndex)
        {
            try
            {
                cListfileEntry MoveItem;

                if (Source == ListName.Export)
                {
                    MoveItem = ExportLabels[SourceIndex];
                    ExportLabels.RemoveAt(SourceIndex);
                }
                else if (Source == ListName.Unassigned)
                {
                    MoveItem = UnassignedLabels[SourceIndex];
                    UnassignedLabels.RemoveAt(SourceIndex);
                }
                else
                    return false;

                if (Destination == ListName.Export)
                    ExportLabels.Add(MoveItem);
                else if (Destination == ListName.Unassigned)
                {
                    UnassignedLabels.Add(MoveItem);
                }
                else
                    return false;

                return true;
            }
            catch
            {
                return false;
            }
        }

        internal bool AddImport(int UnusedIndex, int HeaderIndex, int ImportEntryIndex)
        {
            try
            {
                ImportLibs[HeaderIndex].AddImport(UnassignedLabels[UnusedIndex], ImportEntryIndex);
                UnassignedLabels.RemoveAt(UnusedIndex);
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal bool RemoveImport(int ImportLabelIndex, int HeaderIndex)
        {
            try
            {
                UnassignedLabels.Add(ImportLibs[HeaderIndex].GetImportEntry(ImportLabelIndex);
                ImportLibs[HeaderIndex].RemoveImport(ImportLabelIndex);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// switches 2 elements of an List, according to everything...
        /// </summary>
        /// <param name="ListToWorkOn"></param>
        /// <param name="UpperIndex"></param>
        /// <param name="ImportHeaderIndex"></param>
        /// <returns></returns>
        internal bool SwitchElements(ListName ListToWorkOn, int UpperIndex, int ImportHeaderIndex)
        {
            try
            {
                if (UpperIndex < 0)
                    return false;
                if (ListToWorkOn == ListName.Export)
                    ExportLabels.Reverse(UpperIndex, 2);
                else if (ListToWorkOn == ListName.Import)
                    if ((ImportLibs.Count > ImportHeaderIndex) && (ImportHeaderIndex > -1))
                        ImportLibs[ImportHeaderIndex].ReverseImports(UpperIndex, 2);
                    else
                        return false;
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

        #region generate Adress lists for exporting/importing/whatever
        internal  List<ushort> CreateExportTable()
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
        internal List<ushort> CreateImportTable()       //TODO: change so it actually reassembles a list of import Tables...
        {
            List<ushort> Result = new List<ushort>();
            foreach (cImportHeader Item in ImportLibs)
            {
                Result.AddRange(Item.CreateImportTable());
            }
            if (Result.Count == 0)
                Result.Add(0);
            else
                Result.Add(0xFFFF);
            return Result;
        }


        #endregion

        internal cListfileEntry FindEntryByName(string LabelOfEntry)
        {
            foreach (cListfileEntry Item in UnassignedLabels)
            {
                if (Item.GetLabel() == LabelOfEntry)
                    return Item;
            }
            foreach (cListfileEntry Item in ExportLabels)
            {
                if (Item.GetLabel() == LabelOfEntry)
                    return Item;
            }
            foreach (cImportHeader Item in ImportLibs)
            {
                cListfileEntry TempItem = Item.FindEntryByName(LabelOfEntry);
                if (TempItem != null)
                    return TempItem;
            }
            return new cListfileEntry("");
        }

        /// <summary>
        /// Creates an Saving string, that can be saved and loaded later
        /// </summary>
        /// <returns>the save string</returns>
        internal string CreateSavestring()
        {
            string Savestring = "--ExportLabels:\r\n";
            foreach (cListfileEntry Item in ExportLabels)
                Savestring += Item.CreateSavestring();
            return Savestring;
        }
    }
}
