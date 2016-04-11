using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using InvoiceManager.Domain.Repository;

namespace InvoiceManager.Application.Test
{
    [TestClass]
    public class CompanyServicesTest
    {
        private readonly Mock<ICompanyRepository> _companyRepository;

        public CompanyServicesTest()
        {
            _companyRepository = new Mock<ICompanyRepository>();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void FindCompanyById_with_invalid_company()
        {
            var testClass = new CompanyServices(_companyRepository.Object);
            testClass.FindCompanyById(0);
        }
    }
}
