using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3Seti
{
    public class CRCIra
    {
        public static void CRC32(byte[] arrOrig, out uint ctrlSum)
        {
            int StepPoly = 4;
            const uint bitMaskRegisterFinal = 0b1111;//0b11111111111111111111111111111111; // убираем первую единицу в маске не относящуюся к регистру, получая окончательный результат
            const uint polinome = 0x03;// 0x814141AB;
            uint register = 0;

            //Исходное сообщение дополняется нулями в младших разрядах, в количестве, равном числу разрядов полинома(32)
            byte[] message = new byte[arrOrig.Length]; // кадр
            for (int i = 0; i < arrOrig.Length; i++)
            {
                message[i] = arrOrig[i];
            }

            for (int i = 0; i < message.Length; i++)
            {
                // Пукт №5 Если в сообщении ещё есть биты – переход к шагу 3.
                // Если биты i-ого байта сообщения закончились
                int c = 0; // позиция бита
                int final = 8;
                uint byteMessage = message[i];
                //Console.WriteLine("Байт сообщения (+ 1 в начале): " + Convert.ToString(byteMessage, 16) + " "+ Convert.ToString(byteMessage, 2));
                while (c != final)
                {
                    //Пукт №3 В младший разряд регистра заносится один старший бит сообщения, а из старшего разряда регистра выдвигается один бит
                    uint inBit = GetOneBit(final, c, byteMessage); // Cтарший бит, заносимый в регистр
                    uint outBit = GetOneBit(StepPoly, 0, register); // Выдвигаемый из регистра бит
                    // Сдвигаем регистр так, чтобы старший элемент ушел, а младший элемент сообщения появился
                    register = GetNextRegistor(inBit, outBit, bitMaskRegisterFinal, register, polinome);

                    checked { c++; }
                }
            }

            ctrlSum = register & bitMaskRegisterFinal;
        }
        private static uint GetNextRegistor(in uint inBit, in uint outBit, uint bitMaskRegisterFinal, uint prevRegist, uint polinome)
        {
            uint registor = prevRegist;
            // Сдвигаем регистр так, чтобы старший элемент ушел, а младший элемент сообщения появился
            registor = ((((registor << 1) & bitMaskRegisterFinal))) | inBit;
            // Пукт №4 Если выдвинутый бит равен «1», то производится операция исключающего ИЛИ (XOR)регистра и полинома
            if (outBit == 1)
            {
                registor ^= polinome;
            }
            return registor;
        }

        private static byte GetOneBit(int countBit, int pose, uint message)
        {
            byte bitMask1 = 1;
            byte bit = (byte)((message >> (countBit - pose - 1)) & bitMask1);
            return bit;
        }
    }
}
