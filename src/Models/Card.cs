namespace Sa.Payment.Api.Models;

public class Card
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string BackgroundColor { get; set; }
    public required string Colour { get; set; }
    public required string Image { get; set; }
    public string? Description { get; set; }
    public decimal Total { get; set; } = 0;
    public required int Expiration { get; set; }
    public decimal MaxExpanse { get; set; } = 0;
    public ICollection<Month> Months { get; set; } = new HashSet<Month>();
    public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    public required string EmailOwner { get; set; }
}