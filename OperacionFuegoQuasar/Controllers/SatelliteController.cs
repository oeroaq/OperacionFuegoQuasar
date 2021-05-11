using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OperacionFuegoQuasar.Model;
using OperacionFuegoQuasar.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OperacionFuegoQuasar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SatelliteController : ControllerBase
    {

        private readonly ISatelliteService service;

        public SatelliteController(ISatelliteService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IList<Satellite>> Get()
        {
            return await service.GetAll();
        }
        [HttpPost]
        public async Task<Satellite> Post(Satellite satellite)
        {
            return await service.Upsert(satellite);
        }
    }
}

