using System;
using System.Collections.Generic;

namespace InvoiceManager.Domain.Repository
{
    public interface IInvoiceRepository
    {
        List<Invoice> GetAll();
        Invoice Get(Guid id);
        void Save(Invoice invoice);
    }
}
