using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3Seti
{
    public class CRCReg
    {
        public static void CRC32(byte[] arrOrig, out uint ctrlSum)
        {
            const uint bitMask32 = (uint)1 << 32; // 0b100000000000000000000000000000000 для регистра и полинома
            const uint bitMask8 = (uint)1 << 8; // 0b100000000 для 1 байта сообщения
            const uint bitMaskRegisterFinal = 0b011111111111111111111111111111111; // убираем первую единицу в маске не относящуюся к регистру, получая окончательный результат
            const uint bitMask1 = 1;
            const uint polinome = 0x04C11DB7 | bitMask32;
            //Создаётся массив (регистр), заполненный нулями, равный по длине разрядности (степени) полинома
            uint register = bitMask32;

            //Исходное сообщение дополняется нулями в младших разрядах, в количестве, равном числу разрядов полинома(32)
            byte[] message = new byte[arrOrig.Length + 2]; // кадр
            for (int i = 0; i < arrOrig.Length; i++)
            {
                message[i] = arrOrig[i];
            }
            
            for (int i = 0; i < message.Length; i++)
            {
                // Если в сообщении ещё есть биты – переход к шагу 3.
                // Если биты i-ого байта сообщения закончились
                int c = 1;
                int final = 9;
                uint byteMessage = (uint)(bitMask8 | message[i]);
                while (c != final)
                {
                    //В младший разряд регистра заносится один старший бит сообщения, а из старшего разряда регистра выдвигается один бит
                    uint inBit = (byteMessage >> (final - c - 1)) & bitMask1; // Cтарший бит, заносимый в регистр
                    uint outBit = (register >> (33 - 2)) & bitMask1; // Выдвигаемый из регистра бит
                    // Сдвигаем регистр так, чтобы старший элемент ушел, а младший элемент сообщения появился
                    register = GetNextRegistor(inBit, outBit, bitMaskRegisterFinal, bitMask32, register, polinome);

                    checked { c++; }
                }
            }

            ctrlSum = register & bitMaskRegisterFinal;
        }
        private static uint GetNextRegistor(in uint inBit, in uint outBit, uint bitMaskRegisterFinal, uint bitMask, uint prevRegist, uint polinome)
        {
            uint registor = prevRegist;
            // Сдвигаем регистр так, чтобы старший элемент ушел, а младший элемент сообщения появился
            registor = ((((registor << 1) & bitMaskRegisterFinal) | bitMask)) | inBit;
            //Если выдвинутый бит равен «1», то производится операция исключающего ИЛИ (XOR)регистра и полинома
            if (outBit == 1)
            {
                registor = (registor ^ polinome) | bitMask;
            }
            return registor;
        }
    }
}
