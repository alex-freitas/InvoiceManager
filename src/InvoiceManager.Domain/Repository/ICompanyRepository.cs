using System.Collections.Generic;

namespace InvoiceManager.Domain.Repository
{
    public interface ICompanyRepository
    {
        List<Company> GetAll();
        Company Get(int id);
    }
}
