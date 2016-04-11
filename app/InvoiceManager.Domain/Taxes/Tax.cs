using InvoiceManager.Domain.Interfaces;
using InvoiceManager.Domain.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager.Domain.Taxes
{
    public abstract class Tax : ITax
    {
        protected double Rate { get; set; }

        public abstract WithheldTax Withhold(Invoice invoice);        
    }
}
