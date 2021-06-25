using System;
using ElectronicInvoice.Core.Models.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ElectronicInvoice.API.Extensions;

namespace ElectronicInvoice.API.DTOs
{
    public class ElectronicInvoiceDTO
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public StatusInvoice StatusInvoice { get; set; }
        public string StatusInvoiceName => StatusInvoice.GetDescription();
        public double Amount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public string PaymentMethodName => PaymentMethod.GetDescription();
    }
}
