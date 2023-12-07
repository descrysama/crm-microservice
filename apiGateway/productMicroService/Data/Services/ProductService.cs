using AutoMapper;
using productMicroService.Data.Contract.Services;
using productMicroService.Data.Contract.Repository;
using productMicroService.Data.Dto.Incomming;
using productMicroService.Entities;

namespace productMicroService.Data.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Product> CreateSingle(ProductCreateModel createSingle)
        {
            try
            {
                Product changedEntity = _mapper.Map<Product>(createSingle);
                return await _productRepository.Insert(changedEntity);
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            } 
        }

        public async Task<List<Product>> GetAll()
        {
            try
            {
                return await _productRepository.GetAll();
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Product> GetById(int id)
        {
            try
            {
                return await _productRepository.GetSingle(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
