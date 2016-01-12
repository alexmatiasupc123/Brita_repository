using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.NoTransaccionales
{
    public class BLCategoriaEventoNTAD : IConsultar<BECategoriaEvento>
    {
        private BECategoriaEventoRepository oBECategoriaEventoRepository;

        public BLCategoriaEventoNTAD()
        {
            oBECategoriaEventoRepository = new BECategoriaEventoRepository(Constantes.NOMBRECONEXION);
        }


        #region IConsultar<BECategoriaEvento> Members

        public List<BECategoriaEvento> ListarTodos()
        {
            return oBECategoriaEventoRepository.uspMListarTodosCategora();

        }


        public BECategoriaEvento ListarRegistro(int idCategoriaEvento)
        {
            return oBECategoriaEventoRepository.uspMListarRegistroCategoria(idCategoriaEvento);
        }

        #endregion

        #region IConsultar<BECategoriaEvento> Members


        public List<BECategoriaEvento> ListarTodos(BECategoriaEvento Filtro)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
