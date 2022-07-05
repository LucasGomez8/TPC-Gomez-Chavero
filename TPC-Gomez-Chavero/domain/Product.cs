using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    public class Product
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public ProductBranch Marca { get; set; }
        public ProductCategory Categoria { get; set; }
        public ProductType Tipo { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public short PorcentajeVenta { get; set; }
        public bool Estado { get; set; }

        //SOLO PARA VENTAS/Compras

        public decimal Costo { get; set; }
        public int Cantidad { get; set; }
        public decimal PU { get; set; }

    }
}
