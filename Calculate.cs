using System.Collections.Generic;
using System.Globalization;


namespace Pract5
{
    public class Calculate
    {
        private string polish;
        private Stack<float> stack = new Stack<float>();
        float result;
        public Calculate(string polish)
        {
            this.polish = polish;
        }

        private void Calc()
        {
            HashSet<char> signs = new HashSet<char>()
                {
                    '*','/','+','-'
                };
            int i = 0;
            while (i < polish.Length)
            {
                if (!signs.Contains(polish[i]) && polish[i] != ' ')
                {
                    string num = "";
                    while (i < polish.Length && polish[i] != ' ')
                    {
                        num += polish[i];
                        i++;
                    }
                    float number = float.Parse(num, CultureInfo.InvariantCulture.NumberFormat);
                    stack.Push(number);
                }
                else if (polish[i] != ' ')
                {
                    float first = stack.Peek();
                    stack.Pop();
                    float second = stack.Peek();
                    stack.Pop();
                    if (polish[i] == '+')
                    {
                        stack.Push(first + second);
                    }
                    else if (polish[i] == '-')
                    {
                        stack.Push(second - first);
                    }
                    else if (polish[i] == '*')
                    {
                        stack.Push(first * second);
                    }
                    else
                    {
                        stack.Push(second / first);
                    }
                    i++;
                }
                else i++;
            }
            this.result = stack.Peek();
        }

        public float CalcandGetResult()
        {
            Calc();
            return this.result;
        }
    }
}
