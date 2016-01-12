using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.Transaccionales
{
    public class BLConcursoTemporadaTAD : IMantenimiento<BEConcursoTemporada>
    {
        private BEConcursoTemporadaRepository oBEConcursoTemporadaRepository;


        public BLConcursoTemporadaTAD()
        {
            oBEConcursoTemporadaRepository = new BEConcursoTemporadaRepository(Constantes.NOMBRECONEXION);
        }


        #region IMantenimiento<BEConcursoTemporada> Members

        public void Modificar(BEConcursoTemporada ConcursoTemporada)
        {
            oBEConcursoTemporadaRepository.Save(ConcursoTemporada);
        }

        public void Eliminar(int idConcursoTemporada)
        {
            oBEConcursoTemporadaRepository.Remove(idConcursoTemporada);
        }

        public void Agregar(BEConcursoTemporada ConcursoTemporada)
        {
            oBEConcursoTemporadaRepository.Add(ConcursoTemporada);
        }

        #endregion
    }
}