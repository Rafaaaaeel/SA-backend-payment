namespace PaymentApp.Dto.Read
{
    public class ReadMonthDto
    {
         public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<ReadDataDto> Year { get; set; } = new HashSet<ReadDataDto>();
    }
}