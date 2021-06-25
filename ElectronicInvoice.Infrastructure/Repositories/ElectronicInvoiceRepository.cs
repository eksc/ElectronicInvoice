using ElectronicInvoice.Core.Interfaces;
using ElectronicInvoice.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicInvoice.Infrastructure.Repositories
{
    public class ElectronicInvoiceRepository : IElectronicInvoiceRepository
    {
        private readonly IFileRepository _fileRepository;

        public ElectronicInvoiceRepository(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async Task<Core.Models.ElectronicInvoice> CreateElectronicInvoice(Core.Models.ElectronicInvoice electronicInvoice)
        {
            var electronicInvoices = _fileRepository.ParseCsvTextToElectronicInvoices(await _fileRepository.ReadFile());

            electronicInvoice.Id = electronicInvoices[electronicInvoices.Count - 1].Id + 1;
            electronicInvoice.CreateDate = DateTime.Now;

            electronicInvoices.Add(electronicInvoice);

            await _fileRepository.WriteFile(_fileRepository.ParseElectronicInvoicesToCsvText(electronicInvoices));

            return electronicInvoice;
        }

        public async Task<Core.Models.ElectronicInvoice> EditElectronicInvoice(int id, Core.Models.ElectronicInvoice electronicInvoice)
        {
            var electronicInvoices = _fileRepository.ParseCsvTextToElectronicInvoices(await _fileRepository.ReadFile());

            var editElectronicInvoice = electronicInvoices.Find(e => e.Id == id);

            if (editElectronicInvoice != null)
            {
                editElectronicInvoice.StatusInvoice = electronicInvoice.StatusInvoice;
                editElectronicInvoice.Amount = electronicInvoice.Amount;
                editElectronicInvoice.PaymentMethod = electronicInvoice.PaymentMethod;
            }

            await _fileRepository.WriteFile(_fileRepository.ParseElectronicInvoicesToCsvText(electronicInvoices));

            return electronicInvoice;
        }

        public async Task<Core.Models.ElectronicInvoice> GetElectronicInvoiceById(ISpecification<Core.Models.ElectronicInvoice> specification)
        {
            return (await ApplySpecification(specification)).FirstOrDefault();
        }

        public async Task<List<Core.Models.ElectronicInvoice>> GetElectronicInvoicesAsync(ISpecification<Core.Models.ElectronicInvoice> specification)
        {
            return (await ApplySpecification(specification)).ToList();
        }

        private async Task<IEnumerable<Core.Models.ElectronicInvoice>> ApplySpecification(ISpecification<Core.Models.ElectronicInvoice> specification)
        {
            return SpecificationEvaluator<Core.Models.ElectronicInvoice>.GetCollection(
                _fileRepository.ParseCsvTextToElectronicInvoices(
                    await _fileRepository.ReadFile()
                ),
                specification);
        }


    }
}
