using Microsoft.EntityFrameworkCore;
using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;

namespace userMicroService.Data.Dto.Outcomming
{
    public class UserRead
    {
        public int Id { get; set; }

        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        [JsonIgnore]
        public string Password { get; set; } = null!;

        [JsonIgnore]
        public string? Bearer { get; set; }

        public string Name { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Title { get; set; } = "utilisateur";

        public int RoleId { get; set; }

        public int? AddressId { get; set; }

        public bool IsBanned { get; set; } = false;

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
