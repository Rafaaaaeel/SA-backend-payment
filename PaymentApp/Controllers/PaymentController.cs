using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaymentApp.Dto.Create;
using PaymentApp.Dto.Read;
using PaymentApp.Services;

namespace PaymentApp.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PaymentController : ControllerBase 
    {
        private readonly IPaymentService _service;

        public PaymentController(IPaymentService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<ReadPaymentDto>> AllPayments()
        {
            var payments = _service.GetAllPayments(GetUserEmail());

            return Ok(payments);
        }

        [HttpPost("create")]
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