using Microsoft.EntityFrameworkCore;
using PaymentApp.Models;

namespace PaymentApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}

        public DbSet<Payment> Payment { get; set; }
        public DbSet<Installment> Installments { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<Parcel> Parcel { get; set; }
        public DbSet<PaymentTag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
        }
    }
}