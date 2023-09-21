using Domain.DL.ApplicationDbContext;
using Domain.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace Domain.DL.Repositories.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new ()
    {

        private readonly AppDbContext _appDbContext;
        private DbSet<T> _dbSet;
        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = appDbContext.Set<T>();
        }

        public async Task<T> Add(T item)
        {
            var entity =await _dbSet.AddAsync(item);
            return entity.Entity;
        }

        public void Delete(int id)
        {
            T entity = new ();
            entity.Id = id;
            _dbSet.Remove(entity);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            var resultQueryable=_dbSet.Where(predicate);

            if (includes != null&&includes.Length>0)
                foreach (var expression in includes)
                    resultQueryable.Include(expression);

            return resultQueryable;
        }

        public IQueryable<T> GetAll()
        => _dbSet.AsNoTracking<T>();

        public async Task<T?> GetByID(int id)
        => await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

        public T update(T item)
        {
            var entity = _dbSet.Update(item);
            return entity.Entity;
        }

        public async Task<int> SaveChangeAsync()
            => await _appDbContext.SaveChangesAsync();

        public int SaveChange()
            => _appDbContext.SaveChanges();

    }

}
