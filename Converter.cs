using System;

namespace CurrencyConverter
{
    internal class Converter
    {
        private IExchange exchange;

        public Converter()
        {
        }

        public Converter(IExchange exchange)
        {
            this.exchange = exchange;
        }

        public double Convert(string from, string to, int amount)
        {
            double converted = amount * exchange.GetRate(from, to);
            double valueRoundedUp = Math.Ceiling(converted * 100.0) / 100;
            return valueRoundedUp;
        }
    }
}