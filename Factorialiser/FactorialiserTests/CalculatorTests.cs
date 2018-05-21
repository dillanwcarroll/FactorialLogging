using System;
using NUnit.Framework;
using Factorialiser.Classes;

namespace FactorialiserTests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        [TestCase(2, 2)]
        [TestCase(5, 120)]
        [TestCase(8, 40320)]
        public void Factorial_ValidInput_ReturnsFactorial(int input, int expectedResult)
        {
            // act
            var result = Calculator.Factorial(input);

            // assert
            Assert.That(result.Equals(expectedResult));
        }
        //[Ignore ("Debugging")]
        [Test]
        public void Factorial_InputLessThan1_ThrowsNumberTooLowException()
        {
            // Assert
            Assert.Throws<NumberTooLowException>(delegate { Calculator.Factorial(0); });
        }

        [Test]
        public void Factorial_InputGreaterThan30_ThrowsNumberTooHighException()
        {
            // Assert
            Assert.Throws<NumberTooHighException>(delegate { Calculator.Factorial(31); });
        }
    }
}
 