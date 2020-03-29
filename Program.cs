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
        #region "Main"
        static void Main(string[] args)
        {
            //-----------------------------------------------Menu-----------------------------------------------//
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = Inicio();
                Console.WriteLine("Saliste del DDL.");
            }
            Console.ReadKey();
        }
        #endregion

        #region "MenuPrincipal"
        static bool Inicio()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("Ingrese texto");
            string cadena = Console.ReadLine();

            switch (cadena.ToLower())
            {
                case string _ when cadena.ToLower().StartsWith("exit"):
                    Console.WriteLine("----------------------");
                    return false;
                case string _ when cadena.EndsWith(";")==false:
                    // Can have a null case.
                    Console.WriteLine("----------------------");
                    Console.WriteLine("Falta ; al final");
                    return true;
                case string _ when cadena.ToLower().StartsWith("crea base"):
                    // Can have a null case.
                    Crear(cadena);
                    return true;
                case string _ when cadena.ToLower().StartsWith("borra base"):
                    // Empty string case also works.
                    Borrar(cadena);
                    return true;
                case string _ when cadena.ToLower().StartsWith("usa base"):
                    // Empty string case also works.
                    Usar(cadena);
                    return true;
                case string _ when cadena.ToLower().StartsWith("muestra bases;"):
                    // Empty string case also works.
                    Mostrar();
                    return true;
                case string _ when cadena.ToLower().StartsWith("crea tabla"):
                    // Empty string case also works.
                    //TablaCrear(cadena);
                    Console.WriteLine("Usar una base de datos primero.");
                    return true;
                default:
                    Console.WriteLine("----------------------");
                    Console.WriteLine("Error en comando, ingresar otra vez");
                    return true;
            }
        }
        #endregion

        #region "MenuTablas"
        static bool InicioTablas(string nuevo1)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("Ingrese texto para tablas:");
            string cadena = Console.ReadLine();

            switch (cadena.ToLower())
            {
                case string _ when cadena.ToLower().StartsWith("crea tabla"):
                    TablaCrear(cadena,nuevo1);
                    return true;
                case string _ when cadena.ToLower().StartsWith("borra tabla"):
                    BorraTabla(cadena, nuevo1);
                    return true;
                case string _ when cadena.ToLower().StartsWith("muestra tablas;"):
                    MuestraTabla(nuevo1);
                    return true;
                case string _ when cadena.ToLower().StartsWith("muestra tabla"):
                    MuestraTabla1(cadena, nuevo1);
                    return true;
                case string _ when cadena.ToLower().StartsWith("agregar campo"):
                    AgregarCampo(cadena, nuevo1);
                    return true;
                case string _ when cadena.ToLower().StartsWith("borra campo"):
                    BorrarCampo(cadena, nuevo1);
                    return true;
                case string _ when cadena.ToLower().StartsWith("modificar campo"):
                    ModificarCampo(cadena, nuevo1);
                    return true;
                case string _ when cadena.ToLower().StartsWith("exit"):
                    return false;
                default:
                    Console.WriteLine("----------------------");
                    Console.WriteLine("Error en comando para tablas, ingresar otra vez");
                    return true;
            }
        }
        #endregion

        #region "Agregar Campo"
        static void AgregarCampo(string cadena2, string nuevo1)
        {
            Metodos_DDL metodos = new Metodos_DDL();
            int found = cadena2.IndexOf(";");
            cadena2 = cadena2.Remove(found);

            string nuevo2 = cadena2.Substring(14);

            string output = nuevo2;
            nuevo2 = nuevo2.Replace("(", "add (");
            nuevo2 = nuevo2.Replace("long", "LONG").Replace("entero", "INT").Replace("decimal", "DECIMAL").Replace("fecha", "DATE").Replace("caracter", "varchar(20)");
            try
            {
                metodos.AgregarCampo(nuevo1, nuevo2);
                Console.WriteLine("----------------------");
                Console.WriteLine("Se ha agregado el campo la tabla: {0}.", output);
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
        #endregion

        #region "Borrar Campo"
        static void BorrarCampo(string cadena2, string nuevo1)
        {
            Metodos_DDL metodos = new Metodos_DDL();
            int found = cadena2.IndexOf(";");
            cadena2 = cadena2.Remove(found);

            string nuevo2 = cadena2.Substring(12);

            string output = nuevo2;
            nuevo2 = nuevo2.Replace(" ", " drop ");
            nuevo2 = nuevo2.Replace("long", "LONG").Replace("entero", "INT").Replace("decimal", "DECIMAL").Replace("fecha", "DATE").Replace("caracter", "varchar(20)");
            try
            {
                metodos.BorrarCampo(nuevo1, nuevo2);
                Console.WriteLine("----------------------");
                Console.WriteLine("Se ha borrado el campo la tabla: {0}.", output);
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
        #endregion

        #region "Modificar Campo"
        static void ModificarCampo(string cadena2, string nuevo1)
        {
            Metodos_DDL metodos = new Metodos_DDL();
            int found = cadena2.IndexOf(";");
            cadena2 = cadena2.Remove(found);

            string nuevo2 = cadena2.Substring(16);

            string output = nuevo2;
            int index1 = nuevo2.IndexOf(" ");
            nuevo2 = nuevo2.Insert(index1, " MODIFY ");
            nuevo2 = nuevo2.Replace("long", "LONG").Replace("entero", "INT").Replace("decimal", "DECIMAL").Replace("fecha", "DATE").Replace("caracter", "varchar(20)");
            try
            {
                metodos.ModificarCampo(nuevo1, nuevo2);
                Console.WriteLine("----------------------");
                Console.WriteLine("Se ha modificado el campo la tabla: {0}.", output);
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
        #endregion

        #region "Crear tabla"
        static void TablaCrear(string cadena2,string nuevo1)
        {
            Metodos_DDL metodos = new Metodos_DDL();
            int found = cadena2.IndexOf(";");
            cadena2 = cadena2.Remove(found);

            string nuevo2 = cadena2.Substring(11);

            string output = nuevo2;

            nuevo2 = nuevo2.Replace("long", "LONG").Replace("entero", "INT").Replace("decimal", "DECIMAL").Replace("fecha", "DATE").Replace("caracter", "varchar(20)");
            try
            {
                metodos.TablaCrear(nuevo1, nuevo2);
                Console.WriteLine("----------------------");
                Console.WriteLine("Se ha creado la tabla: {0}.", output);
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
        #endregion

        #region "Borrar tabla"
        static void BorraTabla(string cadena2, string nuevo1)
        {
            Metodos_DDL metodos = new Metodos_DDL();
            int found = cadena2.IndexOf(";");
            cadena2 = cadena2.Remove(found);

            string nuevo2 = cadena2.Substring(12);

            try
            {
                metodos.BorraTable(nuevo1, nuevo2);
                Console.WriteLine("----------------------");
                Console.WriteLine("Se ha borrado la tabla: {0} de la base de datos: {1}", nuevo2, nuevo1);
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
        #endregion

        #region "Muestra tablas"
        static void MuestraTabla(string nuevo1)
        {
            Metodos_DDL metodos = new Metodos_DDL();
            try
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("Tablas de "+nuevo1+":");
                metodos.MostrarTablas(nuevo1);
                Console.WriteLine("----------------------");
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
        #endregion

        #region "Muestra tabla"
        static void MuestraTabla1(string tabla, string database)
        {
            Metodos_DDL metodos = new Metodos_DDL();

            int found = tabla.IndexOf(";");
            tabla = tabla.Remove(found);

            string tabla1 = tabla.Substring(14);

            try
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("Campos de tabla: " + tabla1);
                Console.WriteLine("----------------------");
                Console.WriteLine("{0}\t|\t{1}", "Nombre", "Tipo de dato");
                metodos.MostrarTabla(database,tabla1);
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
        #endregion

        #region "Borrar base de datos"
        static void Borrar(string cadena)
        {
            Metodos_DDL metodos = new Metodos_DDL();
            int found = cadena.IndexOf(";");
            cadena = cadena.Remove(found);

            string nuevo = cadena.Substring(11);
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
        #endregion

        #region "Crear base de dato"
        static void Crear(string cadena)
        {
            Metodos_DDL metodos = new Metodos_DDL();
            int found = cadena.IndexOf(";");
            cadena = cadena.Remove(found);
            
            string nuevo = cadena.Substring(10);
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
        #endregion

        #region "Usar base de datos"
        static void Usar(string cadena)
        {
            Metodos_DDL metodos = new Metodos_DDL();
            int found = cadena.IndexOf(";");
            cadena = cadena.Remove(found);

            string nuevo = cadena.Substring(9);
            try
            {
                metodos.UsarBD(nuevo);
                Console.WriteLine("----------------------");
                Console.WriteLine("Se esta usando la base de datos: {0}.", nuevo);

                bool showMenuTablas = true;
                while (showMenuTablas)
                {
                    showMenuTablas = InicioTablas(nuevo);
                }
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
        #endregion

        #region "Mostrar bases de datos"
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
        #endregion
    }
}
