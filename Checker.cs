using System.Collections.Generic;


namespace Pract5
{
    public class Checker
    {
        private string expression;
        private int balanse = 0;
        public Checker(string str)
        {
            this.expression = str;
        }
        private bool CheckBrackets()
        {
            for (int i = 0; i < this.expression.Length; i++)
            {
                if (balanse < 0) return false;
                if (this.expression[i] == '(') balanse++;
                else if (this.expression[i] == ')') balanse--;
            }
            if (balanse == 0) return true;
            return false;
        }
        private bool IsNumber(char ch)
        {
            if ((int)ch <= 47 || (int)ch >= 58) return false;
            return true;
        }
        private bool CheckSymbols()
        {
            char last = this.expression[0];
            HashSet<char> signs = new HashSet<char>()
            {
                    '*','/','+','-'
            };
            if (last != '-' && last != '(' && !IsNumber(last)) return false;
            for (int i = 1; i < this.expression.Length; i++)
            {
                if (last == '(' && this.expression[i] == ')') return false;
                if (this.expression[i] == ' ') continue;
                if (signs.Contains(last) && signs.Contains(this.expression[i])) return false;
                if (signs.Contains(last) && this.expression[i] == ')') return false;
                if (last == '/' && this.expression[i] == '0')
                {
                    if (i == this.expression.Length - 1 || (i != this.expression.Length - 1 && this.expression[i + 1] != '.')) return false;
                }
                if (this.expression[i] == '.' && (i == this.expression.Length - 1 ||
                    !IsNumber(this.expression[i - 1]) || !IsNumber(this.expression[i + 1]))) return false;
                if (!signs.Contains(this.expression[i]) && this.expression[i] != '(' && this.expression[i] != ')' && this.expression[i] != '.')
                {
                    if (!IsNumber(this.expression[i])) return false;
                }
                if (i == this.expression.Length - 1 && signs.Contains(this.expression[i])) return false;
                last = this.expression[i];
            }
            return true;
        }
        public bool IsCorrect()
        {
            if (!CheckBrackets() || !CheckSymbols()) return false;
            return true;
        }
    }
}
