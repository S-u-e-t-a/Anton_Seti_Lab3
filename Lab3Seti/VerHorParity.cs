using System;
using System.Collections.Generic;

namespace Lab3Seti
{
    public class VerHorParity
    {
        public static void VertAndHorizontParityControlSum(char[] array, out uint[] countSumVer, out uint[] countSumHor)
        {
            const uint bitMask8 = 1 << 8;
            const uint bitMask1 = 1;

            uint[] message = new uint[array.Length];

            int lBorderByte = 1;
            int pBorderByte = 9;


            for (int i = 0; i < array.Length; i++)
            {
                message[i] = array[i] | bitMask8;
            }

            countSumVer = new uint[8]; // По столбу сверху вниз
            countSumHor = new uint[array.Length]; // По строке слева направо  
            for (int i = 0; i < message.Length; i++) // По байту
            {
                for (int j = lBorderByte; j < pBorderByte; j++) // Бит j в байте i
                {
                    uint bitJ = (message[i] >> (pBorderByte - j - 1)) & bitMask1;
                    countSumHor[i] ^= bitJ;
                    countSumVer[j - 1] ^= bitJ;
                }
            }
        }
    }
}
