using Microsoft.EntityFrameworkCore;
using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;

namespace userMicroService.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        [JsonIgnore]
        public string Password { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Title { get; set; } = "utilisateur";

        public int RoleId { get; set; }

        public int? AddressId { get; set; }

        public bool IsBanned { get; set; } = false;

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        [JsonIgnore]
        public virtual Address? Address { get; set; }

        [JsonIgnore]
        public virtual Role? Role { get; set; }
    }
}