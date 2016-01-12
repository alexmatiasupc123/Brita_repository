using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.NoTransaccionales
{
    public class BLConcursoNTAD : IConsultar<BEConcurso>
    {
        private BEConcursoRepository oBEConcursoRepository;

        public BLConcursoNTAD()
        {
            oBEConcursoRepository = new BEConcursoRepository(Constantes.NOMBRECONEXION);
        }


        #region IConsultar<BEConcurso> Members

        public List<BEConcurso> ListarTodos()
        {
            return oBEConcursoRepository.uspMListarTodosConcurso();

        }


        public BEConcurso ListarRegistro(int idConcurso)
        {
            return oBEConcursoRepository.uspMListarRegistroConcurso(idConcurso);
        }

        #endregion

        #region IConsultar<BEConcurso> Members


        public List<BEConcurso> ListarTodos(BEConcurso Filtro)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
