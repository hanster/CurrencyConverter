using System;

namespace CurrencyConverter
{
    public class MockExchangeRateApi : ExchangeRateApi
    {
        public string GetJsonFor(string from, string to)
        {
            return "{ 'base':'GBP','date':'2015-09-02','rates':{ 'USD':1.5273,'EUR':1.357}}";
        }

        public string GetJsonForAllCurrencies()
        {
            return "{ 'base':'GBP','date':'2015-09-02','rates':{ 'USD':1.5273,'EUR':1.357}}";
        }
    }
}