using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.Transaccionales
{
    public class BLConcursoTAD : IMantenimiento<BEConcurso>
    {
        private BEConcursoRepository oBEConcursoRepository;


        public BLConcursoTAD()
        {
            oBEConcursoRepository = new BEConcursoRepository(Constantes.NOMBRECONEXION);
        }


        #region IMantenimiento<BEConcurso> Members

        public void Modificar(BEConcurso Concurso)
        {
            oBEConcursoRepository.Save(Concurso);
        }

        public void Eliminar(int idConcurso)
        {
            oBEConcursoRepository.Remove(idConcurso);
        }

        public void Agregar(BEConcurso Concurso)
        {
            oBEConcursoRepository.Add(Concurso);
        }

        #endregion
    }
}