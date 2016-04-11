using InvoiceManager.Application.Interfaces;
using InvoiceManager.Domain;
using InvoiceManager.Domain.Repository;
using System;
using System.Collections.Generic;

namespace InvoiceManager.Application
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerServices(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer FindCustomerById(int id)
        {
            var customer = _customerRepository.Get(id);

            if (customer == null)
            {
                throw new Exception("Customer not found.");
            }

            return customer;
        }

        public List<Customer> ListAllCustomers()
        {
            return _customerRepository.GetAll();
        }


    }
}
