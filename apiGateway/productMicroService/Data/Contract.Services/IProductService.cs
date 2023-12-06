using productMicroService.Data.Dto.Incomming;
using productMicroService.Entities;


namespace productMicroService.Data.Contract.Services
{
	public interface IProductService
	{
        public Task<List<Product>> GetAll();

        public Task<Product> GetById(int id);

        public Task<Product> CreateSingle(ProductCreateModel createSingle);
    }
}

