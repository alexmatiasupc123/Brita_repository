using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.Transaccionales
{
    public class BLProduccionesTAD : IMantenimiento<BEProducciones>
    {
        private BEProduccionesRepository oBEProduccionesRepository;


        public BLProduccionesTAD()
        {
            oBEProduccionesRepository = new BEProduccionesRepository(Constantes.NOMBRECONEXION);
        }


        #region IMantenimiento<BEProducciones> Members

        public void Modificar(BEProducciones Producciones)
        {
            oBEProduccionesRepository.Save(Producciones);
        }

        public void Eliminar(int idProducciones)
        {
            oBEProduccionesRepository.Remove(idProducciones);
        }

        public void Agregar(BEProducciones Producciones)
        {
            oBEProduccionesRepository.Add(Producciones);
        }

        #endregion
    }
}