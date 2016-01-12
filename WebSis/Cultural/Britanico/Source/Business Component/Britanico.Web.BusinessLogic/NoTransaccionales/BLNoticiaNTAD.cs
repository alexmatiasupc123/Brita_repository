using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.NoTransaccionales
{
    public class BLNoticiaNTAD : IConsultar<BENoticia>
    {
        private BENoticiaRepository oBENoticiaRepository;

        public BLNoticiaNTAD()
        {
            oBENoticiaRepository = new BENoticiaRepository(Constantes.NOMBRECONEXION);
        }


        #region IConsultar<BENoticia> Members

        public List<BENoticia> ListarTodos()
        {
            return oBENoticiaRepository.uspMListarTodosNoticia();

        }
        public List<BENoticia> ListarTodosXMes()
        {
            return oBENoticiaRepository.uspMListarTodosNoticiaXMes();

        }

        public BENoticia ListarRegistro(int idNoticia)
        {
            return oBENoticiaRepository.uspMListarRegistroNoticia(idNoticia);
        }

        #endregion

        #region IConsultar<BENoticia> Members


        public List<BENoticia> ListarTodos(BENoticia Filtro)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
