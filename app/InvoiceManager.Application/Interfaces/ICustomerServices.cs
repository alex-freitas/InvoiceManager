using InvoiceManager.Domain;
using System.Collections.Generic;

namespace InvoiceManager.Application.Interfaces
{
    public interface ICustomerServices
    {
        List<Customer> ListAllCustomers();

        Customer FindCustomerById(int id);
    }
}
