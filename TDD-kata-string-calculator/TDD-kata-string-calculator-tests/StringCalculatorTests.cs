
using System;
using NUnit.Framework;
using TDD_kata_string_calculator;

namespace TDD_kata_string_calculator_tests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        private StringCalculator _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new StringCalculator();
        }

        [Test]
        public void GivenEmptyString_ReturnsZero()
        {
            // Arrange

            // Act
            var result = _sut.Add("");

            // Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void GivenOneNumber_ReturnsSameNumber ([Range(0, 9, 1)] int number)
        {
            var actual = _sut.Add(number.ToString());

            Assert.AreEqual(number, actual);
        }

        [Test]
        public void GivenTwoNumbers_ReturnsSum(
            [Range(0, 9, 1)]int firstNumber,
            [Range(0, 9, 1)]int secondNumber)
        {
            var numbers = firstNumber + "," + secondNumber;

            var actual = _sut.Add(numbers);

            Assert.AreEqual(firstNumber + secondNumber, actual);
        }

        [Test]
        public void GivenManyNumbers_returnSum([Range(3, 20, 1)]int numbersCount)
        {
            var numbers = "";
            var sum = 0;
            Random rand = new Random();
            for (int i = 0; i <= numbersCount; i++)
            {
                var value = rand.Next(1, 10);
                numbers += value;
                sum += value;
                if (numbersCount > i)
                {
                    numbers += ",";
                }
            }

            var actual = _sut.Add(numbers);

            Assert.AreEqual(sum, actual);
        }

        [Test]
        [TestCase("1\n2,3")]
        [TestCase("1\n2\n3")]
        [TestCase("1,2\n3")]
        public void GivenNewLineSeparators_returnSum(string numbers)
        {

            var actual = _sut.Add(numbers);

            Assert.AreEqual(6, actual);
        }

        [Test]
        [TestCase("//;\n1;2")]
        [TestCase("//-\n1-2")]
        [TestCase("//=\n1=2")]
        public void GivenCustomDelimiter_ReturnSum(string numbers)
        {
            var actual = _sut.Add(numbers);

            Assert.AreEqual(3, actual);
        }

        [Test]
        public void GivenPositivaNadNegativeNumbers_throwException()
        {
            var numbers = "1,-2,3,-4,5,-6";

            Assert.Throws<Exception>(() => _sut.Add(numbers), "negatives not allowed: -2, -4, -6");
        }

        [Test]
        public void GivenBigNumbers_ReturnSumIgnoreOverThousandValues()
        {
            var numbers = "1,2, 1001, 1000, 124124";

            var actual = _sut.Add(numbers);

            Assert.AreEqual(1003, actual);
        }
    }
}
