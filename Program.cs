using MySql.Data.MySqlClient;//Libreria para conexion
using System;

namespace MySQL_DDL
{
    class Program
    {
        static void Main(string[] args)
        {
            MySQL mySQL = new MySQL("localhost", "3306", "Abr06", "susana24");//puerto default de mysql 3306
            Console.WriteLine(mySQL.VerBases());
            Console.ReadKey();
        }
    }
}
