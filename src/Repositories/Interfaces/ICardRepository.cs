using PaymentApp.Models;
using PaymentApp.Dto.Card;

namespace PaymentApp.Interfaces
{
    public interface ICardRepository
    {
        IEnumerable<Card> GetAllCards(string email);
        Task<Card> GetCard(int id);
        Task CreateCard(CreateCardDto request);
        Task DeleteCard(Card card);
        Task DeleteAllInstallmentsFromCard(int id);
        Task UpdateCard(UpdateCardDto request);
    }
}