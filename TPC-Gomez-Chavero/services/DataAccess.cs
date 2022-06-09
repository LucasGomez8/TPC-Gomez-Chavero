using System;
using System.Data.SqlClient;

namespace services
{
    public class DataAccess
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader dbReader;
        private int lineAfected;


        public DataAccess()
        {
            connection = new SqlConnection("server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true;");
            command = new SqlCommand();
        }

        public void setConsulta(string e)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = e;
        }

        public void setConsultaWhitParameters(string parameter, object e)
        {

            command.Parameters.AddWithValue(parameter, e);
            
        }

        public void execute()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                dbReader = command.ExecuteReader();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public SqlDataReader dataReader
        {
            get { return dbReader; }
        }

        public int getLineCantAfected()
        {
            return lineAfected;
        }

        public void closeConnection()
        {
            connection.Close();
        }

        public void executeAction()
        {
            command.Connection = connection;

            try
            {
                connection.Open();
                lineAfected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void executeAdder()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
