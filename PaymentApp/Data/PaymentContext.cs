using Microsoft.EntityFrameworkCore;
using PaymentApp.Models;

namespace PaymentApp.Data
{
    public class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options) : base(options) { }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Installment> Installment { get; set; }
        public DbSet<Tag> Tag { get; set; }
        
    }
}