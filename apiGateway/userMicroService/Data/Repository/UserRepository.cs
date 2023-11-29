using userMicroService.Entities;
using userMicroService.Data.Contract.Repository;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using userMicroService.Data.Dto.Incomming;
using userMicroService.Data.Managers;

namespace userMicroService.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;

        private readonly DbSet<User> _table;

        private readonly IUserManager _UserManager;

        public UserRepository(DatabaseContext databaseContext, IUserManager UserManager)
        {
            _databaseContext = databaseContext;
            _table = _databaseContext.Set<User>();
            _UserManager = UserManager;
        }

        public async Task<List<User>> GetAll()
        {
            return await _table.ToListAsync().ConfigureAwait(false);
        }

        public async Task<User> FindById(int Id)
        {
            return await _table.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<User> FindByEmail(string Email)
        {
            return await _table.Where(x => x.Email == Email).FirstOrDefaultAsync();
        }

        public async Task<User> Insert(SignUpModel createUser)
        {
            try
            {
                var elementAdded = await _table.AddAsync(_UserManager.ConvertToEntity(createUser, 10)).ConfigureAwait(false);
                await _databaseContext.SaveChangesAsync().ConfigureAwait(false);

                return elementAdded.Entity;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
