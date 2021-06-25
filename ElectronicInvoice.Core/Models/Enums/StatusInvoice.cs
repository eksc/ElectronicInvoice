using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ElectronicInvoice.Core.Models.Enums
{
    public enum StatusInvoice
    {
        [Description("Новый")]
        New = 1,
        [Description("Оплачен")]
        Paid = 2,
        [Description("Отменен")]
        Canceled = 3
    }
}
