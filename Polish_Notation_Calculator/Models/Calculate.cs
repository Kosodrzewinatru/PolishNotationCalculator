﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;
using System.Data;

namespace Polish_Notation_Calculator
{
    public class Calculate
    {
        public string Source { get; set; }

        public string ToInfix()
        {
            string[] start = Source.Split(' ');
            Stack<string> expression = new Stack<string>();
            for (int i = 0; i < start.Length; i++)
            {
                if (int.TryParse(start[i], out int result) == true)
                    expression.Push(start[i]);
                else
                {
                    string second = expression.Pop();
                    string first = expression.Pop();
                    string combinedElement;
                    if (start[i] == "+" || start[i] == "-")
                        combinedElement = "(" + first + start[i] + second + ")";
                    else
                        combinedElement = first + start[i] + second;
                    expression.Push(combinedElement);
                }
            }
            return expression.Pop();
        }

        public string doInfix()
        {
            return "2";
        }

        public double Calc()
        {
            DataTable dt = new DataTable();
            return Convert.ToDouble(dt.Compute(ToInfix(), ""));
        }
    }
}
