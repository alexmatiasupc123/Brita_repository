using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.Transaccionales
{
    public class BLSedeTAD : IMantenimiento<BESede>
    {
        private BESedeRepository oBESedeRepository;


        public BLSedeTAD()
        {
            oBESedeRepository = new BESedeRepository(Constantes.NOMBRECONEXION);
        }


        #region IMantenimiento<BESede> Members

        public void Modificar(BESede Sede)
        {
            oBESedeRepository.Save(Sede);
        }

        public void Eliminar(int idSede)
        {
            oBESedeRepository.Remove(idSede);
        }

        public void Agregar(BESede Sede)
        {
            oBESedeRepository.Add(Sede);
        }

        #endregion
    }
}