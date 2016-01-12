using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.Transaccionales
{
    public class BLHistoriaTeatroTAD : IMantenimiento<BEHistoriaTeatro>
    {
        private BEHistoriaTeatroRepository oBEHistoriaTeatroRepository;


        public BLHistoriaTeatroTAD()
        {
            oBEHistoriaTeatroRepository = new BEHistoriaTeatroRepository(Constantes.NOMBRECONEXION);
        }


        #region IMantenimiento<BEHistoriaTeatro> Members

        public void Modificar(BEHistoriaTeatro HistoriaTeatro)
        {
            oBEHistoriaTeatroRepository.Save(HistoriaTeatro);
        }

 
        public void Agregar(BEHistoriaTeatro HistoriaTeatro)
        {
            oBEHistoriaTeatroRepository.Add(HistoriaTeatro);
        }

        public void Eliminar(int histo_codi)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        #endregion
    }
}