namespace PaymentApp.Dto.Installment
{
    public class ReadDataDto
    {
        public required string Name { get; set; }
        public int? Total { get; set; }
        public int? Quantity { get; set; }
        public ICollection<ReadInstallementDto> Installments { get; set; } = new HashSet<ReadInstallementDto>();
    }
}