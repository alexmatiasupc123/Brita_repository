using System;
using System.Collections.Generic;
using System.Text;

namespace Britanico.Interfaces
{
    public interface IConsultar<T>
    {
        List<T> ListarTodos();
        List<T> ListarTodos(T Filtro);
      //  List<T> ListarTodos(int id);
        T ListarRegistro(int idEntidad);
        //List<T> LeerDatosGrilla<Filtro>(Filtro Entidad);
        //List<T> LeerDatosPaginacion<Filtro>(Filtro Entidad, int Pagina);
        //List<T> LeerTodosCombo();
        //List<T> LeerTodosCombo<Filtro>(Filtro Entidad);
    }
}
