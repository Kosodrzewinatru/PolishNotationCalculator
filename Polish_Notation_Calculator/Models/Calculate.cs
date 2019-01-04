using System;
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
        public string SourceTrue { get; set; }

        public string toInfix()
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

        public double calcInfix()
        {
            DataTable dt = new DataTable();
            return Convert.ToDouble(dt.Compute(toInfix(), ""));
        }

        internal static int precedence(string curOperator)
        {
            switch(curOperator)
            {
                case "+":
                case "-":
                    return 1;

                case "*":
                case "/":
                    return 2;

                case "^":
                    return 3;
            }
            return -1;
        }

        public string toPostfix()
        {
            Stack<string> expression = new Stack<string>();
            string finalExpression = "";
            string[] start = SourceTrue.Split(' ');
            
            for (int i = 0; i < start.Length; i++)
            {
                string curElement = start[i];

                if (int.TryParse(curElement, out int result))
                    finalExpression += curElement + " ";
                else if (curElement == "(")
                    expression.Push(curElement);
                else if (curElement == ")")
                {
                    while (expression.Count > 0 && expression.Peek() != "(")
                        finalExpression += expression.Pop() + " ";
                    if (expression.Count > 0 && expression.Peek() != "(")
                        return "Syntax error!";
                    else
                        expression.Pop();
                }
                else
                {
                    while (expression.Count > 0 && precedence(curElement) <= precedence(expression.Peek()))
                        finalExpression += expression.Pop() + " ";
                    expression.Push(curElement);
                }
            }
                    while (expression.Count > 0)
                        finalExpression += expression.Pop() + " ";

            return finalExpression;
        }


        public string calcPostfix()
        {
            double result = 0;
            Stack<string> expression = new Stack<string>();
            string[] start = toPostfix().Split(' ');

            for (int i = 0; i < start.Length; i++)
            {
                string curElement = start[i];
                if (int.TryParse(curElement, out int res))
                    expression.Push(curElement);
                else if (expression.Count >= 2)
                {
                    double second = Convert.ToDouble(expression.Pop());
                    double first = Convert.ToDouble(expression.Pop());

                    if (curElement == "+")
                        expression.Push(Convert.ToString(first + second));
                    if (curElement == "-")
                        expression.Push(Convert.ToString(first - second));
                    if (curElement == "*")
                        expression.Push(Convert.ToString(first * second));
                    if (curElement == "/")
                        expression.Push(Convert.ToString(first / second));
                    if (curElement == "^")
                        expression.Push(Convert.ToString(Math.Pow(first, second)));
                }

                if (i == start.Length - 1)
                {
                    result = Convert.ToDouble(expression.Pop()); 
                }
            }
            return Convert.ToString(result);
        }
    }
}
