using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaymentApp.Dto.Create;
using PaymentApp.Dto.Read;
using PaymentApp.Models;
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
        public ActionResult<IEnumerable<Card>> GetAllPayments()
        {
            string email = GetUserEmail();

            IEnumerable<Card> cards = _service.GetAllPayments(email);

            return Ok(cards);
        }

        [HttpGet("payments/{id}/payment")]
        public ActionResult<ReadPaymentDto> GetPayment(int id)
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
        public async Task<ActionResult> CreateInstallment([FromBody] CreateInstallmentDto request, [FromRoute] int id)
        {
            string email = GetUserEmail();

            await _service.CreateInstallment(request, id, email);

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