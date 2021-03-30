using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto1
{
    class Version<T>
    {
        public Version<T> siguiente { set; get; }
        public T data { set; get; }

        public string versionComentario { set; get; }
        public int numeroNodo { set; get; }
        public DateTime fechaHora { set; get; }
       // public string 

        public Version(T pData, string pVersionComentario,DateTime pfecha, int pNumeroNodo)
        {
            siguiente = null;
            data = pData;
            versionComentario = pVersionComentario;
            numeroNodo = pNumeroNodo;
            fechaHora = pfecha;
        }
 
        public static implicit operator Version(Version<T> v)
        {
            throw new NotImplementedException();
        }
    }
}

