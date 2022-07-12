using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class Compras
    {
        public long ID { get; set; }
        public long NumeroFactura { get; set; }
        public int MyProperty { get; set; }
        public TipoFactura TiposFactura { get; set; }
        public User Usuario { get; set; }
        public Provider Proveedor { get; set; }
        public Product Producto { get; set; }
        public long CantidadComprada { get; set; }
        public decimal PrecioUnitario { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal MontoTotal { get; set; }
        public string Detalle { get; set; }

        public string NumeroFacturaConPrefix { get; set; }
    }
}
