using OperacionFuegoQuasar.Model;
using OperacionFuegoQuasar.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperacionFuegoQuasar.Services
{
    public interface ISatelliteService : IGenericService<Satellite, ISatelliteRepository>
    {
        public Task<ResponseApi> GetResponse(IList<MessageSatellite> messages = null);
        Task<MessageSatellite> UpsertMessage(MessageSatellite input);
    }
}
