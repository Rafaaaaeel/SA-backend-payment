using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaymentApp.Dto.Create;
using PaymentApp.Interfaces;
using PaymentApp.Models;

namespace PaymentApp.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class InstallmentsController : ControllerBase
    {
        private readonly IInstallmentsRepository _repository;
        private readonly IMapper _mapper;

        public InstallmentsController(IInstallmentsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("{id}/installment")]
        public async Task<ActionResult> CreateInstallment([FromBody] CreateInstallmentDto request, [FromRoute] int id)
        {
            Installment installment = _mapper.Map<Installment>(request);

            await _repository.CreateInstallmentForCard(installment, id);

            return NoContent();
        }
    }
}