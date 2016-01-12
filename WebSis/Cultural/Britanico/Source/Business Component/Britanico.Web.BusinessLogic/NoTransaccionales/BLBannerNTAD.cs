using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.NoTransaccionales
{
    public class BLBannerNTAD : IConsultar<BEBanner>
    {
        private BEBannerRepository oBEBannerRepository;

        public BLBannerNTAD()
        {
            oBEBannerRepository = new BEBannerRepository(Constantes.NOMBRECONEXION);
        }


        #region IConsultar<BEBanner> Members

        public List<BEBanner> ListarTodos()
        {
            return oBEBannerRepository.uspMListarTodosBanner();

        }

        public List<BEBanner> ListarTodosSimples()
        {
            return oBEBannerRepository.uspMListarTodosBannerSimples();

        }



        public List<BEBanner> ListarTodosPrincipal()
        {
            return oBEBannerRepository.uspMListarTodosBannerPrincipal();

        }

        public List<BEBanner> ListarTodosRedSocial()
        {
            return oBEBannerRepository.uspMListarTodosBannerRedSocial();

        }

        public BEBanner ListarRegistro(int idBanner)
        {
            return oBEBannerRepository.uspMListarRegistroBanner(idBanner);
        }

        #endregion

        #region IConsultar<BEBanner> Members


        public List<BEBanner> ListarTodos(BEBanner Filtro)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
