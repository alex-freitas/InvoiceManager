using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using InvoiceManager.Domain.Repository;
using InvoiceManager.Application.Interfaces;
using InvoiceManager.Domain;

namespace InvoiceManager.Application.Test
{
    [TestClass]
    public class InvoiceServicesTest
    {

        private readonly Mock<IInvoiceRepository> _invoiceRepository;
        private readonly Mock<ICustomerServices> _customerService;
        private readonly Mock<ICompanyServices> _companyService;
                
        public InvoiceServicesTest()
        {
            _invoiceRepository = new Mock<IInvoiceRepository>();
            _customerService = new Mock<ICustomerServices>();
            _companyService = new Mock<ICompanyServices>();
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreateInvoice_with_invalid_amount()  
        {
            var testClass = new InvoiceServices(_invoiceRepository.Object, 
                _customerService.Object, 
                _companyService.Object);

            testClass.CreateInvoice(1, 1, -1);                        
        }


    }
}
