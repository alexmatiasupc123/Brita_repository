using System;
using System.Collections.Generic;
using System.Text;

namespace Britanico.Interfaces
{
    public interface IProxy<dt>
    {
        List<dt> ListarTodos();
        dt ListarRegistro(int id);
        void Agregar(dt Entidad);
        void Modificar(dt Entidad);
        void Eliminar(dt Entidad);
    }
}
