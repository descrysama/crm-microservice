using userMicroService.Data.Dto.Outcomming;

namespace userMicroService.Data.Contract.Services
{
    public interface IIdentityService
    {

        public string GenerateToken(UserRead user);

        public string HashPassword(string password);

        public bool VerifyPassword(string password, string hashedPassword);
    }
}
