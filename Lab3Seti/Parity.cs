using System;
using System.Collections.Generic;

namespace Lab3Seti
{
    public class Parity
    {
        public static string MakeMessage(char[] letter)
        {
            string ctrlSum = string.Empty; // Всего байт в исходных данных

            for (int i = 0; i < letter.Length; i++)
            {
                ctrlSum += ParityControlXORByteSum(letter[i]);
            }
            
            return ctrlSum;
        }
        public static uint ParityControlXORByteSum(char OneByte) 
        {
            const uint bitMask8 = 1 << 8;
            const uint bitMask1 = 1;
            uint message = OneByte | bitMask8;

            int lBorderByte = 1;
            int pBorderByte = 9;
            uint controlSum = 0;

            for (int j = lBorderByte; j < pBorderByte; j++) // Бит j в байте i
            {
                uint bitJ = ((message >> (pBorderByte - j - 1)) & bitMask1);
                controlSum ^= bitJ;
            }
            return controlSum;
        }
    }
}
