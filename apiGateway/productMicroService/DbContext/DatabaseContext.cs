using Microsoft.EntityFrameworkCore;
using System;
using productMicroService.Entities;


namespace productMicroService
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Account> Account { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<InvoiceProduct> InvoiceProduct { get; set; }
        public DbSet<PaymentMethod> PaymentMethod { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Quote> Quote { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Tax> Tax { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasOne(a => a.CreatedBy)
                    .WithMany()
                    .HasForeignKey(a => a.CreatedById)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(a => a.UpdatedBy)
                    .WithMany()
                    .HasForeignKey(a => a.UpdatedById)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(a => a.Owner)
                    .WithMany()
                    .HasForeignKey(a => a.OwnerId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(a => a.BillingAddress)
                    .WithOne()
                    .HasForeignKey<Account>(a => a.BillingAddressId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(a => a.DeliveryAddress)
                    .WithOne()
                    .HasForeignKey<Account>(a => a.DeliveryAddressId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(a => a.PaymentMethod)
                    .WithOne()
                    .HasForeignKey<Account>(a => a.PaymentmethodId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasOne(a => a.CreatedBy)
                    .WithMany()
                    .HasForeignKey(a => a.CreatedById)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(a => a.LastModifiedBy)
                    .WithMany()
                    .HasForeignKey(a => a.LastModifiedById)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(a => a.Country)
                .WithMany()
                .HasForeignKey(a => a.CountryId)
                .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasOne(a => a.CreatedBy)
                    .WithMany()
                    .HasForeignKey(a => a.CreatedById)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(a => a.UpdatedBy)
                    .WithMany()
                    .HasForeignKey(a => a.UpdatedById)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(a => a.Owner)
                    .WithMany()
                    .HasForeignKey(a => a.OwnerId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(a => a.Account)
                    .WithMany()
                    .HasForeignKey(a => a.AccountId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            base.OnModelCreating(modelBuilder);
        }

    }

}
