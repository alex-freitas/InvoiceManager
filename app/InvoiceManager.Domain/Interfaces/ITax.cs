using InvoiceManager.Domain.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager.Domain.Interfaces
{
    public interface ITax
    {
        WithheldTax Withhold(Invoice invoice);
    }
}
