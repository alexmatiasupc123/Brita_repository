using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.NoTransaccionales
{
    public class BLBoletinNTAD : IConsultar<BEBoletin>
    {
        private BEBoletinRepository oBEBoletinRepository;

        public BLBoletinNTAD()
        {
            oBEBoletinRepository = new BEBoletinRepository(Constantes.NOMBRECONEXION);
        }


        #region IConsultar<BEBoletin> Members

        public List<BEBoletin> ListarTodos()
        {
            return oBEBoletinRepository.uspMListarTodosBoletin();

        }


        public BEBoletin ListarRegistro(int idBoletin)
        {
            return oBEBoletinRepository.uspMListarRegistroBoletin(idBoletin);
        }

        public BEBoletin UltimoBoletin()
        {
            return oBEBoletinRepository.uspMListarUltimoBoletin();
        }

        #endregion

        #region IConsultar<BEBoletin> Members


        public List<BEBoletin> ListarTodos(BEBoletin Filtro)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
