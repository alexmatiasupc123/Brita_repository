using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.NoTransaccionales
{
    public class BLPublicacionesNTAD : IConsultar<BEPublicaciones>
    {
        private BEPublicacionesRepository oBEPublicacionesRepository;

        public BLPublicacionesNTAD()
        {
            oBEPublicacionesRepository = new BEPublicacionesRepository(Constantes.NOMBRECONEXION);
        }


        #region IConsultar<BEPublicaciones> Members

        public List<BEPublicaciones> ListarTodos()
        {
            return oBEPublicacionesRepository.uspMListarTodosPublicacion();

        }


        public BEPublicaciones ListarRegistro(int idPublicaciones)
        {
            return oBEPublicacionesRepository.uspMListarRegistroPublicacion(idPublicaciones);
        }

        #endregion

        #region IConsultar<BEPublicaciones> Members


        public List<BEPublicaciones> ListarTodos(BEPublicaciones Filtro)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
