using API2.Services;
using NUnit.Framework;

namespace Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CalculateInterest_CorrectParams_ReturnsResult()
        {
            decimal result = new Calculator().CalculateInterest(100, 0.01m, 5);
            Assert.AreEqual(105.10m, result);
        }

        [Test]
        public void CalculateInterest_NegaviteParams_ReturnsResult()
        {
            decimal result = new Calculator().CalculateInterest(-100, 0.01m, -5);
            Assert.AreEqual(105.10m, result);

        }

    }
}