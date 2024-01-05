using PaymentApp.Dto.Read;
using PaymentApp.Dto.Create;
using PaymentApp.Models;

namespace PaymentApp.Interfaces
{
    public interface ICardRepository
    {
        IEnumerable<Card> GetAllCards(string email);
        Task<Card> GetCard(int id);
        Task CreateCard(Card card);
        Task DeleteCard(Card card);
        Task DeleteAllInstallmentsFromCard(int id);
        Task UpdateCard(Card card);
    }
}