using Microsoft.EntityFrameworkCore;
using PaymentApp.Models;

namespace PaymentApp.Data
{
    public class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options) : base(options) { }
        public DbSet<Card> Card { get; set; }
        public DbSet<Month> Month { get; set; }
        public DbSet<Year> Year { get; set; }
        public DbSet<Installment> Installment { get; set; }
    }
}