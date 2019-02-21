using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Polish_Notation_Calculator.Controllers
{
    public class Check
    {
        public string Source { get; set; }
        public string SourceTrue { get; set; }

        //checking if typed content doesn't include letters
        public bool ifLetter()
        {
            string[] start = Source.Split(' ');
            string[] alphabet = { "q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "a", "s", "d", "f", "g", "h", "j", "k", "l", "z", "x", "c", "v", "b", "n", "m", "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "A", "S", "D", "F", "G", "H", "J", "K", "L", "Z", "X", "C", "V", "B", "N", "M" };
            bool checker = true;

            for (int i = 0; i < start.Length; i++)
            {
                for (int k = 0; k < start[i].Length; k++)
                {
                    string element = start[i];
                    for (int j = 0; j < alphabet.Length; j++)
                    {
                        if (element[k] == Convert.ToChar(alphabet[j]))
                        {
                            checker = false;
                            break;
                        }
                    }
                }
            }

            return (checker == true) ? true : false;
        }

        public bool ifLetterTrue()
        {
            string[] start = SourceTrue.Split(' ');
            string[] alphabet = { "q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "a", "s", "d", "f", "g", "h", "j", "k", "l", "z", "x", "c", "v", "b", "n", "m", "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "A", "S", "D", "F", "G", "H", "J", "K", "L", "Z", "X", "C", "V", "B", "N", "M" };
            bool checker = true;

            for (int i = 0; i < start.Length; i++)
            {
                for (int k = 0; k < start[i].Length; k++)
                {
                    string element = start[i];
                    for (int j = 0; j < alphabet.Length; j++)
                    {
                        if (element[k] == Convert.ToChar(alphabet[j]))
                        {
                            checker = false;
                            break;
                        }
                    }
                }
            }

            return (checker == true) ? true : false;
        }
    }
}
