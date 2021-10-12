using System;
using System.Collections.Generic;

namespace Lab3Seti
{
    public class VerHorParity
    {
        public List<int> MakeMessageHorizontal(List<int> letter)
        {
            int controlSum = letter[0];

            for (int i = 1; i < letter.Count; i++)
            {
                controlSum ^= letter[i];
            }

            letter.Add(controlSum);
            return letter;
        }

        public int MakeMessageVertical(List<int> letter)
        {
            int controlSum = letter[0];

            for (int i = 1; i < letter.Count; i++)
            {
                controlSum ^= letter[i];
            }

            return controlSum;
        }

        public void CreateMessageTable(List<List<int>> word)
        {
            for (int i = 0; i < word.Count; i++)
            {
                word[i] = MakeMessageHorizontal(word[i]);
            }

            List<int> VertialCtrlSum = new List<int>();
            List<int> temp = new List<int>();
            
            for (int i = 0; i < 8; i++)
            {
                foreach (var item in word)
                {
                    temp.Add(item[i]);
                }
                VertialCtrlSum.Add(MakeMessageVertical(temp));
                temp.Clear();
            }
            
            Console.WriteLine("Байты |       Биты");
            Console.WriteLine("      | 0 1 2 3 4 5 6 7 КС");
            Console.WriteLine("  Г   | " + string.Join(" ", word[0]));
            Console.WriteLine("  У   | " + string.Join(" ", word[1]));
            Console.WriteLine("  С   | " + string.Join(" ", word[2]));
            Console.WriteLine("  Е   | " + string.Join(" ", word[3]));
            Console.WriteLine("  В   | " + string.Join(" ", word[4]));
            Console.WriteLine("  КС  | " + string.Join(" ", VertialCtrlSum));
        }
    }
}
