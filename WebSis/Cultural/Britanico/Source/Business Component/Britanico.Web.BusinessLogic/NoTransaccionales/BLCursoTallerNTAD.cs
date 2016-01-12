using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.NoTransaccionales
{
    public class BLCursoTallerNTAD : IConsultar<BECursoTaller>
    {
        private BECursoTallerRepository oBECursoTallerRepository;

        public BLCursoTallerNTAD()
        {
            oBECursoTallerRepository = new BECursoTallerRepository(Constantes.NOMBRECONEXION);
        }


        #region IConsultar<BECursoTaller> Members

        public List<BECursoTaller> ListarTodos()
        {
            return oBECursoTallerRepository.uspMListarTodosCursoTaller();

        }

        public List<BECursoTaller> ListarTodosDestacados()
        {
            return oBECursoTallerRepository.uspMListarTodosCursoTallerDestacados();

        }


        public List<BECursoTaller> ListarTodos(Int32 sede)
        {
            return oBECursoTallerRepository.uspMListarTodosCursosXSede(sede);

        }

        public BECursoTaller ListarRegistro(int idCursoTaller)
        {
            return oBECursoTallerRepository.uspMListarRegistroCurso(idCursoTaller);
        }

        #endregion

        #region IConsultar<BECursoTaller> Members


        public List<BECursoTaller> ListarTodos(BECursoTaller Filtro)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
