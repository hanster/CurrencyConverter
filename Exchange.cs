namespace CurrencyConverter
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json.Linq;

    public class Exchange : IExchange
    {
        private ExchangeRateApi api;

        public Exchange(ExchangeRateApi api)
        {
            this.api = api;
        }

        public List<string> GetAllCurrencies()
        {
            string responseJson = api.GetJsonForAllCurrencies();
            var currencies = GetAvailableCurrencyList(responseJson);
            return currencies;
        }

        public double GetRate(string from, string to)
        {
            string responseJson = api.GetJsonFor(from, to);
            return GetRateFromJson(responseJson, to);
        }
                
        private double GetRateFromJson(string json, string to)
        {
            JObject obj = JObject.Parse(json);
            string rate = (string)obj["rates"][to];

            return Convert.ToDouble(rate);
        }
        
        private List<string> GetAvailableCurrencyList(string json)
        {
            JObject obj = JObject.Parse(json);
            var rates = obj.SelectToken("rates");

            List<string> currencies = new List<string>();

            foreach (JProperty prop in rates)
            {
                currencies.Add(prop.Name);
            }
            return currencies;
        }
    }
}
