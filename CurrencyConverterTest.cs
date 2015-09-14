namespace CurrencyConverter
{
    using System.Collections.Generic;
    using Xunit;

    public class CurrencyConverterTest
    {
        [Fact]
        public void ConvertsAnAmount()
        {
            ExchangeStub exchange = new ExchangeStub();
            var converter = new Converter(exchange);
            double amount = converter.Convert("GBP", "USD", 1);
            Assert.Equal(amount, 1.23);
        }
    }

    class ExchangeStub : IExchange
    {
        public List<string> GetAllCurrencies()
        {
            List<string> currencies = new List<string>();
            currencies.Add("USD");
            currencies.Add("EUR");
            return currencies;
        }

        public double GetRate(string from, string to)
        {
            return 1.222;
        }
    }
}
