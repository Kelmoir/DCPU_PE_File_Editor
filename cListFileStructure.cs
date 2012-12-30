using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PE_File_Exporter
{
    enum ListFiletype
    {
        unknown = 0,
        /// <summary>
        /// output by organic by Sircpwn
        /// </summary>
        /// <example>../src/bootloader.dasm (line 7):  [0x0000]               booloader:
        /// ../src/bootloader.dasm (line 8):  [0x0000] C382            ADD PC, 0x0F
        /// ../src/bootloader.dasm (line 9):  [0x0002]                 .DAT 0xFA16
        /// ../src/bootloader.dasm (line 9):  [0x0002]                      FA16
        /// </example>
        Organic = 1
    };
    class cListFileStructure
    {
    }
}
