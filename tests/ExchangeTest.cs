namespace CurrencyConverter
{
    using System.Collections.Generic;
    using Xunit;
    public class ExchangeTest
    {
        [Fact]
        public void ExtractTheListOfCurrencyFromJson()
        {
            List<string> expected = new List<string>();
            expected.Add("USD");
            expected.Add("EUR");

            MockExchangeRateApi api = new MockExchangeRateApi();
            Exchange exchange = new Exchange(api);

            List<string> currencies = exchange.GetAllCurrencies();

            Assert.Equal(expected, currencies);
        }
        
        [Fact]
        public void GetAnExchangeRate()
        {           
            MockExchangeRateApi api = new MockExchangeRateApi();
            Exchange exchange = new Exchange(api);
            double rate = exchange.GetRate("GBP", "EUR");
            Assert.Equal(1.357, rate);
        }
    }
}