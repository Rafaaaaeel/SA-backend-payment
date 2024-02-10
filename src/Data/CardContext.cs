using Microsoft.EntityFrameworkCore;
using PaymentApp.Models;

namespace PaymentApp.Data
{
    public class CardContext : DbContext
    {
        public CardContext(DbContextOptions<CardContext> options) : base(options) { }
        public DbSet<Card> Card { get; set; }
        public DbSet<Month> Month { get; set; }
        public DbSet<Year> Year { get; set; }
        public DbSet<Installment> Installment { get; set; }
    }
}