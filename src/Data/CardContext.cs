namespace Sa.Payment.Api.Context;

public class CardContext : DbContext
{
    public CardContext(DbContextOptions<CardContext> options) : base(options) { }
    public DbSet<Card> Card { get; set; }
    public DbSet<Month> Month { get; set; }
    public DbSet<Year> Year { get; set; }
    public DbSet<Installment> Installment { get; set; }

    public IEnumerable<Card> QueryAllCardsForUser(string email) => Card.Include(c => c.Months)
        .ThenInclude(m => m.Year)
        .ThenInclude(y => y.Installments)
        .ToList()
        .FindAll(c => c.EmailOwner == email);

    public Task<Card?> QueryCardById(int id) => Card.Include(c => c.Months)
        .ThenInclude(m => m.Year)
        .ThenInclude(y => y.Installments)
        .FirstOrDefaultAsync(c => c.Id == id);
    
}