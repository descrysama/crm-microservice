using AutoMapper;
using userMicroService.Data.Dto.Outcomming;
using userMicroService.Entities;

namespace userMicroService.Data.Dto.Incomming
{
    public class UserUpdate
    {
        public string? Username { get; set; }

        public string? Email { get; set; }

        public string? Name { get; set; }

        public string? LastName { get; set; }

        public string? Title { get; set; }

        public int? RoleId { get; set; }

        public bool? IsBanned { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }


    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserUpdate, User>();
            CreateMap<User, UserUpdate>();
            CreateMap<User, UserRead>();
        }
    }
}
