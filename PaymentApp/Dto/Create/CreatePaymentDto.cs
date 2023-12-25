namespace PaymentApp.Dto.Create
{
    public class CreatePaymentDto
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