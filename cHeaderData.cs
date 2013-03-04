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
        List<List<cListfileEntry>> ImportLabels;


        internal cHeaderData()
        {
            UnassignedLabels = new List<cListfileEntry>();
            ExportLabels = new List<cListfileEntry>();
            ImportLabels = new List<List<cListfileEntry>>();
        }

        internal void ClearLists()
        {
            UnassignedLabels.Clear();
            ExportLabels.Clear();
            ImportLabels.Clear();
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
                List<string> Result = new List<string>();
                foreach (cListfileEntry Item in ImportLabels[Index])
                    Result.Add(Item.GetLabel());
                return Result;
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
        internal bool MoveEntrys(ListName Source, ListName Destination, int SourceIndex, int ImportHeaderIndex)
        {
            List<cListfileEntry> SourceList;
            List<cListfileEntry> DestList;
            if (Source == ListName.Export)
                SourceList = ExportLabels;
            else if (Source == ListName.Import)
                if ((ImportLabels.Count > ImportHeaderIndex) && (ImportHeaderIndex > -1))
                    SourceList = ImportLabels[ImportHeaderIndex];
                else
                    return false;
            else
                SourceList = UnassignedLabels;

            if (Destination == ListName.Export)
                DestList = ExportLabels;
            else if (Destination == ListName.Import)
                if ((ImportLabels.Count > ImportHeaderIndex) && (ImportHeaderIndex > -1))
                    DestList = ImportLabels[ImportHeaderIndex];
                else
                    return false;
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
                    if ((ImportLabels.Count > ImportHeaderIndex) && (ImportHeaderIndex > -1))
                        ImportLabels[ImportHeaderIndex].Reverse(UpperIndex, 2);
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
            foreach (List<cListfileEntry> ListItem in ImportLabels)
            {
                foreach (cListfileEntry Item in ListItem)
                    Result.Add(Item.GetAdress());
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
            foreach (List<cListfileEntry> ListItem in ImportLabels)
            {
                foreach (cListfileEntry Item in ListItem)
                {
                    if (Item.GetLabel() == LabelOfEntry)
                        return Item;
                }
            }
            return new cListfileEntry("");
        }
    }
}
