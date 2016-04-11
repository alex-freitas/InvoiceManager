using InvoiceManager.Domain.Interfaces;
using InvoiceManager.Domain.VO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager.Domain.Taxes
{
    public class IRPJ : Tax
    {
        public IRPJ()
        {
            var rate = Convert.ToDouble(ConfigurationManager.AppSettings["IRPJ"], CultureInfo.InvariantCulture);
            this.Rate = rate == 0 ? 0 : rate / 100;
        }

        public override WithheldTax Withhold(Invoice invoice)
        {
            var minimumValue = Convert.ToDouble(ConfigurationManager.AppSettings["MinimumValueForIRPJ"], CultureInfo.InvariantCulture);
            var amount = 0.0;

            if (invoice.Amount * this.Rate > minimumValue)
            {
                amount = invoice.Amount * this.Rate;
            }

            return new WithheldTax(this.GetType().Name, Rate, amount);
        }
    }
}
