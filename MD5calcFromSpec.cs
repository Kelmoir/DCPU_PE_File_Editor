using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE_File_Exporter
{
    internal static class MD5calcFromSpec
    {
        internal static byte[] CalcMD5(string SpecFunc, string SpecName, string SpecDev, int RevMaj, int RevMin)
        {
            byte[] Md5Buffer = new byte[62];
            System.Security.Cryptography.MD5Cng Calc = new System.Security.Cryptography.MD5Cng();
            AddToBuffer(Md5Buffer, 0, 20, AllignTo20(SpecFunc));
            AddToBuffer(Md5Buffer, 20, 20, AllignTo20(SpecName));
            AddToBuffer(Md5Buffer, 40, 20, AllignTo20(SpecDev));
            Md5Buffer[60] = (byte)(RevMaj + 0x30);
            Md5Buffer[61] = (byte)(RevMin + 0x30);
            return Calc.ComputeHash(Md5Buffer,0, 62);
        }

        private static void AddToBuffer(byte[] Buffer, int startIndex, int Count, string str)
        {
            char [] Temp = str.ToCharArray();
            for (int i = 0; i < Temp.Length; i++)
                Buffer[startIndex + i] = (byte)Temp[i];
        }

        private static string AllignTo20(string str)
        {
            while (str.Length < 20)
                str += " ";
            if (str.Length > 20)
                str = str.Substring(0, 20);
            return str;
        }
    }
}
