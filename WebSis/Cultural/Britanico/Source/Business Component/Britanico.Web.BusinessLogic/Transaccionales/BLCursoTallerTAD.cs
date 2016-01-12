using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.Transaccionales
{
    public class BLCursoTallerTAD : IMantenimiento<BECursoTaller>
    {
        private BECursoTallerRepository oBECursoTallerRepository;


        public BLCursoTallerTAD()
        {
            oBECursoTallerRepository = new BECursoTallerRepository(Constantes.NOMBRECONEXION);
        }


        #region IMantenimiento<BECursoTaller> Members

        public void Modificar(BECursoTaller CursoTaller)
        {
            oBECursoTallerRepository.Save(CursoTaller);
        }

        public void Eliminar(int idCursoTaller)
        {
            oBECursoTallerRepository.Remove(idCursoTaller);
        }

        public void Agregar(BECursoTaller CursoTaller)
        {
            oBECursoTallerRepository.Add(CursoTaller);
        }

        #endregion
    }
}