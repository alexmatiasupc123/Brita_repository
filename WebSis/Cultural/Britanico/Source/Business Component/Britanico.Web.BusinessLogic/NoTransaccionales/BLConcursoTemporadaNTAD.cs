using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.NoTransaccionales
{
    public class BLConcursoTemporadaNTAD : IConsultar<BEConcursoTemporada>
    {
        private BEConcursoTemporadaRepository oBEConcursoTemporadaRepository;

        public BLConcursoTemporadaNTAD()
        {
            oBEConcursoTemporadaRepository = new BEConcursoTemporadaRepository(Constantes.NOMBRECONEXION);
        }


        #region IConsultar<BEConcursoTemporada> Members

        public List<BEConcursoTemporada> ListarTodos()
        {
            return oBEConcursoTemporadaRepository.uspMListarTodosConcursoTemporada();

        }

        public List<BEConcursoTemporada> ListarTodos(int conc_codi)
        {
            return oBEConcursoTemporadaRepository.uspMListarTodosConcursoTemporadaXConcurso(conc_codi);

        }


        public BEConcursoTemporada ListarRegistro(int idConcursoTemporada)
        {
            return oBEConcursoTemporadaRepository.uspMListarRegistroConcursoTemporada(idConcursoTemporada);
        }

        public BEConcursoTemporada ListarRegistroXConcurso(int idConcurso)
        {
            return oBEConcursoTemporadaRepository.uspMListarRegistroConcursoTemporadaXConcurso(idConcurso);
        }

        #endregion

        #region IConsultar<BEConcursoTemporada> Members


        public List<BEConcursoTemporada> ListarTodos(BEConcursoTemporada Filtro)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
