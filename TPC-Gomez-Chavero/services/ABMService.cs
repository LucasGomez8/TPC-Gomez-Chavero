using domain;
using System;
using System.Collections.Generic;

namespace services
{
    public class ABMService
    {

        //Adders
        public int createTypes(string descripcion, string tabla)
        {
            DataAccess da = new DataAccess();
            try
            {
                da.setConsulta("insert into " + tabla + " (descripcion, Estado) values(@descripcion, 1)");
                da.setConsultaWhitParameters("@descripcion", descripcion);

                da.executeAction();
                return da.getLineCantAfected();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar con la base de datos." + ex.Message);
                return -2;
            }
            finally
            {
                da.closeConnection();
            }
        }

        public int addClient(string nombre, string cod, string date, string telefono, string email)
        {
            DataAccess da = new DataAccess();

            try
            {
                da.setConsulta("insert into Clientes(Nombre, CuitOrDni, FechaNac, Telefono, Email, Estado) values(@nombre, @cod, @date, @telefono, @email, 1)");
                da.setConsultaWhitParameters("@nombre", nombre);
                da.setConsultaWhitParameters("@cod", cod);
                da.setConsultaWhitParameters("@date", date);
                da.setConsultaWhitParameters("@telefono", telefono);
                da.setConsultaWhitParameters("@email", email);

                da.executeAction();
                return da.getLineCantAfected();

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

        public int addProduct(string nombre, string descripcion, long idcategoria, long idmarca, long idtipoproducto, int stockminimo, short porcentaje)
        {
            DataAccess da = new DataAccess();

            try
            {
                da.setConsulta("insert into Productos(Nombre, Descripcion, IDCATEGORIA, IDMARCA, IDTIPOPRODUCTO, STOCK, STOCKMINIMO, PORCENTAJEVENTA, Estado) values(@nombre, @descripcion, @idcategoria, @idmarca, @idtipoproducto, 0, @stockminimo, @porcentaje, 1)");
                da.setConsultaWhitParameters("@nombre", nombre);
                da.setConsultaWhitParameters("@descripcion", descripcion);
                da.setConsultaWhitParameters("@idcategoria", idcategoria);
                da.setConsultaWhitParameters("@idmarca", idmarca);
                da.setConsultaWhitParameters("@idtipoproducto", idtipoproducto);
                da.setConsultaWhitParameters("@stockminimo", stockminimo);
                da.setConsultaWhitParameters("@porcentaje", porcentaje);

                da.executeAction();
                return da.getLineCantAfected();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar con la base de datos." + ex.Message);
                throw;
            }
            finally
            {
                da.closeConnection();
            }
        }

        public int addProvider(string nombre)
        {
            DataAccess da = new DataAccess();

            try
            {
                da.setConsulta("insert into Proveedores(Nombre, Estado) values(@nombre, 1)");
                da.setConsultaWhitParameters("@nombre", nombre);
                da.executeAction();

                return da.getLineCantAfected();
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

        public long añadirCompra(long numeroFactura, long idtipo, long idprov, long idadm, string fecha, decimal money, string detalle)
        {
            DataAccess da = new DataAccess();
            long id = 0;
            try
            {
                da.setConsulta("Insert into Compras(NumeroFactura, TipoFactura, IDProveedor, IDAdministrador, Fecha, MontoTotal, detalle) OUTPUT Inserted.IDRegistro values(@numeroFactura, @idtipo, @idprov, @idadm,  @fecha, @money, @detalle)");
                da.setConsultaWhitParameters("@numeroFactura", numeroFactura);
                da.setConsultaWhitParameters("@idtipo", idtipo);
                da.setConsultaWhitParameters("@idprov", idprov);
                da.setConsultaWhitParameters("@idadm", idadm);
                da.setConsultaWhitParameters("@fecha", fecha);
                da.setConsultaWhitParameters("@money", money);
                da.setConsultaWhitParameters("@detalle", detalle);

                id = da.scalar();

                return id;
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
        
        public long añadirVenta(long numeroFactura, long idtipo, long idcliente, long iduser, string fecha, decimal money, string detalle)
        {
            DataAccess da = new DataAccess();
            long id = 0;
            try
            {
                da.setConsulta("Insert into Ventas(NumeroFactura, TipoFactura, idVendedor, idCliente, Fecha, MontoTotal, detalle) OUTPUT Inserted.IDRegistro values(@numeroFactura, @idtipo, @iduser, @idcliente,  @fecha, @money, @detalle)");
                da.setConsultaWhitParameters("@numeroFactura", numeroFactura);
                da.setConsultaWhitParameters("@idtipo", idtipo);
                da.setConsultaWhitParameters("@iduser", iduser);
                da.setConsultaWhitParameters("@idcliente", idcliente);
                da.setConsultaWhitParameters("@fecha", fecha);
                da.setConsultaWhitParameters("@money", money);
                da.setConsultaWhitParameters("@detalle", detalle);

                id = da.scalar();

                return id;
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

        public int crossProductoCompra(long idregistro, long idproducto, long cantidad, decimal preciounitario)
        {
            DataAccess da = new DataAccess();

            try
            {
                da.setConsulta("insert into ProductoXCompra(IDRegistro, IDProducto, Cantidad, precioCompra) values(@idregistro, @idproducto, @cantidad, @preciounitario)");
                da.setConsultaWhitParameters("@idregistro", idregistro);
                da.setConsultaWhitParameters("@idproducto",idproducto);
                da.setConsultaWhitParameters("@cantidad", cantidad);
                da.setConsultaWhitParameters("@preciounitario", preciounitario);

                da.executeAction();
                return da.getLineCantAfected();
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

        public int crossProductoVenta(long idregistro, long idproducto, long cantidad, decimal preciounitario)
        {
            DataAccess da = new DataAccess();

            try
            {
                da.setConsulta("insert into ProductoXVENTA(IDRegistro, IDProducto, Cantidad, precioVenta) values(@idregistro, @idproducto, @cantidad, @preciounitario)");
                da.setConsultaWhitParameters("@idregistro", idregistro);
                da.setConsultaWhitParameters("@idproducto", idproducto);
                da.setConsultaWhitParameters("@cantidad", cantidad);
                da.setConsultaWhitParameters("@preciounitario", preciounitario);

                da.executeAction();
                return da.getLineCantAfected();
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

        //Getters

        /*public long getLasID()
         {
             DataAccess da = new DataAccess();

             try
             {
                 return da.scalar("Select SCOPE_IDENTITY()");

             }
             catch (Exception ex)
             {

                 throw ex;
             }
             finally
             {
                 da.closeConnection();
             }

         }*/

        public long getNumberTicketBuy(long type, string table)
        {
            DataAccess da = new DataAccess();

            try
            {
                da.setConsulta("select top 1 NumeroFactura from " + table + " order by NumeroFactura desc");
                da.setConsultaWhitParameters("@type", type);
                da.execute();

                if (da.dataReader.Read())
                {
                    return (long)da.dataReader["NumeroFactura"];
                }

                return 0;
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

        public List<ProductBranch> getBranch(int status)
        {
            List<ProductBranch> branchList = new List<ProductBranch>();
            DataAccess da = new DataAccess();

            try
            {
                da.setConsulta("select Idmarca, Descripcion from Marcas Where Estado = @status");
                da.setConsultaWhitParameters("@status", status);
                da.execute();

                while (da.dataReader.Read())
                {
                    ProductBranch branch = new ProductBranch();
                    branch.Id = (long)da.dataReader["Idmarca"];
                    branch.Descripcion = (string)da.dataReader["Descripcion"];

                    branchList.Add(branch);
                }

                return branchList;
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


        public List<ProductCategory> getCategory(int status)
        {
            List<ProductCategory> categoryList = new List<ProductCategory>();
            DataAccess da = new DataAccess();

            try
            {
                da.setConsulta("select Idcategoria, Descripcion from Categorias Where Estado = @status");
                da.setConsultaWhitParameters("@status", status);
                da.execute();

                while (da.dataReader.Read())
                {
                    ProductCategory category = new ProductCategory();
                    category.Id = (long)da.dataReader["Idcategoria"];
                    category.Descripcion = (string)da.dataReader["Descripcion"];


                    categoryList.Add(category);
                }

                return categoryList;
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


        public List<ProductType> getProductType(int status)
        {
            List<ProductType> typeList = new List<ProductType>();
            DataAccess da = new DataAccess();

            try
            {
                da.setConsulta("select IdTipoProducto, Descripcion from TipoProducto Where Estado = @status");
                da.setConsultaWhitParameters("@status", status);
                da.execute();

                while (da.dataReader.Read())
                {
                    ProductType type = new ProductType();
                    type.Id = (long)da.dataReader["Idtipoproducto"];
                    type.Descripcion = (string)da.dataReader["Descripcion"];


                    typeList.Add(type);
                }

                return typeList;
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

        public List<Product> getProducts(int status)
        {
            DataAccess da = new DataAccess();
            List<Product> productlist = new List<Product>();

            try
            {
                da.setConsulta("select Productos.IDProducto, Productos.Nombre, Productos.Descripcion, Productos.IDCategoria as CID, Productos.IDMarca as MID, Productos.IDTipoProducto as TID, Productos.Stock,"+
                                " Productos.StockMinimo, Productos.porcentajeVenta, Marcas.Descripcion as Mdes, Categorias.Descripcion as CDes, TipoProducto.Descripcion as TDes from Productos"+
                                " inner join Marcas on Marcas.IDMarca = Productos.IDMarca" +
                                " inner join Categorias on Categorias.IDCategoria = Productos.IDCategoria"+
                                " inner join TipoProducto on TipoProducto.IDTipoProducto = Productos.IDTipoProducto Where Productos.Estado = @status");
                da.setConsultaWhitParameters("@status", status);

                da.execute();

                while (da.dataReader.Read())
                {
                    Product response = new Product();

                    response.Id = (long)da.dataReader["IDProducto"];
                    response.Nombre = (string)da.dataReader["Nombre"];
                    response.Descripcion = (string)da.dataReader["Descripcion"];
                    response.Marca = new ProductBranch();
                    response.Marca.Id = (long)da.dataReader["MID"];
                    response.Marca.Descripcion = (string)da.dataReader["Mdes"];
                    response.Categoria = new ProductCategory();
                    response.Categoria.Id = (long)da.dataReader["CID"];
                    response.Categoria.Descripcion = (string)da.dataReader["CDes"];
                    response.Tipo = new ProductType();
                    response.Tipo.Id = (long)da.dataReader["TID"];
                    response.Tipo.Descripcion = (string)da.dataReader["TDes"];
                    response.Stock = (int)da.dataReader["Stock"];
                    response.StockMinimo = (int)da.dataReader["StockMinimo"];
                    response.PorcentajeVenta = (short)da.dataReader["porcentajeVenta"];

                    productlist.Add(response);
                }
                return productlist;
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

        public List<Client> getClients()
        {
            DataAccess da = new DataAccess();
            List<Client> clientList = new List<Client>();

            try
            {
                da.setConsulta("Select IDCliente, Nombre, cuitOrDni, fechaNac, telefono, email from Clientes where estado = 1");
                da.execute();

                while (da.dataReader.Read())
                {
                    Client response = new Client();

                    response.Id = (long)da.dataReader["IDCliente"];
                    response.Nombre = (string)da.dataReader["Nombre"];
                    response.CuitOrDni = (string)da.dataReader["cuitOrDni"];
                    response.fechaNac = (DateTime)da.dataReader["fechaNac"];
                    response.Telefono = (string)da.dataReader["telefono"];
                    response.Email = (string)da.dataReader["email"];

                    clientList.Add(response);
                }
                return clientList;
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

        public List<Provider> getProvider(int status)
        {
            DataAccess da = new DataAccess();
            List<Provider> provList = new List<Provider>();

            try
            {
                da.setConsulta("Select IDProveedor, Nombre from Proveedores where estado = @status");
                da.setConsultaWhitParameters("@status", status);
                da.execute();

                while (da.dataReader.Read())
                {
                    Provider response = new Provider();

                    response.Id = (long)da.dataReader["IDProveedor"];
                    response.Nombre = (string)da.dataReader["Nombre"];

                    provList.Add(response);
                }
                return provList;
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

        public List<TipoFactura> getTFacturas()
        {
            DataAccess da = new DataAccess();
            List<TipoFactura> list = new List<TipoFactura>();

            try
            {
                da.setConsulta("Select idTipoFactura, descripcion from TipoDeFactura");
                da.execute();

                while (da.dataReader.Read())
                {
                    TipoFactura response = new TipoFactura();

                    response.IdTipo = (long)da.dataReader["idTipoFactura"];
                    response.Descripcion = (string)da.dataReader["descripcion"];

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


        //Deleters
        public int deleteProduct(long id)
        {
            DataAccess da = new DataAccess();

            try
            {
                da.setConsulta("Update Productos set Estado = 0 where IDProducto = @id");
                da.setConsultaWhitParameters("@id", id);
                
                da.executeAction();
                return da.getLineCantAfected();
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

        public int deleteClient(long id)
        {
            DataAccess da = new DataAccess();

            try
            {
                da.setConsulta("Update Clientes set Estado = 0 where IDCliente = @id");
                da.setConsultaWhitParameters("@id", id);

                da.executeAction();
                return da.getLineCantAfected();
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

        public int deleteCategory(long id)
        {
            DataAccess da = new DataAccess();

            try
            {
                da.setConsulta("Update Categorias set Estado = 0 where IDCategoria = @id");
                da.setConsultaWhitParameters("@id", id);

                da.executeAction();
                return da.getLineCantAfected();
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

        public int deleteBranch(long id)
        {
            DataAccess da = new DataAccess();

            try
            {
                da.setConsulta("Update Marcas set Estado = 0 where IDMarca = @id");
                da.setConsultaWhitParameters("@id", id);

                da.executeAction();
                return da.getLineCantAfected();
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
        public int deleteProvider(long id)
        {
            DataAccess da = new DataAccess();

            try
            {
                da.setConsulta("Update Proveedores set Estado = 0 where IDProveedor = @id");
                da.setConsultaWhitParameters("@id", id);

                da.executeAction();
                return da.getLineCantAfected();
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
        public int deleteTipo(long id)
        {
            DataAccess da = new DataAccess();

            try
            {
                da.setConsulta("Update TipoProducto set Estado = 0 where IDTipoProducto = @id");
                da.setConsultaWhitParameters("@id", id);

                da.executeAction();
                return da.getLineCantAfected();
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
        public int deleteUsuarios(long id)
        {
            DataAccess da = new DataAccess();

            try
            {
                da.setConsulta("Update Usuarios set Estado = 0 where IDUsuario = @id");
                da.setConsultaWhitParameters("@id", id);

                da.executeAction();
                return da.getLineCantAfected();
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

        //Modifiers
        public int editProduct(long id, string nombre, string descripcion, long idcategoria, long idmarca, long idtipoproducto, int stock, int stockminimo, short porcentaje)
        {
            DataAccess da = new DataAccess();

            try
            {
                da.setConsulta("Update Productos set Nombre = @nombre, Descripcion = @descripcion, Stock = @stock, StockMinimo = @stockminimo, porcentajeVenta = @porcentaje where IDProducto = @id");
                da.setConsultaWhitParameters("@id", id);
                da.setConsultaWhitParameters("@nombre", nombre);
                da.setConsultaWhitParameters("@descripcion", descripcion);
                da.setConsultaWhitParameters("@stock", stock);
                da.setConsultaWhitParameters("@stockminimo", stockminimo);
                da.setConsultaWhitParameters("@porcentaje", porcentaje);

                da.executeAction();
                return da.getLineCantAfected();
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

        public int changeStatus(string table, string column, int status,long id)
        {
            DataAccess da = new DataAccess();

            try
            {
                da.setConsulta("Update "+table+" Set Estado = @status where "+column+ "= @id");
                da.setConsultaWhitParameters("@status", status);
                da.setConsultaWhitParameters("@id", id);

                da.executeAction();
                return da.getLineCantAfected();
            }
            catch (Exception ex)
            {
                return -2;
            }
            finally
            {
                da.closeConnection();
            }
        }

        public int editCategory(long id, string desc)
        {
            DataAccess da = new DataAccess();
            
            try
            {
                da.setConsulta("Update Categorias set Descripcion = @descripcion where IDCategoria = @id");
                da.setConsultaWhitParameters("@id", id);
                da.setConsultaWhitParameters("@descripcion", desc);

                da.executeAction();
                return da.getLineCantAfected();
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

        public int editBranch(long id, string desc)
        {
            DataAccess da = new DataAccess();

            try
            {
                da.setConsulta("Update Marcas set Descripcion = @descripcion where IDMarca = @id");
                da.setConsultaWhitParameters("@id", id);
                da.setConsultaWhitParameters("@descripcion", desc);

                da.executeAction();
                return da.getLineCantAfected();
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

        public int editType(long id, string desc)
        {
            DataAccess da = new DataAccess();

            try
            {
                da.setConsulta("Update TipoProducto set Descripcion = @descripcion where IDTipoProducto = @id");
                da.setConsultaWhitParameters("@id", id);
                da.setConsultaWhitParameters("@descripcion", desc);

                da.executeAction();
                return da.getLineCantAfected();
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
        public int editClient(long id, string nombre, string cod, string fecha, string tele, string email)
        {
            DataAccess da = new DataAccess();

            try
            {
                da.setConsulta("Update Clientes set Nombre = @nombre, cuitOrDni = @cod, fechaNac = @fecha, telefono = @tele, email = @email where IDCliente = @id");
                da.setConsultaWhitParameters("@id",id);
                da.setConsultaWhitParameters("@cod", cod);
                da.setConsultaWhitParameters("@fecha", fecha);
                da.setConsultaWhitParameters("@tele", tele);
                da.setConsultaWhitParameters("@email", email);
                da.setConsultaWhitParameters("@nombre",nombre);

                da.executeAction();
                return da.getLineCantAfected();
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

        public int editProvider(long id, string nombre)
        {
            DataAccess da = new DataAccess();

            try
            {
                da.setConsulta("Update Proveedores set Nombre = @nombre where IDProveedor = @id");
                da.setConsultaWhitParameters("@id", id);
                da.setConsultaWhitParameters("@nombre", nombre);

                da.executeAction();
                return da.getLineCantAfected();
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
