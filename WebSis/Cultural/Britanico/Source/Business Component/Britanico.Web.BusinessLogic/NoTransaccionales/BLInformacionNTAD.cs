using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.NoTransaccionales
{
    public class BLInformacionNTAD : IConsultar<BEInformacion>
    {
        private BEInformacionRepository oBEInformacionRepository;

        public BLInformacionNTAD()
        {
            oBEInformacionRepository = new BEInformacionRepository(Constantes.NOMBRECONEXION);
        }


        #region IConsultar<BEInformacion> Members

        public List<BEInformacion> ListarTodos()
        {
            return oBEInformacionRepository.uspMListarTodosProximamente();

        }


        public List<BEInformacion> ListarTodosXEvento(Int32 even_tipo)
        {
            return oBEInformacionRepository.uspMListarTodosInformacionXEvento(even_tipo);

        }

        
        public BEInformacion ListarRegistro(int idInformacion)
        {
            return oBEInformacionRepository.uspMListarRegistroInformacion(idInformacion);
        }

        #endregion

        #region IConsultar<BEInformacion> Members


        public List<BEInformacion> ListarTodos(BEInformacion Filtro)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
