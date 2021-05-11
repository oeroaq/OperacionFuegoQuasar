using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperacionFuegoQuasar.Services
{
    public interface IGenericService<TEntity, IRepositorio>
    {
        public Task<TEntity> GetById<TKey>(TKey id);
        public Task<IList<TEntity>> GetAll();
        public Task<TEntity> Upsert(TEntity entity);
    }
}
