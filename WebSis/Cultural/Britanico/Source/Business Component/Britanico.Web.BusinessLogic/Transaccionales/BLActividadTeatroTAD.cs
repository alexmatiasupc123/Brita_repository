using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.Transaccionales
{
    public class BLActividadTeatroTAD : IMantenimiento<BEActividadTeatro>
    {
        private BEActividadTeatroRepository oBEActividadTeatroRepository;


        public BLActividadTeatroTAD()
        {
            oBEActividadTeatroRepository = new BEActividadTeatroRepository(Constantes.NOMBRECONEXION);
        }


        #region IMantenimiento<BEActividadTeatro> Members

        public void Modificar(BEActividadTeatro ActividadTeatro)
        {
            oBEActividadTeatroRepository.Save(ActividadTeatro);
        }

        public void Eliminar(int idActividadTeatro)
        {
            oBEActividadTeatroRepository.Remove(idActividadTeatro);
        }

        public void Agregar(BEActividadTeatro ActividadTeatro)
        {
            oBEActividadTeatroRepository.Add(ActividadTeatro);
        }

        #endregion
    }
}