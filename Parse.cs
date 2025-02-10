using System.Collections.Generic;
using System.Linq;


namespace Pract5
{
    public class Parse
    {
        private string expression;
        private string polish;
        private Stack<char> stack = new Stack<char>();
        public Parse(string str)
        {
            this.expression = str;
        }

        private bool IsNumber(char ch)
        {
            if ((int)ch <= 47 || (int)ch >= 58) return false;
            return true;
        }
        private string RealizeUnaryMinus()
        {
            string str = "";
            for (int i = 0; i < this.expression.Length; i++)
            {
                if ((i == 0 || this.expression[i - 1] == '(') && this.expression[i] == '-')
                {
                    str += '0';
                    str += this.expression[i];
                }
                else
                {
                    str += this.expression[i];
                }
            }
            return (str);
        }
        private string RealizeMultiplication(string s)
        {
            string str = "";
            int fl;
            for (int i = 0; i < s.Length; i++)
            {
                fl = 0;
                if (i != 0)
                {
                    if ((IsNumber(s[i]) && s[i - 1] == ')' )|| (s[i]=='(' && s[i-1]==')'))
                    {
                        str += '*';
                        str += s[i];
                        fl = 1;
                    }
                }
                if (i!= s.Length - 1)
                {
                    if(IsNumber(s[i]) && s[i + 1] == '(')
                    {
                        str += s[i];
                        str += '*';
                        fl = 1;
                    }
                }
                if(fl==0) str += s[i];
            }
            return (str);
        }
        private void PolishString()
        {
            string str_with_minus = RealizeUnaryMinus();
            string correct_str = RealizeMultiplication(str_with_minus);
            Dictionary<char, int> signs = new Dictionary<char, int>()
                {
                    {'+', 0 }, {'-', 0}, {'*',1}, {'/', 1}, {'(', -1}
                };

            string polish = "";
            int i = 0;
            while (i < correct_str.Length)
            {
                if (correct_str[i] == ' ') i++;
                if (signs.ContainsKey(correct_str[i]) && correct_str[i] != '(')
                {
                    if (stack.Count() == 0) stack.Push(correct_str[i]);
                    else
                    {
                        while (stack.Count() > 0 && signs[stack.Peek()] >= signs[correct_str[i]])
                        {
                            polish += stack.Peek();
                            polish += ' ';
                            stack.Pop();
                        }
                        stack.Push(correct_str[i]);
                        polish += ' ';
                    }
                    i++;
                }
                else if (correct_str[i] == '(')
                {
                    stack.Push('(');
                    i++;
                }
                else if (correct_str[i] == ')')
                {
                    while (stack.Count() > 0 && stack.Peek() != '(')
                    {
                        polish += stack.Peek();
                        polish += ' ';
                        stack.Pop();
                    }
                    if (stack.Peek() == '(') stack.Pop();
                    polish += ' ';
                    i++;
                }
                else
                {
                    string number = "";
                    while (i < correct_str.Length)
                    {
                        if (correct_str[i] == '(' || correct_str[i] == ')' || signs.ContainsKey(correct_str[i]) || correct_str[i] == ' ') break;
                        number += correct_str[i];
                        i++;
                    }
                    polish += number;
                    polish += ' ';
                }


            }
            while (stack.Count > 0)
            {
                polish += stack.Peek();
                stack.Pop();
            }
            this.polish = polish;

        }

        public string ConvertandGet_polish()
        {
            PolishString();
            return this.polish;
        }

    }
}
