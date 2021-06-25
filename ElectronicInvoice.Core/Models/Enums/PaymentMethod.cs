using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ElectronicInvoice.Core.Models.Enums
{
    public enum PaymentMethod
    {
        [Description("Кредитная карта")]
        CreditCard = 1,
        [Description("Дебетовая карта")]
        DebitCard = 2,
        [Description("Электронный чек")]
        ElectronicCheck = 3
    }
}
