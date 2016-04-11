using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using InvoiceManager.Domain.Repository;

namespace InvoiceManager.Application.Test
{
    [TestClass]
    public class CustomerServicesTest
    {
        private readonly Mock<ICustomerRepository> _customerRepository;

        public CustomerServicesTest()
        {
            _customerRepository = new Mock<ICustomerRepository>();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void FindCustomerById_with_invalid_customer()
        {
            var testClass = new CustomerServices(_customerRepository.Object);

            testClass.FindCustomerById(0);
        }
    }
}
