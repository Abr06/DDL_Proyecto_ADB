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
            Int_Usuario usuario = new Int_Usuario();
            Console.Clear();
            bool showMenu;
            do
            {
                showMenu = usuario.Inicio();
            } while (showMenu);
            Console.WriteLine("Saliste del DDL.");
        }
    }
}
