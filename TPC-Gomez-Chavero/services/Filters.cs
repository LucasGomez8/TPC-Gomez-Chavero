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

        public List<Client> listarCliente()
        {
            DataAccess da = new DataAccess();
            List<Client> list = new List<Client>();

            try
            {
                da.setProcedimientoAlmacenado("sp_Clientes");
                da.execute();

                while (da.dataReader.Read())
                {
                    Client response = new Client();

                    response.Id = (long)da.dataReader["idCliente"];
                    response.Nombre = (string)da.dataReader["Nombre"];
                    response.CuitOrDni = (string)da.dataReader["cuitOrDni"];
                    response.fechaNac = (DateTime)da.dataReader["fechaNac"];
                    response.Email = (string)da.dataReader["email"];
                    response.Telefono = (string)da.dataReader["Telefono"];

                    list.Add(response);
                }

                return list;
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

        public List<Compras> listarCompras()
        {
            DataAccess da = new DataAccess();
            List<Compras> list = new List<Compras>();

            try
            {
                da.setProcedimientoAlmacenado("sp_VistaCompras");
                da.execute();

                while (da.dataReader.Read())
                {
                    Compras response = new Compras();

                    response.ID = (long)da.dataReader["IDRegistro"];
                    response.NumeroFactura = (long)da.dataReader["NumeroFactura"];
                    response.TiposFactura = new TipoFactura();
                    response.TiposFactura.Descripcion = (string)da.dataReader["descripcion"];
                    response.Usuario = new User();
                    response.Usuario.Nick = (string)da.dataReader["nick"];
                    response.Proveedor = new Provider();
                    response.Proveedor.Nombre = (string)da.dataReader["nombre"];
                    response.Producto = new Product();
                    response.Producto.Nombre = (string)da.dataReader["NombreProducto"];
                    response.CantidadComprada = (long)da.dataReader["cantidad"];
                    response.PrecioUnitario = (decimal)da.dataReader["precioCompra"];
                    response.MontoTotal = (decimal)da.dataReader["MontoTotal"];
                    response.FechaVenta = (DateTime)da.dataReader["Fecha"];
                    response.Detalle = (string)da.dataReader["detalle"];


                    list.Add(response);
                }

                return list;
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
