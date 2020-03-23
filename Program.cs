using MySql.Data.MySqlClient;//Libreria para conexion
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace MySQL_DDL
{
    public class Program
    {
        static void Main(string[] args)
        {
            //string datos = "";
            //string cadena = "server=localhost; port=3306; user id=root; password=rojo7913@; database=ejemplo1;";//Se crea la cadena para instanciar la base de datos
            //MySqlConnection connection = new MySqlConnection(cadena);
            //try
            //{
            //    connection.Open();
            //    MySqlDataReader reader = null;
            //    MySqlCommand cmd = new MySqlCommand("SHOW DATABASES", connection);//instruccion para mostrar bases de datos
            //    reader = cmd.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        datos += reader.GetString(0) + "\n";
            //    }
            //}
            //catch (MySqlException ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}
            //Console.WriteLine(datos);
            //Console.ReadKey();

            //------------------------------------------------MyConetions---------------------------------//
            //MySqlConnection conexion;
            //string servidor = "localhost";
            //string puerto = "3306";
            //string usuario = "root";
            //string password = "rojo7913@";
            //string database = "ejemplo1";

            //string connStr =
            //    string.Format("server={0};port={1};user id={2};password={3};database={4};pooling=false;Allow Zero Datetime=False;Convert Zero Datetime=True", servidor, puerto, usuario, password, database);
            //try
            //{
            //    conexion = new MySqlConnection(connStr);
            //    conexion.Open();
            //    Console.WriteLine("Conectado a la base de datos [{0}]", database);
            //    conexion.Close();
            //    Console.WriteLine("La conexion a terminado...");
            //}
            //catch (MySqlException e)
            //{
            //    Console.WriteLine("ERROR: " + e.Message);
            //}

            //Console.WriteLine("\nPresione cualquier tecla para terminar");
            //Console.ReadKey();
            //----------------------------------------------------------------------------------------------//
            bool showMenu = true;
            while (showMenu)
            {
                Console.WriteLine("Ingrese texto");
                string cadena = Console.ReadLine();
                showMenu = Inicio(cadena);
            }
            Console.ReadKey();
        }

        static bool Inicio(string cadena)
        {
            switch (cadena.ToLower())
            {
                case string _ when cadena.ToLower().StartsWith("crear base de datos:"):
                    // Can have a null case.
                    Crear(cadena);
                    return true;
                case string _ when cadena.ToLower().StartsWith("eliminar base de datos:"):
                    // Empty string case also works.
                    Eliminar(cadena);
                    return true;
                case string _ when cadena.ToLower().StartsWith("editar base de datos:"):
                    // Empty string case also works.
                    Editar(cadena);
                    return true;
                default:
                    Console.Clear();
                    Console.WriteLine("Error en comando, ingresar otra vez");
                    return true;
            }
        }

        static void Eliminar(string cadena)
        {
            Console.Clear();
            Metodos_DDL metodos = new Metodos_DDL();
            int found = cadena.IndexOf(":");
            string nuevo = cadena.Substring(found + 1);
            Console.WriteLine(nuevo);
            try
            {
                metodos.EliminiarBD(nuevo);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine("Aqui se va a eliminar: {0}.", cadena.Substring(found + 1));
            }
        }
        static void Crear(string cadena)
        {
            Console.Clear();
            Metodos_DDL metodos = new Metodos_DDL();
            int found = cadena.IndexOf(":");
            string nuevo = cadena.Substring(found+1);
            Console.WriteLine(nuevo);
            try
            {
                metodos.CrearBD(nuevo);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine("Aqui se va a crear: {0}.", cadena.Substring(found + 1));
            }
        }
        static void Editar(string cadena)
        {
            Console.Clear();

            int found = cadena.IndexOf(":");
            string nuevo = cadena.Substring(found + 1);
            Console.WriteLine("Aqui se va a editar: {0}.", cadena.Substring(found + 1));
            Console.WriteLine(nuevo);
        }
    }
}
