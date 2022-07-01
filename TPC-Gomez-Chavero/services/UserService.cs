using domain;
using System;
using System.Collections.Generic;

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
                    "where U.Estado = 1 And U.nick = @nick and U.contraseña = @pass COLLATE SQL_Latin1_General_CP1_CS_AS");
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

        public List<User> getUser(int status)
        {
            List<User> userList = new List<User>();
            DataAccess da = new DataAccess();

            try
            {
                da.setConsulta("select U.idUsuario as id, U.nombre, U.apellido, U.dni, U.nick, U.contraseña, U.fechaNac," +
                    "T.descripcion as descripcionTipo, T.idTipoUsuario " +
                    "from Usuarios as U inner join TipoUsuario as T on U.IDTipoUsuario = T.idTipoUsuario Where U.Estado = @status");

                da.setConsultaWhitParameters("@status", status);
                da.execute();

                while (da.dataReader.Read())
                {
                    User response = new User();
                    response.ID = (long)da.dataReader["id"];
                    response.Nombre = (string)da.dataReader["nombre"];
                    response.Apellido = (string)da.dataReader["apellido"];
                    response.DNI = (string)da.dataReader["dni"];
                    response.Nick = (string)da.dataReader["nick"];
                    response.Pass = (string)da.dataReader["contraseña"];
                    response.FechaNacimiento = new DateTime();
                    response.FechaNacimiento = (DateTime)da.dataReader["fechaNac"];
                    response.type = new UserType();
                    response.type.Description = (string)da.dataReader["descripcionTipo"];
                    response.type.ID = (long)da.dataReader["idTipoUsuario"];

                    userList.Add(response);
                }

                return userList;
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

        public List<User> getAdmins()
        {
            DataAccess da = new DataAccess();
            List<User> list = new List<User>();


            try
            {
                da.setConsulta("select U.idUsuario as id, U.nombre, U.apellido, U.dni, U.nick, U.contraseña, U.fechaNac," +
                    "T.descripcion as descripcionTipo, T.idTipoUsuario " +
                    "from Usuarios as U inner join TipoUsuario as T on U.IDTipoUsuario = T.idTipoUsuario where T.idTipoUsuario = 1 And U.Estado = 1");
                da.execute();

                while (da.dataReader.Read())
                {
                    User response = new User();
                    response.ID = (long)da.dataReader["id"];
                    response.Nombre = (string)da.dataReader["nombre"];
                    response.Apellido = (string)da.dataReader["apellido"];
                    response.DNI = (string)da.dataReader["dni"];
                    response.Nick = (string)da.dataReader["nick"];
                    response.Pass = (string)da.dataReader["contraseña"];
                    response.FechaNacimiento = new DateTime();
                    response.FechaNacimiento = (DateTime)da.dataReader["fechaNac"];
                    response.type = new UserType();
                    response.type.Description = (string)da.dataReader["descripcionTipo"];
                    response.type.ID = (long)da.dataReader["idTipoUsuario"];

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

        public List<UserType> getTypes()
        {
            List<UserType> typelist = new List<UserType>();
            DataAccess da = new DataAccess();

            try
            {

                da.setConsulta("Select idTipoUsuario, descripcion from TipoUsuario");
                da.execute();

                while (da.dataReader.Read())
                {
                    UserType response = new UserType();
                    response.ID = (long)da.dataReader["idTipoUsuario"];
                    response.Description = (string)da.dataReader["descripcion"];


                    typelist.Add(response);
                }

                return typelist;
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

        public int userAdd(string nombre, string apellido, string dni, long idtipo, string nick, string pass, string date)
        {
            DataAccess da = new DataAccess();

            try
            {
                da.setConsulta("insert into Usuarios(Nombre, Apellido, DNI, IdTipoUsuario, nick, contraseña, fechaNac, Estado) values(@nombre, @apellido, @dni, @idtipo, @nick, @pass, @date, 1)");
                da.setConsultaWhitParameters("@nombre", nombre);
                da.setConsultaWhitParameters("@apellido", apellido);
                da.setConsultaWhitParameters("@dni", dni);
                da.setConsultaWhitParameters("@idtipo", idtipo);
                da.setConsultaWhitParameters("@nick", nick);
                da.setConsultaWhitParameters("@pass", pass);
                da.setConsultaWhitParameters("@date", date);

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

        public int changeStatus(long id, int status)
        {
            DataAccess da = new DataAccess();
            try
            {
                da.setConsulta("Update Usuarios Set estado = @status where idUsuario = @id");
                da.setConsultaWhitParameters("@id", id);
                da.setConsultaWhitParameters("@status", status);

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

        public int editUser(long id, string nom, string ape, string dni, string fec, string nick, string pass, long idtipo)
        {
            DataAccess da = new DataAccess();

            try
            {
                da.setConsulta("Update Usuarios set Nombre = @nom, Apellido = @ape, dni=@dni, IDTipoUsuario = @idtipo, contraseña=@pass, nick=@nick, fechaNac = @fec where idUsuario = @id");
                da.setConsultaWhitParameters("@id", id);
                da.setConsultaWhitParameters("@nom",nom);
                da.setConsultaWhitParameters("@ape",ape);
                da.setConsultaWhitParameters("@dni",dni);
                da.setConsultaWhitParameters("@fec",fec);
                da.setConsultaWhitParameters("@nick",nick);
                da.setConsultaWhitParameters("@pass",pass);
                da.setConsultaWhitParameters("@idtipo",idtipo);

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
