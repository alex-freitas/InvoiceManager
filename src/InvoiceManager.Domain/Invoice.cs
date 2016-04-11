using InvoiceManager.Domain.Interfaces;
using InvoiceManager.Domain.VO;
using System;
using System.Collections.Generic;

namespace InvoiceManager.Domain
{
    public class Invoice
    {
        public Guid Id { get; private set; }
        public DateTime Date { get; private set; }
        public Customer Customer { get; private set; }
        public Company Company { get; private set; }
        public double Amount { get; private set; }        
        public List<WithheldTax> Taxes { get; private set; }

        public string CurrencyAmount { get { return Amount.ToString("c2"); } }
        
        public Invoice(Customer customer, Company company, double amount, List<ITax> taxes)
        {
            Id = Guid.NewGuid();
            Date = DateTime.Now;
            Amount = amount;
            Customer = customer;
            Company = company;
            Taxes = new List<WithheldTax>();
            
            CalculateTaxes(taxes);
        }

        private void CalculateTaxes(List<ITax> taxes)
        {
            foreach (var tax in taxes)
            {
                var withheldTax = tax.Withhold(this);

                if (withheldTax != null)
                {
                    this.Taxes.Add(withheldTax);
                }
            }
        }       
    }
}
