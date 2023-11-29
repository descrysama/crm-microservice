using System.Runtime.CompilerServices;
using userMicroService.Data.Dto.Incomming;
using userMicroService.Data.Dto.Outcomming;
using userMicroService.Entities;

namespace userMicroService.Data.Managers
{

    public interface IUserManager
    {
        public SignUpModel CryptPassword(SignUpModel signUpModel);

        public User ConvertToEntity(SignUpModel signUpModel, int RoleId);

        public UserRead ConvertToRead(User user, string bearerToken);

        public bool VerifyPassword(string password, string hashedPassword);
    }

    public class UserManager : IUserManager
    {
        public UserManager() { }

        public SignUpModel CryptPassword(SignUpModel createUser)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(createUser.Password, salt);
            createUser.Password = hashedPassword;
            return createUser;
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        public User ConvertToEntity(SignUpModel signUpModel, int RoleId)
        {
            User user = new()
            {
                Email = signUpModel.Email,
                Username = signUpModel.Username,
                Password = signUpModel.Password,
                Name = signUpModel.Name,
                LastName = signUpModel.LastName,
                Title = signUpModel.Title,
                RoleId = RoleId,
                IsBanned = false,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            return user;
        }

        public UserRead ConvertToRead(User userEntity, string bearerToken)
        {
            UserRead user = new()
            {
                Id = userEntity.Id,
                Username = userEntity.Username,
                Email = userEntity.Email,
                Name = userEntity.Name,
                LastName = userEntity.LastName,
                Title = userEntity.Title,
                RoleId = userEntity.RoleId,
                AddressId = userEntity.AddressId,
                Bearer = bearerToken,
                IsBanned = userEntity.IsBanned,
                CreatedAt = userEntity.CreatedAt,
                UpdatedAt = userEntity.UpdatedAt,
            };

            return user;
        }
    }
}
