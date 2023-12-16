using StandBy.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StandBy.Business.Interfaces
{
    public interface IRepository<TEntity> : IDisposable
    {
        Task Adicionar(TEntity entidade);
        Task<TEntity> GetEntidadeID(int id);
        Task<List<TEntity>> GetAll();
        Task Atualizar(TEntity entidade);
        Task Remove(TEntity entity);

        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> expression);
        Task<int> SaveChanges();
    }
}
