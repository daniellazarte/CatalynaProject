using Catalyna.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyna.Core.Interfaces
{
    public interface IRepository<T> where T : BaseEntity //Definir una restriccion para que solo sea de tipo Base Entity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetByid(T id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);

    }
}
