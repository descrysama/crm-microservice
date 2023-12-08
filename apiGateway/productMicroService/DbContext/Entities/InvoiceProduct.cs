namespace productMicroService.Entities
{
    public class InvoiceProduct
    {
        public int Id { get; set; }

        public int InvoiceId { get; set; }

        public int ProductId { get; set; }

        public decimal? DiscountPercentage { get; set; }

        public decimal? TaxPercentage { get; set; }

        public string? Description { get; set; }

        public int Quantity { get; set; } = 1;

        public int? PaymentMethodId { get; set; }

        public decimal Total { get; set; } = 0;

        public decimal TotalWithTax { get; set; } = 0;

        public decimal TotalWithTaxWithDiscount { get; set; } = 0;

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual required User CreatedBy { get; set; }

        public virtual required User UpdatedBy { get; set; }
    }
}
