using System;
using System.Collections.Generic;
using System.Text;

namespace Britanico.Interfaces
{
    public interface IMantenimiento<T> 
    {
        void Modificar(T Objeto);
        void Eliminar(int idEntidad);
        void Agregar(T Objeto);
       
    }   

}
