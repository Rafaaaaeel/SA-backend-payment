namespace PaymentApp.Models
{
    public class Installment 
    {
        public int Id { get; set; }
        public string Colour { get; set; } = string.Empty;
        public Decimal Value { get; set; }
        public Parcel? Parcel { get; set; }
        public ICollection<Tag>? Tags { get; set; }
        public DateTime CreationDate { get; set; }
    }
}