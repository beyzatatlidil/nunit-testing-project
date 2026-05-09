using NUnit.Framework;
using TermProject2.Core;

namespace TermProject2.Tests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        private FizzBuzz _fizzBuzz;

        [SetUp]
        public void Setup()
        {
            _fizzBuzz = new FizzBuzz();
        }

        [Test]
        [TestCase(0, "FizzBuzz")] // 0 is divisible by 3 and 5
        [TestCase(15, "FizzBuzz")]
        [TestCase(-15, "FizzBuzz")]
        [TestCase(-30, "FizzBuzz")]
        [TestCase(30, "FizzBuzz")]
        [TestCase(3, "Fizz")]
        [TestCase(-3, "Fizz")]
        [TestCase(6, "Fizz")]
        [TestCase(5, "Buzz")]
        [TestCase(-5, "Buzz")]
        [TestCase(10, "Buzz")]
        [TestCase(1, "1")]
        [TestCase(-1, "-1")]
        [TestCase(2, "2")]
        [TestCase(4, "4")]   
        [TestCase(2147483647, "2147483647")]


        public void GetOutput_WhenCalled_ReturnsCorrectString(int number, string expected)
        {
            // Arrange is done in Setup and Parameters

            // Act
            var result = _fizzBuzz.GetOutput(number);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
