using productMicroService.Entities;

namespace productMicroService.Data.Contract.Repository
{
	public interface IProductRepository
	{
		public Task<List<Product>> GetAll();

		public Task<Product> Insert(Product product);

        public Task<Product> GetSingle(int id);

    }
}

