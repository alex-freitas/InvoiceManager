using System;
using System.Collections.Generic;
using InvoiceManager.Application.Interfaces;
using InvoiceManager.Domain;
using InvoiceManager.Domain.Interfaces;
using InvoiceManager.Domain.Repository;
using InvoiceManager.Domain.Taxes;

namespace InvoiceManager.Application
{
    public class InvoiceServices : IInvoiceServices
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ICustomerServices _customerService;
        private readonly ICompanyServices _companyService;
        
        public InvoiceServices(IInvoiceRepository invoiceRepository,
            ICustomerServices customerService,
            ICompanyServices companyService)
        {
            _invoiceRepository = invoiceRepository;
            _customerService = customerService;
            _companyService = companyService;
        }

        public Invoice CreateInvoice(int customerId, int companyId, double amount)
        {
            if (amount < 0)
            {
                throw new Exception("Invalid amount.");
            }

            var customer = _customerService.FindCustomerById(customerId);

            var company = _companyService.FindCompanyById(companyId);

            var taxes = new List<ITax>
            {
                new IRPJ(),
                new PIS(),
                new COFINS(),
                new CSLL()
            };

            var invoice = new Invoice(customer, company, amount, taxes);

			_invoiceRepository.Save (invoice);

            return invoice;
        }
    }
}
