namespace Sa.Payment.Api.Interface;

public interface ICardRepository
{
    IEnumerable<Card> GetAllCards(string email);
    Task<Card> GetCard(int id);
    Task CreateCard(CardRequest request);
    Task DeleteCard(Card card);
    Task DeleteAllInstallmentsFromCard(int id);
    Task UpdateCard(CardRequest request);
}