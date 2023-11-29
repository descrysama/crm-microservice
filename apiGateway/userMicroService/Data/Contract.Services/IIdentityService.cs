using userMicroService.Entities;

namespace userMicroService.Data.Contract.Services
{
    public interface IIdentityService
    {

        public string GenerateToken(User user);

        public string HashPassword(string password);

        public bool VerifyPassword(string password, string hashedPassword);
    }
}
