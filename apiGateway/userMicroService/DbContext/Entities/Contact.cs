namespace userMicroService.Entities
{
    public class Contact
    {
        public int Id { get; set; }

        public int? AccountId { get; set; }

        public string Email { get; set; } = null!;

        public string MobilePhone { get; set; } = null!;

        public bool IsDeactivated { get; set; } = false;

        public int OwnerId { get; set; }

        public string? Description { get; set; }

        public string RequiredAuthorization { get; set; } = null!;

        public bool IsBanned { get; set; } = false;

        public int CreatedById { get; set; }

        public int UpdatedById { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual Account? Account { get; set; }

        public virtual required User Owner { get; set; }

        public virtual required User CreatedBy { get; set; }

        public virtual required User UpdatedBy { get; set; }
    }
}
