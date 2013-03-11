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

        internal cImportHeader()
        {
            UnselectedImports = new List<cListfileEntry>();
            SelectedImports = new List<cListfileEntry>();
        }

        internal void AddImport(cListfileEntry Source)
        {
            throw new NotImplementedException();
        }

        internal void RemoveImport(int SourceIndex)
        {
            throw new NotImplementedException();
        }

        internal void ReverseImports(int UpperIndex, int p)
        {
            throw new NotImplementedException();
        }

        internal List<ushort> CreateImportTable()
        {
            throw new NotImplementedException();
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
