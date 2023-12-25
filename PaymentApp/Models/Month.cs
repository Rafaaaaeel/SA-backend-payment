namespace PaymentApp.Models
{
    public class Month 
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required Payment Payment { get; set; }
        public ICollection<Year> Year { get; set; } = new HashSet<Year>();
    }
}