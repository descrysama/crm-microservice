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
                    Id = 1,
                    Name = "owner"
                });

                entity.HasData(new Role
                {
                    Id = 2,
                    Name = "administrateur"
                });

                entity.HasData(new Role
                {
                    Id = 10,
                    Name = "visiteur"
                });
            });

            modelBuilder.Entity<Country>(entity =>
            {
                int id = 1;

                entity.HasData(new Country { Id = id++, Name = "Albania", CountryCode = "AL" });
                entity.HasData(new Country { Id = id++, Name = "Andorra", CountryCode = "AD" });
                entity.HasData(new Country { Id = id++, Name = "Armenia", CountryCode = "AM" });
                entity.HasData(new Country { Id = id++, Name = "Austria", CountryCode = "AT" });
                entity.HasData(new Country { Id = id++, Name = "Azerbaijan", CountryCode = "AZ" });
                entity.HasData(new Country { Id = id++, Name = "Belarus", CountryCode = "BY" });
                entity.HasData(new Country { Id = id++, Name = "Belgium", CountryCode = "BE" });
                entity.HasData(new Country { Id = id++, Name = "Bosnia and Herzegovina", CountryCode = "BA" });
                entity.HasData(new Country { Id = id++, Name = "Bulgaria", CountryCode = "BG" });
                entity.HasData(new Country { Id = id++, Name = "Croatia", CountryCode = "HR" });
                entity.HasData(new Country { Id = id++, Name = "Cyprus", CountryCode = "CY" });
                entity.HasData(new Country { Id = id++, Name = "Czech Republic", CountryCode = "CZ" });
                entity.HasData(new Country { Id = id++, Name = "Denmark", CountryCode = "DK" });
                entity.HasData(new Country { Id = id++, Name = "Estonia", CountryCode = "EE" });
                entity.HasData(new Country { Id = id++, Name = "Finland", CountryCode = "FI" });
                entity.HasData(new Country { Id = id++, Name = "France", CountryCode = "FR" });
                entity.HasData(new Country { Id = id++, Name = "Georgia", CountryCode = "GE" });
                entity.HasData(new Country { Id = id++, Name = "Germany", CountryCode = "DE" });
                entity.HasData(new Country { Id = id++, Name = "Greece", CountryCode = "GR" });
                entity.HasData(new Country { Id = id++, Name = "Hungary", CountryCode = "HU" });
                entity.HasData(new Country { Id = id++, Name = "Iceland", CountryCode = "IS" });
                entity.HasData(new Country { Id = id++, Name = "Ireland", CountryCode = "IE" });
                entity.HasData(new Country { Id = id++, Name = "Italy", CountryCode = "IT" });
                entity.HasData(new Country { Id = id++, Name = "Kazakhstan", CountryCode = "KZ" });
                entity.HasData(new Country { Id = id++, Name = "Kosovo", CountryCode = "XK" });
                entity.HasData(new Country { Id = id++, Name = "Latvia", CountryCode = "LV" });
                entity.HasData(new Country { Id = id++, Name = "Liechtenstein", CountryCode = "LI" });
                entity.HasData(new Country { Id = id++, Name = "Lithuania", CountryCode = "LT" });
                entity.HasData(new Country { Id = id++, Name = "Luxembourg", CountryCode = "LU" });
                entity.HasData(new Country { Id = id++, Name = "Malta", CountryCode = "MT" });
                entity.HasData(new Country { Id = id++, Name = "Moldova", CountryCode = "MD" });
                entity.HasData(new Country { Id = id++, Name = "Monaco", CountryCode = "MC" });
                entity.HasData(new Country { Id = id++, Name = "Montenegro", CountryCode = "ME" });
                entity.HasData(new Country { Id = id++, Name = "Netherlands", CountryCode = "NL" });
                entity.HasData(new Country { Id = id++, Name = "North Macedonia", CountryCode = "MK" });
                entity.HasData(new Country { Id = id++, Name = "Norway", CountryCode = "NO" });
                entity.HasData(new Country { Id = id++, Name = "Poland", CountryCode = "PL" });
                entity.HasData(new Country { Id = id++, Name = "Portugal", CountryCode = "PT" });
                entity.HasData(new Country { Id = id++, Name = "Romania", CountryCode = "RO" });
                entity.HasData(new Country { Id = id++, Name = "Russia", CountryCode = "RU" });
                entity.HasData(new Country { Id = id++, Name = "San Marino", CountryCode = "SM" });
                entity.HasData(new Country { Id = id++, Name = "Serbia", CountryCode = "RS" });
                entity.HasData(new Country { Id = id++, Name = "Slovakia", CountryCode = "SK" });
                entity.HasData(new Country { Id = id++, Name = "Slovenia", CountryCode = "SI" });
                entity.HasData(new Country { Id = id++, Name = "Spain", CountryCode = "ES" });
                entity.HasData(new Country { Id = id++, Name = "Sweden", CountryCode = "SE" });
                entity.HasData(new Country { Id = id++, Name = "Switzerland", CountryCode = "CH" });
                entity.HasData(new Country { Id = id++, Name = "Turkey", CountryCode = "TR" });
                entity.HasData(new Country { Id = id++, Name = "Ukraine", CountryCode = "UA" });
                entity.HasData(new Country { Id = id++, Name = "United Kingdom", CountryCode = "GB" });
                entity.HasData(new Country { Id = id++, Name = "Vatican City", CountryCode = "VA" });
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

            modelBuilder.Entity<Tax>(entity =>
            {
                int id = 1;
                entity.HasData(new Tax
                {
                    Id = id++,
                    Tax_amount = 5
                });

                entity.HasData(new Tax
                {
                    Id = id++,
                    Tax_amount = 10
                });

                entity.HasData(new Tax
                {
                    Id = id++,
                    Tax_amount = 15
                });

                entity.HasData(new Tax
                {
                    Id = id++,
                    Tax_amount = 20
                });

                entity.HasData(new Tax
                {
                    Id = id++,
                    Tax_amount = 25
                });
            });

            base.OnModelCreating(modelBuilder);
        }

    }

}
