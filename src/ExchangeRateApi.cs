namespace CurrencyConverter
{
	public interface ExchangeRateApi
	{
		string GetJsonFor(string from, string to);
		string GetJsonForAllCurrencies();
	}
}