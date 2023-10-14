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
        public DbSet<PaymentInstallment> PaymentInstallments { get; set; }
        public DbSet<InstallmentTag> InstallmentTags { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<PaymentInstallment>()
                .HasKey(pi => new { pi.PaymentId, pi.InstallementId });

            modelBuilder.Entity<PaymentInstallment>()
                .HasOne(p => p.Payment)
                .WithMany(p => p.PaymentInstallment)
                .HasForeignKey( p=> p.PaymentId);

            modelBuilder.Entity<PaymentInstallment>()
                .HasOne(p => p.Installment)
                .WithMany(p => p.PaymentInstallments)
                .HasForeignKey( p=> p.InstallementId);
            
            modelBuilder.Entity<InstallmentTag>()
                .HasKey(it => new { it.InstallementId, it.TagId });

            modelBuilder.Entity<InstallmentTag>()
                .HasOne(p => p.Tag)
                .WithMany(p => p.InstallmentTags)
                .HasForeignKey( p=> p.TagId);

            modelBuilder.Entity<InstallmentTag>()
                .HasOne(p => p.Installment)
                .WithMany(p => p.Tags)
                .HasForeignKey( p=> p.InstallementId);
        
            base.OnModelCreating(modelBuilder);
        }
    }
}