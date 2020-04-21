using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace MySQL_DDL
{
    public class Metodos_DDL
    {
        public ConexioMySQL conexioMySQL;
        private MySqlCommand comando;
        private MySqlDataReader reader;

        public Metodos_DDL(string usuario, string contraseña)
        {
            conexioMySQL = new ConexioMySQL(usuario,contraseña);
            comando = new MySqlCommand();
            comando.Connection = conexioMySQL.AbrirConexion();
        }

        public void CrearBD(string nameBD)
        {

            comando.CommandText = "create database "+nameBD+";";
            comando.CommandType = CommandType.Text;
            //comando.Parameters.AddWithValue("@namebd",nameBD); para que sirve
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void BorrarBD(string nameBD)
        {

            comando.CommandText = "drop database "+nameBD+";";
            comando.CommandType = CommandType.Text;
            //comando.Parameters.AddWithValue("nameBD",nameBD);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void UsarBD(string nameBD)
        {

            comando.CommandText = "use " + nameBD + ";";
            comando.CommandType = CommandType.Text;
            //comando.Parameters.AddWithValue("nameBD",nameBD);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            //conexioMySQL.CerrarConexion();
        }

        public void TablaCrear(string nameBD,string nameTable)
        {

            comando.CommandText = "use "+nameBD+"; create table " + nameTable +";";
            comando.CommandType = CommandType.Text;
            //comando.Parameters.AddWithValue("nameBD",nameBD);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void BorraTable(string nameBD, string nameTable)
        {

            comando.CommandText = "use " + nameBD + "; drop table " + nameTable + ";";
            comando.CommandType = CommandType.Text;
            //comando.Parameters.AddWithValue("nameBD",nameBD);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void MostrarTablas(string nameBD)
        { 
            comando.CommandText = "use "+nameBD+"; show tables;";
            comando.CommandType = CommandType.Text;
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("----------------------");
                Console.WriteLine(reader.GetString(0));
            }
            reader.Close();
        }

        public void MostrarTabla(string nameBD, string nameTable)
        {

            comando.CommandText = "use " + nameBD + "; SHOW COLUMNS FROM " + nameTable + ";";///Nuevo para tablas columnas
            //comando.CommandText = "use " + nameBD + "; SELECT COLUMN_NAME,DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '"+nameTable+"';";
            comando.CommandType = CommandType.Text;
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("----------------------");
                Console.WriteLine("{0}\t|\t{1}", 
                    reader.GetString(0), 
                    reader.GetString(1).Replace("int", "entero").Replace("decimal", "decimal").Replace("date", "fecha").Replace("varchar", "caracter").Replace("mediumtext", "long"));
            }
            reader.Close();

        }

        public void AgregarCampo(string nameBD, string nameTable)
        {

            comando.CommandText = "use "+nameBD+"; ALTER TABLE " + nameTable + ";";
            comando.CommandType = CommandType.Text;
            //comando.Parameters.AddWithValue("nameBD",nameBD);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void BorrarCampo(string nameBD, string nameTable)
        {

            comando.CommandText = "use " + nameBD + "; ALTER TABLE " + nameTable + ";";
            comando.CommandType = CommandType.Text;
            //comando.Parameters.AddWithValue("nameBD",nameBD);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void ModificarCampo(string nameBD, string nameTable)
        {

            comando.CommandText = "use " + nameBD + "; ALTER TABLE " + nameTable + ";";
            comando.CommandType = CommandType.Text;
            //comando.Parameters.AddWithValue("nameBD",nameBD);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();

        }

        public void Mostrar()
        {
            comando.CommandText = "show databases;";
            comando.CommandType = CommandType.Text;
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("----------------------");
                Console.WriteLine(reader.GetString(0));
            }
            reader.Close();
        }

        public void Fin_Conexion()
        {
            comando.Connection = conexioMySQL.CerrarConexion();
        }
    }
}
