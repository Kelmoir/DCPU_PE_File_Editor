using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE_File_Exporter
{
    class cListfileEntry
    {
        private string ListReadout;
        private bool Label;
        private List<ushort> Opcodes;
        private ushort Address;
        private string FileName;
        private int LineNumber;
        private string AssemblerCode;
        private ListFiletype HowTo;

        internal cListfileEntry(string ReadOut)
        {
            ListReadout = ReadOut;
            Label = false;
            Opcodes = new List<ushort>();
            Address = 0;
            FileName = "";
            LineNumber = 0;
            AssemblerCode = "";
            HowTo = ListFiletype.unknown;
        }

        internal bool IsEmpty()
        {
            return (ListReadout == "");
        }

        internal void AddCharToReadout(char NewChar)
        {
            ListReadout += Convert.ToString(NewChar);
        }

        internal void Parse()
        {
            string Temp = ListReadout;
            string TempWork;
            if (HowTo == ListFiletype.Organic)
            {
                //1st thing: the File name
                FileName = "";
                while (Temp.Substring(0, 1) != " ")
                {
                    FileName += Temp.Substring(0, 1);
                    Temp = Temp.Substring(1, Temp.Length - 1);
                }
                Temp = Temp.Trim();
                //2nd thing the line in the source file
                TempWork = "";
                while (Temp.Substring(0, 1) != " ")
                    Temp = Temp.Substring(1, Temp.Length - 1);
                Temp = Temp.Trim();
                while (Temp.Substring(0, 1) != ")")
                {
                    TempWork += Temp.Substring(0, 1);
                    Temp = Temp.Substring(1, Temp.Length - 1);
                }
                LineNumber = Convert.ToInt32(TempWork);
                Temp = Temp.Substring(2, Temp.Length - 2);
                Temp = Temp.Trim();
                //3rd thing: Adress in the DCPU memory
                TempWork = "";
                while (Temp.Substring(0, 1) == "[")
                    Temp = Temp.Substring(1, Temp.Length - 1);
                while (Temp.Substring(0, 1) != "]")
                {
                    TempWork += Temp.Substring(0, 1);
                    Temp = Temp.Substring(1, Temp.Length - 1);
                }
                Address = DCPU_Utilitys.cHexInterface.ConvertToUshort(TempWork, true);
                Temp = Temp.Substring(1, Temp.Length - 1);
                Temp = Temp.Trim();
                //4th thing: either opcodes or the assembler code
                //how to differentiate Opcodes from assembler code? Well, the cHexConverteil will convert the opcodes and they are 4 chars wide...
                //and after some non-opcode can't follow some Opcode...
                char[] Sperator = new char[1];
                Sperator[0] = ' ';
                string[] TempArray = Temp.Split(Sperator, StringSplitOptions.RemoveEmptyEntries);
                bool OpcodePossible = true;
                AssemblerCode = "";
                foreach (string Item in TempArray)
                {
                    if ((Item.Length == 4) && OpcodePossible)
                    {
                        try
                        {
                            Opcodes.Add(DCPU_Utilitys.cHexInterface.ConvertToUshort(Item, false));
                        }
                        catch
                        {
                            OpcodePossible = false;
                            if (AssemblerCode != "")
                            {
                                AssemblerCode += " ";
                            }
                            AssemblerCode += Item;
                        }
                    }
                    else
                    {
                        OpcodePossible = false;
                        if (AssemblerCode != "")
                        {
                            AssemblerCode += " ";
                        }
                        AssemblerCode += Item;
                    }
                }
                Label = false;
                if (AssemblerCode.Length > 0)
                {
                    if (AssemblerCode.Substring(AssemblerCode.Length - 1) == ":")
                    {
                        Label = true;
                    }
                }
            }
            else
            {
                throw new Exception("The way to Interpret information was not specified. Call SetHowTo to specify.");
            }
        }

        internal bool IsUnimportant()
        {
            return (!Label && (Opcodes.Count == 0));
        }

        internal bool IsLabel()
        {
            return Label;
        }

        internal bool IsLocalLabel()
        {
            if (HowTo == ListFiletype.Organic)
            {
                return (AssemblerCode.Substring(0, 1) == ".");
            }
            else           //no Idea howw to handle....
            {
                return false;
            }
        }

        internal void SetHowToParse(ListFiletype NewHowTo)
        {
            HowTo = NewHowTo;
        }

        internal void PrecendLabel(string PreName)
        {
            if (HowTo == ListFiletype.Organic)
            {
                AssemblerCode = PreName + "_" + AssemblerCode.Substring(1);
            }
        }

        internal string GetLabel()
        {
            if (IsLabel())
            {
                if (HowTo == ListFiletype.Organic)
                {
                    return AssemblerCode.Substring(0, AssemblerCode.Length - 1);
                }
                else
                {
                    throw new Exception("The way to Interpret information was not specified. Call SetHowTo to specify.");
                }
            }
            else
                throw new Exception("This list entry is not a Label.");
        }
    }
}
