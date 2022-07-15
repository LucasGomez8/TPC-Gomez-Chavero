using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain;
using services;

namespace Controllers
{
    public class EmailController
    {

       public bool isUserExists(string email)
        {
            DataAccess da = new DataAccess();

            try
            {
                da.setConsulta("Select * from Usuarios where email like @email");
                da.setConsultaWhitParameters("@email", email);

                da.execute();

                if (da.dataReader.Read())
                {
                    return true;
                }


                return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                da.closeConnection();
            }

        }

       public bool newPass(string email)
       {
            DataAccess da = new DataAccess();

            try
            {
                da.setConsulta("Update Usuarios set contraseña = 1234 where Email like @email");
                da.setConsultaWhitParameters("@email", email);

                da.executeAction();

                if (da.getLineCantAfected()>0)
                {
                    return true;
                }


                return false;
            }
            catch
            {
                return false;
            }
            finally
            {
                da.closeConnection();
            }

       }


    }
}
