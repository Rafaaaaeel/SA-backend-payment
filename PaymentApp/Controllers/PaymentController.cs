using Microsoft.AspNetCore.Mvc;
using PaymentApp.Services;

namespace PaymentApp.Controllers 
{
    [Controller]
    [Route("/api/[controller]")]
    public class PaymentController : ControllerBase 
    {
        private readonly IPaymentService _service;

        public PaymentController(IPaymentService service)
        {
            _service = service;
        }
        
    }
}