using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.NoTransaccionales
{
    public class BLGaleriaArteDetalleNTAD : IConsultar<BEGaleriaArteDetalle>
    {
        private BEGaleriaArteDetalleRepository oBEGaleriaArteDetalleRepository;

        public BLGaleriaArteDetalleNTAD()
        {
            oBEGaleriaArteDetalleRepository = new BEGaleriaArteDetalleRepository(Constantes.NOMBRECONEXION);
        }


        #region IConsultar<BEGaleriaArteDetalle> Members

        public List<BEGaleriaArteDetalle> ListarTodos()
        {
            return oBEGaleriaArteDetalleRepository.uspMListarTodosGaleriaArteDetalle();

        }


        public List<BEGaleriaArteDetalle> ListarTodosDestacados()
        {
            return oBEGaleriaArteDetalleRepository.uspMListarTodosGaleriaArteDetalleDestacados();

        }



        public List<BEGaleriaArteDetalle> ListarTodos(Int32 gale_codi)
        {
            return oBEGaleriaArteDetalleRepository.uspMListarTodosXGaleria(gale_codi);

        }


        public List<BEGaleriaArteDetalle> ListarTodosDetalle(Int32 gale_codi)
        {
            return oBEGaleriaArteDetalleRepository.uspMListarTodosDetalleXGaleria(gale_codi);

        }

        public BEGaleriaArteDetalle ListarRegistro(int idGaleriaArteDetalle)
        {
            return oBEGaleriaArteDetalleRepository.uspMListarRegistroGaleriaArteDetalle(idGaleriaArteDetalle);
        }

        #endregion

        #region IConsultar<BEGaleriaArteDetalle> Members


        public List<BEGaleriaArteDetalle> ListarTodos(BEGaleriaArteDetalle Filtro)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
