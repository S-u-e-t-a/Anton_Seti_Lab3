using System;
using System.Collections.Generic;

namespace Lab3Seti
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] surname = new byte[] { 0x83, 0xE3, 0xE1, 0xA5, 0xA2}; //Гусев
            //вывод исходного сообщения
            Console.WriteLine();
            Console.WriteLine("=== Контроль по паритету ===");

            Console.WriteLine($"Исходное сообщение: Гусев");
            for (int i = 0; i < surname.Length; i++)
            {
                Console.Write(Convert.ToString(surname[i], 2) + " ");
            }
            Console.WriteLine();

            var ctrlSumParity = Parity.MakeMessage(surname);

            for (int i = 0; i < ctrlSumParity.Count; i++)
            {
                Console.WriteLine($"{i} байт: { Convert.ToString(surname[i], 2)} КС: {ctrlSumParity[i]}");
            }

            Console.WriteLine("===  ===");
            Console.WriteLine();

            Console.WriteLine("=== Вертикальный и горизонтальный контроль по паритету ===");
            Console.WriteLine($"Исходное сообщение: Гусев");
            for (int i = 0; i < surname.Length; i++)
            {
                Console.Write(Convert.ToString(surname[i], 2) + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Таблица для метода вертикального и горизонтального контроля по паритету");
            uint[] countSumHor;
            uint[] countSumVer;

            VerHorParity.VertAndHorizontParityControlSum(surname, out countSumVer, out countSumHor);

            for (int i = 0; i < surname.Length; i++)
            {
                Console.Write($"{i}Б  { Convert.ToString(surname[i], 2)}  КC: { Convert.ToString(countSumHor[i], 2)}");
                Console.WriteLine();
            }
            Console.Write("КС: ");
            for (int i = 0; i < countSumVer.Length; i++)
            {
                Console.Write(Convert.ToString(countSumVer[i], 2));
            }
            Console.WriteLine();

            Console.WriteLine("===  ===");
            Console.WriteLine();

            Console.WriteLine("=== Циклический избыточный контроль ===");

            byte[] arr = new byte[] { 0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0x7, 0x8, 0x9 };
            var CRC = new CRCRegNew();
            Console.WriteLine(Convert.ToString(CRC.CRCBitByBit(arr), 16));


            //CRCReg.CRC32(surname, out contrlSum);
            //Console.Write("КС CRC-32-ITU: ");
            //Console.Write(Convert.ToString(contrlSum, 2));
            //Console.WriteLine();


            //var crc = new CRC();
            //List<int> result = crc.MakeResult();
            //Console.WriteLine($"Контрольная сумма:" + Environment.NewLine + $"{string.Join("", result)}");

            Console.WriteLine("===  ===");
            Console.WriteLine();
            

            Console.ReadLine();
        }
                
    }
}
