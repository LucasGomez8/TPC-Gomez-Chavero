using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using services;
using domain;
using helpers;

namespace Controllers
{
    public class ReportesController
    { 
        
        public Reportitos setReporte(long id)
        {
            DataAccess da = new DataAccess();
            Reportitos response = new Reportitos();
            try
            {
                da.setProcedimientoAlmacenado("sp_ReportePersonas");
                da.setConsultaWhitParameters("@id", id);
                da.execute();

                if (da.dataReader.Read())
                {
                    response.NumeroDeFactura = (long)da.dataReader["NumeroFactura"];
                    response.Fecha = (DateTime)da.dataReader["Fecha"];
                    response.MontoFinal = (decimal)da.dataReader["MontoTotal"];

                    response.Cliente = new Client();
                    response.Cliente.Nombre = (string)da.dataReader["ClienteNombre"];
                    response.Cliente.CuitOrDni = (string)da.dataReader["ClienteDni"];
                    response.Cliente.Telefono = (string)da.dataReader["ClienteTelefono"];
                    response.Cliente.Email = (string)da.dataReader["ClienteEmail"];

                    response.Usuario = new User();
                    response.Usuario.Nombre = (string)da.dataReader["UsuarioNombre"];
                    response.Usuario.Apellido = (string)da.dataReader["UsuarioApellido"];
                    response.Usuario.type = new UserType();
                    response.Usuario.type.Description = (string)da.dataReader["Cargo"];

                    return response;
                }

                return null;
            }
            catch
            {

                return null;
            }
            finally
            {
                da.closeConnection();
            }
            
        }

        public List<Product> setProductosReporte(long id)
        {
            DataAccess da = new DataAccess();
            List<Product> list = new List<Product>();

            try
            {
                da.setProcedimientoAlmacenado("sp_ProductoVentaxID");
                da.setConsultaWhitParameters("@id", id);
                da.execute();

                while (da.dataReader.Read())
                {
                    Product response = new Product();
                    response.Nombre = (string)da.dataReader["Nombre"];
                    response.CantidadVenta = (long)da.dataReader["Cantidad"];
                    response.PU = (decimal)da.dataReader["precioVenta"];

                    list.Add(response);

                }
                return list;
            }
            catch
            {
                return null;
            }
        }

        public long getId()
        {
            DataAccess da = new DataAccess();
            try
            {
                da.setConsulta("Select Ventas.IDRegistro from Ventas order by Ventas.IDRegistro desc");
                da.execute();

                if (da.dataReader.Read())
                {
                    return (long)da.dataReader["IDRegistro"];
                }

                return -1;
            }
            catch
            {
                return -1;
            }
        }


    }
}
