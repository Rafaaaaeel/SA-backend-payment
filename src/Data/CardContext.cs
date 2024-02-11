namespace Sa.Payment.Api.Context;

public class CardContext : DbContext
{
    public CardContext(DbContextOptions<CardContext> options) : base(options) { }
    public DbSet<Card> Card { get; set; }
    public DbSet<Month> Month { get; set; }
    public DbSet<Year> Year { get; set; }
    public DbSet<Installment> Installment { get; set; }
}