using Pract5;
using System.Linq.Expressions;
namespace TestCalculator
{
    public class UnitTest1
    {
        [Fact]
        public void PSP1()
        {
            string str = "(2+3))";
            Checker chek = new Checker(str);
            bool result = false;
            Assert.Equal(result, chek.IsCorrect());
        }
        [Fact]
        public void PSP2()
        {
            string str = ")3+5)";
            Checker chek = new Checker(str);
            bool result = false;
            Assert.Equal(result, chek.IsCorrect());
        }
        [Fact]
        public void PSP3()
        {
            string str = "(4+(8+9)";
            Checker chek = new Checker(str);
            bool result = false;
            Assert.Equal(result, chek.IsCorrect());
        }
        [Fact]
        public void Correct1()
        {
            string str = "a+2";
            Checker chek = new Checker(str);
            bool result = false;
            Assert.Equal(result, chek.IsCorrect());
        }
        [Fact]
        public void Correct2()
        {
            string str = ".38+4";
            Checker chek = new Checker(str);
            bool result = false;
            Assert.Equal(result, chek.IsCorrect());
        }
        [Fact]
        public void Correct3()
        {
            string str = "-4+3-";
            Checker chek = new Checker(str);
            bool result = false;
            Assert.Equal(result, chek.IsCorrect());
        }
        [Fact]
        public void Correct4()
        {
            string str = ".8+9";
            Checker chek = new Checker(str);
            bool result = false;
            Assert.Equal(result, chek.IsCorrect());
        }
        [Fact]
        public void Correct5()
        {
            string str = "2.+3";
            Checker chek = new Checker(str);
            bool result = false;
            Assert.Equal(result, chek.IsCorrect());
        }
        [Fact]
        public void Correct6()
        {
            string str = "2+-3";
            Checker chek = new Checker(str);
            bool result = false;
            Assert.Equal(result, chek.IsCorrect());
        }
        [Fact]
        public void Correct8()
        {
            string str = "2 + 3.";
            Checker chek = new Checker(str);
            bool result = false;
            Assert.Equal(result, chek.IsCorrect());
        }
        [Fact]
        public void Correct9()
        {
            string str = "2 + 3. 8";
            Checker chek = new Checker(str);
            bool result = false;
            Assert.Equal(result, chek.IsCorrect());
        }
        [Fact]
        public void Correct10()
        {
            string str = "2+ 6/0 + 7";
            Checker chek = new Checker(str);
            bool result = false;
            Assert.Equal(result, chek.IsCorrect());
        }

        [Fact]
        public void Correct11()
        {
            string str = "2+ 6/0.2";
            Checker chek = new Checker(str);
            bool result = true;
            Assert.Equal(result, chek.IsCorrect());
        }
        [Fact]
        public void Correct12()
        {
            string str = "(3+4)(7+8)";
            Checker chek = new Checker(str);
            bool result = true;
            Assert.Equal(result, chek.IsCorrect());
        }
        [Fact]
        public void Correct13()
        {
            string str = "-(3+4)";
            Checker chek = new Checker(str);
            bool result = true;
            Assert.Equal(result, chek.IsCorrect());
        }
        [Fact]
        public void Correct15()
        {
            string str = "3(-4)";
            Checker chek = new Checker(str);
            bool result = true;
            Assert.Equal(result, chek.IsCorrect());
        }
        [Fact]
        public void Correct17()
        {
            string str = "(-4)3";
            Checker chek = new Checker(str);
            bool result = true;
            Assert.Equal(result, chek.IsCorrect());
        }

        [Fact]
        public void Correct18()
        {
            string str = "(-4)(v+3)";
            Checker chek = new Checker(str);
            bool result = false;
            Assert.Equal(result, chek.IsCorrect());
        }




        [Fact]
        public void Calc()
        {
            string expression = "2+3";
            Parse parse = new Parse(expression);
            string polish = parse.ConvertandGet_polish();
            Calculate calc_expr = new Calculate(polish);
            float result = 5;
            Assert.Equal(result, calc_expr.CalcandGetResult());
        }
        
        [Fact]
        public void Calc1()
        {
            string expression = "(2+3)(3+7)";
            Parse parse = new Parse(expression);
            string polish = parse.ConvertandGet_polish();
            Calculate calc_expr = new Calculate(polish);
            float result = 50;
            Assert.Equal(result, calc_expr.CalcandGetResult());
        }

        [Fact]
        public void Calc2()
        {
            string expression = "-2(3+7)";
            Parse parse = new Parse(expression);
            string polish = parse.ConvertandGet_polish();
            Calculate calc_expr = new Calculate(polish);
            float result = -20;
            Assert.Equal(result, calc_expr.CalcandGetResult());
        }

        [Fact]
        public void Calc3()
        {
            string expression = "-(3+7)";
            Parse parse = new Parse(expression);
            string polish = parse.ConvertandGet_polish();
            Calculate calc_expr = new Calculate(polish);
            float result = -10;
            Assert.Equal(result, calc_expr.CalcandGetResult());
        }

        [Fact]
        public void Calc4()
        {
            string expression = "5(-2)";
            Parse parse = new Parse(expression);
            string polish = parse.ConvertandGet_polish();
            Calculate calc_expr = new Calculate(polish);
            float result = -10;
            Assert.Equal(result, calc_expr.CalcandGetResult());
        }

        [Fact]
        public void Calc5()
        {
            string expression = "(-2)5";
            Parse parse = new Parse(expression);
            string polish = parse.ConvertandGet_polish();
            Calculate calc_expr = new Calculate(polish);
            float result = -10;
            Assert.Equal(result, calc_expr.CalcandGetResult());
        }
        
        [Fact]
        public void Calc6()
        {
            string expression = "2(6+(-7+6))";
            Parse parse = new Parse(expression);
            string polish = parse.ConvertandGet_polish();
            Calculate calc_expr = new Calculate(polish);
            float result = 10;
            Assert.Equal(result, calc_expr.CalcandGetResult());
        }

        [Fact]
        public void CalcFloat()
        {
            string expression = "2(6.09 + (-7.3+6.1))";
            Parse parse = new Parse(expression);
            string polish = parse.ConvertandGet_polish();
            Calculate calc_expr = new Calculate(polish);
            float result = 9.78f;
            Assert.Equal(result, calc_expr.CalcandGetResult());
        }
    }
}