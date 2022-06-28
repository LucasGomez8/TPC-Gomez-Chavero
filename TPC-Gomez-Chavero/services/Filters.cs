using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain;


namespace services
{
    public class Filters
    {

        public List<Ventas> listarVentas()
        {
            DataAccess da = new DataAccess();
            List<Ventas> lista = new List<Ventas>();

            try
            {
                da.setProcedimientoAlmacenado("sp_VistaVentas");
                da.execute();

                while (da.dataReader.Read())
                {
                    Ventas response = new Ventas();

                    response.ID = (long)da.dataReader["IDRegistro"];
                    response.NumeroFactura = (long)da.dataReader["NumeroFactura"];
                    response.TiposFactura = new TipoFactura();
                    response.TiposFactura.Descripcion = (string)da.dataReader["descripcion"];
                    response.Vendedor = new User();
                    response.Vendedor.Nick = (string)da.dataReader["nick"];
                    response.Cliente = new Client();
                    response.Cliente.Nombre = (string)da.dataReader["nombre"];
                    response.Producto = new Product();
                    response.Producto.Nombre = (string)da.dataReader["NombreProducto"];
                    response.CantidadVendida = (long)da.dataReader["cantidad"];
                    response.PrecioUnitario = (decimal)da.dataReader["precioVenta"];
                    response.MontoTotal = (decimal)da.dataReader["MontoTotal"];
                    response.FechaVenta = (DateTime)da.dataReader["Fecha"];
                    response.Detalle = (string)da.dataReader["detalle"];

                    lista.Add(response);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                da.closeConnection();
            }

        }

    }
}
