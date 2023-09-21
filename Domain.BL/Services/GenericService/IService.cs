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
        IEnumerable<TEntity> GetAllAsync();
        Task CreateAsync(TEntity entity);
        TEntity UpdateAsync(TEntity entity);
        void DeleteAsync(int id);
    }
}
