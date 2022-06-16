using domain;
using System;
using System.Collections.Generic;
using System.Data;


namespace services
{
    public class ABMService
    {
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

        public List<ProductBranch> getBranch()
        {
            List<ProductBranch> branchList = new List<ProductBranch>();
            DataAccess da = new DataAccess();

            try
            {
                da.setConsulta("select Id, Descripcion from Marcas");
                da.execute();

                while (da.dataReader.Read())
                {
                    ProductBranch branch = new ProductBranch();
                    branch.Id = (long)da.dataReader["Id"];
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
                da.setConsulta("select Id, Descripcion from Categorias");
                da.execute();

                while (da.dataReader.Read())
                {
                    ProductCategory category = new ProductCategory();
                    category.Id = (long)da.dataReader["Id"];
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
                da.setConsulta("select Id, Descripcion from TipoProducto");
                da.execute();

                while (da.dataReader.Read())
                {
                    ProductType type = new ProductType();
                    type.Id = (long)da.dataReader["Id"];
                    type.Descripcion = (string)da.dataReader["Descripcion"];


                    typeList.Add(type);
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
    }
}
