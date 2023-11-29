namespace userMicroService.Entities
{
    public class Quote
    {
        public int Id { get; set; }

        public string QuoteUuid { get; set; } = Guid.NewGuid().ToString();

        public int UserId { get; set; }

        public int? AccountId { get; set; }
        
        public int? ContactId { get; set; }

        public string LastName { get; set; } = null!;

        public int? PaymentMethodId { get; set; }

        public decimal Total { get; set; } = 0;

        public decimal TotalWithTax { get; set; } = 0;

        public decimal TotalWithTaxWithDiscount { get; set; } = 0;

        public decimal DiscountPercentage { get; set; }

        public decimal TaxPercentage { get; set; }

        public string? Description { get; set; }

        public string RequiredAuthorization { get; set; } = null!;
        public int CreatedById { get; set; }

        public int UpdatedById { get; set; }

        public bool Status { get; set; }

        public DateTime InvoiceDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual required User User { get; set; }

        public virtual Account? Account { get; set; }

        public virtual Contact? Contact { get; set; }

        public virtual PaymentMethod? PaymentMethod { get; set; }

        public virtual required User CreatedBy { get; set; }

        public virtual required User UpdatedBy { get; set; }

    }
}
