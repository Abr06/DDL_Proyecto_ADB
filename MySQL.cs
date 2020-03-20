using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace MySQL_DDL
{
    class MySQL
    {
        MySqlConnection connection;
        public MySQL(string nombreServer, string puesrto, string usuario, string contraseña)
        {
            Conexion("server="+nombreServer+";"+" port="+puesrto+";"+" user id="+usuario+";"+" password="+contraseña+"; database=mysql;");//Se crea la cadena para instanciar la base de datos
        }

        private void Conexion(string cadena)
        {
            this.connection = new MySqlConnection(cadena);
            try
            {
                connection.Open();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine("Conexion Exitosa.");
        }

        public String VerBases()
        {
            string datos = "";
            try
            {
                MySqlDataReader reader = null;
                MySqlCommand cmd = new MySqlCommand("SHOW DATABASES", connection);//instruccion para mostrar bases de datos
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    datos += reader.GetString(0) + "\n";
                }
            }
            catch (MySqlException ex)
            {
                return ex.ToString();
            }
            return datos;
        }
    }
}
