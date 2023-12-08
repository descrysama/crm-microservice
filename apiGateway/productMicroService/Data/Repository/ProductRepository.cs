using productMicroService.Entities;
using productMicroService.Data.Contract.Repository;
using Microsoft.EntityFrameworkCore;

namespace productMicroService.Data.Repository
{
	public class ProductRepository: IProductRepository
	{
        private readonly DatabaseContext _databaseContext;

        private readonly DbSet<Product> _table;

        public ProductRepository(DatabaseContext databaseContext)
		{
            _databaseContext = databaseContext;
            _table = _databaseContext.Set<Product>();
        }

        public async Task<List<Product>> GetAll()
        {
            try
            {
                return await _table.AsNoTracking().ToListAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Product> GetSingle(int Id)
        {
            try
            {
                return await _table.AsNoTracking().Where(x => x.Id == Id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Product> Insert(Product product)
        {
            try
            {
                var elementAdded = await _table.AddAsync(product).ConfigureAwait(false);
                await _databaseContext.SaveChangesAsync().ConfigureAwait(false);

                return elementAdded.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

