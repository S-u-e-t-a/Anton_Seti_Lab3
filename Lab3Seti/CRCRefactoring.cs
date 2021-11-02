using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3Seti
{

    //тоже самое (почти) что и в классе CRCFromC но более понятным языком
    public static class CRCRefactoring
    {
        public static void CRC32(char[] arrOrig, out uint ctrlSum, int degreePolynom, ulong polymome)
        {
            ulong _register = 0x0;
            uint _bitMask = (uint)(Math.Pow(2, degreePolynom) - 1); // маска для удаления лишнего байта, кол-во единиц = степени полинома

            char[] message = new char[arrOrig.Length + (degreePolynom / 8)];
            for (int i = 0; i < arrOrig.Length; i++)
            {
                message[i] = arrOrig[i];
            }

            for (int i = 0; i < message.Length; i++)
            {
                int bitPosition = 0;
                int bitPositionFinal = 8;
                while (bitPosition != bitPositionFinal)
                {
                    ulong BitIn = GetBit(bitPositionFinal, bitPosition, message[i]);
                    ulong BitOut = GetBit(degreePolynom, 0, _register);
                    _register = RegistorPushAndXOR(BitIn, BitOut, _register, polymome, _bitMask);
                    bitPosition++;
                    
                }
            }
            ctrlSum = (uint)_register & _bitMask;
        }

        private static ulong GetBit(int countBit, int position, ulong word)
        {
            byte bitMask = 1;
            return word >> (countBit - position - 1) & bitMask;
        }

        private static ulong RegistorPushAndXOR(ulong inBit, ulong outBit, ulong register, ulong polinome, uint bitMask)
        {
            register = (register << 1) & bitMask | inBit;
            if (outBit == 1)
            {
                register ^= polinome;
            }
            return register;
        }
    }
}
