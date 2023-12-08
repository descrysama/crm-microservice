namespace productMicroService.Entities
{
    public class Account
    {
        public int Id { get; set; }

        public string CompanyName { get; set; } = null!;

        public string? Siret { get; set; }

        public string? MainEmail { get; set; }

        public string? PhoneNumber { get; set; }

        public string? TvaNumber { get; set; }

        public string? WebsiteUrl { get; set; }

        public int PaymentmethodId { get; set; }

        public int BillingAddressId { get; set;}

        public int DeliveryAddressId { get; set;}

        public int OwnerId { get; set; }

        public string? Description { get; set; }

        public bool IsDisabled { get; set; } = false;

        public int CreatedById { get; set; }

        public int UpdatedById { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual required User CreatedBy { get; set; }

        public virtual required User UpdatedBy { get; set; }

        public virtual required User Owner { get; set; }

        public virtual Address BillingAddress { get; set; } = null!;

        public virtual Address DeliveryAddress { get; set; } = null!;

        public virtual PaymentMethod PaymentMethod { get; set; } = null!;
    }
}
