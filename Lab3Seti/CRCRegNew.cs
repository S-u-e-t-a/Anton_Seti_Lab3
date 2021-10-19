using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3Seti
{
    public class CRCRegNew
    {
        const int order = 4;
        const int polynom = 0x3; //0x4c11db7;
        //byte[] str= {0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0x7, 0x8, 0x9}; 123456789 -> CRC = 0x7
        //byte[] input= {0x83}; // Г -> CRC = 0b1011 -> 0xВ
        int crcmask = (((1 << (order - 1)) - 1) << 1) | 1;
        int CRC;
        int CRCHighBit = 1 << (order - 1);

        public int CRCBitByBit(byte[] input)
        {
            int c, bit;
            CRC = 0x0;           

            for (int i = 0; i < input.Length; i++)
            {
                c = Convert.ToInt32(input[i]);
                for (int j = 0x80; j > 0; j>>=1)
                {
                    bit = CRC & CRCHighBit;
                    CRC <<= 1;
                    if (Convert.ToBoolean(c & j)) CRC |= 1;
                    if (Convert.ToBoolean(bit)) CRC ^= polynom;
                }
                //Console.WriteLine("->{0}<-", Convert.ToString(CRC,16));
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
