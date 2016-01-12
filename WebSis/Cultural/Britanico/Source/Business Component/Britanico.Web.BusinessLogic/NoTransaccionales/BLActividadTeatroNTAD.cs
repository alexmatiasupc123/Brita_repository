using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.NoTransaccionales
{
    public class BLActividadTeatroNTAD : IConsultar<BEActividadTeatro>
    {
        private BEActividadTeatroRepository oBEActividadTeatroRepository;

        public BLActividadTeatroNTAD()
        {
            oBEActividadTeatroRepository = new BEActividadTeatroRepository(Constantes.NOMBRECONEXION);
        }


        #region IConsultar<BEActividadTeatro> Members

        public List<BEActividadTeatro> ListarTodos()
        {
            return oBEActividadTeatroRepository.uspMListarTodosActividad();

        }



        public List<BEActividadTeatro> ListarTodosDestacados()
        {
            return oBEActividadTeatroRepository.uspMListarTodosActividadDestacados();

        }


        public List<BEActividadTeatro> ListarTodosResumen()
        {
            return oBEActividadTeatroRepository.uspMListarTodosActividadResumen();

        }



        public BEActividadTeatro ListarRegistro(int idActividadTeatro)
        {
            return oBEActividadTeatroRepository.uspMListarRegistroActividad(idActividadTeatro);
        }

        #endregion

        #region IConsultar<BEActividadTeatro> Members


        public List<BEActividadTeatro> ListarTodos(BEActividadTeatro Filtro)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
