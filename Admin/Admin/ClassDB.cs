using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Admin
{
    class ClassDB
    {
        private MySqlConnection connection = new MySqlConnection("Server=localhost;Database=data_siswa;Uid=root;pwd=''");

        // create a function to open the connection
        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        // create a function to close the connection
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        // create a function to return the connection
        public MySqlConnection getConnection()
        {
            return connection;
        }
    }

    class Koneksi
    {
        public static MySqlConnection getKoneksi()
        {
            String MyConString = "SERVER=localhost;" +
                "DATABASE=data_siswa;" +
                "UID=root;" +
                "PASSWORD=''";
            return new MySqlConnection(MyConString);
        }
    }
}
