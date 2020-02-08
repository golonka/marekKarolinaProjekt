using System;

namespace marekKarolinaProjekt
{
    public enum Currency
    {
        EURO,
        PLN
    }

    public class CurrencyAndPrice
    {
        private readonly double value;
        private readonly Currency currency;

        public CurrencyAndPrice(double value, Currency currency)
        {
            if (value < 0)
            {
                throw new ArgumentException("Price cannot be negative");
            }

            this.value = value;
            this.currency = currency;
        }

        public double Value { get => value; }

        public Currency Currency { get => currency; }

        public CurrencyAndPrice InEURO()
        {
            if (this.currency == Currency.PLN)
            {
                return new CurrencyAndPrice(Math.Round(this.value / 4.27, 2), Currency.EURO);
            }

            return this;
        }

        public CurrencyAndPrice InPLN()
        {
            if (this.currency == Currency.EURO)
            {
                return new CurrencyAndPrice(Math.Round(this.value * 4.27, 2), Currency.PLN);
            }

            return this;
        }
    }
}
