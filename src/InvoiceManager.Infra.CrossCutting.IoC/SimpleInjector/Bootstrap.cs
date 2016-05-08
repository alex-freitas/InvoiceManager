using System;
using InvoiceManager.Application;
using InvoiceManager.Application.Interfaces;
using InvoiceManager.Domain.Repository;
using InvoiceManager.Infra.Data.Repository;
using SimpleInjector;

namespace InvoiceManager.Infra.CrossCutting.IoC.SimpleInjector
{
	public class Bootstrap
	{
		public  static Container container;

		public static void Start()
		{
			container = new Container();

			// Register your types, for instance:
			container.Register<ICompanyServices, CompanyServices>(Lifestyle.Singleton);
			container.Register<ICompanyRepository, CompanyRepository>(Lifestyle.Singleton);

			container.Register<ICustomerServices, CustomerServices>(Lifestyle.Singleton);
			container.Register<ICustomerRepository, CustomerRepository>(Lifestyle.Singleton);

			container.Register<IInvoiceServices, InvoiceServices>(Lifestyle.Singleton);
			container.Register<IInvoiceRepository, InvoiceRepository>(Lifestyle.Singleton);

			// Optionally verify the container.
			container.Verify();
		}
	}
}

