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
                IEnumerable<Card> cards = _context.Card.Include(c => c.Months)
                                                        .ThenInclude(m => m.Year)
                                                        .ThenInclude(y => y.Installments)
                                                        .ToList()
                                                        .FindAll(c => c.EmailOwner == email);
                
                return cards;
            } catch 
            {
                return new HashSet<Card>();
            }
        }
        
        public async Task<Card> GetCard(int id) 
        {
            Card? card = await _context.Card.Include(c => c.Months)
                                            .ThenInclude(m => m.Year)
                                            .ThenInclude(y => y.Installments)
                                            .FirstOrDefaultAsync(c => c.Id == id);

            if (card == null) throw new NullReferenceException();

            return card;
        } 

        public async Task CreateCard(Card card)
        {   
            await _context.Card.AddAsync(card);

            await Save();
        }

        public async Task DeleteCard(Card card)
        {
            _context.Remove(card);

            await Save();
        }

        public async Task DeleteAllInstallmentsFromCard(int id)
        {
            Card? card = await FetchCardById(id);

            if(card == null) throw new NullReferenceException();

            
            card.Months.ToList().ForEach(m => _context.Month.Remove(m));

            await Save();
        }

        public async Task UpdateCard(Card card)
        {
            _context.Update(card);

            await Save();
        }

        private async Task<bool> Save()
        {
            int state = await _context.SaveChangesAsync();
            
            return state >= 0;
        }

        private async Task<Card?> FetchCardById(int id) => await _context.Card.Include(c => c.Months).FirstOrDefaultAsync(c => c.Id == id);
    }
}