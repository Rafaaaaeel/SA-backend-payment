namespace Sa.Payment.Api.Response;

public class CardResponse
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Colour { get; set; }
    public required string BackgroundColor { get; set; }
    public required string Image { get; set; }
    public string? Description { get; set; }
    public decimal Total { get; set; } = 0;
    public required int Expiration { get; set; }
    public IEnumerable<MonthResponse> Months = new HashSet<MonthResponse>();
}