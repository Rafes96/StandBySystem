using Microsoft.EntityFrameworkCore;
using StandBy.Business.Interfaces;

using StandBy.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using System.Threading.Tasks;

namespace StandBy.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly AppDbContext _db;
        private readonly DbSet<TEntity> _dbset;

        protected Repository(AppDbContext dbContext)
        {
            _db = dbContext;
            _dbset = dbContext.Set<TEntity>();
        }

        public async Task Remove(TEntity entity)
        {
            _dbset.Remove(entity);
            await SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> expression)
        {
            return await _dbset.AsNoTracking().Where(expression).ToListAsync();
        }
        
        public async Task<List<TEntity>> GetAll()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<TEntity> GetEntidadeID(int id)
        {
            return await _dbset.FindAsync(id);
        }


        public async Task Adicionar(TEntity entidade)
        {
            _dbset.Add(entidade);
            await SaveChanges();
        }

        public async Task Atualizar(TEntity entidade)
        {
            _dbset.Update(entidade);
            await SaveChanges();
        }

      

        public async Task<int> SaveChanges()
        {
            return await _db.SaveChangesAsync();
        }

        public void Dispose()
        {
            _db?.Dispose();
        }

    }
}
