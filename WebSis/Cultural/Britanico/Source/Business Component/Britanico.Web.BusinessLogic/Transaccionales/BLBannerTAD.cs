using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.Transaccionales
{
    public class BLBannerTAD : IMantenimiento<BEBanner>
    {
        private BEBannerRepository oBEBannerRepository;


        public BLBannerTAD()
        {
            oBEBannerRepository = new BEBannerRepository(Constantes.NOMBRECONEXION);
        }


        #region IMantenimiento<BEBanner> Members

        public void Modificar(BEBanner Banner)
        {
            oBEBannerRepository.Save(Banner);
        }

        public void Eliminar(int idBanner)
        {
            oBEBannerRepository.Remove(idBanner);
        }

        public void Agregar(BEBanner Banner)
        {
            oBEBannerRepository.Add(Banner);
        }

        #endregion
    }
}