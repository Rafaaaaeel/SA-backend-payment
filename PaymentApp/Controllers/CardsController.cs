using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaymentApp.Dto.Create;
using PaymentApp.Dto.Read;
using PaymentApp.Models;
using PaymentApp.Interfaces;

namespace PaymentApp.Controllers 
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class CardsController : ControllerBase 
    {
        private readonly ICardRepository _repository;
        private readonly IMapper _mapper;

        public CardsController(ICardRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Card>> GetAllCards()
        {
            string email = GetUserEmail();

            IEnumerable<Card> cards = _repository.GetAllCards(email);

            return Ok(cards);
        }

        [HttpGet("{id}/card")]
        public async Task<ActionResult<Card>> GetCard(int id)
        {
            Card card  = await _repository.GetCard(id);

            return Ok(card);
        }
        
        [HttpPost]
        public async Task<ActionResult> CreateCard([FromBody] CreateCardDto request)
        {
            Card card = _mapper.Map<Card>(request);
            
            await _repository.CreateCard(card);

            return Ok();
        }

        private string GetUserEmail() 
        {   
            return HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.Email).Value;
        }
    }
}