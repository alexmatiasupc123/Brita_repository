using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.Transaccionales
{
    public class BLNoticiaTAD : IMantenimiento<BENoticia>
    {
        private BENoticiaRepository oBENoticiaRepository;


        public BLNoticiaTAD()
        {
            oBENoticiaRepository = new BENoticiaRepository(Constantes.NOMBRECONEXION);
        }


        #region IMantenimiento<BENoticia> Members

        public void Modificar(BENoticia Noticia)
        {
            oBENoticiaRepository.Save(Noticia);
        }

        public void Eliminar(int idNoticia)
        {
            oBENoticiaRepository.Remove(idNoticia);
        }

        public void Agregar(BENoticia Noticia)
        {
            oBENoticiaRepository.Add(Noticia);
        }

        #endregion
    }
}