using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.Transaccionales
{
    public class BLSuscriptorTAD : IMantenimiento<BESuscriptor>
    {
        private BESuscriptorRepository oBESuscriptorRepository;


        public BLSuscriptorTAD()
        {
            oBESuscriptorRepository = new BESuscriptorRepository(Constantes.NOMBRECONEXION);
        }


        #region IMantenimiento<BESuscriptor> Members

        public void Modificar(BESuscriptor Suscriptor)
        {
            oBESuscriptorRepository.Save(Suscriptor);
        }

        public void Eliminar(int idSuscriptor)
        {
            oBESuscriptorRepository.Remove(idSuscriptor);
        }

        public void Agregar(BESuscriptor Suscriptor)
        {
            oBESuscriptorRepository.Add(Suscriptor);
        }

        #endregion
    }
}