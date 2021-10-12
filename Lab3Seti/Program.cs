using System;
using System.Collections.Generic;

namespace Lab3Seti
{
    class Program
    {
        static void Main(string[] args)
        {
            //вывод исходного сообщения
            Console.WriteLine();
            Console.WriteLine("=== Контроль по паритету ===");

            string letterParity = "10000011";
            Console.WriteLine($"Исходное сообщение: {letterParity}");

            //вывод сообщения для отправки
            var parity = new Parity();
            Console.WriteLine($"Сообщение для отправки: {parity.MakeMessage(letterParity)}");

            #region проверка вводимого сообщения

            //проверка вводимого сообщения            
            //Console.WriteLine("Введите 9 битовое сообщение с контрольной суммой в конце для проверки");
            //var testMessage = new List<int>();
            //for (int i = 0; i < 9; i++)
            //{
            //    testMessage.Add(Convert.ToInt32(Console.ReadLine()));
            //}
            //if (parity.CheckMessage(testMessage))
            //{
            //    Console.WriteLine($"Сообщение {string.Join("", testMessage)} может быть без искажений или искажено четное число бит");
            //}
            //else
            //{
            //    Console.WriteLine($"Сообщение {string.Join("", testMessage)} передано с искажениями. Искажено нечетное кол-во бит");
            //}
            #endregion

            Console.WriteLine("===  ===");
            Console.WriteLine();

            Console.WriteLine("=== Вертикальный и горизонтальный контроль по паритету ===");

            Console.WriteLine("Таблица для метода вертикального и горизонтального контроля по паритету");
            var vhp = new VerHorParity();
            var wordParity = new List<List<int>>
            {
                new List<int>{ 1,0,0,0,0,0,1,1 },
                new List<int>{ 1,1,1,0,0,0,1,1},
                new List<int>{ 1,1,1,0,0,0,0,1 },
                new List<int>{ 1,0,1,0,0,1,0,1 },
                new List<int>{ 1,0,1,0,0,0,1,0 }

            };
            vhp.CreateMessageTable(wordParity);

            Console.WriteLine("===  ===");
            Console.WriteLine();

            Console.WriteLine("=== Циклический избыточный контроль ===");

            var crc = new CRC();
            List<int> result = crc.MakeResult();
            Console.WriteLine($"Контрольная сумма:" + Environment.NewLine + $"{string.Join("", result)}");

            Console.WriteLine("===  ===");
            Console.WriteLine();
            

            Console.ReadLine();
        }
                
    }
}
