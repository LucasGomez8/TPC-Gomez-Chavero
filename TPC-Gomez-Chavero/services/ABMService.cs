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
                da.setConsulta("insert into "+ tabla +" (descripcion) values(@descripcion)");
                da.setConsultaWhitParameters("@descripcion", descripcion);

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

        public int addClient(string nombre, string cod, string date, string telefono, string email)
        {
            DataAccess da = new DataAccess();

            try
            {
                da.setConsulta("insert into Clientes(Nombre, CuitOrDni, FechaNac, Telefono, Email) values(@nombre, @cod, @date, @telefono, @email)");
                da.setConsultaWhitParameters("@nombre", nombre);
                da.setConsultaWhitParameters("@cod", cod);
                da.setConsultaWhitParameters("@date", date);
                da.setConsultaWhitParameters("@telefono", telefono);
                da.setConsultaWhitParameters("@email", email);

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

        public int addProduct(string nombre, string descripcion,long idcategoria, long idmarca, long idtipoproducto, int stock, int stockminimo, short porcentaje )
        {
            DataAccess da = new DataAccess();

            try
            {
                da.setConsulta("insert into Productos(Nombre, Descripcion, IDCATEGORIA, IDMARCA, IDTIPOPRODUCTO, STOCK, STOCKMINIMO, PORCENTAJEVENTA) values(@nombre, @descripcion, @idcategoria, @idmarca, @idtipoproducto, @stock, @stockminimo, @porcentaje)");
                da.setConsultaWhitParameters("@nombre", nombre);
                da.setConsultaWhitParameters("@descripcion", descripcion);
                da.setConsultaWhitParameters("@idcategoria", idcategoria);
                da.setConsultaWhitParameters("@idmarca", idmarca);
                da.setConsultaWhitParameters("@idtipoproducto", idtipoproducto);
                da.setConsultaWhitParameters("@stock", stock);
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
                da.setConsulta("insert into Proveedores(Nombre) values(@nombre)");
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


        //Getters
        public List<ProductBranch> getBranch()
        {
            List<ProductBranch> branchList = new List<ProductBranch>();
            DataAccess da = new DataAccess();

            try
            {
                da.setConsulta("select Idmarca, Descripcion from Marcas");
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


        public List<ProductCategory> getCategory()
        {
            List<ProductCategory> categoryList = new List<ProductCategory>();
            DataAccess da = new DataAccess();

            try
            {
                da.setConsulta("select Idcategoria, Descripcion from Categorias");
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


        public List<ProductType> getProductType()
        {
            List<ProductType> typeList = new List<ProductType>();
            DataAccess da = new DataAccess();

            try
            {
                da.setConsulta("select IdTipoProducto, Descripcion from TipoProducto");
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

        public List<Product> getProducts()
        {
            DataAccess da = new DataAccess();
            List<Product> productlist = new List<Product>();

            try
            {
                da.setConsulta("select Productos.IDProducto, Productos.Nombre, Productos.Descripcion, Productos.IDCategoria as CID, Productos.IDMarca as MID, Productos.IDTipoProducto as TID, Productos.Stock,"+
                                " Productos.StockMinimo, Productos.porcentajeVenta, Marcas.Descripcion as Mdes, Categorias.Descripcion as CDes, TipoProducto.Descripcion as TDes from Productos"+
                                " inner join Marcas on Marcas.IDMarca = Productos.IDMarca" +
                                " inner join Categorias on Categorias.IDCategoria = Productos.IDCategoria"+
                                " inner join TipoProducto on TipoProducto.IDTipoProducto = Productos.IDTipoProducto");

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
                da.setConsulta("Select IDCliente, Nombre, cuitOrDni, fechaNac, telefono, email from Clientes");
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

        public List<Provider> getProvider()
        {
            DataAccess da = new DataAccess();
            List<Provider> provList = new List<Provider>();

            try
            {
                da.setConsulta("Select IDProveedor, Nombre from Proveedores");
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
                da.setConsulta("Delete from Productos where IDProducto = @id");
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
                da.setConsulta("delete from Clientes where IDCliente = @id");
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
                da.setConsulta("delete from Categorias where IDCategoria = @id");
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
                da.setConsulta("delete from Marcas where IDMarca = @id");
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
                da.setConsulta("delete from Proveedores where IDProveedor = @id");
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
                da.setConsulta("delete from TipoProducto where IDTipoProducto = @id");
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
                da.setConsulta("delete from Usuarios where IDUsuario = @id");
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
                da.setConsulta("Update Productos set Nombre = @nombre, Descripcion = @descripcion, idcategoria = @idcat, idmarca = @idmar, idTipoProducto = @idtipo, Stock = @stock, StockMinimo = @stockminimo, porcentajeVenta = @porcentaje where IDProducto = @id");
                da.setConsultaWhitParameters("@id", id);
                da.setConsultaWhitParameters("@nombre", nombre);
                da.setConsultaWhitParameters("@descripcion", descripcion);
                da.setConsultaWhitParameters("@idcat", idcategoria);
                da.setConsultaWhitParameters("@idmar", idmarca);
                da.setConsultaWhitParameters("@idtipo", idtipoproducto);
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
            catch (Exception ex)
            {

                throw ex;
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
