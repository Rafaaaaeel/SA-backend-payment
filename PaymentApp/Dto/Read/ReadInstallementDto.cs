using PaymentApp.Models;

namespace PaymentApp.Dto.Read 
{
    public class ReadInstallementDto 
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Value { get; set; }
        public int? Total { get; set; }
        public required int Quantity { get; set; }
        public DateTime? Date { get; set; }
        // public ICollection<ReadTagDto>? Tags { get; set; }
    }
}