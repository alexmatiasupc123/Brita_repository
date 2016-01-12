using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.Transaccionales
{
    public class BLBritanicoRadioTAD : IMantenimiento<BEBritanicoRadio>
    {
        private BEBritanicoRadioRepository oBEBritanicoRadioRepository;


        public BLBritanicoRadioTAD()
        {
            oBEBritanicoRadioRepository = new BEBritanicoRadioRepository(Constantes.NOMBRECONEXION);
        }


        #region IMantenimiento<BEBritanicoRadio> Members

        public void Modificar(BEBritanicoRadio BritanicoRadio)
        {
            oBEBritanicoRadioRepository.Save(BritanicoRadio);
        }

        public void Eliminar(int idBritanicoRadio)
        {
            oBEBritanicoRadioRepository.Remove(idBritanicoRadio);
        }

        public void Agregar(BEBritanicoRadio BritanicoRadio)
        {
            oBEBritanicoRadioRepository.Add(BritanicoRadio);
        }

        #endregion
    }
}