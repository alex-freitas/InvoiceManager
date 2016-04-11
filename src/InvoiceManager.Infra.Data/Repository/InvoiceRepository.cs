using InvoiceManager.Domain;
using InvoiceManager.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvoiceManager.Infra.Data.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        public List<Invoice> Invoices { get; set; }

        public InvoiceRepository()
        {
            Invoices = new List<Invoice>();
        }

        public Invoice Get(Guid id)
        {
            return Invoices.FirstOrDefault(c => c.Id == id);
        }

        public List<Invoice> GetAll()
        {
            return Invoices;
        }

        public void Save(Invoice invoice)
        {
            Invoices.Add(invoice);
        }
    }
}
