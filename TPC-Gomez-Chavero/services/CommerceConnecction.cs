using domain;
using System;
using System.Collections.Generic;
using System.Data;


namespace services
{
    public class CommerceConnecction
    {
        public List<Product> listarProducto()
        {
            List<Product> listaProducto = new List<Product>();
            DataAccess da = new DataAccess();

            try
            {

                da.setConsulta("Select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, A.ImagenUrl, M.Descripcion as Marca, "+
                    "M.Id as MID, C.Id as CID, C.Descripcion as Categoria From ARTICULOS A, MARCAS M, CATEGORIAS C"+
                    " where A.Idmarca = M.Id AND C.Id=A.IdCategoria");
                da.execute();

                while (da.dataReader.Read())
                {

                    Product showP = new Product();
                    showP.Id = (int)da.dataReader["Id"];
                    showP.codArticulo = (string)da.dataReader["Codigo"];
                    showP.Nombre = (string)da.dataReader["Nombre"];
                    showP.Descripcion = (string)da.dataReader["Descripcion"];
                    showP.Precio = (decimal)da.dataReader["Precio"];
                    showP.Marca = new ComercialBrand();
                    showP.Marca.Description = (string)da.dataReader["Marca"];
                    showP.Marca.IdComercialBrand = (int)da.dataReader["MID"];
                    showP.Categoria = new Category();
                    showP.Categoria.IdCategory = (int)da.dataReader["CID"];
                    showP.Categoria.Description = (string)da.dataReader["Categoria"];
                    showP.urlImagen = (string)da.dataReader["ImagenUrl"];

                    listaProducto.Add(showP);
                }
                return listaProducto;
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

        public Product buscarPorCod(string e)
        {
            Product response = new Product();
            DataAccess da = new DataAccess();
            try
            {

                da.setConsulta("Select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, A.ImagenUrl, M.Descripcion as Marca, " + 
                    "M.Id as MID, C.ID as CID, C.Descripcion as Categoria From ARTICULOS A, MARCAS M, " +
                    "CATEGORIAS C where A.Codigo = @Codigo");
                da.setConsultaWhitParameters("@Codigo", e);

                da.execute();
                if (da.dataReader.Read())
                {
                    response.Id = (int)da.dataReader["Id"];
                    response.codArticulo = (string)da.dataReader["Codigo"];
                    response.Nombre = (string)da.dataReader["Nombre"];
                    response.Descripcion = (string)da.dataReader["Descripcion"];
                    response.Precio = (decimal)da.dataReader["Precio"];
                    response.Marca = new ComercialBrand();
                    response.Categoria = new Category();
                    response.Marca.Description = (string)da.dataReader["Marca"];
                    response.Marca.IdComercialBrand = (int)da.dataReader["MID"];
                    response.Categoria.Description = (string)da.dataReader["Categoria"];
                    response.Categoria.IdCategory = (int)da.dataReader["CID"];
                    response.urlImagen = (string)da.dataReader["ImagenUrl"];
                }
                else
                {
                    return null;
                }

                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro al conectar con la base de datos." + ex.Message);
                throw;
            }
            finally
            {
                da.closeConnection();
            }

        }

        public Product buscarPorNombre(string e)
        {
            Product elegido = new Product();
            DataAccess da = new DataAccess();

            try
            {
                da.setConsulta("Select A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, A.ImagenUrl,"+
                    " M.Descripcion as Marca, M.Id as MID, C.ID as CID, C.Descripcion as Categoria "+
                    "From ARTICULOS A left join MARCAS M on M.Id = A.IdMarca left "+
                    "join CATEGORIAS C ON C.ID = A.IdCategoria where A.Nombre = @Nombre");
                da.setConsultaWhitParameters("@Nombre", e);

                da.execute();

                if (da.dataReader.Read())
                {
                    elegido.Id = (int)da.dataReader["Id"];
                    elegido.Nombre = (string)da.dataReader["Nombre"];
                    elegido.codArticulo = (string)da.dataReader["Codigo"];
                    elegido.Descripcion = (string)da.dataReader["Descripcion"];
                    elegido.Precio = (decimal)da.dataReader["Precio"];
                    elegido.Marca = new ComercialBrand();
                    elegido.Marca.Description = (string)da.dataReader["Marca"];
                    elegido.Marca.IdComercialBrand = (int)da.dataReader["MID"];
                    elegido.Categoria = new Category();
                    elegido.Categoria.IdCategory = (int)da.dataReader["CID"];
                    elegido.Categoria.Description = (string)da.dataReader["Categoria"];
                    elegido.urlImagen = (string)da.dataReader["ImagenUrl"];
                }
                else
                {
                    return null;
                }

                return elegido;
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
        public int addProduct(Product adding)
        {
            DataAccess da = new DataAccess();
            try
            {
                da.setConsulta("Insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio)"+
                    " values(@Codigo, @Nombre, @Descripcion, @idmarca, @idcategoria, @Imagen, @precio)");
                da.setConsultaWhitParameters("@Codigo", adding.codArticulo);
                da.setConsultaWhitParameters("@Nombre", adding.Nombre);
                da.setConsultaWhitParameters("@Descripcion", adding.Descripcion);
                da.setConsultaWhitParameters("@Imagen", adding.urlImagen);
                da.setConsultaWhitParameters("@idmarca", adding.Marca.IdComercialBrand);
                da.setConsultaWhitParameters("@idcategoria", adding.Categoria.IdCategory);
                da.setConsultaWhitParameters("@precio", adding.Precio);

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

        public int deleteProduct(string del)
        {
            DataAccess da = new DataAccess();
            try
            {
                da.setConsulta("delete articulos where codigo = @Codigo");
                da.setConsultaWhitParameters("@Codigo", del);
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

        public DataTable getConfigFromDB(string info)
        {
            DataTable data = new DataTable();
            DataAccess response = new DataAccess();
            data.Columns.Add("id");
            data.Columns.Add("descripcion");

            try
            {
                response.setConsulta("Select id, descripcion from " + info);
                response.execute();

                while (response.dataReader.Read())
                {

                    DataRow row = data.NewRow();
                    row["id"] = (int)response.dataReader["id"];
                    row["descripcion"] = (string)response.dataReader["descripcion"];

                    data.Rows.Add(row);
                }
                return data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                response.closeConnection();
            }
        }

        public int editProduct (Product edit)
        {
            DataAccess da = new DataAccess();
            try
            {
                da.setConsulta("Update ARTICULOS set Codigo=@Codigo,Nombre=@Nombre,Descripcion=@Descripcion, " + 
                    "ImagenUrl=@Imagen,IdMarca=@idmarca,IdCategoria=@idcategoria,Precio=@precio where Id=@id");
                da.setConsultaWhitParameters("@Codigo",edit.codArticulo);
                da.setConsultaWhitParameters("@Nombre",edit.Nombre);
                da.setConsultaWhitParameters("@Descripcion",edit.Descripcion);
                da.setConsultaWhitParameters("@Imagen",edit.urlImagen);
                da.setConsultaWhitParameters("@idmarca",edit.Marca.IdComercialBrand);
                da.setConsultaWhitParameters("@idcategoria",edit.Categoria.IdCategory);
                da.setConsultaWhitParameters("@precio",edit.Precio);
                da.setConsultaWhitParameters("@id", edit.Id);

                da.executeAction();
                return da.getLineCantAfected();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
