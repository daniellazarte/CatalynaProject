using Catalyna.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalyna.Core.Interfaces
{
    public interface IUnitOfWork: IDisposable //Para que se pueda lberar
    {
        //Matricular todos los repositorios de la aplicacion
        IRepository<Article> PostRepository { get;}
        IRepository<Category> CategoryRepository { get; }
        //IRepository<User> UserRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
