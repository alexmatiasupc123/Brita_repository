using System;
using System.Configuration;
using System.Collections.Generic;
using System.Transactions;

using Britanico.SacNet.BusinessEntities;
using Britanico.SacNet.DataAccess;
using Oxinet.Tools;

namespace Britanico.SacNet.BusinessLogic
{
	/// <summary>
	/// 
	/// </summary>
	public class UsuariosLogic
	{
		private UsuariosData oUsuariosData = null;
		private ReturnValor oReturn = null;
		public UsuariosLogic()
		{
			oUsuariosData = new UsuariosData();
			oReturn = new ReturnValor();
		}

	

	#region " /* Funciones Seleccionar */ "

        /// <summary>
        /// Retorna un coleccion de registros de tipo [Tabla].
        /// <summary>
        /// <returns>List</returns>
        public Usuarios Buscar(string p_LoginUsuario)
        {
            Usuarios itemUsuario = new Usuarios();
            try
            {
                itemUsuario = oUsuariosData.Buscar(p_LoginUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itemUsuario;
        }
        /// <summary>
        /// Retorna un coleccion de registros de tipo [Tabla].
        /// <summary>
        /// <returns>List</returns>
        public List<Usuarios> Listar(string p_NombresUsuario, string p_ApellidosUsuario, string p_LoginUsuario)
        {
            List<Usuarios> lista = new List<Usuarios>();
            try
            {
                lista = oUsuariosData.Listar(p_NombresUsuario, p_ApellidosUsuario, p_LoginUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

	#endregion 

	

	
	}
}
