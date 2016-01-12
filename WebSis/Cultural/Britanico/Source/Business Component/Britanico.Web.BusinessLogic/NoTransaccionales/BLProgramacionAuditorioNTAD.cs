using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.NoTransaccionales
{
    public class BLProgramacionAuditorioNTAD : IConsultar<BEProgramacionAuditorio>
    {
        private BEProgramacionAuditorioRepository oBEProgramacionAuditorioRepository;

        public BLProgramacionAuditorioNTAD()
        {
            oBEProgramacionAuditorioRepository = new BEProgramacionAuditorioRepository(Constantes.NOMBRECONEXION);
        }


        #region IConsultar<BEProgramacionAuditorio> Members

        public List<BEProgramacionAuditorio> ListarTodos()
        {
            return oBEProgramacionAuditorioRepository.uspMListarTodosProgramacionAuditorio();

        }

        public List<BEProgramacionAuditorio> ListarTodosDestacados()
        {
            return oBEProgramacionAuditorioRepository.uspMListarTodosProgramacionAuditorioDestacados();

        }


        public List<BEProgramacionAuditorio> ListarTodos(Int32 sede)
        {
            return oBEProgramacionAuditorioRepository.uspMListarTodosXSede(sede);

        }


        public BEProgramacionAuditorio ListarRegistro(int idProgramacionAuditorio)
        {
            return oBEProgramacionAuditorioRepository.uspMListarRegistroAuditorio(idProgramacionAuditorio);
        }

        #endregion

        #region IConsultar<BEProgramacionAuditorio> Members


        public List<BEProgramacionAuditorio> ListarTodos(BEProgramacionAuditorio Filtro)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
