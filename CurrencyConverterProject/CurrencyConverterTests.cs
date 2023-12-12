using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.VisualStudio.TestTools.UnitTesting;
// CurrencyConverterTests.cs (in a separate test project)
[TestClass]
public class CurrencyConverterTests
{
    [TestMethod]
    public void TestSuccessfulConversion()
    {
        var service = new ExternalCurrencyService();
        var adapter = new CurrencyServiceAdapter(service);

        double result = adapter.Convert("USD", "EUR", 100);
        Assert.AreEqual(110, result, 0.01); // Assuming a mock conversion rate
    }

    [TestMethod]
    public void TestConversionWithZeroAmount()
    {
        var service = new ExternalCurrencyService();
        var adapter = new CurrencyServiceAdapter(service);

        double result = adapter.Convert("USD", "EUR", 0);
        Assert.AreEqual(0, result, 0.01);
    }

    [TestMethod]
    public void TestConversionWithNegativeAmount()
    {
        var service = new ExternalCurrencyService();
        var adapter = new CurrencyServiceAdapter(service);

        double result = adapter.Convert("USD", "EUR", -50);
        Assert.IsTrue(result < 0); // Assuming the service handles negative values
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestInvalidCurrencyCode()
    {
        var service = new ExternalCurrencyService();
        var adapter = new CurrencyServiceAdapter(service);

        adapter.Convert("XXX", "YYY", 100); // Assuming the service throws an exception for invalid codes
    }

    //[TestMethod]
    //public void TestServiceFailureHandling()
    //{
    //    var service = new FaultyCurrencyService(); // A mock service that simulates failure
    //    var adapter = new CurrencyServiceAdapter(service);

    //    try
    //    {
    //        adapter.Convert("USD", "EUR", 100);
    //        Assert.Fail("Exception not thrown");
    //    }
    //    catch (Exception ex)
    //    {
    //        Assert.IsInstanceOfType(ex, typeof(ServiceUnavailableException));
    //    }
    //}
    // Additional tests...
}
