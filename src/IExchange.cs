namespace CurrencyConverter
{
	using System.Collections.Generic;
	public interface IExchange
	{
		List<string> GetAllCurrencies();
		double GetRate(string from, string to);
	}
}