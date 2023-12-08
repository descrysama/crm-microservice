using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using userMicroService.Data.Managers;
using userMicroService.Entities;


namespace userMicroService
{
    public class DatabaseContext : DbContext
    {
        public readonly UserManager _userManager;
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            _userManager = new UserManager();
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasIndex(x => x.Siret).IsUnique();
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

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasData(new Role
                {
                    Id = 10,
                    Name = "visiteur"
                });
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(x => x.Email).IsUnique();
                entity.HasIndex(x => x.Username).IsUnique();
                entity.Property(x => x.RoleId).HasDefaultValue(10);
                entity.HasData(new User
                {
                    Id = 1,
                    Email = "descry@gmail.com",
                    Password = _userManager.CryptPasswordAndReturnString("Google59"),
                    RoleId = 10,
                    LastName = "gmail",
                    Name = "descry",
                    Username = "descry"
                });
            });

            base.OnModelCreating(modelBuilder);
        }

    }

}
