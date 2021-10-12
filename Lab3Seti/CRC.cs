using System;
using System.Collections.Generic;

namespace Lab3Seti
{
    public class CRC
    {
        public List<int> MakeResult()
        {
            List<int> register = new List<int> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // 32 битный регистр
            List<int> message = new List<int> { 1, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // буква Г + r(=32) нулевых бит
            List<int> polynom = new List<int> { 1, 0, 0, 0, 0, 0, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1 };
            Console.WriteLine($"32 разрядный регистр. Сообщение(дополненное):" + Environment.NewLine + $"{string.Join("", message)}");
            Console.WriteLine();
            Console.WriteLine("Полином x32 + x26 + x23 + x22 + x16 + x12 + x11 + x10 + x8 + x7 + x5 + x4 + x2 + x + 1:" + Environment.NewLine + $"{ string.Join("", polynom)}");
            Console.WriteLine();

            int counter = 0;
            int deletedRegister;
            while (counter != message.Count - 1)
            {
                deletedRegister = register[0]; // запоминаем какое значение регистра сейчас сдвинем
                register = PopRegister(register, message[counter]); // сдвиг
                if (deletedRegister == 1) // если значение выдвинутого регистра 1, то регистр ХОR полином
                {
                    for (int i = 0; i < register.Count; i++)
                    {
                        register[i] ^= polynom[i];                        
                    }
                }
                counter++; // следующий бит сообщения
            }
            return register;
        }
        public List<int> PopRegister(List<int> reg, int message)
        {
            for (int i = 0; i < reg.Count-1; i++)
            {
                reg[i] = reg[i+1]; // реализуем сдвиг влево
                if (i == reg.Count - 2) // вставляем в конец бит сообщения
                {
                    reg[i] = message;
                }
            }
            //Console.WriteLine($"reg: {string.Join("", reg)}");
            return reg;
        }
    }

}
