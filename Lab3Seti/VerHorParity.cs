using System;
using System.Collections.Generic;

namespace Lab3Seti
{
    public class VerHorParity
    {
        //требует рефакторинга (см строку 14, 25, 26)
        public static void VertAndHorizontParityControlSum(char[] array, out uint[] countSumVer, out uint[] countSumHor)
        {
            const uint bitMask8 = 1 << 8;
            const uint bitMask1 = 1;

            uint[] message = new uint[array.Length]; // так лучше не надо делать

            int lBorderByte = 1;
            int pBorderByte = 9;


            for (int i = 0; i < array.Length; i++)
            {
                message[i] = (uint)array[i] | bitMask8;
            }

            countSumVer = new uint[array.Length]; // По столбу сверху вниз, так тоже нельзя
            countSumHor = new uint[array.Length]; // По строке слева направо  , и так тоже нельзя, надо обрабатывать поблочно - 8х8
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
