using Domain.DL.Repositories.GenericRepository;
using Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BL.Services.GenericService
{
    public class Service<TEntity> : IService<TEntity> where TEntity :  BaseEntity, new()
    {
        private readonly IGenericRepository<TEntity> _repository;

        public Service(IGenericRepository<TEntity> repository)
        => _repository = repository;


        public async Task<TEntity?> GetByIdAsync(int id)
        => await _repository.GetByID(id);

        public IEnumerable<TEntity> GetAllAsync()
         => _repository.GetAll();

        public async Task CreateAsync(TEntity entity)
        {
            await _repository.Add(entity);
        }

        public TEntity UpdateAsync(TEntity entity)
        => _repository.update(entity);
        

        public void DeleteAsync(int id)
        {
             _repository.Delete(id);
        }
    }
}
