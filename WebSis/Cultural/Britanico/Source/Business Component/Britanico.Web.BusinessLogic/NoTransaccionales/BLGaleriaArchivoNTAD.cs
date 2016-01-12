using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.NoTransaccionales
{
    public class BLGaleriaArchivoNTAD : IConsultar<BEGaleriaArchivo>
    {
        private BEGaleriaArchivoRepository oBEGaleriaArchivoRepository;

        public BLGaleriaArchivoNTAD()
        {
            oBEGaleriaArchivoRepository = new BEGaleriaArchivoRepository(Constantes.NOMBRECONEXION);
        }


        #region IConsultar<BEGaleriaArchivo> Members

        public List<BEGaleriaArchivo> ListarTodos()
        {
            return oBEGaleriaArchivoRepository.uspMListarTodosArchivo();

        }

        public List<BEGaleriaArchivo> ListarTodosXFiltro(int idPadre, int tipoevento, string tipoArchivo, int numPag)
        {
            return oBEGaleriaArchivoRepository.uspMListarTodosArchivoXFiltros(idPadre, tipoevento, tipoArchivo, numPag);

        }

        public List<BEGaleriaArchivo> ListarTodosXValores(int idPadre, int tipoevento, string tipoArchivo)
        {
            return oBEGaleriaArchivoRepository.uspMListarTodosArchivoXValores(idPadre, tipoevento, tipoArchivo);

        }

        public List<BEGaleriaArchivo> ListarTodosGaleria(int idPadre, int tipoevento)
        {
            return oBEGaleriaArchivoRepository.uspMListarTodosArchivoGaleria(idPadre, tipoevento);

        }


        public List<BEGaleriaArchivo> ListarTodosXGaleria(int idPadre, int tipoevento, string tipoArchivo)
        {
            return oBEGaleriaArchivoRepository.uspMListarTodosArchivoXGaleria(idPadre, tipoevento, tipoArchivo);

        }

        public BEGaleriaArchivo ListarRegistro(int idGaleriaArchivo)
        {
            return oBEGaleriaArchivoRepository.uspMListarRegistroArchivo(idGaleriaArchivo);
        }

        #endregion

        #region IConsultar<BEGaleriaArchivo> Members


        public List<BEGaleriaArchivo> ListarTodos(BEGaleriaArchivo Filtro)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
