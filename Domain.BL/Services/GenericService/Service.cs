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

        public IEnumerable<TEntity> GetAll()
         => _repository.GetAll();

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
           var added = await _repository.Add(entity);
            _repository.SaveChange();
            return added;
        }

        public TEntity Update(TEntity entity)
        {
           var updatedEntity = _repository.update(entity);
            _repository.SaveChange();
            return updatedEntity;
        }

        public void Delete(int id)
        {
             _repository.Delete(id);
            _repository.SaveChange();
        }
    }
}
