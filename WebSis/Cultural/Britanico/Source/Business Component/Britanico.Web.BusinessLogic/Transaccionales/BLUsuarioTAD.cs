using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.Transaccionales
{
    public class BLUsuarioTAD : IMantenimiento<BEUsuario>

    {
        private BEUsuarioRepository oBEUsuarioRepository;


        public BLUsuarioTAD()
        {
            oBEUsuarioRepository = new BEUsuarioRepository(Constantes.NOMBRECONEXION);
        }


        #region IMantenimiento<BEUsuario> Members

        public void Modificar(BEUsuario Usuario)
        {
           // oBEUsuarioRepository.Save(Usuario);
        }
        public void GuardaLogin(BEUsuario Usuario)
        {
           oBEUsuarioRepository.GuardarLogin(Usuario);
        }

        public void GuardaEstado(BEUsuario Usuario)
        {
            oBEUsuarioRepository.GuardarEstado(Usuario);
        }

        public void GuardaEmail(BEUsuario Usuario)
        {
           oBEUsuarioRepository.GuardarEmail(Usuario);
        }

        public void GuardaClave(BEUsuario Usuario)
        {
           oBEUsuarioRepository.GuardarClave(Usuario);
        }


        public void Eliminar(int idUsuario)
        {
         oBEUsuarioRepository.Remove(idUsuario);
        }

        public void Agregar(BEUsuario Usuario)
        {
            oBEUsuarioRepository.Add(Usuario);
        }

        #endregion
    }
}
