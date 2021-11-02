using System;
using System.Collections.Generic;

namespace Lab3Seti
{
    class Program
    {
        static void Main()
        {
            byte[] surname = new byte[] { 0x83, 0xE3, 0xE1, 0xA5, 0xA2 }; //Гусев
            //вывод исходного сообщения
            Console.WriteLine();
            Console.WriteLine("=== Контроль по паритету ===");

            Console.WriteLine($"Исходное сообщение: Гусев");
            for (int i = 0; i < surname.Length; i++)
            {
                Console.Write(Convert.ToString(surname[i], 2) + " ");
            }
            Console.WriteLine();

            var ctrlSumParity = Parity.MakeMessage(surname.ToString().ToCharArray());

            for (int i = 0; i < ctrlSumParity.Length; i++)
            {
                Console.WriteLine($"{i + 1} байт: { Convert.ToString(surname[i], 2)} КС: {ctrlSumParity[i]}");
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

            VerHorParity.VertAndHorizontParityControlSum(surname.ToString().ToCharArray(), out uint[] countSumVer, out uint[] countSumHor);

            for (int i = 0; i < surname.Length; i++)
            {
                Console.Write($"{i + 1}Б  { Convert.ToString(surname[i], 2)}  КC: { Convert.ToString(countSumHor[i], 2)}");
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

            char[] arr = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            CRCFromC crcFromC = new CRCFromC();
            Console.WriteLine(Convert.ToString(crcFromC.CRCBitByBit(arr), 16));

            CRCRefactoring.CRC32(arr, out uint crcRes, 32, 0x814141AB);
            Console.WriteLine(Convert.ToString(crcRes, 16));

            Console.WriteLine("===  ===");
            Console.WriteLine();


            Console.ReadLine();
        }

    }
}
