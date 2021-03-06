﻿using InvoiceManager.Domain.VO;
using System;
using System.Configuration;
using System.Globalization;

namespace InvoiceManager.Domain.Taxes
{
    public class PIS : Tax
    {
        public PIS()
        {
            var rate = Convert.ToDouble(ConfigurationManager.AppSettings["PIS"], CultureInfo.InvariantCulture);
            Rate = rate == 0 ? 0 : rate / 100;
        }

        public override WithheldTax Withhold(Invoice invoice)
        {
            var minimumValue = Convert.ToDouble(ConfigurationManager.AppSettings["MinimumValueForPIS"], CultureInfo.InvariantCulture);
            var amount = 0.0;
            
            if (invoice.Amount > minimumValue)
            {
                amount = invoice.Amount * this.Rate;
            }

            return new WithheldTax(this.GetType().Name, Rate, amount);
        }
    }
}
