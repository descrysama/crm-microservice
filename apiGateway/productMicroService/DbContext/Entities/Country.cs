namespace productMicroService.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string CountryCode { get; set; } = null!;
    }
}
