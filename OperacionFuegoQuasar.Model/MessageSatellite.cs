using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OperacionFuegoQuasar.Model
{
    public class MessageSatellite : Message
    {
        [Key]
        [ForeignKey("Satellite")]
        public string name { get; set; }
        public Satellite Satellite { get; set; }
    }

}
