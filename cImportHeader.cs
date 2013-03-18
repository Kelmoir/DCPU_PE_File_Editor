using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE_File_Exporter
{
    internal class cImportHeader
    {
        List<cListfileEntry> UnselectedImports;
        List<cListfileEntry> SelectedImports;
        List<cListfileEntry> CorrespondingEntrys;

        internal cImportHeader()
        {
            UnselectedImports = new List<cListfileEntry>();
            SelectedImports = new List<cListfileEntry>();
            CorrespondingEntrys = new List<cListfileEntry>();
        }

        internal void AddImport(cListfileEntry Source, int Index)
        {
            CorrespondingEntrys.Add(Source);
            SelectedImports.Add(UnselectedImports[Index]);
            UnselectedImports.RemoveAt(Index);
        }

        internal void RemoveImport(int SourceIndex)
        {
            UnselectedImports.Add(SelectedImports[SourceIndex]);
            SelectedImports.RemoveAt(SourceIndex);
            CorrespondingEntrys.RemoveAt(SourceIndex);
        }

        internal void ReverseImports(int UpperIndex, int count)
        {
            SelectedImports.Reverse(UpperIndex, count);
            CorrespondingEntrys.Reverse(UpperIndex, count);
        }

        internal List<ushort> CreateImportTable()
        {
            List<ushort> Result = new List<ushort>();
            Result.Add(0);
            return;
        }

        internal cListfileEntry GetImportEntry(int SourceIndex)
        {
            throw new NotImplementedException();
        }

        internal List<string> GetLabelList()
        {
            throw new NotImplementedException();
        }

        internal cListfileEntry FindEntryByName(string LabelOfEntry)
        {
            throw new NotImplementedException();
        }
    }
}
