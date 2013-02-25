﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE_File_Exporter
{
    class NoInstructionException:Exception
    {}
    class NoArgumentB : Exception
    { }

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
        private bool Instruction;

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
            Instruction = false;
        }

        internal bool IsEmpty()
        {
            return (ListReadout == "");
        }

        internal void AddCharToReadout(char NewChar)
        {
            ListReadout += Convert.ToString(NewChar);
        }
        #region Parse
        /// <summary>
        /// parses the list file entry accordingly
        /// </summary>
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
                Instruction = IsInstruction();
            }
            else
            {
                throw new Exception("The way to Interpret information was not specified. Call SetHowTo to specify.");
            }
        }
        #endregion

        internal bool IsInstruction()
        {
            string[] Parts = AssemblerCode.Split(' ');
            if (HowTo == ListFiletype.Organic)          //probably would also work with other assemblers...
            {
                if (Parts.Length > 0)
                {
                    Parts[0] = Parts[0].Trim();
                    Parts[0] = Parts[0].ToLower();
                    switch (Parts[0])
                    {
                        case "set":
                        case "add":
                        case "sub":
                        case "mul":
                        case "mli":
                        case "div":
                        case "dvi":
                        case "mod":
                        case "mdi":
                        case "and":
                        case "bor":
                        case "xor":
                        case "shr":
                        case "asr":
                        case "shl":
                        case "ifb":
                        case "ifc":
                        case "ife":
                        case "ifn":
                        case "ifg":
                        case "ifa":
                        case "ifl":
                        case "ifu":
                        case "adx":
                        case "sbx":
                        case "sti":
                        case "std":
                        case "jsr":
                        case "int":
                        case "iag":
                        case "ias":
                        case "rfi":
                        case "iaq":
                        case "hwn":
                        case "hwq":
                        case "hwi":
                            return true;
                        default:
                            return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
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
        internal ushort getOpcode()
        {
            if (Instruction)
                return Opcodes[0];
            else
                throw new NoInstructionException();
        }
        internal ushort getArgA()
        {
            if (Instruction)
                return Opcodes[1];
            else
                throw new NoInstructionException();
        }
        internal ushort getArgB()
        {
            if (Instruction)
            {
                if (Opcodes.Count == 3)
                    return Opcodes[2];
                else
                    throw new NoArgumentB();
            }
            else
                throw new NoInstructionException();
        }
        internal List<ushort> GetBinary()
        {
            if (Instruction)
            {
                return Opcodes;
            }
            else
                throw new NoInstructionException();
        }

        /// <summary>
        /// will return the abolute adresses addresses  of the Labels (not the addresses they are referring to!)
        /// </summary>
        /// <returns>the List of the Adresses, can be empty, but not null</returns>
        internal List<ushort> GetRefenencedLabels()
        {
            //How to? well, we know what the actual opcode is. Thus, just parse it, and determine whether A or B are referencing...
            List<ushort> Result = new List<int>();
            if (IsInstruction())
            {
                ushort Temp = (Opcodes[0] >> 10) & 0x3F;
                if (IsReferring(Temp))
                    Result.Add(Address + 1);
                Temp = (Opcodes[0] >> 5) & 0x1F;
                if (IsReferring(Temp))
                    Result.Add(Address + Opcodes.Count -1);     //B will always refer to the last Instruction
            }
            else if (AssemblerCode.Substring(0, 4) == ".dat")    //in case of Vector Tables...
            {
                string[] array = AssemblerCode.Split(' ',StringSplitOptions.RemoveEmptyEntries);
            }
            return Result;
        }


        private bool IsReferring(ushort Temp)
        {
            switch (Temp)
            {
                case 0x10:
                case 0x11:
                case 0x12:
                case 0x13:
                case 0x14:
                case 0x15:
                case 0x16:
                case 0x17:
                case 0x1A:
                case 0x1E:
                    return true;
                default:
                    return false;
            }
        }
    }
}
