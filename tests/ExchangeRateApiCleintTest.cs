using System;
using Xunit;

namespace CurrencyConverter
{
    public class ExchangeRateApiClientTest
    {
        private ExchangeRateApiClient exchange;
        private string json;
        
        public ExchangeRateApiClientTest()
        {
            exchange = new ExchangeRateApiClient();
            json = "{ 'base':'GBP','date':'2015-09-02','rates':{ 'USD':1.5273,'EUR':1.357}}";
        }
        
        [Fact]
        [Trait("Category", "Integration")]
        public void CheckFormatOfJsonFromApi()
        {
            String json = exchange.GetJsonFor("USD", "EUR");
            Assert.Contains("\"base\":", json);
            Assert.Contains("\"date\":", json);
            Assert.Contains("\"rates\":{", json);
            Assert.Contains("\"EUR\":", json);
        }
    }
}
