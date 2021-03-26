using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto1_Programación_III
{
    class Version<T>
    {
        public Version<T> siguiente { set; get; }
        public T data { set; get; }
        public string versionComentario { set; get; }
        public string nombreNodo { set; get; }
        public Version(T pData, string pVersionComentario, string pNombreNodo)
        {
            siguiente = null;
            data = pData;
            versionComentario = pVersionComentario;
            nombreNodo = pNombreNodo;
        }

        public static implicit operator Version(Version<T> v)
        {
            throw new NotImplementedException();
        }
    }
}
