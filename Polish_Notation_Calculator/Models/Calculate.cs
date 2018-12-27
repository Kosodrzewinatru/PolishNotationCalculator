using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

namespace Polish_Notation_Calculator
{
    public class Calculate
    {
       public string Source { get; set; }

       private string[] PrepareToGo()
       {
            return Source.Split(' ');
       }

        public string toInfix()
        {
            string[] start = PrepareToGo();
            Stack<string> expression = new Stack<string>();
            for (int i = 0; i < start.Length; i++)
            {
                if (int.TryParse(start[i], out int result) == true)
                    expression.Push(start[i]);
                else
                {
                    string second = expression.Pop();
                    string first = expression.Pop();
                    string combinedElement = "(" + first + start[i] + second + ")";
                    expression.Push(combinedElement);
                }
            }
            return expression.Pop();
        }
    }
}
