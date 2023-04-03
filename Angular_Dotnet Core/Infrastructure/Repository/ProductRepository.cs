using Core.Interfaces;
using Core.Models;
using Infrastrcuture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ProductRepository : IProductRepository 
    {
        private readonly DBContext context;
        public ProductRepository(DBContext context)
        {
            this.context = context;
        }

        public async Task<Product> GetProduct(int id)
        {
            return await context.Products.Include(e => e.Productbrand).Include(e => e.ProductType).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await context.Products.Include(e=>e.Productbrand).Include(e=>e.ProductType).ToListAsync();

        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductsBrandsAsync()
        {
            return await context.ProductBrands.ToListAsync();

        }

        public async Task<IReadOnlyList<ProductType>> GetProductstypesAsync()
        {
            return await context.ProductTypes.ToListAsync();

        }
    }
}
