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
        
    }
}
