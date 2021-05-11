using OperacionFuegoQuasar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperacionFuegoQuasar.Repositories.Implementations
{
    public class SatelliteRepository : GenericRepository<Satellite>, ISatelliteRepository
    {
        public SatelliteRepository(Context context) : base(context)
        {
        }
    }
}
