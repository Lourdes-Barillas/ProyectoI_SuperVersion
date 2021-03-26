using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto1_Programación_III
{
    class Controlador
    {
        
        private string fileName;
        private string path;
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
                using (System.IO.FileStream fs = System.IO.File.Create(path))
                {
                    //fs.Write("");
                }
            }
            else //Si el archivo ya existe
            {
                Console.WriteLine("File \"{0}\" already exists.");
                return;
            }
        }


        public string Save()
        {
            //Tomamos el texto del archivo
            string comentario;
            string textInTheFile = System.IO.File.ReadAllText(@""+ path);
            ListaVersiones<string> versiones = new ListaVersiones<string>();
            Console.WriteLine("Comentario: "); 
            comentario = Console.ReadLine();
            Console.WriteLine("Nombre: ");
            string nombreNodo = Console.ReadLine();

            //El nodo ha sido agregado
            listaString.Agregar(textInTheFile, comentario, nombreNodo);
            Console.WriteLine("\nNode Added");

            //Creemos el archivo txt

            listaString.Recorrer(listaString);
            //versiones.Recorrer(versiones);
            //this.listaString = versiones;

            return listaString.primero.data;
        }


        public void Delete()
        {

            Console.WriteLine("Cuál versión quieres eliminar?");
            string nombreNodo = Console.ReadLine();
            this.listaString.Recorrer(this.listaString.Eliminar(this.listaString, nombreNodo));
        }

    }


}
/*
 * 
 * //Revisamos si existe
            if (!System.IO.File.Exists(this.path))
            {
                //Si no existe, entonces lo crearemos
                Console.WriteLine("This path isn't correct. Try again with another one.");
                using (System.IO.FileStream fs = System.IO.File.Create(path))
                {
                    //fs.Write("");
                }
            }
 */