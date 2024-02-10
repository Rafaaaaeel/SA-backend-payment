namespace PaymentApp.Dto.Card
{
    public class CreateCardDto
    {
        public required string Name { get; set; }
        public required string Colour { get; set; }
        public required string BackgroundColor { get; set; }
        public required string Image { get; set; }
        public string? Description { get; set; }
        public required int Expiration { get; set; }
        public required string EmailOwner { get; set; }
    }
}