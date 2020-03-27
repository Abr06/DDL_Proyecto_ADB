using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace MySQL_DDL
{
    public class Metodos_DDL
    {
        private ConexioMySQL conexioMySQL = new ConexioMySQL();

        MySqlCommand comando= new MySqlCommand();
        MySqlDataReader reader;

        public void CrearBD(string nameBD)
        {
            comando.Connection = conexioMySQL.AbrirConexion();
            comando.CommandText = "create database "+nameBD+";";
            comando.CommandType = CommandType.Text;
            //comando.Parameters.AddWithValue("@namebd",nameBD);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            comando.Connection = conexioMySQL.CerrarConexion();
        }

        public void BorrarBD(string nameBD)
        {
            comando.Connection = conexioMySQL.AbrirConexion();
            comando.CommandText = "drop database "+nameBD+";";
            comando.CommandType = CommandType.Text;
            //comando.Parameters.AddWithValue("nameBD",nameBD);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            comando.Connection = conexioMySQL.CerrarConexion();
        }

        public void UsarBD(string nameBD)
        {
            comando.Connection = conexioMySQL.AbrirConexion();
            comando.CommandText = "use " + nameBD + ";";
            comando.CommandType = CommandType.Text;
            //comando.Parameters.AddWithValue("nameBD",nameBD);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            //conexioMySQL.CerrarConexion();
        }

        public void TablaCrear(string nameBD,string nameTable)
        {
            comando.Connection = conexioMySQL.AbrirConexion();
            comando.CommandText = "use "+nameBD+"; create table " + nameTable +";";
            comando.CommandType = CommandType.Text;
            //comando.Parameters.AddWithValue("nameBD",nameBD);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            //conexioMySQL.CerrarConexion();
        }

        public void BorraTable(string nameBD, string nameTable)
        {
            comando.Connection = conexioMySQL.AbrirConexion();
            comando.CommandText = "use " + nameBD + "; drop table " + nameTable + ";";
            comando.CommandType = CommandType.Text;
            //comando.Parameters.AddWithValue("nameBD",nameBD);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            //conexioMySQL.CerrarConexion();
        }

        public void MostrarTablas(string nameBD)
        {
            comando.Connection = conexioMySQL.AbrirConexion();
            comando.CommandText = "use "+nameBD+"; show tables;";
            comando.CommandType = CommandType.Text;
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("----------------------");
                Console.WriteLine(reader.GetString(0));
            }
            reader.Close();
            comando.Connection = conexioMySQL.CerrarConexion();
        }

        public void MostrarTabla(string nameBD, string nameTable)
        {
            comando.Connection = conexioMySQL.AbrirConexion();
            comando.CommandText = "use " + nameBD + "; SELECT COLUMN_NAME,DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '"+nameTable+"';";
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
            comando.Connection = conexioMySQL.CerrarConexion();
        }

        public void AgregarCampo(string nameBD, string nameTable)
        {
            comando.Connection = conexioMySQL.AbrirConexion();
            comando.CommandText = "use "+nameBD+"; ALTER TABLE " + nameTable + ";";
            comando.CommandType = CommandType.Text;
            //comando.Parameters.AddWithValue("nameBD",nameBD);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            //conexioMySQL.CerrarConexion();
        }

        public void BorrarCampo(string nameBD, string nameTable)
        {
            comando.Connection = conexioMySQL.AbrirConexion();
            comando.CommandText = "use " + nameBD + "; ALTER TABLE " + nameTable + ";";
            comando.CommandType = CommandType.Text;
            //comando.Parameters.AddWithValue("nameBD",nameBD);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            //conexioMySQL.CerrarConexion();
        }

        public void ModificarCampo(string nameBD, string nameTable)
        {
            comando.Connection = conexioMySQL.AbrirConexion();
            comando.CommandText = "use " + nameBD + "; ALTER TABLE " + nameTable + ";";
            comando.CommandType = CommandType.Text;
            //comando.Parameters.AddWithValue("nameBD",nameBD);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            //conexioMySQL.CerrarConexion();
        }

        public void Mostrar()
        {
            comando.Connection = conexioMySQL.AbrirConexion();
            comando.CommandText = "show databases;";
            comando.CommandType = CommandType.Text;
            reader = comando.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("----------------------");
                Console.WriteLine(reader.GetString(0));
            }
            reader.Close();
            comando.Connection=conexioMySQL.CerrarConexion();
        }
    }
}
