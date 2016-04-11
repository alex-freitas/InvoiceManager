using InvoiceManager.Domain.Interfaces;
using InvoiceManager.Domain.VO;

namespace InvoiceManager.Domain.Taxes
{
    public abstract class Tax : ITax
    {
        protected double Rate { get; set; }

        public abstract WithheldTax Withhold(Invoice invoice);        
    }
}
