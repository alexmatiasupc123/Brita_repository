using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.NoTransaccionales
{
    public class BLEventoNTAD : IConsultar<BEEvento>
    {
        private BEEventoRepository oBEEventoRepository;

        public BLEventoNTAD()
        {
            oBEEventoRepository = new BEEventoRepository(Constantes.NOMBRECONEXION);
        }


        #region IConsultar<BEEvento> Members

        public List<BEEvento> ListarTodos()
        {
            return oBEEventoRepository.uspMListarTodosEventos();

        }

        public List<BEEvento> ListarTodosProximos()
        {
            return oBEEventoRepository.uspMListarTodosEventosProximos();

        }

        public List<BEEvento> ListarTodos(int sede)
        {
            return oBEEventoRepository.uspMListarTodosEventosXSede(sede);

        }

        public List<BEEvento> ListarTodosDestacados()
        {
            return oBEEventoRepository.uspMListarTodosEventosDestacados();

        }

        public List<BEEvento> ListarTodos(string criterio)
        {
            return oBEEventoRepository.uspMListarTodosEventosXPalabra(criterio);

        }

        public List<BEEvento> ListarTodos(DateTime fecha)
        {
            return oBEEventoRepository.uspMListarTodosEventosXFecha(fecha);

        }

        public List<BEEvento> ListarTodosXstrFecha(string fecha)
        {
            return oBEEventoRepository.uspMListarTodosEventosXstrFecha(fecha);

        }


        public BEEvento ListarRegistro(int idEvento)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public BEEvento ListarRegistroDestacado(int destacado)
        {
            return oBEEventoRepository.uspMListarRegistroEventosDestacado(destacado);
        }

        #endregion

        #region IConsultar<BEEvento> Members


        public List<BEEvento> ListarTodos(BEEvento Filtro)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
