using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ICurrencyConverter.cs

    public interface ICurrencyConverter
    {
        double Convert(string fromCurrency, string toCurrency, double amount);
    }
