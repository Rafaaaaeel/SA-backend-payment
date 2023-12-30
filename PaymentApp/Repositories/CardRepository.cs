using PaymentApp.Data;
using PaymentApp.Models;
using Microsoft.EntityFrameworkCore;
using PaymentApp.Interfaces;
using System.Security.Claims;

namespace PaymentApp.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly CardContext _context;

        public CardRepository(CardContext context)
        {
            _context = context;
        }

        public IEnumerable<Card> GetAllCards(string email)
        {
            try
            {
                IEnumerable<Card> cards = _context.Card.Include(c => c.Months).ToList().FindAll(p => p.EmailOwner == email);

                return cards;
            } catch 
            {
                return new HashSet<Card>();
            }
        }
        
        public async Task<Card> GetCard(int id) 
        {

            Card? card = await _context.Card.FirstOrDefaultAsync(c => c.Id == id);

            if (card == null) throw new NullReferenceException();

            return card;
        } 

        public async Task CreateCard(Card card)
        {   
            await _context.Card.AddAsync(card);

            await Save();
        }

        private async Task<bool> Save()
        {
            int state = await _context.SaveChangesAsync();
            
            return state >= 0;
        }
    }
}