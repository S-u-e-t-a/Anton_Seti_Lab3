using System.Collections.Generic;

namespace Lab3Seti
{
    public class Parity
    {
        public string MakeMessage(string letter)
        {
            int controlSum = letter[0];

            for (int i = 1; i < letter.Length; i++)
            {
                controlSum ^= letter[i];
            }

            string result = letter + controlSum;
            return result;
        }

        public bool CheckMessage(List<int> letter)
        {
            int realControlSum = letter[letter.Count - 1];
            int theoryConSum = (letter[0]);

            for (int i = 1; i < letter.Count - 1; i++)
            {
                theoryConSum ^= letter[i];
            }
            return Equals(realControlSum, theoryConSum);
        }
    }
}
