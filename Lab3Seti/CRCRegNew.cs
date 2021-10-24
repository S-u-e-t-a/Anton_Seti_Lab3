﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3Seti
{
    public class CRCRegNew
    {
        const int order = 4;
        const int polynom = 0x03; //0x03;
        //byte[] str= {0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0x7, 0x8, 0x9}; 123456789 -> CRC = 0x7
        //byte[] input= {0x83}; // Г -> CRC = 0b1011 -> 0xВ
        private readonly int crcmask = (((1 << (order - 1)) - 1) << 1) | 1;
        int CRC;
        private readonly int CRCHighBit = 1 << (order - 1);

        public int CRCBitByBit(byte[] input)
        {
            int c, bit;
            CRC = 0x0;           

            for (int i = 0; i < input.Length - 1; i++)
            {
                c = Convert.ToInt32(input[i + 1]);
                for (int j = 0x80; Convert.ToBoolean(j); j>>=1)
                {
                    bit = CRC & CRCHighBit;
                    CRC <<= 1;
                    if (Convert.ToBoolean(c & j)) CRC |= 1;
                    if (Convert.ToBoolean(bit)) CRC ^= polynom;
                }
            }
            for (int i = 0; i < order; i++)
            {
                bit = CRC & CRCHighBit;
                CRC <<= 1;
                if (Convert.ToBoolean(bit)) CRC ^= polynom;
            }
            CRC ^= 0;
            CRC &= crcmask;
            return CRC;
        }    
    }
}
