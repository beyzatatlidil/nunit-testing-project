using System;
using NUnit.Framework;
using TermProject2.Core;

namespace TermProject2.Tests
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new DemeritPointsCalculator();
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-100)]
        [TestCase(301)]
        [TestCase(int.MaxValue)]
        [TestCase(int.MinValue)]
        public void CalculateDemeritPoints_SpeedIsOutOfRange_ThrowArgumentOutOfRangeException(int speed)
        {
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.CalculateDemeritPoints(speed));
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(64, 0)]
        [TestCase(65, 0)]
        public void CalculateDemeritPoints_SpeedIsLessOrEqualSpeedLimit_ReturnZero(int speed, int expectedPoints)
        {
            // Act
            var result = _calculator.CalculateDemeritPoints(speed);

            // Assert
            Assert.That(result, Is.EqualTo(expectedPoints));
        }

        [Test]
        [TestCase(70, 1)] // (70-65)/5 = 1
        [TestCase(75, 2)] // (75-65)/5 = 2
        [TestCase(66, 0)] // (66-65)/5 = 0.2 -> 0
        [TestCase(69, 0)] // (69-65)/5 = 0.8 -> 0
        [TestCase(79, 2)] // (79-65)/5 = 2.8 -> 2
        [TestCase(300, 47)] // (300-65)/5 = 235/5 = 47 (Max Valid Speed)
        public void CalculateDemeritPoints_SpeedIsOverSpeedLimit_ReturnDemeritPoints(int speed, int expectedPoints)
        {
            // Act
            var result = _calculator.CalculateDemeritPoints(speed);

            // Assert
            Assert.That(result, Is.EqualTo(expectedPoints));
        }
    }
}
