using OperacionFuegoQuasar.Model;
using OperacionFuegoQuasar.Repositories;
using OperacionFuegoQuasar.Repositories.Implementations;
using OperacionFuegoQuasar.Transversal;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperacionFuegoQuasar.Services.Implementations
{
    public class SatelliteService : GenericService<Satellite, ISatelliteRepository>, ISatelliteService
    {
        private readonly IMessageSatelliteRepository messageSatelliteRepository;
        public SatelliteService(ISatelliteRepository repository, IMessageSatelliteRepository messageSatelliteRepository) : base(repository)
        {
            this.messageSatelliteRepository = messageSatelliteRepository;
        }

        public SatelliteService(ISatelliteRepository repository) : base(repository)
        {
        }

        private async Task<Position> GetLocation(IList<MessageSatellite> distances)
        {
            IList<Satellite> satellites = await GetAll();

            Satellite satellite1 = satellites.FirstOrDefault(s => s.name == distances.FirstOrDefault().name);
            Satellite satellite2 = satellites.FirstOrDefault(s => s.name == distances.LastOrDefault().name);
            Satellite satellite3 = satellites.FirstOrDefault(s => s.name == distances[1].name);

            satellite1.distance = distances.FirstOrDefault().distance;
            satellite2.distance = distances.LastOrDefault().distance;
            satellite3.distance = distances[1].distance;

            return satellite1.Trilateracion(satellite2, satellite3);
        }
        private string GetMessage(IList<IList<string>> messages)
        {
            var lenghts = messages.Select(m => m.Count).ToList();
            lenghts.Sort();
            int minLength = lenghts.FirstOrDefault() - 1;
            string[] messagesArray = new string[minLength + 1];
            for (int i = minLength; i >= 0; i--)
            {
                foreach (IList<string> message in messages)
                {
                    int position = i - minLength + message.Count - 1;
                    if (!string.IsNullOrEmpty(message[position]))
                    {
                        messagesArray[i] = message[position];
                        break;
                    }
                }
            }
            return string.Join(' ', messagesArray);
        }

        public async Task<ResponseApi> GetResponse(IList<MessageSatellite> satellites = null)
        {
            bool db = false;
            if (satellites == null)
            {
                satellites = await messageSatelliteRepository.GetAll();
                if (satellites.Count < 3)
                    throw new Exception("No hay suficiente información");
                db = true;
            }
            Position position = await GetLocation(satellites);
            string message = GetMessage(satellites.Select(m => m.message).ToList());
            if(position != null && db)
                await messageSatelliteRepository.DeleteAll(satellites);
            return new ResponseApi
            {
                position = position,
                message = message
            };
        }

        public Task<MessageSatellite> UpsertMessage(MessageSatellite input)
        {
            return messageSatelliteRepository.Upsert(input);
        }
    }
}
