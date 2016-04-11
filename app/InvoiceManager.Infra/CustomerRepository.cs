using InvoiceManager.Domain;
using InvoiceManager.Domain.Repository;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceManager.Infra
{
    public class CustomerRepository : ICustomerRepository
    {
        private List<Customer> Customers { get; set; }

        public CustomerRepository()
        {
            Customers = new List<Customer>() {
                new Customer(1, "Clark Kent"),
                new Customer(2, "Lex Luthor"),
                new Customer(3, "Bruce Wayne"),
                new Customer(4, "Oliver Queen"),
                new Customer(5, "Ted Kord")
            };
        }

        public Customer Get(int id)
        {
            return Customers.FirstOrDefault(c => c.Id == id);
        }

        public List<Customer> GetAll()
        {
            return Customers;
        }
    }
}
