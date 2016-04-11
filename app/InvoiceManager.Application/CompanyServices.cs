using InvoiceManager.Application.Interfaces;
using InvoiceManager.Domain;
using InvoiceManager.Domain.Repository;
using System;
using System.Collections.Generic;

namespace InvoiceManager.Application
{
    public class CompanyServices : ICompanyServices
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyServices(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public Company FindCompanyById(int id)
        {
            var company = _companyRepository.Get(id);

            if (company == null)
            {
                throw new Exception("Company not found.");
            }

            return company;
        }

        public List<Company> ListAllCompanies()
        {
            return _companyRepository.GetAll();
        }
    }
}
