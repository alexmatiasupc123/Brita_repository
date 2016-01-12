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
	/// Fecha       : 14/07/2010-11:03:42 
	/// Descripcion : Capa de Lógica 
	/// Archivo     : [Sacnet.UsuariosBloqueadosLogic.cs]
	/// </summary>
	public class UsuariosBloqueadosLogic
	{ 
		private UsuariosBloqueadosData oUsuariosBloqueadosData = null;
		private ReturnValor oReturnValor = null;
		public UsuariosBloqueadosLogic()
		{
			oUsuariosBloqueadosData = new UsuariosBloqueadosData();
			oReturnValor = new ReturnValor();
		}
		
        #region /* Proceso de SELECT ALL */ 

		/// <summary>
		/// Retorna un LISTA de registros de la Entidad Sacnet.UsuariosBloqueados
		/// En la BASE de DATO la Tabla : [Sacnet.UsuariosBloqueados]
		/// <summary>
		/// <returns>List</returns>
		public List<UsuariosBloqueados> Listar(Nullable<DateTime> prm_dFechaProcesoINI, Nullable<DateTime>prm_dFechaProcesoFIN, string prm_sCodUsuarioSAC, bool prm_bEstado)
		{
			List<UsuariosBloqueados> miLista = new List<UsuariosBloqueados>();
			try
			{
				 miLista = oUsuariosBloqueadosData.Listar(HelpDates.FormatFechaYMD(prm_dFechaProcesoINI), HelpDates.FormatFechaYMD(prm_dFechaProcesoFIN), prm_sCodUsuarioSAC, prm_bEstado);
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
		/// Retorna una ENTIDAD de registro de la Entidad Sacnet.UsuariosBloqueados
		/// En la BASE de DATO la Tabla : [Sacnet.UsuariosBloqueados]
		/// <summary>
		/// <returns>Entidad</returns>
        /// 
        public UsuariosBloqueados Buscar(string prm_sCodUsuarioSAC, bool prm_bEstado)
        {
            List<UsuariosBloqueados> miLista = new List<UsuariosBloqueados>();
            UsuariosBloqueados miItem = new UsuariosBloqueados();
            try
            {
                miLista = Listar(null, null, prm_sCodUsuarioSAC, prm_bEstado);
                if (miLista.Count == 1)
                {
                    miItem = new UsuariosBloqueados
                    {
                        bEstado = miLista[0].bEstado,
                        dFechaBloqueoOFF = miLista[0].dFechaBloqueoOFF,
                        dFechaBloqueoON = miLista[0].dFechaBloqueoON,
                        sCodRegistro = miLista[0].sCodRegistro,
                        sCodUsuarioSAC = miLista[0].sCodUsuarioSAC,
                        sCodUsuarioSACApellidosNombre = miLista[0].sCodUsuarioSACApellidosNombre,
                        SSIFechaHora_Creacion = miLista[0].SSIFechaHora_Creacion,
                        SSIFechaHora_Modificacion = miLista[0].SSIFechaHora_Modificacion,
                        SSIHost = miLista[0].SSIHost,
                        SSIUsuario_Creacion = miLista[0].SSIUsuario_Creacion,
                        SSIUsuario_Modificacion = miLista[0].SSIUsuario_Modificacion
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miItem;
        }
		
        #endregion 

		#region /* Proceso de INSERT RECORD */ 

		/// <summary>
		/// Almacena el registro de una ENTIDAD de registro de Tipo UsuariosBloqueados
		/// En la BASE de DATO la Tabla : [Sacnet.UsuariosBloqueados]
		/// <summary>
		/// <param name = >itemUsuariosBloqueados</param>
        public ReturnValor Registrar(UsuariosBloqueados itemUsuariosBloqueados)
		{
			try
			{
				using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
				{
                    oReturnValor.CodigoRetorno = oUsuariosBloqueadosData.Registrar(itemUsuariosBloqueados);
					if (oReturnValor.CodigoRetorno!=null)
					{
						oReturnValor.Message = HelpMessage.Message( HelpMessage.TMessage.Registrar);
						tx.Complete();
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
