﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DCPU_Utilitys
{
    public static class cHexInterface
    {
        public static uint ConvertToUint(string Source)
        {
            uint Number = 0;
            if (Source.Length > 10)
            {
                throw new Exception("Number too big");
            }
            if (Source.Substring(0, 2) != "0x")
            {
                throw new Exception ("Please stick to the hex numerator (0x)");
            }
            Source = Source.Substring(2, Source.Length - 2);
            for (int Index = 0; Index < Source.Length; Index++)
            {
                Number = Number << 4;
                switch (Source.Substring(Index, 1))
                {
                    case "0":
                        Number += 0;
                        break;
                    case "1":
                        Number += 1;
                        break;
                    case "2":
                        Number += 2;
                        break;
                    case "3":
                        Number += 3;
                        break;
                    case "4":
                        Number += 4;
                        break;
                    case "5":
                        Number += 5;
                        break;
                    case "6":
                        Number += 6;
                        break;
                    case "7":
                        Number += 7;
                        break;
                    case "8":
                        Number += 8;
                        break;
                    case "9":
                        Number += 9;
                        break;
                    case "A":
                    case "a":
                        Number += 10;
                        break;
                    case "B":
                    case "b":
                        Number += 11;
                        break;
                    case "C":
                    case "c":
                        Number += 12;
                        break;
                    case "D":
                    case "d":
                        Number += 13;
                        break;
                    case "E":
                    case "e":
                        Number += 14;
                        break;
                    case "F":
                    case "f":
                        Number += 15;
                        break;
                    default:
                        throw new Exception("invalid hex number");
                        //break;

                }
            }
            return Number;
        }
        public static string ConvertToString(uint Number)
        {
            string result = "";
            while (Number > 0)
            {
                switch (Number & 0xF)
                {
                    case 0:
                        result = "0" + result;
                        break;
                    case 1:
                        result = "1" + result;
                        break;
                    case 2:
                        result = "2" + result;
                        break;
                    case 3:
                        result = "3" + result;
                        break;
                    case 4:
                        result = "4" + result;
                        break;
                    case 5:
                        result = "5" + result;
                        break;
                    case 6:
                        result = "6" + result;
                        break;
                    case 7:
                        result = "7" + result;
                        break;
                    case 8:
                        result = "8" + result;
                        break;
                    case 9:
                        result = "9" + result;
                        break;
                    case 10:
                        result = "A" + result;
                        break;
                    case 11:
                        result = "B" + result;
                        break;
                    case 12:
                        result = "C" + result;
                        break;
                    case 13:
                        result = "D" + result;
                        break;
                    case 14:
                        result = "E" + result;
                        break;
                    case 15:
                        result = "F" + result;
                        break;
                }
                Number = Number >> 4;
            }
            return "0x" + result;
        }
        public static ushort ConvertToUshort(string HexNumber, bool HasNumerator)
        {
            ushort Number = 0;
            if (((HexNumber.Length > 6) && HasNumerator) || ((HexNumber.Length > 4) && !HasNumerator))
            {
                throw new Exception("Number too big");
            }
            if ((HexNumber.Substring(0, 2) != "0x") && HasNumerator)
            {
                throw new Exception ("Please stick to the hex numerator (0x)");
            }
            if (HasNumerator)
            {
                HexNumber = HexNumber.Substring(2, HexNumber.Length - 2);
            }
            for (int Index = 0; Index < HexNumber.Length; Index++)
            {
                Number = (ushort)(Number << 4);
                switch (HexNumber.Substring(Index, 1))
                {
                    case "0":
                        Number += 0;
                        break;
                    case "1":
                        Number += 1;
                        break;
                    case "2":
                        Number += 2;
                        break;
                    case "3":
                        Number += 3;
                        break;
                    case "4":
                        Number += 4;
                        break;
                    case "5":
                        Number += 5;
                        break;
                    case "6":
                        Number += 6;
                        break;
                    case "7":
                        Number += 7;
                        break;
                    case "8":
                        Number += 8;
                        break;
                    case "9":
                        Number += 9;
                        break;
                    case "A":
                    case "a":
                        Number += 10;
                        break;
                    case "B":
                    case "b":
                        Number += 11;
                        break;
                    case "C":
                    case "c":
                        Number += 12;
                        break;
                    case "D":
                    case "d":
                        Number += 13;
                        break;
                    case "E":
                    case "e":
                        Number += 14;
                        break;
                    case "F":
                    case "f":
                        Number += 15;
                        break;
                    default:
                        throw new Exception("invalid hex number");
                        //break;

                }
            }
            return Number;
        }
        static internal ushort[] ConverToUshortArray(string str)
        {
            char[] Temp = str.ToCharArray();
            int Count = Temp.Length / 2;
            Count += Temp.Length % 2;
            ushort[] Result = new ushort[Count];
            for (int i = 0; i < Temp.Length; i++)
            {
                if (i % 2 == 1)
                {
                    Result[i / 2] |= (ushort)Convert.ToByte(Temp[i]);
                }
                else
                {
                    Result[i/2] = (ushort)((int)Convert.ToByte(Temp[i]) << 8);
                }
            }
            return Result;
        }
        static internal List<ushort> ConvertToUshortList(byte[] Input)
        {
            List<ushort> result = new List<ushort>();
            for (int i = 0; i < Input.Length - 1; i += 2)
            {
                result.Add((ushort)(Input[i] | ((ushort)Input[i + 1] << 8)));
            }
            return result;
        }
    }
}
