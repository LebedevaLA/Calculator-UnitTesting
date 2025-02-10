using System;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Pract5
{
    internal class Program
    {

        static void Main(string[] args)
        {
            string ch = "-1";
            while (ch != "0")
            {
                Console.WriteLine("Введите 1, чтобы вычислить выражение, 0 - чтобы закончить вычисления");
                ch = Console.ReadLine();
                switch (ch)
                {
                    case "1":
                        Console.WriteLine("Введите выражение");
                        string expression = Console.ReadLine();
                        Checker check = new Checker(expression);
                        if (check.IsCorrect())
                        {
                            Parse parse = new Parse(expression);
                            string polish = parse.ConvertandGet_polish();
                            Calculate calc_expr = new Calculate(polish);
                            Console.WriteLine(calc_expr.CalcandGetResult());
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Некоректное выражение");
                        }
                        break;
                    case "0":
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
