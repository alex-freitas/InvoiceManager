using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager.Domain.VO
{
    public class WithheldTax
    {
        public readonly string Type; 
        public readonly double Rate;
        public readonly double Amount;
        public readonly string CurrencyAmount;

        public WithheldTax(string type, double rate, double amount)
        {
            Type = type;
            Rate = rate;
            Amount = amount;
            CurrencyAmount = amount.ToString("c2");
        }
    }
}
