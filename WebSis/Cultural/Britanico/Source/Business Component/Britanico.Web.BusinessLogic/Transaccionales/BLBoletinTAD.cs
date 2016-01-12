using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.Transaccionales
{
    public class BLBoletinTAD : IMantenimiento<BEBoletin>
    {
        private BEBoletinRepository oBEBoletinRepository;


        public BLBoletinTAD()
        {
            oBEBoletinRepository = new BEBoletinRepository(Constantes.NOMBRECONEXION);
        }


        #region IMantenimiento<BEBoletin> Members

        public void Modificar(BEBoletin Boletin)
        {
            oBEBoletinRepository.Save(Boletin);
        }

        public void Eliminar(int idBoletin)
        {
            oBEBoletinRepository.Remove(idBoletin);
        }

        public void Agregar(BEBoletin Boletin)
        {
            oBEBoletinRepository.Add(Boletin);
        }

        #endregion
    }
}