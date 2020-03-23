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

        public void CrearBD(string nameBD)
        {
            comando.Connection = conexioMySQL.AbrirConexion();
            comando.CommandText = "create database "+nameBD+";";
            comando.CommandType = CommandType.Text;
            //comando.Parameters.AddWithValue("@namebd",nameBD);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexioMySQL.CerrarConexion();
        }

        public void EliminiarBD(string nameBD)
        {
            comando.Connection = conexioMySQL.AbrirConexion();
            comando.CommandText = "drop database "+nameBD+";";
            comando.CommandType = CommandType.Text;
            //comando.Parameters.AddWithValue("nameBD",nameBD);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
            conexioMySQL.CerrarConexion();
        }
    }
}
