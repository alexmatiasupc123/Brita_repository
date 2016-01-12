using System;
using System.Collections.Generic;
using System.Configuration;
using System.Transactions;

using Britanico.SacNet.BusinessEntities;
using Britanico.SacNet.DataAccess;
using Oxinet.Tools;

namespace Britanico.SacNet.BusinessLogic 
{ 
	/// <summary>
	/// Proyecto    : Modulo de Mantenimiento de : 
	/// Creacion    : CROM - Orlando Carril Ramírez
	/// Fecha       : 09/07/2010-11:33:49 
	/// Descripcion : Capa de Lógica 
	/// Archivo     : [Sacnet.UsuariosMotivoCorreosLogic.cs]
	/// </summary>
	public class UsuariosMotivoCorreosLogic
	{ 
		private UsuariosMotivoCorreosData oUsuariosMotivoCorreosData = null;
		private ReturnValor oReturnValor = null;
		public UsuariosMotivoCorreosLogic()
		{
			oUsuariosMotivoCorreosData = new UsuariosMotivoCorreosData();
			oReturnValor = new ReturnValor();
		}
		#region /* Proceso de SELECT ALL */ 

		/// <summary>
		/// Retorna un LISTA de registros de la Entidad Sacnet.UsuariosMotivoCorreos
		/// En la BASE de DATO la Tabla : [Sacnet.UsuariosMotivoCorreos]
		/// <summary>
		/// <returns>List</returns>
        public List<UsuariosMotivoCorreos> Listar(string prm_sApellidos, string prm_sCodArguCargo, string prm_sCodArguAccionMotivo, bool? prm_bEstado)
		{
			List<UsuariosMotivoCorreos> miLista = new List<UsuariosMotivoCorreos>();
			try
			{
                miLista = oUsuariosMotivoCorreosData.Listar(prm_sApellidos, prm_sCodArguCargo, prm_sCodArguAccionMotivo, prm_bEstado);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return miLista;
		}

		#endregion 

		#region /* Proceso de SELECT BY ID CODE */ 

		/// <summary>
		/// Retorna una ENTIDAD de registro de la Entidad Sacnet.UsuariosMotivoCorreos
		/// En la BASE de DATO la Tabla : [Sacnet.UsuariosMotivoCorreos]
		/// <summary>
		/// <returns>Entidad</returns>
        public UsuariosMotivoCorreos Buscar(string prm_sCodUsuario, string prm_sCodArguAccionMotivo)
		{
			UsuariosMotivoCorreos miEntidad = new UsuariosMotivoCorreos();
			try
			{
				miEntidad = oUsuariosMotivoCorreosData.Buscar(prm_sCodUsuario,prm_sCodArguAccionMotivo);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return miEntidad;
		}

		#endregion 

		#region /* Proceso de INSERT RECORD */ 

		/// <summary>
		/// Almacena el registro de una ENTIDAD de registro de Tipo UsuariosMotivoCorreos
		/// En la BASE de DATO la Tabla : [Sacnet.UsuariosMotivoCorreos]
		/// <summary>
		/// <param name = >itemUsuariosMotivoCorreos</param>
        public ReturnValor Registrar(UsuariosMotivoCorreos itemUsuariosMotivoCorreos)
		{
			try
			{
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.CodigoRetorno = oUsuariosMotivoCorreosData.Registrar(itemUsuariosMotivoCorreos);
                    if (oReturnValor.CodigoRetorno != null)
                    {
                        oReturnValor.Exitosa = true;
                        tx.Complete();
                        oReturnValor.Message = HelpMessage.Message(HelpMessage.TMessage.Registrar);
                    }
                }
			}
			catch (Exception ex)
			{
				oReturnValor= HelpMessage.Message(ex);
			}
			return oReturnValor;
		}

		#endregion 

		#region /* Proceso de UPDATE RECORD */ 

		/// <summary>
		/// Almacena el registro de una ENTIDAD de registro de Tipo UsuariosMotivoCorreos
		/// En la BASE de DATO la Tabla : [Sacnet.UsuariosMotivoCorreos]
		/// <summary>
		/// <param name = >itemUsuariosMotivoCorreos</param>
        public ReturnValor Actualizar(UsuariosMotivoCorreos itemUsuariosMotivoCorreos)
		{
			try
			{
				using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
				{
					oReturnValor.Exitosa = oUsuariosMotivoCorreosData.Actualizar(itemUsuariosMotivoCorreos);
					if (oReturnValor.Exitosa)
					{
						tx.Complete();
                        oReturnValor.Message = HelpMessage.Message(HelpMessage.TMessage.Editar);
					}
				}
			}
			catch (Exception ex)
			{
				oReturnValor= HelpMessage.Message(ex);
			}
			return oReturnValor;
		}

		#endregion 

		#region /* Proceso de DELETE BY ID CODE */ 

		/// <summary>
		/// ELIMINA un registro de la Entidad Sacnet.UsuariosMotivoCorreos
		/// En la BASE de DATO la Tabla : [Sacnet.UsuariosMotivoCorreos]
		/// <summary>
		/// <returns>bool</returns>
        public ReturnValor Eliminar(string prm_sCodUsuario, string prm_sCodArguAccionMotivo)
		{
			try
			{
				using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
				{
					oReturnValor.Exitosa = oUsuariosMotivoCorreosData.Eliminar(prm_sCodUsuario,prm_sCodArguAccionMotivo);
					if (oReturnValor.Exitosa)
					{
                        tx.Complete();
                        oReturnValor.Message = HelpMessage.Message(HelpMessage.TMessage.Eliminar);
					}
				}
			}
			catch (Exception ex)
			{
				oReturnValor= HelpMessage.Message(ex);
			}
			return oReturnValor;
		}
	
        #endregion 

	} 
} 
