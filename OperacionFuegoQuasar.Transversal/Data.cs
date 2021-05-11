using OperacionFuegoQuasar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperacionFuegoQuasar.Transversal
{
    public static class Data
    {
        public static IList<Satellite> satellites = new List<Satellite>()
        {

            new Satellite()
            {
                name = "kenobi",
                position = new Position()
                {
                    x = -500,
                    y = -200
                }
            },new Satellite()
            {
                name = "sato",
                position = new Position()
                {
                    x = 500,
                    y = 100
                }
            },new Satellite()
            {
                name = "skywalker",
                position = new Position()
                {
                    x = 100,
                    y = -100
                }
            }
        };
        public static InputList input = new InputList()
        {
            satellites = new List<MessageSatellite>()
                {
                    new MessageSatellite()
                    {
                        name="kenobi",
                        distance=100,
                        message = new string[]
                        {
                            "", "", "es", "", "mensaje"
                        }
                    },
                    new MessageSatellite()
                    {
                        name="skywalker",
                        distance=115.5,
                        message = new string[]
                        {
                            "", "este", "es", "un", "mensaje"
                        }
                    },
                    new MessageSatellite()
                    {
                        name="sato",
                        distance=142.7,
                        message = new string[]
                        {
                            "este", "", "un", "mensaje"
                        }
                    }
                }
        };
    }
}
