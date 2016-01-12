using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.NoTransaccionales
{
    public class BLSuscriptorNTAD : IConsultar<BESuscriptor>
    {
        private BESuscriptorRepository oBESuscriptorRepository;

        public BLSuscriptorNTAD()
        {
            oBESuscriptorRepository = new BESuscriptorRepository(Constantes.NOMBRECONEXION);
        }


        #region IConsultar<BESuscriptor> Members

        public List<BESuscriptor> ListarTodos()
        {
            return oBESuscriptorRepository.uspMListarTodosSuscriptor();

        }

        public List<BESuscriptor> ListarTodosXValores(DateTime inicio, DateTime fin, int estado)
        {
            return oBESuscriptorRepository.uspMListarTodosSuscriptoresXValores(inicio,fin,estado);

        }

        public BESuscriptor ListarRegistro(int idSuscriptor)
        {
            return oBESuscriptorRepository.uspMListarRegistroSuscriptor(idSuscriptor);
        }

        #endregion

        #region IConsultar<BESuscriptor> Members


        public List<BESuscriptor> ListarTodos(BESuscriptor Filtro)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
