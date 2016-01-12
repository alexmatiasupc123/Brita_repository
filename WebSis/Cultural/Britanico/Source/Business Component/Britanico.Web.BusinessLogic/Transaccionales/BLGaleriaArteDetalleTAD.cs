using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.Transaccionales
{
    public class BLGaleriaArteDetalleTAD : IMantenimiento<BEGaleriaArteDetalle>
    {
        private BEGaleriaArteDetalleRepository oBEGaleriaArteDetalleRepository;


        public BLGaleriaArteDetalleTAD()
        {
            oBEGaleriaArteDetalleRepository = new BEGaleriaArteDetalleRepository(Constantes.NOMBRECONEXION);
        }


        #region IMantenimiento<BEGaleriaArteDetalle> Members

        public void Modificar(BEGaleriaArteDetalle GaleriaArteDetalle)
        {
            oBEGaleriaArteDetalleRepository.Save(GaleriaArteDetalle);
        }

        public void Eliminar(int idGaleriaArteDetalle)
        {
            oBEGaleriaArteDetalleRepository.Remove(idGaleriaArteDetalle);
        }

        public void Agregar(BEGaleriaArteDetalle GaleriaArteDetalle)
        {
            oBEGaleriaArteDetalleRepository.Add(GaleriaArteDetalle);
        }

        #endregion
    }
}