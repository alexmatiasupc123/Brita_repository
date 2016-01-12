using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.NoTransaccionales
{
    public class BLSedeNTAD : IConsultar<BESede>
    {
        private BESedeRepository oBESedeRepository;

        public BLSedeNTAD()
        {
            oBESedeRepository = new BESedeRepository(Constantes.NOMBRECONEXION);
        }


        #region IConsultar<BESede> Members

        public List<BESede> ListarTodos()
        {
            return oBESedeRepository.uspMListarTodosSede();

        }

        public List<BESede> ListarTodosSedesCursos()
        {
            return oBESedeRepository.uspMListarTodosSedesCursos();

        }

        public List<BESede> ListarTodosSedesAuditorios()
        {
            return oBESedeRepository.uspMListarTodosSedesAuditorios();

        }


        public BESede ListarRegistro(int idSede)
        {
            return oBESedeRepository.uspMListarRegistroSede(idSede);
        }

        #endregion

        #region IConsultar<BESede> Members


        public List<BESede> ListarTodos(BESede Filtro)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
