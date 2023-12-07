using userMicroService.Data.Dto.Incomming;
using userMicroService.Data.Dto.Outcomming;
using userMicroService.Entities;

namespace userMicroService.Data.Contract.Services
{
    public interface IUserService
    {
        public Task<List<User>> GetAll();

        public Task<User> GetById(int userId);

        public Task<User> Create(SignUpModel createUser);

        public Task<UserRead> SignIn(SignInModel loginUser);

        public User UpdateUser(User user);
    }
}
