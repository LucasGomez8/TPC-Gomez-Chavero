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

        public List<Product> getStoresProducts()
        {
            DataAccess da = new DataAccess();
            List<Product> list = new List<Product>();


            try
            {
                da.setProcedimientoAlmacenado("sp_VistaProductos");
                da.execute();

                while (da.dataReader.Read())
                {
                    Product response = new Product();

                    response.Id = (long)da.dataReader["IDProducto"];
                    response.Nombre = (string)da.dataReader["Nombre"];
                    response.Descripcion = (string)da.dataReader["Descripcion"];
                    response.Categoria = new ProductCategory();
                    response.Categoria.Descripcion = (string)da.dataReader["Categoria"];
                    response.Tipo = new ProductType();
                    response.Tipo.Descripcion = (string)da.dataReader["TipoProducto"];
                    response.Marca = new ProductBranch();
                    response.Marca.Descripcion = (string)da.dataReader["Marca"];
                    response.Stock = (int)da.dataReader["Stock"];
                    response.StockMinimo = (int)da.dataReader["StockMinimo"];
                    response.PorcentajeVenta = (short)da.dataReader["PorcentajeVenta"];
                    response.Estado = (bool)da.dataReader["Activo"];

                    list.Add(response);
                }

                return list;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                da.closeConnection();
            }
        }

        public List<Provider> listarProveedores()
        {
            DataAccess da = new DataAccess();
            List<Provider> list = new List<Provider>();

            try
            {
                da.setProcedimientoAlmacenado("sp_Proveedores");
                da.execute();

                while (da.dataReader.Read())
                {
                    Provider response = new Provider();

                    response.Id = (long)da.dataReader["IDProveedor"];
                    response.Nombre = (string)da.dataReader["Nombre"];
                    response.Estado = (bool)da.dataReader["Estado"];


                    list.Add(response);
                }

                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        public List<User> listarUsuarios()
        {
            DataAccess da = new DataAccess();
            List<User> list = new List<User>();

            try
            {
                da.setProcedimientoAlmacenado("sp_Usuarios");
                da.execute();

                while (da.dataReader.Read())
                {
                    User response = new User();

                    response.ID = (long)da.dataReader["idUsuario"];
                    response.Nombre = (string)da.dataReader["Nombre"];
                    response.Apellido = (string)da.dataReader["Apellido"];
                    response.DNI = (string)da.dataReader["DNI"];
                    response.type = new UserType();
                    response.type.Description = (string)da.dataReader["descripcion"];
                    response.Nick = (string)da.dataReader["Nick"];
                    response.Estado = (bool)da.dataReader["Estado"];

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

        public decimal getUltimoCosto(long id)
        {
            DataAccess da = new DataAccess();
            decimal resul = 0;

            try
            {
                da.setProcedimientoAlmacenado("sp_UltimoCosto");
                da.setConsultaWhitParameters("@id", id);


                da.execute();

                if (da.dataReader.Read())
                {
                    resul = (decimal)da.dataReader["precioCompra"];
                }
                return resul;
            }
            catch
            {

                return -2;
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
                    response.Estado = (bool)da.dataReader["Activo"];

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
