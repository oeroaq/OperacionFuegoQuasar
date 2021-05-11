using OperacionFuegoQuasar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperacionFuegoQuasar.Repositories
{
    public interface IMessageSatelliteRepository : IGenericRepository<MessageSatellite>
    {
        Task<int> DeleteAll(IList<MessageSatellite> entities);
    }
}
