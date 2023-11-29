using userMicroService.Entities;

namespace userMicroService.Data.Contract.Repository
{
    public interface IRoleRepository
    {
        public Task<Role> FindById(int id);
    }
}
