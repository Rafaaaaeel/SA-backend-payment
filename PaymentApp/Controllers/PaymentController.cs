using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaymentApp.Dto.Create;
using PaymentApp.Dto.Read;
using PaymentApp.Services;

namespace PaymentApp.Controllers 
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentController : ControllerBase 
    {
        private readonly IPaymentService _service;

        public PaymentController(IPaymentService service)
        {
            _service = service;
        }
        
        [HttpGet("payments")]
        public ActionResult<IEnumerable<ReadPaymentDto>> GetAllPayments()
        {
            var payments = _service.GetAllPayments(GetUserEmail());

            return Ok(payments);
        }

        [HttpGet("payments/{id}/payment")]
        public ActionResult<ReadPaymentDto> GetPayment([FromQuery] int id)
        {
            string email = GetUserEmail();
            ReadPaymentDto payment  = _service.GetPayment(email, id);

            return Ok(payment);
        }

        [HttpGet("payments/{id}/installments")]
        public async Task<ActionResult<IEnumerable<ReadInstallementDto>>> GetInstallmnetsFromPaymnet()
        {
            return NoContent();
        }

        [HttpPost("payments/{id}/installments")]
        public async Task<ActionResult> CreateInstallment([FromBody] CreateInstallmentDto request, [FromQuery] int id)
        {
            await _service.CreateInstallment(request, id);
            return NoContent();
        }
        
        [HttpPost("payments")]
        public async Task<ActionResult> CreatePayment([FromBody] CreateCardDto request)
        {
            
            await _service.CreatePayment(request);

            return Ok();
        }

        private string GetUserEmail() 
        {   
            return HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.Email).Value;
        }
    }
}