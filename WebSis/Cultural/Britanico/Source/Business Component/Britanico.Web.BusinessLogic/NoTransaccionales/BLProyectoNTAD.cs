using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.NoTransaccionales
{
    public class BLProyectoNTAD : IConsultar<BEProyecto>
    {
        private BEProyectoRepository oBEProyectoRepository;

        public BLProyectoNTAD()
        {
            oBEProyectoRepository = new BEProyectoRepository(Constantes.NOMBRECONEXION);
        }


        #region IConsultar<BEProyecto> Members

        public List<BEProyecto> ListarTodos()
        {
            return oBEProyectoRepository.uspMListarTodosProyecto();

        }


        public BEProyecto ListarRegistro(int idProyecto)
        {
            return oBEProyectoRepository.uspMListarRegistroProyecto(idProyecto);
        }

        #endregion

        #region IConsultar<BEProyecto> Members


        public List<BEProyecto> ListarTodos(BEProyecto Filtro)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
