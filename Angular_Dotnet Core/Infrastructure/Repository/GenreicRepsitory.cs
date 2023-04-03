using Core.Interfaces;
using Core.Models;
using Core.Specification;
using Infrastrcuture.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class GenreicRepsitory<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly DBContext context;
        public GenreicRepsitory(DBContext context)
        {
            this.context = context;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsyncById(int id)
        {
            return await context.Set<T>().FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<T> GetEtitywithSpecification(ISpecification<T> specification)
        {
           return await ApplySpecification(specification).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).ToListAsync();

        }

        private IQueryable<T> ApplySpecification(ISpecification<T> specification)
        {
            return SpecificEvaluator<T>.GetQuery(context.Set<T>().AsQueryable(), specification);
        }
    }
}
