using OperacionFuegoQuasar.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperacionFuegoQuasar.Services.Implementations
{
    public class GenericService<TEntity, IRepository> : IGenericService<TEntity, IRepository> where TEntity : class
        where IRepository : class
    {
        public readonly IGenericRepository<TEntity> repository;

        public GenericService(IRepository repository)
        {
            this.repository = repository as IGenericRepository<TEntity>;
        }

        public virtual async Task<IList<TEntity>> GetAll()
        {
            return await repository.GetAll();
        }

        public virtual async Task<TEntity> GetById<TKey>(TKey id)
        {
            return await repository.GetById(id);
        }

        public virtual async Task<TEntity> Upsert(TEntity entity)
        {
            return await repository.Upsert(entity);
        }
    }
}
