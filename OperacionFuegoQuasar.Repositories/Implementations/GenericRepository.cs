using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;

namespace OperacionFuegoQuasar.Repositories.Implementations
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public readonly DbContext context;

        public GenericRepository(Context context)
        {
            this.context = context;
        }

        public virtual async Task<TEntity> GetById<TKey>(TKey id)
        {
            return await context.Set<TEntity>()
                          .FindAsync(id);
        }

        public virtual async Task<IList<TEntity>> GetAll()
        {
            return await context.Set<TEntity>()
                                .ToListAsync();
        }

        public virtual async Task<TEntity> Upsert(TEntity entity)
        {
            context.Set<TEntity>()
                          .AddOrUpdate(entity);
            await context.SaveChangesAsync();
            return entity;

        }
    }
}
