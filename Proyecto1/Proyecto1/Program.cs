using System;
using System.IO;
namespace Proyecto1
{
    class Program
    {
        String  name = "emusk";
        public static String ubicacion;
        public string cumpleAlvaro = "16 de junio";
       // public string cumple
        static void Main(string[] args)
        {

            //ListaVersiones<string> lista= new ListaVersiones<string>();
            Controlador con = new Controlador();
            Program p= new Program();
            string dir= @"c:\"+p.name+" begin ", comando,ruta;
            bool op=false;
            int nocommand;
            string[] allfiles= new string[10];
           do
            {
                Console.WriteLine("ingrese comando inicial:");
                comando = Console.ReadLine();
               // comando = comando.Replace(" ", "");//elimina espacios
                if(comando!="exit")
                if ((comando.Length > dir.Length))
                {
                    if (comando.Substring(0, dir.Length).Equals(dir))
                    {
                        //verificar que existe la ubicacion 
                        ruta = comando.Remove(0, dir.Length);
                        if (Directory.Exists(ruta))
                        {
                                allfiles = Directory.GetFiles(ruta, "*.*", SearchOption.AllDirectories);
                                //Console.WriteLine(allfiles[0]);
                                ubicacion = allfiles[0];
                                op = true;
                            Console.WriteLine("Archivo a dar seguiimiento: "+ allfiles[0]) ;

                        }else { Console.WriteLine("ruta no encontrada"); }
                    } else { Console.WriteLine("valor inválido"); }
                } else { Console.WriteLine("valor inválido"); }

            } while (comando!="exit"&& !op );
            //ubicacion = C:\Users\Adriana P\Desktop\hola.hh.txt;
            do
            {
                comando = Console.ReadLine();
                
                nocommand = opcion(comando);
                comando = comando.Replace(" ", "");
                switch (nocommand)
                {
                    case 1://save
                        //comando=comando.Replace(" ", "");
                        con.Save(comando.Remove(0,(p.name.Length+4)));
                        
                        break;
                    case 2://compass
                        Console.WriteLine("Version\t fecha y hora\t\t   comentario");
                        Console.WriteLine("------------------------------------------------------------");
                        con.rec();
                        break;
                    case 3://watch
                        comando = comando.Remove(0, (p.name.Length + 5));
                        Console.WriteLine("[" + comando + "]");
                        int numBus = Int32.Parse(comando);
                        con.watch(numBus);
                        break;
                    case 4://delete
                        comando = comando.Remove(0,(p.name.Length+6));
                        int numDel = Int32.Parse(comando);
                        con.Delete(numDel);
                        break; 

                    case 5://cambiar de directorio
                        comando = comando.Replace(" ", "");
                        ruta = comando.Remove(0, dir.Length);
                        allfiles = new string[10];
                        //Console.WriteLine(ruta);
                        allfiles = Directory.GetFiles(ruta, "*.*", SearchOption.AllDirectories);
                        Console.WriteLine("nueva ubicacion de archivo:"+allfiles[0]);
                        break;
                    default:
                        //Console.WriteLine("comando no valido");
                        break;
                }//switch
            } while (comando != "exit");


        }//main
       

        static int opcion(String pr)
        {
            String comando,ruta;
            Program p = new Program();
            int nq=8;
            bool v=true;
            string dir = @"c:\" + p.name + "begin";
            if (pr.Length> p.name.Length) 
            {
                pr = pr.Replace(" ","");
                //si la primera palabra esel nombre
                if (p.name.Equals(pr.Substring(0, p.name.Length)))
                {
                    //Console.WriteLine("hasta ahora bien");
                    comando = pr.Remove(0, p.name.Length);
                    //tipo de comando
                    //save
                    if (comando.Length>=4) { 

                        if (comando.Substring(0, 4)==("save"))
                        {
                            nq = 0;
                            comando = comando.Remove(0, 4);
                            if (comando.Equals(""))
                            {
                                Console.WriteLine("falta agregar comentario");
                                
                            }
                            else
                            {
                                return 1;
                            }
                        }//save
                        if(comando.Length>=5)
                         if (comando.Substring(0, 5)==("watch"))
                        {
                            comando = comando.Remove(0, 5);
                            if (comando.Equals(""))
                            {
                                Console.WriteLine("falta agregar la version");
                            }
                            else
                            {
                                for (int i = 0; i < comando.Length; i++)
                                {
                                    if (!(comando.Substring(i, i + 1) == "1" || comando.Substring(i, i + 1) == "2" || comando.Substring(i, i + 1) == "3" || comando.Substring(i, i + 1) == "4" || comando.Substring(i, i + 1) == "5" || comando.Substring(i, i + 1) == "6" || comando.Substring(i, i + 1) == "7" || comando.Substring(i, i + 1) == "8" || comando.Substring(i, i + 1) == "9" || comando.Substring(i, i + 1) == "0"))
                                        v = false;
                                }
                                if (v)
                                {
                                    return 3;
                                }
                                else
                                {
                                    Console.WriteLine("la version que desea ver debe tener un valor numerico numericos");
                                }
                            }
                        }//watch
                        if(comando.Length>=6)
                        if (comando.Substring(0, 6)==("delete"))
                        {
                            comando = comando.Remove(0, 6);
                            if (comando.Equals(""))
                            {
                                Console.WriteLine("falta agregar la version");
                            }
                            else
                            {
                                for (int i = 0; i < comando.Length; i++)
                                {
                                        string d;//= comando.Substring(0, 1);
                                        d = comando.Remove(0, 1);
                                        //Console.WriteLine("[" + d + "]");
                                        if (!(comando.Substring(i, i + 1) == "1" || comando.Substring(i, i + 1) == "2" || comando.Substring(i, i + 1) == "3" || comando.Substring(i, i + 1) == "4" || comando.Substring(i, i + 1) == "5" || comando.Substring(i, i + 1) == "6" || comando.Substring(i, i + 1) == "7" || comando.Substring(i, i + 1) == "8" || comando.Substring(i, i + 1) == "9" || comando.Substring(i, i + 1) == "0"))
                                       // if (d!="1" && d!="2" && d != "3"&& d!="4" && d != "5"&& d!="6" && d != "7"&& d!="8" && d != "9"&& d!="0")    
                                        v = false;
                                }
                                if (v)
                                {
                                    return 4;
                                }
                                else
                                {
                                    Console.WriteLine("la version que desea eliminar debe llevar solo valores numericos");
                                }
                            }

                        }//delete
                        if(comando.Length>=7)
                        if (comando.Substring(0, 7)==("compass"))
                        {
                            comando = comando.Remove(0, 7);
                            if (comando.Equals(""))
                            {
                                return 2;
                            }
                            else
                            {
                                Console.WriteLine("comando incorrecto");
                            }
                        }//compass
                    }
                    else { Console.WriteLine("comando invalido"); }


                }
                else
                {
//if***************************
                    if(nq==8)
                    if (pr.Substring(0, dir.Length).Equals(dir)) 
                    {
                        ruta = pr.Remove(0, dir.Length);
                        if (Directory.Exists(ruta))
                        {
                            return 5;
                        }
                        else
                        {
                            Console.WriteLine("Ruta no encontrada");
                        }
                    }
                    else
                    {
                        Console.WriteLine("comando incorrecto");
                    }
                }
                /*else
                {
                    Console.WriteLine("comando incorrecto");
                }*/
            }
            else
            {
                Console.WriteLine("comando incorrecto");
            }
            return 0;
        }
    }//class
}
