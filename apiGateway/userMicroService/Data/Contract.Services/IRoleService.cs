using userMicroService.Entities;

namespace userMicroService.Data.Contract.Services
{
    public interface IRoleService
    {
        public Task<Role> FindById(int id);
    }
}
