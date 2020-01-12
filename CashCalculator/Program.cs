using CashCalculator.Library;
using System;

namespace CashCalculator
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Select currency: £ = 1, $ = 2");

            ICurrency currency = CurrencySelector.CurrencySelect(Console.ReadLine());

            if (currency != null)
            {
                Console.WriteLine("What is the till's float?");

                if (int.TryParse(Console.ReadLine(), out int cashFloat))
                {
                    currency = CurrencyCalc.SetFloat(cashFloat, currency);
                }

                foreach (int denomination in currency.Denominations)
                {
                    Console.WriteLine(currency.SpecifiedCurrency + denomination);

                    if (int.TryParse(Console.ReadLine(), out int numberOfdenominations))
                    {
                        currency = CurrencyCalc.CalculateCurrency(numberOfdenominations, denomination, currency);
                    }
                }

                currency = CurrencyCalc.CalculateBankingTotal(currency);

                Console.WriteLine("Total cash in the till: " + currency.SpecifiedCurrency + currency.CashTotal);
                Console.WriteLine("Total Amount of cash to be banked: " + currency.SpecifiedCurrency + currency.BankingTotal);
            }
            else
            {
                Console.WriteLine("No Valid currency selected");
            }
        }
    }
}