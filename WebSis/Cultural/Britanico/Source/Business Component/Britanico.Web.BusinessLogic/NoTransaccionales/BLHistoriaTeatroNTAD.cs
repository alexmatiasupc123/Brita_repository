using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.NoTransaccionales
{
    public class BLHistoriaTeatroNTAD : IConsultar<BEHistoriaTeatro>
    {
        private BEHistoriaTeatroRepository oBEHistoriaTeatroRepository;

        public BLHistoriaTeatroNTAD()
        {
            oBEHistoriaTeatroRepository = new BEHistoriaTeatroRepository(Constantes.NOMBRECONEXION);
        }


        #region IConsultar<BEHistoriaTeatro> Members



        public BEHistoriaTeatro ListarRegistro(int histo_codi)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<BEHistoriaTeatro> ListarTodos()
        {
            return oBEHistoriaTeatroRepository.uspMListarTodosHistoriaTeatro();

        }
        public List<BEHistoriaTeatro> ListarTodos(BEHistoriaTeatro Filtro)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        
    }
}
