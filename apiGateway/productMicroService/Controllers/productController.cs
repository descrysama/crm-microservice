using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using productMicroService.Data.Dto.Incomming;
using productMicroService.Entities;
using productMicroService.Data.Contract.Services;

namespace userMicroService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [Authorize]
        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                int adminId = Int32.Parse(User.FindFirst(ClaimTypes.Sid).Value);
                List<Product> products = await _productService.GetAll();
                return Ok(products);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("/get/{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                Product product = await _productService.GetById(id);
                if(product != null)
                {
                    return Ok(product);
                } else
                {
                    return BadRequest("Ce produit n'existe pas.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("/create")]
        public async Task<IActionResult> CreateSingle(ProductCreateModel createProduct)
        {
            try
            {
                Product product = await _productService.CreateSingle(createProduct);
                return Ok(product);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    };
}