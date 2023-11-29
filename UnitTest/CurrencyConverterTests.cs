using NUnit.Framework;
using CurrencyConverter; // Replace with the actual namespace of your currency converter classes
using Assert = NUnit.Framework.Assert;

namespace CurrencyConverterTests
{
    public class Tests
    {
        private ExternalCurrencyService _service;
        private CurrencyServiceAdapter _adapter;

        [SetUp]
        public void Setup()
        {
            _service = new ExternalCurrencyService();
            _adapter = new CurrencyServiceAdapter(_service);
        }

        [Test]
        public void TestSuccessfulConversion()
        {
            double result = _adapter.Convert("USD", "EUR", 100);
            Assert.That(result, Is.EqualTo(110).Within(0.01), "Conversion did not return expected result.");
        }

        [Test]
        public void TestConversionWithZeroAmount()
        {
            double result = _adapter.Convert("USD", "EUR", 0);
            Assert.That(result, Is.EqualTo(0).Within(0.01), "Conversion with zero amount did not return zero.");
        }

        [Test]
        public void TestConversionWithNegativeAmount()
        {
            double result = _adapter.Convert("USD", "EUR", -50);
            Assert.That(result, Is.LessThan(0), "Conversion with negative amount did not return a negative result.");
        }

        [Test]
        public void TestInvalidCurrencyCode()
        {
            Assert.Throws<ArgumentException>(() => _adapter.Convert("XXX", "YYY", 100), "No exception thrown for invalid currency codes.");
        }

        [Test]
        public void TestLargeAmountConversion()
        {
            double result = _adapter.Convert("USD", "EUR", 100000);
            Assert.That(result, Is.EqualTo(110000).Within(0.01), "Conversion of a large amount did not return expected result.");
        }

        // Additional tests...
    }
}
