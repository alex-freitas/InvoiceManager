using InvoiceManager.Domain.VO;

namespace InvoiceManager.Domain.Interfaces
{
    public interface ITax
    {
        WithheldTax Withhold(Invoice invoice);
    }
}
