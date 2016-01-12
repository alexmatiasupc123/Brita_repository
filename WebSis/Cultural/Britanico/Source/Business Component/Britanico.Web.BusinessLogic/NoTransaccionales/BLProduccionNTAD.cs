using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.NoTransaccionales
{
    public class BLProduccionesNTAD : IConsultar<BEProducciones>
    {
        private BEProduccionesRepository oBEProduccionesRepository;

        public BLProduccionesNTAD()
        {
            oBEProduccionesRepository = new BEProduccionesRepository(Constantes.NOMBRECONEXION);
        }


        #region IConsultar<BEProducciones> Members

        public List<BEProducciones> ListarTodos()
        {
            return oBEProduccionesRepository.uspMListarTodosProducciones();

        }


        public BEProducciones ListarRegistro(int idProducciones)
        {
            return oBEProduccionesRepository.uspMListarRegistroProducciones(idProducciones);
        }

        #endregion

        #region IConsultar<BEProducciones> Members


        public List<BEProducciones> ListarTodos(BEProducciones Filtro)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
