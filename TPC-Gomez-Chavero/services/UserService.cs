using domain;
using System;

namespace services
{
    public class UserService
    {

        public User login(string nick, string pass)
        {
            User response = new User();
            DataAccess da = new DataAccess();

            try
            {
                da.setConsulta("select U.idUsuario as id, U.nombre, U.apellido, U.dni, U.nick, " +
                    "T.descripcion as descripcionTipo, T.idTipoUsuario " +
                    "from Usuarios as U left join TipoUsuario as T on U.IDTipoUsuario = T.idTipoUsuario " +
                    "where U.nick = @nick and U.contraseña = @pass COLLATE SQL_Latin1_General_CP1_CS_AS");
                da.setConsultaWhitParameters("@nick", nick);
                da.setConsultaWhitParameters("@pass", pass);
                da.execute();

                if (da.dataReader.Read())
                {
                    response.ID = (long)da.dataReader["id"];
                    response.Nombre = (string)da.dataReader["nombre"];
                    response.Apellido = (string)da.dataReader["apellido"];
                    response.DNI = (string)da.dataReader["dni"];
                    response.Nick = (string)da.dataReader["nick"];
                    response.type = new UserType();
                    response.type.Description = (string)da.dataReader["descripcionTipo"];
                    response.type.ID = (long)da.dataReader["idTipoUsuario"];
                }
                else
                {
                    return null;
                }

                return response;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar con la base de datos ." + ex.Message);
                throw;
            }
            finally
            {
                da.closeConnection();
            }
        }
    }
}
