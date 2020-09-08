using Catalogue.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue.Core.Interfaces
{
    public interface IRepository<T> where  T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(long id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(long id);

    }
}
