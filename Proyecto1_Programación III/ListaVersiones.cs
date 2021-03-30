using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto1_Programación_III
{
    class ListaVersiones<T>
    {
        public Version<T> primero { set; get; }
        public Version<T> actual { set; get; }
        public Version<T> temporal { set; get; }
        public Version<T> ultimo { set; get; }

        public ListaVersiones()
        {
            primero = null;
        }

        public void Agregar(T pData, string pComentario, string pNombreNodo)
        {
            //Si no hay ningún dato, cerremos el método
            if (pData == null)
                return;
            else
            {
                if (primero == null)
                {
                    primero = new Version<T>(pData, pComentario, pNombreNodo);
                    primero.siguiente = null;
                    ultimo = primero;

                }
                else
                {

                    actual = ultimo;
                    if (actual.siguiente == null)
                    {
                        actual.siguiente = new Version<T>(pData, pComentario, pNombreNodo);
                        temporal = actual.siguiente;
                        temporal.siguiente = null;
                        ultimo = temporal;
                        actual = ultimo;
                    }
                }
            }
        }

        public void Recorrer(ListaVersiones<T> lista)
        {
            if (lista.primero != null)
            {
                int i = 0;
                lista.actual = lista.primero;
                do
                {
                    i++;
                    Console.WriteLine(i + ". " + lista.actual.data);
                    lista.actual = lista.actual.siguiente;
                } while (lista.actual != null);

            }

        }//fin del método

        public void RecorrerInverso(ListaVersiones<T> lista)
        {
            if (lista.primero != null)
            {
            //Recoree para contar cuántos elementos hay
                int i = 0;
                lista.actual = lista.primero;
                do
                {
                    i++;
                    lista.actual = lista.actual.siguiente;
                } while (lista.actual != null);
            //Hacemos un array con los datos de la lista y el tamaño establecido y guardamos en ese array los datos de la lista
                T[] nodos = new T[i];
                i = 0;
                lista.actual = lista.primero;
                do
                {
                    nodos[i] = lista.actual.data;
                    i++;
                    lista.actual = lista.actual.siguiente;
                } while (lista.actual != null);
                //Imprimimos lo que obtuvimos de mayor a menor
                while (i > 0)
                {
                    i--;
                    Console.WriteLine(i + ". " + nodos[i]);
                }

            }

        }//fin del método

        public ListaVersiones<T> Eliminar(ListaVersiones<T> lista, string pNombreNodo)
        {
            ListaVersiones<T> listaNueva = new ListaVersiones<T>();
            if (lista.primero != null)
            {
                int i = 1;
                lista.actual = lista.primero;
                if(lista.actual.siguiente != null) { 
                    while (lista.actual.siguiente != null)
                    {
                        
                        i++;
                    
                        if (lista.actual.nombreNodo.Equals(pNombreNodo))
                        {
                            lista.actual = lista.actual.siguiente;
                            Console.WriteLine("The node has been deleted!");
                            if (lista.actual.siguiente == null)
                            {
                                listaNueva.Agregar(lista.actual.data, lista.actual.versionComentario, lista.actual.nombreNodo);
                                return listaNueva;
                            }
                        }
                        if (lista.actual != null)
                        {
                            listaNueva.Agregar(lista.actual.data, lista.actual.versionComentario, lista.actual.nombreNodo);
                            lista.actual = lista.actual.siguiente;
                        }
                        
                    }
                    }
                if (lista.actual.siguiente == null && lista.actual != null)
                    listaNueva.Agregar(lista.ultimo.data, lista.actual.versionComentario, pNombreNodo);
                lista = listaNueva;
            }
            return listaNueva;
        }

    }
}
