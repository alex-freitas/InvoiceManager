using System.Collections.Generic;

namespace InvoiceManager.Domain.Repository
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();
        Customer Get(int id);
    }
}
