using Microsoft.EntityFrameworkCore;
using StandBy.Business.Interfaces;
using StandBy.Business.Models;
using StandBy.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StandBy.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Cliente , new()
    {
        protected readonly AppDbContext Db;
        protected readonly DbSet<TEntity> dbset;

        protected Repository(AppDbContext dbContext)
        {
            Db = dbContext;
            dbset = dbContext.Set<TEntity>();
        }
        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> expression)
        {
            return await dbset.AsNoTracking().Where(expression).ToListAsync();
        }
        
        public async Task<List<TEntity>> GetAll()
        {
            return await dbset.ToListAsync();
        }

        public async Task<TEntity> GetEntidadeID(int id)
        {
            return await dbset.FindAsync(id);
        }


        public async Task Adicionar(TEntity entidade)
        {
            dbset.Add(entidade);
            await SaveChanges();
        }

        public async Task Atualizar(TEntity entidade)
        {
            dbset.Update(entidade);
            await SaveChanges();
        }

        public async Task Remove(int id)
        {
            var entidade = new TEntity { CLIENTE_ID = id };
            dbset.Remove(entidade);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }

    }
}
