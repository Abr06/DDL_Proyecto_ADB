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
