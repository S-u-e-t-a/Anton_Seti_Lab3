using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// код взят с примера реализации на С
namespace Lab3Seti
{ 
    public class CRCFromC
    {
        const int _degreePolynom = 32; // степень полинома
        const uint _polynom = 0x814141AB;  // сам образующий полином
        static uint x = 1 << 30; // костыли. потому что если сделать 1 << 31 оно не работает (причем 1 << 32 работает)
        uint _сrcMask = (((x << 1) - 1) << 1) | 1; // создаем маску для CRC 
        uint _CRC;
        static uint y = 1 << 30; // аналогичный костыль, надо 1 << 31 но почему то так нельзя (другое число вместо 31 работает)
        uint _crcHighBit = y << 1; 

        public uint CRCBitByBit(char[] input)
        {
            uint c, bit;
            _CRC = 0x0;           

            for (int i = 0; i < input.Length; i++)
            {
                c = input[i];
                for (int j = 0x80; Convert.ToBoolean(j); j>>=1)
                {
                    bit = _CRC & _crcHighBit;
                    _CRC <<= 1;
                    if (Convert.ToBoolean(c & j)) _CRC |= 1;
                    if (Convert.ToBoolean(bit)) _CRC ^= _polynom;
                }
            }
            for (int i = 0; i < _degreePolynom; i++)
            {
                bit = _CRC & _crcHighBit;
                _CRC <<= 1;
                if (Convert.ToBoolean(bit)) _CRC ^= _polynom;
            }
            _CRC ^= 0;
            _CRC &= _сrcMask;
            return _CRC;
        }    
    }
}
