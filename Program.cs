using MySql.Data.MySqlClient;//Libreria para conexion
using System;

namespace MySQL_DDL
{
    class Program
    {
        static void Main(string[] args)
        {
            string datos = "";
            string cadena = "server=localhost; port=3306; user id=Abr06; password=susana24; database=mysql;";//Se crea la cadena para instanciar la base de datos
            MySqlConnection connection = new MySqlConnection(cadena);
            try
            {
                connection.Open();
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
                Console.WriteLine(ex.ToString());
            }
            Console.WriteLine(datos);
            Console.ReadKey();
        }
    }
}
