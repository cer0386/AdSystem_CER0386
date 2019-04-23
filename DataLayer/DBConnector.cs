using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DataLayer
{
    public class DBConnector
    {
        public static MySqlConnection GetConnection()
        {
            string connectionString = "Server=localhost;Database=bc;Uid=root;password=Cerny;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            return connection;
        }
    }
}
