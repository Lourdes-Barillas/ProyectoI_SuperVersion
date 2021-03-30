using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Proyecto1
{
    class Controlador
    {
        private string fileName;
        private string path;
        private static string infofile="";
        private static int numeroNodo=0;
        public ListaVersiones<String> listaString { set; get; }

        public Controlador()
        {
            listaString = new ListaVersiones<string>();
        }
        public void Init()
        {
            //Pedimos el path
            Console.Write("Specify a path for your folder\nc:" + @"\");
            string pathString = @"" + Console.ReadLine();

            //Pedimos el nombre del proyecto
            fileName = Console.ReadLine();

            //Combinamos el path
            this.path = System.IO.Path.Combine(pathString, fileName);

            //Revisamos si existe
            if (!System.IO.File.Exists(path))
            {
                //Si no existe, entonces lo crearemos
                Console.WriteLine("This path isn't correct. Try again with another one.");
            }
            else //Si el archivo ya existe
            {
                Console.WriteLine("File already exists.");
                return;
            }
        }
        public void rec() {
            listaString.RecorrerInverso(this.listaString);
        }

        public string Save(string comentario)
        {
            DateTime fecha = DateTime.Now;
            //Tomamos el texto del archivo
            //string comentario;
            String textInTheFile = File.ReadAllText(Program.ubicacion);
            ListaVersiones<string> versiones = new ListaVersiones<string>();
            //Console.WriteLine("Nombre: ");
            //string nombreNodo = Console.ReadLine();
            
            //El nodo ha sido agregado
            if (!textInTheFile.Equals(infofile))
            {
                infofile = textInTheFile;
                numeroNodo = numeroNodo + 1;
                listaString.Agregar(textInTheFile, comentario,fecha, numeroNodo);
                
                Console.WriteLine("\nNode Added ");

                //Creemos el archivo txt

                listaString.Actualizar(listaString);
                //versiones.Recorrer(versiones);
                //this.listaString = versiones;

                return listaString.primero.data;
            }
            else
                Console.WriteLine("no hubieron cambios en el archivo");
            return "";
        }

        //c:\emusk begin c:\users\deleo\desktop\zero

        public void Delete(int datobuscar)
        {

            // Console.WriteLine("Cuál versión quieres eliminar?");
            //string nombreNodo = Console.ReadLine();
            this.listaString = this.listaString.Eliminar(this.listaString,datobuscar);
           
            this.listaString.Actualizar(this.listaString);
        }
        public void watch(int numBuscar)
        {
            string nodo = this.listaString.Buscar(this.listaString, numBuscar);
            Console.WriteLine("\n" + nodo);
        }
    }
}
