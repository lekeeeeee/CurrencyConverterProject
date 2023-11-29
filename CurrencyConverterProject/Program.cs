using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Program.cs
namespace CurrencyConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new ExternalCurrencyService();
            ICurrencyConverter converter = new CurrencyServiceAdapter(service);

            double amount = converter.Convert("USD", "EUR", 50);
            Console.WriteLine($"Converted Amount: {amount}");
        }
    }
}