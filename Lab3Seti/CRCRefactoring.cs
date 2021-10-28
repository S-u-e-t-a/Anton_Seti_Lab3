using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3Seti
{

    //тоже самое (почти) что и в классе CRCFromC но более понятным языком
    class CRCRefactoring
    {
        public static void CRC32(char[] arrOrig, out uint ctrlSum)
        {
            int _degreePolynom = 16;
            const uint _polymome = 0x589;
            uint _register = 0x0;
            uint _bitMask = (uint)(Math.Pow(2, _degreePolynom) - 1); // маска для удаления лишнего байта, кол-во единиц = степени полинома

            char[] message = new char[arrOrig.Length + 2];
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
                    uint BitIn = GetBit(bitPositionFinal, bitPosition, message[i]);
                    uint BitOut = GetBit(_degreePolynom, 0, _register);
                    _register = RegistorPushAndXOR(BitIn, BitOut, _register, _polymome, _bitMask);
                    bitPosition++;
                    
                }
            }
            ctrlSum = _register & _bitMask;
        }

        private static uint GetBit(int countBit, int position, uint word)
        {
            byte bitMask = 1;
            return word >> (countBit - position - 1) & bitMask;
        }

        private static uint RegistorPushAndXOR(uint inBit, uint outBit, uint register, uint polinome, uint bitMask)
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
