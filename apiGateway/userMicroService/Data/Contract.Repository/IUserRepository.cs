using userMicroService.Data.Dto.Incomming;
using userMicroService.Entities;

namespace userMicroService.Data.Contract.Repository
{
    public interface IUserRepository
    {
        public Task<List<User>> GetAll();

        public Task<User> FindByEmail(string email);

        public Task<User> FindById(int Id);

        public Task<User> Insert(SignUpModel createUser);
    }
}
