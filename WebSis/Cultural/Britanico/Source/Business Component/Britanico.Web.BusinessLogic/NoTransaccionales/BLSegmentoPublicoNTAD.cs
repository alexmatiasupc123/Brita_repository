using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.NoTransaccionales
{
    public class BLSegmentoPublicoNTAD : IConsultar<BESegmentoPublico>
    {
        private BESegmentoPublicoRepository oBESegmentoPublicoRepository;

        public BLSegmentoPublicoNTAD()
        {
            oBESegmentoPublicoRepository = new BESegmentoPublicoRepository(Constantes.NOMBRECONEXION);
        }


        #region IConsultar<BESegmentoPublico> Members

        public List<BESegmentoPublico> ListarTodos()
        {
            return oBESegmentoPublicoRepository.uspMListarTodosSegmento();

        }


        public BESegmentoPublico ListarRegistro(int idSegmentoPublico)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IConsultar<BESegmentoPublico> Members


        public List<BESegmentoPublico> ListarTodos(BESegmentoPublico Filtro)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
