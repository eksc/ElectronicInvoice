using ElectronicInvoice.Core.Models;
using ElectronicInvoice.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicInvoice.Core.Interfaces
{
    public interface IElectronicInvoiceRepository
    {
        Task<List<Models.ElectronicInvoice>> GetElectronicInvoicesAsync(ISpecification<Models.ElectronicInvoice> specification);
        Task<Models.ElectronicInvoice> GetElectronicInvoiceById(ISpecification<Models.ElectronicInvoice> specification);
        Task<Models.ElectronicInvoice> CreateElectronicInvoice(Models.ElectronicInvoice electronicInvoice);
        Task<Models.ElectronicInvoice> EditElectronicInvoice(int id, Models.ElectronicInvoice electronicInvoice);
    }
}
