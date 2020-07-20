using Packt.CS7;
using Xunit;
namespace CalculatorLibUnitTests
{
    public class CalculatorUnitTests
    {
        [Fact]
        public void TestAdding2And2()
        {
            // подготовка
            double a = 2;
            double b = 2;
            double expected = 4;
            var calc = new Calculator();
            // действие
            double actual = calc.Add(a, b);
            // проверка
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TestAdding2And3()
        {
            // подготовка
            double a = 2;
            double b = 3;
            double expected = 5;
            var calc = new Calculator();
            // действие
            double actual = calc.Add(a, b);
            // проверка
            Assert.Equal(expected, actual);
        }
    }
}
