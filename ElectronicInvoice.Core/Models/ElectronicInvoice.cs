using ElectronicInvoice.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicInvoice.Core.Models
{
    public class ElectronicInvoice
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public StatusInvoice StatusInvoice { get; set; }
        public double Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
