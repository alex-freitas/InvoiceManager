using InvoiceManager.Application;
using InvoiceManager.Application.Interfaces;
using InvoiceManager.Domain.Repository;
using InvoiceManager.Infra.Data.Repository;
using Ninject;
using Ninject.Modules;

namespace InvoiceManager.Infra.CrossCutting.IoC.Ninject
{
    public class NinjectUtil
    {
        private static IKernel _kernel;

        public static IKernel CreateKernel()
        {
            if (_kernel == null)
            {
                using (var iocResolver = new IocResolver())
                {
                    _kernel = new StandardKernel(new NinjectSettings() { InjectNonPublic = true }, iocResolver);
                }
            }

            return _kernel;
        }
    }


    public class IocResolver : NinjectModule
    {
        public override void Load()
        {
            Bind<ICompanyServices>().To<CompanyServices>();
            Bind<ICompanyRepository>().To<CompanyRepository>();

            Bind<ICustomerServices>().To<CustomerServices>();
            Bind<ICustomerRepository>().To<CustomerRepository>();
            
            Bind<IInvoiceServices>().To<InvoiceServices>();
            Bind<IInvoiceRepository>().To<InvoiceRepository>();
        }
    }
}
