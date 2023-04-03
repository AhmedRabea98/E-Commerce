using Core.Models;
using Core.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class SpecificEvaluator<T> where T : BaseEntity
    {

        public static IQueryable<T> GetQuery(IQueryable<T> InputQuery , ISpecification<T> specification) {

            var query = InputQuery;
            if (specification.Criteria != null) { 
            query= query.Where(specification.Criteria);
            
            }

            query = specification.Includes.Aggregate(query,(current,include)=>
            current.Include(include));
            return query;
        }
    }
}
