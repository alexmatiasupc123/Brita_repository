using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.NoTransaccionales
{
    public class BLCabeceraNTAD : IConsultar<BECabecera>
    {
        private BECabeceraRepository oBECabeceraRepository;

        public BLCabeceraNTAD()
        {
            oBECabeceraRepository = new BECabeceraRepository(Constantes.NOMBRECONEXION);
        }


        #region IConsultar<BECabecera> Members

        public BECabecera ListarRegistro(int cabe_codi)
        {
            throw new Exception("The method or operation is not implemented.");
        }

       public BECabecera ListarXTitulo(string cabe_titu)
        {
            return oBECabeceraRepository.uspMListarXTituloCabecera(cabe_titu);
        }

        public List<BECabecera> ListarTodos()
        {
            return oBECabeceraRepository.uspMListarTodosCabecera();

        }
        public List<BECabecera> ListarTodos(BECabecera Filtro)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        
    }
}
