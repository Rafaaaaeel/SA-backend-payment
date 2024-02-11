namespace Sa.Payment.Api.Response;

public class MonthResponse 
{
    public required string Name { get; set; }
    public IEnumerable<YearResponse> Years { get; set; } = new HashSet<YearResponse>();
}