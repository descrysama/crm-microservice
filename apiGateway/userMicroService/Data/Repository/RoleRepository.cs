using userMicroService.Entities;
using userMicroService.Data.Contract.Repository;
using Microsoft.EntityFrameworkCore;


namespace userMicroService.Data.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DatabaseContext _databaseContext;

        private readonly DbSet<Role> _table;

        public RoleRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            _table = _databaseContext.Set<Role>();
        }

        public async Task<Role> FindById(int id)
        {
            return await _table.FindAsync(id);
        }
    }
}
