using InvoiceManager.Domain;

namespace InvoiceManager.Application.Interfaces
{
    public interface IInvoiceServices
    {
        Invoice CreateInvoice(int customerId, int companyId, double amount);
    }
}
