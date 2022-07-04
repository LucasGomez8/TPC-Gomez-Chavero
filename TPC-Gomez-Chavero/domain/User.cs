using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class User
    {
        public long ID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public UserType type { get; set; }
        public string Nick { get; set; }
        public string Pass { get; set; }

        public bool Estado { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}
