using ElectronicInvoice.Core.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicInvoice.Core.Specifications
{
    public class ElectronicInvoiceSpecificationParams
    {
        private int _pageSize = 6;
        private const int MaxPageSize = 50;

        public int PageIndex { get; set; } = 1;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public PaymentMethod? PaymentMethod { get; set; }
        public StatusInvoice? StatusInvoice { get; set; }

        public string Sort { get; set; }

    }
}
