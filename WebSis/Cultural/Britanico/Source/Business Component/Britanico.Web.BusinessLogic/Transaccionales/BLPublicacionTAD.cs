using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.Transaccionales
{
    public class BLPublicacionesTAD : IMantenimiento<BEPublicaciones>
    {
        private BEPublicacionesRepository oBEPublicacionesRepository;


        public BLPublicacionesTAD()
        {
            oBEPublicacionesRepository = new BEPublicacionesRepository(Constantes.NOMBRECONEXION);
        }


        #region IMantenimiento<BEPublicaciones> Members

        public void Modificar(BEPublicaciones Publicaciones)
        {
            oBEPublicacionesRepository.Save(Publicaciones);
        }

        public void Eliminar(int idPublicaciones)
        {
            oBEPublicacionesRepository.Remove(idPublicaciones);
        }

        public void Agregar(BEPublicaciones Publicaciones)
        {
            oBEPublicacionesRepository.Add(Publicaciones);
        }

        #endregion
    }
}