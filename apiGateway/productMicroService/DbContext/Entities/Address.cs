namespace productMicroService.Entities
{
    public class Address
    {
        public int Id { get; set; }

        public string Street { get; set; } = null!;

        public string City { get; set; } = null!;

        public string PostalCode { get; set; } = null!;

        public int CountryId { get; set; }

        public int AccessLevel { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public int CreatedById { get; set; }

        public int LastModifiedById { get; set; }

        public virtual required User CreatedBy { get; set; }

        public virtual required User LastModifiedBy { get; set; }

        public virtual Country Country { get; set; } = null!;
    }
}
