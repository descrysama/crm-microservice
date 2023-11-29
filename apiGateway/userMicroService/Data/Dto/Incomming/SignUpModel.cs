using userMicroService.Entities;

namespace userMicroService.Data.Dto.Incomming
{
    public class SignUpModel
    {
        public required string Email { get; set; }

        public required string Username { get; set; }

        public required string Password { get; set; }

        public required string Name { get; set; }

        public required string LastName { get; set; }

        public required string Title { get; set; }

    }
}
