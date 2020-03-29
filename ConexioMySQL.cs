using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace MySQL_DDL
{
    public class ConexioMySQL
    {
        private MySqlConnection connection = new MySqlConnection("server=localhost;user id=root;password=******************");
        //Metodo publico para abrir conexion
        public MySqlConnection AbrirConexion()
        {
            //if (connection.State.ToString()=="Close")
            connection.Open();
            return connection;
        }
        //Metodo publico para cerrar conexion
        public MySqlConnection CerrarConexion()
        {
            //if (connection.State.ToString()=="Open")
            connection.Close();
            return connection;
        }
    }
}
