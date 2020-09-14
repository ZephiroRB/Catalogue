using Catalogue.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue.Core.Interfaces
{
    public interface IRepository<T> where  T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<T> GetById(long id);
        Task Add(T entity);
        void Update(T entity);
        Task Delete(long id);

    }
}
