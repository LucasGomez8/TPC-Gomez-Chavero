using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    class Client
    {
        public long Id { get; set; }

        public string Npmbre { get; set; }
        public string CuitOrDni { get; set; }
        public DateTime fechaNac { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
    }
}
