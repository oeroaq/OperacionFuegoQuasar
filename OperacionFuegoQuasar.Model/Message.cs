using System.Collections.Generic;

namespace OperacionFuegoQuasar.Model
{
    public class Message
    {
        public double distance { get; set; }
        public IList<string> message { get; set; }

        public string messageStr
        {
            get
            {
                return message!=null?string.Join(',', message):null;
            }

            set
            {
                if (value != null)
                    message = value.Split(',');
            }

        }
    }

}
