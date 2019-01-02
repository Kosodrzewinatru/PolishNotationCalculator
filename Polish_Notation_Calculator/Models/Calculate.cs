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
                if (int.TryParse(start[i], out int result))
                    finalExpression += start[i] + " ";
                if (start[i] == "+" || start[i] == "-" || start[i] == "*" || start[i] == "/")
                {
                    if (expression.Count == 0 || precedence(start[i]) > precedence(expression.Pop()))
                        expression.Push(start[i]);
                    else
                    {
                        for (int j = 0; j < expression.Count; j++)
                        {
                            if (expression.Pop() == "(" || expression.Pop() == ")")
                            {
                                expression.Push(start[i]);
                                break;
                            }

                            if (precedence(expression.Pop()) >= precedence(start[i]))
                                expression.Pop();
                            else
                                expression.Push(start[i]);
                        }
                    }
                }
                if (start[i] == "(")
                    expression.Push(start[i]);
                if (start[i] == ")")
                {
                    for (int j = 0; j < expression.Count; j++)
                    {
                        if (expression.Pop() == "(")
                            break;
                        else
                            finalExpression += start[i] + " ";
                    }
                }
            }
            return finalExpression;
        }


        public string calcPostfix()
        {
            string result = "";
            return result;
        }
    }
}
