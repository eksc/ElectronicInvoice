using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicInvoice.Core.Specifications
{
    public class ElectronicInvoiceWithFiltersForCountSpecification : BaseSpecification<Models.ElectronicInvoice>
    {
        public ElectronicInvoiceWithFiltersForCountSpecification(ElectronicInvoiceSpecificationParams electronicInvoiceParams) 
            : base(x =>
                (!electronicInvoiceParams.PaymentMethod.HasValue || electronicInvoiceParams.PaymentMethod.Value == x.PaymentMethod) &&
                (!electronicInvoiceParams.StatusInvoice.HasValue || electronicInvoiceParams.StatusInvoice.Value == x.StatusInvoice))
        {

        }
    }
}
