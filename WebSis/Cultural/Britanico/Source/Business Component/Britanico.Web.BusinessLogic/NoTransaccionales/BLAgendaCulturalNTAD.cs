using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.NoTransaccionales
{
    public class BLAgendaCulturalNTAD : IConsultar<BEAgendaCultural>
    {
        private BEAgendaCulturalRepository oBEAgendaCulturalRepository;

        public BLAgendaCulturalNTAD()
        {
            oBEAgendaCulturalRepository = new BEAgendaCulturalRepository(Constantes.NOMBRECONEXION);
        }


        #region IConsultar<BEAgendaCultural> Members



        public BEAgendaCultural ListarRegistro(int agen_codi)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public List<BEAgendaCultural> ListarTodos()
        {
            return oBEAgendaCulturalRepository.uspMListarTodosAgendaCultural();

        }
        public List<BEAgendaCultural> ListarTodos(BEAgendaCultural Filtro)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        
    }
}
