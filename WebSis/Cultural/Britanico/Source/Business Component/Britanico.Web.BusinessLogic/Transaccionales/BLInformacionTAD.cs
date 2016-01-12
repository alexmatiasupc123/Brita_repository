using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.Transaccionales
{
    public class BLInformacionTAD : IMantenimiento<BEInformacion>
    {
        private BEInformacionRepository oBEInformacionRepository;


        public BLInformacionTAD()
        {
            oBEInformacionRepository = new BEInformacionRepository(Constantes.NOMBRECONEXION);
        }


        #region IMantenimiento<BEInformacion> Members

        public void Modificar(BEInformacion Informacion)
        {
            oBEInformacionRepository.Save(Informacion);
        }

        public void Eliminar(int idInformacion)
        {
            oBEInformacionRepository.Remove(idInformacion);
        }

        public void Agregar(BEInformacion Informacion)
        {
            oBEInformacionRepository.Add(Informacion);
        }

        #endregion
    }
}