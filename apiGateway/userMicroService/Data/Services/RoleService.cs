using userMicroService.Data.Contract.Repository;
using userMicroService.Data.Contract.Services;
using userMicroService.Entities;


namespace userMicroService.Data.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Role> FindById(int id)
        {
            return await _roleRepository.FindById(id);
        }
    }
}
