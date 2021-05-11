using OperacionFuegoQuasar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperacionFuegoQuasar.Repositories.Implementations
{
    public class MessageSatelliteRepository : GenericRepository<MessageSatellite>, IMessageSatelliteRepository
    {
        public MessageSatelliteRepository(Context context) : base(context)
        {
        }

        public async Task<int> DeleteAll(IList<MessageSatellite> entities)
        {
            context.Set<MessageSatellite>().RemoveRange(entities);
            return await context.SaveChangesAsync();
        }
    }
}
