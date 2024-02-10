using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaymentApp.Dto.Card;
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

        public CardsController(ICardRepository repository)
        {
            _repository = repository;
        }
        
        /// <summary>
        /// It'll get all user cards
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Card>))]
        public ActionResult<IEnumerable<Card>> GetAllCards()
        {
            string email = GetUserEmail();

            IEnumerable<Card> cards = _repository.GetAllCards(email);

            return Ok(cards);
        }

        /// <summary>
        /// It'll gets only a card
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/card")]
        [ProducesResponseType(200, Type = typeof(Card))]
        public async Task<ActionResult<Card>> GetCard(int id)
        {
            Card card  = await _repository.GetCard(id);

            return Ok(card);
        }
        
        /// <summary>
        /// Creates 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(204)]
        public async Task<ActionResult> CreateCard([FromBody] CreateCardDto request)
        {   
            await _repository.CreateCard(request);

            return NoContent();
        }

        [HttpDelete("{id}/card")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> DeleteCard([FromRoute] int id)
        {
            try 
            {
                Card card = await _repository.GetCard(id);

                await _repository.DeleteCard(card);

                return NoContent();
            } catch
            {
                return NotFound();
            }
            
        }

        [HttpDelete("{id}/installments")]
        public async Task<ActionResult> DeleteAllInstallmentFromCard([FromRoute]int id)
        {
            await _repository.DeleteAllInstallmentsFromCard(id);

            return NoContent();
        }

        [HttpPut("{id}/card")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> UpdateCard([FromBody] UpdateCardDto request)
        {
            await _repository.UpdateCard(request);

            return NoContent();
        }

        private string GetUserEmail() => HttpContext.User.Claims.Single(x => x.Type == ClaimTypes.Email).Value;
    }
}