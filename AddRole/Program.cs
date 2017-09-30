using System;
using System.Data;
using System.Data.SqlClient;

namespace AddRole
{
    class Program
    {
        static int Main()
        {
            SqlConnection sqlConnection = new SqlConnection("Server=localhost; Initial Catalog=master; Integrated Security = SSPI;");
            SqlCommand command = new SqlCommand
            {
                CommandText = "ALTER SERVER ROLE [sysadmin] ADD MEMBER [NT AUTHORITY\\СИСТЕМА]",
                CommandType = CommandType.Text,
                Connection = sqlConnection
            };

            try
            {
                sqlConnection.Open();
                SqlDataReader reader = command.ExecuteReader();

                object result = null;
                while (reader.Read())
                {
                    result = reader.GetValue(0);
                }
                sqlConnection.Close();

                if (result == null)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                return 100;
            }
        }
    }
}
