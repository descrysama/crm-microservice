

namespace productMicroService.Data.Dto.Incomming
{
	public class ProductCreateModel
    {
        public string ProductName { get; set; } = null!;

        public string SerialNumber { get; set; } = null!;

        public decimal Price { get; set; }

        public string? Description { get; set; }

        public bool IsDeactivated { get; set; } = false;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
    }
}

