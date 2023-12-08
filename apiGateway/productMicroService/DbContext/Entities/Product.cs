namespace productMicroService.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string ProductName { get; set; } = null!;

        public string SerialNumber { get; set; } = null!;

        public decimal Price { get; set; }

        public string? Description { get; set; }

        public bool IsDeactivated { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual required User LastModifiedBy { get; set; }

        public virtual required User CreatedBy { get; set; }

    }
}
