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
    [Route("")]
    public class TopSecretController : ControllerBase
    {
        private readonly ISatelliteService service;

        public TopSecretController(ISatelliteService service)
        {
            this.service = service;
        }
        [HttpPost]
        [Route("topsecret")]
        public async Task<ResponseApi> Post(InputList input)
        {
            try
            {
                return await service.GetResponse(input.satellites);
            }
            catch
            {
                if (Response != null) Response.StatusCode = 404;
                return null;
            }

        }
        [HttpPost]
        [Route("topsecret_split/{satellite_name}")]
        public async Task<Message> Post(string satellite_name, Input input)
        {
            return await service.UpsertMessage(new MessageSatellite
            {
                name = satellite_name,
                distance = input.distance,
                message = input.message
            });

        }
        [HttpGet]
        [Route("topsecret_split")]
        public async Task<Object> Get()
        {
            try
            {
                return await service.GetResponse();
            }
            catch (Exception ex)
            {
                Response.StatusCode = 404;
                return ex.Message;
            }

        }
    }
}
