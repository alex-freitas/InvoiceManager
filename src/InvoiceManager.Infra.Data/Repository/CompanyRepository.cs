using InvoiceManager.Domain;
using InvoiceManager.Domain.Repository;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceManager.Infra.Data.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private List<Company> Companies { get; set; }

        public CompanyRepository()
        {
            Companies = new List<Company>() {
                new Company(1, "Daily Planet"),
                new Company(2, "Lex Corp"),
                new Company(3, "Wayne Tech"),
                new Company(4, "Queen Industries"),
                new Company(5, "Kord Enterprises")
            };
        }

        public Company Get(int id)
        {
            return Companies.FirstOrDefault(c => c.Id == id);
        }

        public List<Company> GetAll()
        {
            return Companies;
        }
    }
}
