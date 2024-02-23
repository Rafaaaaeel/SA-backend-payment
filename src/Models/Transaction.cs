namespace Sa.Payment.Api.Models;

public class Transaction 
{
    public string Name { get; set; } = string.Empty;
    public int LeftQuantity { get; set; }
    public string Description { get; set; } = string.Empty;
}