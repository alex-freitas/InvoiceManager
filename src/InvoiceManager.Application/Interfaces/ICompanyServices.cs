using InvoiceManager.Domain;
using System.Collections.Generic;

namespace InvoiceManager.Application.Interfaces
{
    public interface ICompanyServices
    {
        List<Company> ListAllCompanies();
        Company FindCompanyById(int id);
    }
}
