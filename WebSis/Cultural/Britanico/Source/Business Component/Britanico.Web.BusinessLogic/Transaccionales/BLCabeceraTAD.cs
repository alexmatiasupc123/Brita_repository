using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.Transaccionales
{
    public class BLCabeceraTAD : IMantenimiento<BECabecera>
    {
        private BECabeceraRepository oBECabeceraRepository;


        public BLCabeceraTAD()
        {
            oBECabeceraRepository = new BECabeceraRepository(Constantes.NOMBRECONEXION);
        }


        #region IMantenimiento<BECabecera> Members

        public void Modificar(BECabecera Cabecera)
        {
            oBECabeceraRepository.Save(Cabecera);
        }

 
        public void Agregar(BECabecera Cabecera)
        {
            oBECabeceraRepository.Add(Cabecera);
        }

        public void Eliminar(int cabe_codi)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        #endregion
    }
}