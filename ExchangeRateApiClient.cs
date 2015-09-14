using System.Net.Http;

namespace CurrencyConverter
{

    class ExchangeRateApiClient : ExchangeRateApi
    {
        private static string BASE_API = "http://api.fixer.io/latest";
        
        public string GetJsonFor(string from, string to)
        {
            var uri = BASE_API + $"?base={from}&symbols={to}";
            return GetResponseBody(uri);
        }
        
        public string GetJsonForAllCurrencies()
        {
            return GetResponseBody(BASE_API);
        }
        
        private string GetResponseBody(string uri)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(uri).Result;
            response.EnsureSuccessStatusCode();
            var responseBody = response.Content.ReadAsStringAsync().Result;
            return responseBody;
        }
    }
}
