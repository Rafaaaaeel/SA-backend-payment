namespace PaymentApp.Dto.Read
{
    public class ReadPaymentDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string Colour { get; set; }
        public required string BackgroundColor { get; set; }
        public required string Image { get; set; }
        public string? Description { get; set; }
        public decimal Total { get; set; } = 0;
        public required int Expiration { get; set; }
        public ICollection<ReadMonthDto> Months { get; set; } = new HashSet<ReadMonthDto>();
    }
}