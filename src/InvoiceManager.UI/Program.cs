using InvoiceManager.Application.Interfaces;
using InvoiceManager.Infra.CrossCutting.IoC.Ninject;
using Ninject;
using System;
using InvoiceManager.Infra.CrossCutting.IoC.SimpleInjector;

namespace InvoiceManager.UI
{
    class Program
    {
        private static IKernel _kernel = NinjectUtil.CreateKernel();

        static void Main(string[] args)
        {
			Bootstrap.Start();

            CreateInvoices();

            Console.ReadKey();
        }

        private static void CreateInvoices()
        {
            //var invoiceServices = _kernel.Get<IInvoiceServices>();
			var invoiceServices = Bootstrap.container.GetInstance<IInvoiceServices>();

            var invoice = invoiceServices.CreateInvoice(1, 1, 5001);
            LogInvoice(invoice);
            
            invoice = invoiceServices.CreateInvoice(2, 2, 5000);
            LogInvoice(invoice);
           
            invoice = invoiceServices.CreateInvoice(3, 3, 500);
            LogInvoice(invoice);          
        }

        private static void LogInvoice(Domain.Invoice invoice)
        {
            Console.WriteLine(string.Format(
                "INVOICE\nID: {0}\nCompany: {1}\nCustomer: {2}\nAmount: {3}",
                invoice.Id,
                invoice.Company.Name,
                invoice.Customer.Name,
                invoice.CurrencyAmount));

            foreach (var tax in invoice.Taxes)
            {
                Console.Write(string.Format("{0} : {1}\n", tax.Type, tax.CurrencyAmount));
            }

            Console.WriteLine();
        }

        private static void ListCompanies()
        {
            var companies = _kernel.Get<ICompanyServices>().ListAllCompanies();

            foreach (var company in companies)
            {
                Console.WriteLine(string.Format("{0} : {1}", company.Id, company.Name));
            }
        }

        private static void ListCustomers()
        {
            var customers = _kernel.Get<ICustomerServices>().ListAllCustomers();

            foreach (var customer in customers)
            {
                Console.WriteLine(string.Format("{0} : {1}", customer.Id, customer.Name));
            }
        }
    }
}
