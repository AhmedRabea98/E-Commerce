using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class ProductWithTypesAndBrands:BaseSpecification<Product>
    {
        public ProductWithTypesAndBrands()
        {
            AddIncludes(e => e.ProductType);
            AddIncludes(e => e.Productbrand);
        }
        public ProductWithTypesAndBrands(int id) :base(e=>e.Id == id)
        {
            AddIncludes(e => e.ProductType);
            AddIncludes(e => e.Productbrand);
        }
    }
}
