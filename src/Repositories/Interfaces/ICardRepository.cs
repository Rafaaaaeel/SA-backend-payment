namespace Sa.Payment.Api.Interface;

public interface ICardRepository
{
    IEnumerable<Card> GetAllCards(string email);
    Task<CardResponse> GetCard(int id);
    Task CreateCard(CardRequest request);
    Task DeleteCard(int id);
    Task DeleteAllInstallmentsFromCard(int id);
    Task UpdateCard(CardRequest request);
}