using domain;
using System;
using System.Collections.Generic;
using System.Data;


namespace services
{
    public class CommerceConnecction
    {
        public bool UserVerify(string nick, string pass) {
            DataAccess da = new DataAccess();
            try
            {
                da.setConsulta("Select nick, contraseña from Usuarios");
                da.execute();

                while (da.dataReader.Read())
                {
                    if ((string)da.dataReader["nick"]==nick && (string)da.dataReader["contraseña"] == pass)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                return false;
               
            }
            catch (Exception)
            {

                return false;
            }


        }
    }
}
