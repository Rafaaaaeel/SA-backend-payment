using PaymentApp.Models;

namespace PaymentApp.Dto.Read 
{
    public class ReadInstallementDto 
    {
        public decimal Value { get; set; }
        public int? Total { get; set; }
        public DateTime? Initial { get; set; }
        public DateTime? Final { get; set; }
        public ICollection<ReadTagDto>? Tags { get; set; }
    }
}