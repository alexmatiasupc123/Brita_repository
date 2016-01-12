using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.Transaccionales
{
    public class BLAgendaCulturalTAD : IMantenimiento<BEAgendaCultural>
    {
        private BEAgendaCulturalRepository oBEAgendaCulturalRepository;


        public BLAgendaCulturalTAD()
        {
            oBEAgendaCulturalRepository = new BEAgendaCulturalRepository(Constantes.NOMBRECONEXION);
        }


        #region IMantenimiento<BEAgendaCultural> Members

        public void Modificar(BEAgendaCultural AgendaCultural)
        {
            oBEAgendaCulturalRepository.Save(AgendaCultural);
        }

 
        public void Agregar(BEAgendaCultural AgendaCultural)
        {
            oBEAgendaCulturalRepository.Add(AgendaCultural);
        }

        public void Eliminar(int agen_codi)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        #endregion
    }
}