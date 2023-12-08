using AutoMapper;
using Microsoft.EntityFrameworkCore;
using userMicroService.Data.Dto.Incomming;
using userMicroService.Entities;
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

    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserUpdate, UserUpdate>(); // a tester voir si il est utiliser
            CreateMap<UserUpdate, User>().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null && !srcMember.Equals(0)));
            CreateMap<User, UserUpdate>();
            CreateMap<User, UserRead>();
        }
    }
}
