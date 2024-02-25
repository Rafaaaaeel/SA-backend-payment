namespace Sa.Payment.Api.Interface;

public interface ISummaryRepository
{
    Task<SummaryResponse> GetSummary(string email);
}