using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PE_File_Exporter
{
    internal class cListFileLoader
    {
        List<cListfileEntry> Readout;
        internal cListFileLoader()
        {
            Readout = new List<cListfileEntry>();
        }

        internal bool ReadListFile()
        {
            OpenFileDialog Dia = new OpenFileDialog();
            Dia.Title = "Select the list file to open";
            Dia.DefaultExt = "lst";
            Dia.Filter = "list files (*.lst)|*.lst|All files (*.*)|*.*";
            if (Dia.ShowDialog() == DialogResult.OK)
            {
                Readout.Clear();
                string Read = "";
                System.IO.Stream Strom = Dia.OpenFile();
                byte Temp = 0;
                int i;
                for (i = 0; i < Strom.Length; i++)
                {
                    Temp = (byte)Strom.ReadByte();
                    if ((Temp != (byte)'\r') && (Temp != (byte)'\n'))       //new line
                    {
                        Read += Convert.ToChar(Temp);
                    }
                    else
                    {
                        if (Read.Length > 0)
                        {
                            Readout.Add(new cListfileEntry(Read));
                            Read = "";
                        }
                    }
                }
                //TODO: obtain information how listfiles are layoutet
                foreach (cListfileEntry Item in Readout)
                {
                    Item.SetHowToParse(ListFiletype.Organic);
                    Item.Parse();           //TODO: change Later
                }
                //remove unimportant entrys
                i = 0;
                while (i < Readout.Count)
                {
                    if (Readout[i].IsUnimportant())
                    {
                        Readout.RemoveAt(i);
                    }
                    else
                    {
                        i++;
                    }
                }
                return true;
            }
            else
                return false;
        }

        internal List<cListfileEntry> GetLabelEntrys()
        {
            List<cListfileEntry> ResultList = new List<cListfileEntry>();
            foreach (cListfileEntry Item in Readout)
            {
                if (Item.IsLabel())
                {
                    ResultList.Add(Item);
                }
            }
            return ResultList;
        }
        internal List<cListfileEntry> GetReadout()
        {
            return Readout;
        }
    }
}
