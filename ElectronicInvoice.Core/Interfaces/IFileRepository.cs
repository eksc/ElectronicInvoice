using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicInvoice.Core.Interfaces
{
    public interface IFileRepository
    {
        Task<string> ReadFile();
        Task WriteFile(string text);
        List<Models.ElectronicInvoice> ParseCsvTextToElectronicInvoices(string csvText);
        string ParseElectronicInvoicesToCsvText(List<Models.ElectronicInvoice> electronicInvoices);

    }
}
