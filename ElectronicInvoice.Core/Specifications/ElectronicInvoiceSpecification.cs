using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicInvoice.Core.Specifications
{
    public class ElectronicInvoiceSpecification : BaseSpecification<Models.ElectronicInvoice>
    {
        public ElectronicInvoiceSpecification(int id) : base(x => x.Id == id)
        {

        }

        public ElectronicInvoiceSpecification(ElectronicInvoiceSpecificationParams electronicInvoiceParams)
            : base(x =>
                (!electronicInvoiceParams.PaymentMethod.HasValue || electronicInvoiceParams.PaymentMethod.Value == x.PaymentMethod) &&
                (!electronicInvoiceParams.StatusInvoice.HasValue || electronicInvoiceParams.StatusInvoice.Value == x.StatusInvoice))
        {
            AddOrderBy(x => x.Id);
            ApplyPaging(electronicInvoiceParams.PageSize * (electronicInvoiceParams.PageIndex - 1), electronicInvoiceParams.PageSize);

            if (!string.IsNullOrEmpty(electronicInvoiceParams.Sort))
            {
                switch (electronicInvoiceParams.Sort)
                {
                    case "idAsc":
                        AddOrderBy(x => x.Id);
                        break;
                    case "idDesc":
                        AddOrderByDescending(x => x.Id);
                        break;
                    case "amountAsc":
                        AddOrderBy(x => x.Amount);
                        break;
                    case "amountDesc":
                        AddOrderByDescending(x => x.Amount);
                        break;
                    case "createDateAsc":
                        AddOrderBy(x => x.CreateDate);
                        break;
                    case "createDateDesc":
                        AddOrderByDescending(x => x.CreateDate);
                        break;
                    default:
                        AddOrderBy(x => x.Id);
                        break;
                }
            }
        }
    }
}
