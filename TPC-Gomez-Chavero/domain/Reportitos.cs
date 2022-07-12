using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class Reportitos
    {
        public long ID { get; set; }
        public long NumeroDeFactura { get; set; }
        public DateTime Fecha { get; set; }
        public Client Cliente { get; set; }
        public User Usuario { get; set; }
        public List<Product> Productos { get; set; }
        public decimal MontoFinal { get; set; }
        public TipoFactura type { get; set; }


    }
}
