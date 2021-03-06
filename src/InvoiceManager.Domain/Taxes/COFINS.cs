﻿using InvoiceManager.Domain.VO;
using System;
using System.Configuration;
using System.Globalization;

namespace InvoiceManager.Domain.Taxes
{
    public class COFINS : Tax
    {
        public COFINS()
        {
            var rate = Convert.ToDouble(ConfigurationManager.AppSettings["COFINS"], CultureInfo.InvariantCulture);
            this.Rate = rate == 0 ? 0 : rate / 100;
        }

        public override WithheldTax Withhold(Invoice invoice)
        {
            var minimumValue = Convert.ToDouble(ConfigurationManager.AppSettings["MinimumValueForCOFINS"], CultureInfo.InvariantCulture);
            var amount = 0.0;

            if (invoice.Amount > minimumValue)
            {
                amount = invoice.Amount * this.Rate;
            }

            return new WithheldTax(this.GetType().Name, Rate, amount);
        }
    }
}
