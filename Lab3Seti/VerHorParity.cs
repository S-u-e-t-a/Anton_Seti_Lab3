using System;
using System.Collections.Generic;

namespace Lab3Seti
{
    public class VerHorParity
    {
        public static void VertAndHorizontParityControlSum(in byte[] array, out uint[] countSumVer, out uint[] countSumHor)
        {
            const uint bitMask8 = 1 << 8;
            const uint bitMask1 = 1;

            uint[] message = new uint[8];

            int lBorderByte = 1;
            int pBorderByte = 9;


            for (int i = 0; i < array.Length; i++)
            {
                message[i] = (uint)array[i] | bitMask8;
            }

            countSumVer = new uint[8]; // По столбу сверху вниз
            countSumHor = new uint[8]; // По строке слева направо 
            for (int i = 0; i < message.Length; i++) // По байту
            {
                for (int j = lBorderByte; j < pBorderByte; j++) // Бит j в байте i
                {
                    uint bitJ = ((message[i] >> (pBorderByte - j - 1)) & bitMask1);
                    countSumHor[i] ^= bitJ;
                    countSumVer[j - 1] ^= bitJ;
                }
            }
        }
    }
}
