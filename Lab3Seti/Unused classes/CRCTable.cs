using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3Seti
{
    internal class CRCTable
    {
        const int order = 4;
        const int polynom = 0x03; //0x03;
        //byte[] str= {0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0x7, 0x8, 0x9}; 123456789 -> CRC = 0x7
        //byte[] input= {0x83}; // Г -> CRC = 0b1011 -> 0xВ
        private readonly int crcmask = (((1 << (order - 1)) - 1) << 1) | 1;
        int CRC;
        private readonly int CRCHighBit = 1 << (order - 1);
        int[] crctab = new int[256];
        public void GenarateCRCTablae()
        {
            int i, j;
            int bit;

            for (i = 0; i < 256; i++)
            {
                CRC = i;
                CRC <<= order - 8;

                for (j = 0; j < 8; j++)
                {
                    bit = CRC & CRCHighBit;
                    CRC <<= 1;
                    if (Convert.ToBoolean(bit)) CRC ^= polynom;
                }
                CRC &= crcmask;
                crctab[i] = CRC;
            }

        }
    }
}
