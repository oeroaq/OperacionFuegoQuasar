using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OperacionFuegoQuasar.Model
{
    public class Satellite : Position
    {
        [Key]
        public string name { get; set; }

        [NotMapped]
        public Position position
        {
            get
            {
                return new Position
                {
                    x = x,
                    y = y
                };
            }
            set
            {
                x = value.x;
                y = value.y;
            }
        }

        [NotMapped]
        public double distance { get; set; }
    }

}
