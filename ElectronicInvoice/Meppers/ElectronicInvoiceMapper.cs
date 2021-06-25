using ElectronicInvoice.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicInvoice.API.Meppers
{
    public static class ElectronicInvoiceMapper
    {
        public static Core.Models.ElectronicInvoice MapToElectronicInvoice(this ElectronicInvoiceDTO electronicInvoiceDTO)
        {
            return new Core.Models.ElectronicInvoice()
            {
                Id = electronicInvoiceDTO.Id,
                CreateDate = electronicInvoiceDTO.CreateDate,
                StatusInvoice = electronicInvoiceDTO.StatusInvoice,
                Amount = electronicInvoiceDTO.Amount,
                PaymentMethod = electronicInvoiceDTO.PaymentMethod
            };
        }

        public static ElectronicInvoiceDTO MapToElectronicInvoiceDTO(this Core.Models.ElectronicInvoice electronicInvoice)
        {
            return new ElectronicInvoiceDTO()
            {
                Id = electronicInvoice.Id,
                CreateDate = electronicInvoice.CreateDate,
                StatusInvoice = electronicInvoice.StatusInvoice,
                Amount = electronicInvoice.Amount,
                PaymentMethod = electronicInvoice.PaymentMethod
            };
        }
    }
}
