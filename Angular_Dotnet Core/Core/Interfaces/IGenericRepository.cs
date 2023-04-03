using Core.Models;
using Core.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T :BaseEntity
    {
        public Task<T> GetAsyncById(int id);
        public Task<IReadOnlyList<T>> GetAllAsync();
        public Task<T> GetEtitywithSpecification(ISpecification<T> specification);
        public Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification);

    }
}
