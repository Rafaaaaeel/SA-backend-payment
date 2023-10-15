namespace PaymentApp.Dto.Create
{
    public class CreateInstallmentDto
    {
        public Decimal Value { get; set; }
        public int? Total { get; set; }
        public DateTime? Initial { get; set; }
        public DateTime? Final { get; set; }
    }
}