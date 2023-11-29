namespace userMicroService.Entities
{
    public class PaymentMethod
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public decimal Percentage { get; set; }
    }
}
