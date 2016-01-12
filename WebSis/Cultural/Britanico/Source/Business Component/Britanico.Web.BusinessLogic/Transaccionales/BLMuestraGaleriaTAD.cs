using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.Transaccionales
{
    public class BLMuestraGaleriaTAD : IMantenimiento<BEMuestraGaleria>
    {
        private BEMuestraGaleriaRepository oBEMuestraGaleriaRepository;


        public BLMuestraGaleriaTAD()
        {
            oBEMuestraGaleriaRepository = new BEMuestraGaleriaRepository(Constantes.NOMBRECONEXION);
        }


        #region IMantenimiento<BEMuestraGaleria> Members

        public void Modificar(BEMuestraGaleria MuestraGaleria)
        {
            oBEMuestraGaleriaRepository.Save(MuestraGaleria);
        }

        public void Eliminar(int idMuestraGaleria)
        {
            oBEMuestraGaleriaRepository.Remove(idMuestraGaleria);
        }

        public void Agregar(BEMuestraGaleria MuestraGaleria)
        {
            oBEMuestraGaleriaRepository.Add(MuestraGaleria);
        }

        #endregion
    }
}