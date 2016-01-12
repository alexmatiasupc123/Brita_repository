using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.Transaccionales
{
    public class BLProyectoTAD : IMantenimiento<BEProyecto>
    {
        private BEProyectoRepository oBEProyectoRepository;


        public BLProyectoTAD()
        {
            oBEProyectoRepository = new BEProyectoRepository(Constantes.NOMBRECONEXION);
        }


        #region IMantenimiento<BEProyecto> Members

        public void Modificar(BEProyecto Proyecto)
        {
            oBEProyectoRepository.Save(Proyecto);
        }

        public void Eliminar(int idProyecto)
        {
            oBEProyectoRepository.Remove(idProyecto);
        }

        public void Agregar(BEProyecto Proyecto)
        {
            oBEProyectoRepository.Add(Proyecto);
        }

        #endregion
    }
}