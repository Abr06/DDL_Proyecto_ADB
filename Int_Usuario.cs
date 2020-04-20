using MySql.Data.MySqlClient;//Libreria para conexion
using System;
using System.Collections.Generic;
using System.Text;

namespace MySQL_DDL
{
    public class Int_Usuario
    {
        Metodos_DDL metodos;
        public Int_Usuario()
        {
            Conexion();
        }
        #region "MenuPrincipal"
        public bool Inicio()
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("Ingrese texto");
            string cadena = Console.ReadLine();

            switch (cadena.ToLower())
            {
                case string _ when cadena.ToLower().StartsWith("exit"):
                    Console.WriteLine("----------------------");
                    metodos.Fin_Conexion();
                    return false;
                case string _ when cadena.EndsWith(";") == false:
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
        public bool InicioTablas(string nuevo1)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine("Ingrese texto para tablas:");
            string cadena = Console.ReadLine();

            switch (cadena.ToLower())
            {
                case string _ when cadena.ToLower().StartsWith("crea tabla"):
                    TablaCrear(cadena, nuevo1);
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
        public void AgregarCampo(string cadena2, string nuevo1)
        {
            int found;
            try
            {
                found = cadena2.IndexOf(";");
                cadena2 = cadena2.Remove(found);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error falto ;");
                return;
            }

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
        public void BorrarCampo(string cadena2, string nuevo1)
        {
            int found;
            try
            {
                found = cadena2.IndexOf(";");
                cadena2 = cadena2.Remove(found);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error falto ;");
                return;
            }

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
        public void ModificarCampo(string cadena2, string nuevo1)
        {
            int found;
            try
            {
                found = cadena2.IndexOf(";");
                cadena2 = cadena2.Remove(found);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error falto ;");
                return;
            }

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
        public void TablaCrear(string cadena2, string nuevo1)
        {
            int found;
            try
            {
                found = cadena2.IndexOf(";");
                cadena2 = cadena2.Remove(found);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error falto ;");
                return;
            }

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
        public void BorraTabla(string cadena2, string nuevo1)
        {
            int found;
            try
            {
                found = cadena2.IndexOf(";");
                cadena2 = cadena2.Remove(found);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error falto ;");
                return;
            }

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
        public void MuestraTabla(string nuevo1)
        {
            try
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("Tablas de " + nuevo1 + ":");
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
        public void MuestraTabla1(string tabla, string database)
        {
            int found;
            try
            {
                found = tabla.IndexOf(";");
                tabla = tabla.Remove(found);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error falto ;");
                return;
            }

            string tabla1 = tabla.Substring(14);

            try
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("Campos de tabla: " + tabla1);
                Console.WriteLine("----------------------");
                Console.WriteLine("{0}\t|\t{1}", "Nombre", "Tipo de dato");
                metodos.MostrarTabla(database, tabla1);
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
        public void Borrar(string cadena2)
        {
            int found;
            try
            {
                found = cadena2.IndexOf(";");
                cadena2 = cadena2.Remove(found);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error falto ;");
                return;
            }

            string nuevo = cadena2.Substring(11);
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
        public void Crear(string cadena2)
        {
            int found;
            try
            {
                found = cadena2.IndexOf(";");
                cadena2 = cadena2.Remove(found);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error falto ;");
                return;
            }

            string nuevo = cadena2.Substring(10);
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
        public void Usar(string cadena)
        {
            int found;
            try
            {
                found = cadena.IndexOf(";");
                cadena = cadena.Remove(found);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error falto ;");
                return;
            }

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
        public void Mostrar()
        {
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

        #region "Conexion con base de datos"
        public void Conexion()
        {
            Console.Write("Introdusca nombre de usuario: ");
            string usuario = Console.ReadLine();
            Console.Write("Introdusca contraseña: ");
            metodos = new Metodos_DDL(usuario, Console.ReadLine());
        }
        #endregion
    }
}
