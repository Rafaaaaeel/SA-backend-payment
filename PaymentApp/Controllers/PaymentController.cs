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

        [HttpGet("payments/{id}/installments")]
        public async Task<ActionResult<IEnumerable<ReadInstallementDto>>> GetInstallmnetsFromPaymnet()
        {
            return NoContent();
        }

        [HttpPost("payments")]
        public async Task<ActionResult> CreatePayment(CreatePaymentDto request)
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