using ElectronicInvoice.API.DTOs;
using ElectronicInvoice.API.Helpers;
using ElectronicInvoice.API.Meppers;
using ElectronicInvoice.Core.Interfaces;
using ElectronicInvoice.Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicInvoice.API.Controllers
{
    public class ElectronicInvoiceController : BaseController
    {
        private readonly IElectronicInvoiceRepository _electronicInvocieRepository;

        public ElectronicInvoiceController(IElectronicInvoiceRepository electronicInvocieRepository)
        {
            _electronicInvocieRepository = electronicInvocieRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ElectronicInvoiceDTO>>> GetElectronicInvoices(
            [FromQuery] ElectronicInvoiceSpecificationParams electronicInvoiceParams)
        {
            var specification = new ElectronicInvoiceSpecification(electronicInvoiceParams);

            var countSpecification = new ElectronicInvoiceWithFiltersForCountSpecification(electronicInvoiceParams);

            var totalItems = (await _electronicInvocieRepository.GetElectronicInvoicesAsync(countSpecification)).Count;

            var electronicInvoices = await _electronicInvocieRepository.GetElectronicInvoicesAsync(specification);

            var data = electronicInvoices.Select(e => e.MapToElectronicInvoiceDTO()).ToList().AsReadOnly();

            return Ok(new Pagination<ElectronicInvoiceDTO>(electronicInvoiceParams.PageIndex, electronicInvoiceParams.PageSize, totalItems, data));
        }

        [HttpGet("{id}", Name = nameof(GetElectronicInvoiceById))]
        public async Task<ActionResult<ElectronicInvoiceDTO>> GetElectronicInvoiceById(int id)
        {
            var specification = new ElectronicInvoiceSpecification(id);

            var electronicInvoice = await _electronicInvocieRepository.GetElectronicInvoiceById(specification);

            if (electronicInvoice == null)
            {
                return NotFound();
            }

            return Ok(electronicInvoice.MapToElectronicInvoiceDTO());
        }

        [HttpPost(Name = nameof(CreateElectronicInvoice))]
        public async Task<ActionResult> CreateElectronicInvoice([FromBody]ElectronicInvoiceDTO electronicInvoiceDTO)
        {
            await _electronicInvocieRepository.CreateElectronicInvoice(electronicInvoiceDTO.MapToElectronicInvoice());

            return Ok();
        }

        [HttpPut("{id:int}", Name = nameof(EditElectronicInvoice))]
        public async Task<ActionResult> EditElectronicInvoice(int id, [FromBody]ElectronicInvoiceDTO electronicInvoiceDTO)
        {
            await _electronicInvocieRepository.EditElectronicInvoice(id, electronicInvoiceDTO.MapToElectronicInvoice());

            return Ok();
        }
    }
}
