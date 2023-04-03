using Infrastrcuture.Data;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Specification;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository repo;
        private IGenericRepository<Product> genreicProductRepo;
        private IGenericRepository<ProductBrand> genreicBrandRepo;
        private IGenericRepository<ProductType> genreicTypeRepo;

        public ProductController(IProductRepository repo , IGenericRepository<Product> genreicProductRepo
            , IGenericRepository<ProductBrand> genreicBrandRepo, IGenericRepository<ProductType> genreicTypeRepo)
        {
            this.repo = repo;
            this.genreicProductRepo = genreicProductRepo;
            this.genreicBrandRepo= genreicBrandRepo;
            this.genreicTypeRepo= genreicTypeRepo;
        }

        [HttpGet]
        public async Task<ActionResult<Product>> getProducts()
        {
            /*  var products = await repo.GetProductsAsync();*/
            var spec = new ProductWithTypesAndBrands();
            var products = await genreicProductRepo.ListAsync(spec);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getProduct(int id)
        {
            var spec = new ProductWithTypesAndBrands(id);

            return Ok(await genreicProductRepo.GetEtitywithSpecification(spec));
        }
        [HttpGet("Brands")]
        public async Task<ActionResult<ProductBrand>> getProductsBrands()
        {
            var products = await genreicBrandRepo.GetAllAsync();
            return Ok(products);
        }
        [HttpGet("Types")]
        public async Task<ActionResult<ProductType>> getProductsTypes()
        {
            var products = await genreicTypeRepo.GetAllAsync();
            return Ok(products);
        }
    }
}
