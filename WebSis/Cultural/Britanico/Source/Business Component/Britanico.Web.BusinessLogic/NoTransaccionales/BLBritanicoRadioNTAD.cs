using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.NoTransaccionales
{
    public class BLBritanicoRadioNTAD : IConsultar<BEBritanicoRadio>
    {
        private BEBritanicoRadioRepository oBEBritanicoRadioRepository;

        public BLBritanicoRadioNTAD()
        {
            oBEBritanicoRadioRepository = new BEBritanicoRadioRepository(Constantes.NOMBRECONEXION);
        }


        #region IConsultar<BEBritanicoRadio> Members

        public List<BEBritanicoRadio> ListarTodos()
        {
            return oBEBritanicoRadioRepository.uspMListarTodosBritanicoRadio();

        }


        public BEBritanicoRadio ListarRegistro(int idBritanicoRadio)
        {
            return oBEBritanicoRadioRepository.uspMListarRegistroBritanicoRadio(idBritanicoRadio);
        }

        #endregion

        #region IConsultar<BEBritanicoRadio> Members


        public List<BEBritanicoRadio> ListarTodos(BEBritanicoRadio Filtro)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
