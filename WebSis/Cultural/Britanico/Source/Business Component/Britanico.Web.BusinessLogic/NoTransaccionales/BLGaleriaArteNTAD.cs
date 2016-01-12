using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.NoTransaccionales
{
    public class BLGaleriaArteNTAD : IConsultar<BEGaleriaArte>
    {
        private BEGaleriaArteRepository oBEGaleriaArteRepository;

        public BLGaleriaArteNTAD()
        {
            oBEGaleriaArteRepository = new BEGaleriaArteRepository(Constantes.NOMBRECONEXION);
        }


        #region IConsultar<BEGaleriaArte> Members

        public List<BEGaleriaArte> ListarTodos()
        {
            return oBEGaleriaArteRepository.uspMListarTodosGaleria();

        }


        public BEGaleriaArte ListarRegistro(int idGaleriaArte)
        {
            return oBEGaleriaArteRepository.uspMListarRegistroGaleria(idGaleriaArte);
        }

        #endregion

        #region IConsultar<BEGaleriaArte> Members


        public List<BEGaleriaArte> ListarTodos(BEGaleriaArte Filtro)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
