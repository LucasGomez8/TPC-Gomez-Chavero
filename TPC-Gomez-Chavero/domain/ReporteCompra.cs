using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class ReporteCompra
    {
        public long ID { get; set; }
        public long NumeroDeFactura { get; set; }
        public DateTime Fecha { get; set; }
        public Provider Proveedor { get; set; }

        public User Usuario { get; set; }
        public List<Product> Productos { get; set; }
        public decimal MontoFinal { get; set; }
        public TipoFactura type { get; set; }
    }
}
