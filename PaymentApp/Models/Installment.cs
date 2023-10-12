namespace PaymentApp.Models
{
    public class Installment 
    {
        public int Id { get; set; }
        public string Colour { get; set; }
        public Decimal Value { get; set; }
        public Parcel Parcel { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
    }
}