namespace PaymentApp.Dto.Installment
{
    public class ReadYearDto
    {
        public required string Name { get; set; }
        public int? Total { get; set; }
        public int? Quantity { get; set; }
        public ICollection<InstallmentResponse> Installments { get; set; } = new HashSet<InstallmentResponse>();
    }
}