using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.Transaccionales
{
    public class BLGaleriaArteTAD : IMantenimiento<BEGaleriaArte>
    {
        private BEGaleriaArteRepository oBEGaleriaArteRepository;


        public BLGaleriaArteTAD()
        {
            oBEGaleriaArteRepository = new BEGaleriaArteRepository(Constantes.NOMBRECONEXION);
        }


        #region IMantenimiento<BEGaleriaArte> Members

        public void Modificar(BEGaleriaArte GaleriaArte)
        {
            oBEGaleriaArteRepository.Save(GaleriaArte);
        }

        public void Eliminar(int idGaleriaArte)
        {
            oBEGaleriaArteRepository.Remove(idGaleriaArte);
        }

        public void Agregar(BEGaleriaArte GaleriaArte)
        {
            oBEGaleriaArteRepository.Add(GaleriaArte);
        }

        #endregion
    }
}