using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.Transaccionales
{
    public class BLProgramacionAuditorioTAD : IMantenimiento<BEProgramacionAuditorio>
    {
        private BEProgramacionAuditorioRepository oBEProgramacionAuditorioRepository;


        public BLProgramacionAuditorioTAD()
        {
            oBEProgramacionAuditorioRepository = new BEProgramacionAuditorioRepository(Constantes.NOMBRECONEXION);
        }


        #region IMantenimiento<BEProgramacionAuditorio> Members

        public void Modificar(BEProgramacionAuditorio ProgramacionAuditorio)
        {
            oBEProgramacionAuditorioRepository.Save(ProgramacionAuditorio);
        }

        public void Eliminar(int idProgramacionAuditorio)
        {
            oBEProgramacionAuditorioRepository.Remove(idProgramacionAuditorio);
        }

        public void Agregar(BEProgramacionAuditorio ProgramacionAuditorio)
        {
            oBEProgramacionAuditorioRepository.Add(ProgramacionAuditorio);
        }

        #endregion
    }
}