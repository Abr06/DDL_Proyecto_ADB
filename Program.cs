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
            //-----------------------------------------------Menu-----------------------------------------------//
            bool showMenu = true;
            while (showMenu)
            {
                //Console.WriteLine("Ingrese texto");
                //string cadena = Console.ReadLine();
                showMenu = Inicio();
            }
            Console.ReadKey();
        }

        static bool Inicio()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("Ingrese texto");
            string cadena = Console.ReadLine();

            switch (cadena.ToLower())
            {
                case string _ when cadena.EndsWith(";")==false:
                    // Can have a null case.
                    Console.WriteLine("----------------------");
                    Console.WriteLine("Falta ; al final");
                    return true;
                case string _ when cadena.ToLower().StartsWith("crear base"):
                    // Can have a null case.
                    Crear(cadena);
                    return true;
                case string _ when cadena.ToLower().StartsWith("borrar base"):
                    // Empty string case also works.
                    Borrar(cadena);
                    return true;
                case string _ when cadena.ToLower().StartsWith("usar base"):
                    // Empty string case also works.
                    Usar(cadena);
                    return true;
                case string _ when cadena.ToLower().StartsWith("mostrar bases;"):
                    // Empty string case also works.
                    Mostrar();
                    return true;
                default:
                    Console.WriteLine("----------------------");
                    Console.WriteLine("Error en comando, ingresar otra vez");
                    return true;
            }
        }

        static void Borrar(string cadena)
        {
            Metodos_DDL metodos = new Metodos_DDL();
            int found = cadena.IndexOf(";");
            cadena = cadena.Remove(found);

            string nuevo = cadena.Substring(12);
            try
            {
                metodos.BorrarBD(nuevo);
                Console.WriteLine("----------------------");
                Console.WriteLine("Se ha borrado la base de datos: {0}.", nuevo);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("----------------------");
                const int MaxLength = 103;
                string error = ex.ToString();
                if (error.Length > MaxLength)
                {
                    error = error.Substring(0, MaxLength);
                    Console.WriteLine(error);
                }
            }
        }
        static void Crear(string cadena)
        {
            Metodos_DDL metodos = new Metodos_DDL();
            int found = cadena.IndexOf(";");
            cadena = cadena.Remove(found);
            
            string nuevo = cadena.Substring(11);
            try
            {
                metodos.CrearBD(nuevo);
                Console.WriteLine("----------------------");
                Console.WriteLine("Se ha creado la base de datos: {0}.", nuevo);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("----------------------");
                const int MaxLength = 103;
                string error = ex.ToString();
                if (error.Length > MaxLength)
                {
                    error = error.Substring(0, MaxLength);
                    Console.WriteLine(error);
                }
            }
        }
        static void Usar(string cadena)
        {
            Metodos_DDL metodos = new Metodos_DDL();
            int found = cadena.IndexOf(";");
            cadena = cadena.Remove(found);

            string nuevo = cadena.Substring(10);
            try
            {
                metodos.UsarBD(nuevo);
                Console.WriteLine("----------------------");
                Console.WriteLine("Se esta usando la base de datos: {0}.", nuevo);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("----------------------");
                const int MaxLength = 103;
                string error = ex.ToString();
                if (error.Length > MaxLength)
                {
                    error = error.Substring(0, MaxLength);
                    Console.WriteLine(error);
                }
            }
        }
        static void Mostrar()
        {
            Metodos_DDL metodos = new Metodos_DDL();
            try
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("Bases de datos:");
                metodos.Mostrar();
                Console.WriteLine("----------------------");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
