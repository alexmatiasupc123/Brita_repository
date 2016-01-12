using System;
using System.Collections.Generic;
using System.Text;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess;
using Britanico.Utilitario;
using Britanico.Interfaces;

namespace Britanico.BusinessLogic.NoTransaccionales
{
    public class BLUsuarioNTAD : IConsultar<BEUsuario>
    {
        private BEUsuarioRepository oBEUsuarioRepository;
      

        public BLUsuarioNTAD()
        {
            oBEUsuarioRepository = new BEUsuarioRepository(Constantes.NOMBRECONEXION);
        }


        #region IConsultar<BEUsuario> Members

        public List<BEUsuario> ListarTodos()
        {
            return oBEUsuarioRepository.uspMListarTodosUsuario();
        }


     

        public List<BEUsuario> ListarTodos(BEUsuario Filtro)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public BEUsuario ListarRegistro(int id)
        {
            return oBEUsuarioRepository.uspMListarRegistroUsuario(id);
        }

        public Int32 VerificaLogin(string usuario)
        {
            Int32 encontrado=0;
            BEUsuario user = oBEUsuarioRepository.VerificaLogin(usuario);

            if (user != null)
            {
                encontrado = 1;
            }

            return encontrado;
        }

        public Int32 VerificaModificaLogin(int codigo, string usuario)
        {
            Int32 encontrado = 0;
            BEUsuario user = oBEUsuarioRepository.VerificaModificaLogin(codigo,usuario);

            if (user != null)
            {
                encontrado = 1;
            }

            return encontrado;
        }

        public BEUsuario ListarRegistro(BEUsuario F)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public BEUsuario ListarTodos(int id)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public BEUsuario ValidaAcceso(string usuario, string clave)
        {
        return oBEUsuarioRepository.uspMValidaAccesoUsuario(usuario, clave);
       
        }

        #endregion
    }
}

