using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.Transaccionales
{
    public class BLGaleriaArchivoTAD : IMantenimiento<BEGaleriaArchivo>
    {
        private BEGaleriaArchivoRepository oBEGaleriaArchivoRepository;


        public BLGaleriaArchivoTAD()
        {
            oBEGaleriaArchivoRepository = new BEGaleriaArchivoRepository(Constantes.NOMBRECONEXION);
        }


        #region IMantenimiento<BEGaleriaArchivo> Members

        public void Modificar(BEGaleriaArchivo GaleriaArchivo)
        {
            oBEGaleriaArchivoRepository.Save(GaleriaArchivo);
        }

        public void Eliminar(int idGaleriaArchivo)
        {
            oBEGaleriaArchivoRepository.Remove(idGaleriaArchivo);
        }

        public void Agregar(BEGaleriaArchivo GaleriaArchivo)
        {
            oBEGaleriaArchivoRepository.Add(GaleriaArchivo);
        }

        #endregion
    }
}