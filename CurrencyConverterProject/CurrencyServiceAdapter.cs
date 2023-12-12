using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// CurrencyServiceAdapter.cs

    public class CurrencyServiceAdapter : ICurrencyConverter
    {
        private ExternalCurrencyService _service;

        public CurrencyServiceAdapter(ExternalCurrencyService service)
        {
            _service = service;
        }

        public double Convert(string fromCurrency, string toCurrency, double amount)
        {
            return _service.ConvertCurrency(fromCurrency, toCurrency, amount);
        }
    }
