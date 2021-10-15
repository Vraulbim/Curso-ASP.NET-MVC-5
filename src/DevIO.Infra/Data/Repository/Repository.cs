using DevIO.Bussines.Core.Data;
using DevIO.Bussines.Core.Models;
using DevIO.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DevIO.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly DataContext context;
        protected readonly DbSet<TEntity> dbSet;

        public Repository(DataContext context)
        {
            context = context;
            dbSet = context.Set<TEntity>();
        }

        public virtual async Task Adicionar(TEntity entity)
        {
            dbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task Remover(Guid id)
        {
            context.Entry(new TEntity { Id = id }).State = EntityState.Deleted;
            dbSet.Remove(new TEntity { Id = id });

            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context?.Dispose();
        }
    }
}
