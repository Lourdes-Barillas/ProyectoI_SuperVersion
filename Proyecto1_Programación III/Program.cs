using System;

namespace Proyecto1_Programación_III
{
    class Program
    {
        static void Main(string[] args)
        {
            Controlador controla = new Controlador();
            controla.Init();
            controla.Save();
            controla.Save();
            controla.Save();
            controla.Delete();
            
            //controla.Delete();
        }

       
    }
}
