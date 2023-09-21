using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BL.Services.GenericService
{
    public interface IService<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        IEnumerable<TEntity> GetAll();
        Task<TEntity> CreateAsync(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(int id);
    }
}
