using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.NoTransaccionales
{
    public class BLMuestraGaleriaNTAD : IConsultar<BEMuestraGaleria>
    {
        private BEMuestraGaleriaRepository oBEMuestraGaleriaRepository;

        public BLMuestraGaleriaNTAD()
        {
            oBEMuestraGaleriaRepository = new BEMuestraGaleriaRepository(Constantes.NOMBRECONEXION);
        }


        #region IConsultar<BEMuestraGaleria> Members

        public List<BEMuestraGaleria> ListarTodos()
        {
            return oBEMuestraGaleriaRepository.uspMListarTodosMuestraGaleria();

        }


        public List<BEMuestraGaleria> ListarTodosXGaleria(int idGaleria)
        {
            return oBEMuestraGaleriaRepository.uspMListarTodosMuestraGaleriaXGaleria(idGaleria);

        }


        public BEMuestraGaleria ListarRegistro(int idMuestraGaleria)
        {
            return oBEMuestraGaleriaRepository.uspMListarRegistroMuestraGaleria(idMuestraGaleria);
        }

        #endregion

        #region IConsultar<BEMuestraGaleria> Members


        public List<BEMuestraGaleria> ListarTodos(BEMuestraGaleria Filtro)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
