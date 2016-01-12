using System;
using System.Configuration;
using System.Collections.Generic;
using Britanico.SacNet.BusinessEntities ;

namespace Britanico.SacNet.DataAccess
{
	/// <summary>
	/// 
	/// </summary>
	public class SolicitudTransferenciaData
	{
		public string conexion = string.Empty;
		public SolicitudTransferenciaData()
		{
            conexion = ConfigurationManager.ConnectionStrings["cnSacNET"].ConnectionString;
		}

	#region " /* Funciones Insertar */ "

		/// <summary>
		/// Ingresa un registro en la tabla SolicitudTransferencia
		/// </summary>
		/// <param name="pItem"></param>
		public  string Registrar(SolicitudTransferencia  pItem)
		{
            string Codigo = string.Empty;
			
			try
			{
				using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
				{
					 SQLDC.pa_mnt_RegistrarSolicitudTransferencia(
                        ref Codigo,
						pItem.dFechaProcesoSolicitud,
						pItem.sCodArguEstadoTransferencia,
						pItem.sUsuarioSolicitante,
						pItem.sCodSacOrigen,
						pItem.sUsuarioSacOrigen,
						pItem.dFechaProcesoRetiro,
						pItem.sCodSacDestino,
						pItem.sUsuarioSacDestino,
						pItem.dFechaProcesoIngreso,
						pItem.SSIUsuario_Creacion,						
						pItem.SSIHost
						);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
            return Codigo;
		}
	#endregion 

	#region " /* Funciones Seleccionar */ "

		/// <summary>
		/// Buscar un regitro de la tabla SolicitudTransferencia segun su pk enviado por parametro
		/// </summary>
		/// <returns>Item</returns>
		public  SolicitudTransferencia Buscar(string sCodTransferencia)
		{
			SolicitudTransferencia Item = new SolicitudTransferencia();
			try
			{
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
				{
					var resul = SQLDC.pa_mnt_BuscarSolicitudTransferencia(sCodTransferencia);
					foreach (var item in resul)
					{
						Item = new SolicitudTransferencia()
						{
							sCodTransferencia = item.sCodTransferencia,
							dFechaProcesoSolicitud = Convert.ToDateTime(item.dFechaProcesoSolicitud),
							sCodArguEstadoTransferencia = item.sCodArguEstadoTransferencia,
                            sCodArguNombreEstadoTransferencia=item.sCodArguNombreEstadoTransferencia,
							sUsuarioSolicitante = item.sUsuarioSolicitante,
							sCodSacOrigen = item.sCodSacOrigen,
                            sNombreLocalDestino = item.NombreLocalDestino,
							sUsuarioSacOrigen = item.sUsuarioSacOrigen,
                            dFechaProcesoRetiro = item.dFechaProcesoRetiro,
							sCodSacDestino = item.sCodSacDestino,
                            sNombreLocalOrigen=item.NombreLocalOrigen,
							sUsuarioSacDestino = item.sUsuarioSacDestino,
							dFechaProcesoIngreso = item.dFechaProcesoIngreso,
							SSIUsuario_Creacion = item.SSIUsuario_Creacion,
							SSIFechaHora_Creacion = item.SSIFechaHora_Creacion,
							SSIUsuario_Modificacion = item.SSIUsuario_Modificacion,
							SSIFechaHora_Modificacion = item.SSIFechaHora_Modificacion,
							SSIHost = item.SSIHost

						};
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return Item;
		}

		/// <summary>
		/// Lista todos los registros de la tabla SolicitudTransferencia
		/// <summary>
		/// <returns>List</returns>
		public  List<SolicitudTransferencia> Listar(string pFechaSolicitudIni,string pFechaSolicitudFin,string pCodArguEstadoTransferencia,string pCodTransferencia,string pCodSacOrigen,string pCodSacDestino)
		{
			List<SolicitudTransferencia> Lista = new List<SolicitudTransferencia>();
			try
			{
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
				{
                    var resul = SQLDC.pa_mnt_ListarSolicitudTransferencia(pCodTransferencia, pCodArguEstadoTransferencia, pCodSacOrigen, pCodSacDestino, pFechaSolicitudIni, pFechaSolicitudFin);
					foreach (var item in resul)
					{
						Lista.Add(new SolicitudTransferencia()
						{
							sCodTransferencia = item.sCodTransferencia,
							dFechaProcesoSolicitud = Convert.ToDateTime(item.FechaProcesoSolicitud),
							sCodArguEstadoTransferencia = item.sCodArguEstadoTransferencia,
							sUsuarioSolicitante = item.sUsuarioSolicitante,
							sCodSacOrigen = item.sCodSacOrigen,
							sUsuarioSacOrigen = item.sUsuarioSacOrigen,
							dFechaProcesoRetiro = item.dFechaProcesoRetiro,
							sCodSacDestino = item.sCodSacDestino,
							sUsuarioSacDestino = item.sUsuarioSacDestino,
							dFechaProcesoIngreso = item.dFechaProcesoIngreso,
                            sCodArguNombreEstadoTransferencia = item.sCodArguNombreEstadoTransferencia,
                            sNombreLocalOrigen = item.NombreLocalOrigen,
                            sNombreLocalDestino= item.NombreLocalDestino,
							SSIUsuario_Creacion = item.SSIUsuario_Creacion,
							SSIFechaHora_Creacion = item.SSIFechaHora_Creacion,
							SSIUsuario_Modificacion = item.SSIUsuario_Modificacion,
							SSIFechaHora_Modificacion = item.SSIFechaHora_Modificacion,
							SSIHost = item.SSIHost

						});
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return Lista;
		}
	#endregion 

	#region " /* Funciones Modificar */ "

		/// <summary>
		/// Modificar los registros de la tabla SolicitudTransferencia que cumplan con los parametros de busqueda embiados
		/// </summary>
		/// <param name="pItem"></param>
		/// <returns></returns>
		public  bool Actualizar(SolicitudTransferencia  pItem)
		{
			int lnAfectados = -1;
			try
			{
				using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
				{
					lnAfectados = SQLDC.pa_mnt_ActualizarSolicitudTransferencia(
						pItem.sCodTransferencia,
						pItem.dFechaProcesoSolicitud,
						pItem.sCodArguEstadoTransferencia,
						pItem.sUsuarioSolicitante,
						pItem.sCodSacOrigen,
						pItem.sUsuarioSacOrigen,
						pItem.dFechaProcesoRetiro,
						pItem.sCodSacDestino,
						pItem.sUsuarioSacDestino,
						pItem.dFechaProcesoIngreso,						
						pItem.SSIUsuario_Modificacion,						
						pItem.SSIHost

					);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return lnAfectados == 0 ? true : false;
		}
        public bool ActualizarRetiro(SolicitudTransferencia pItem)
        {
            int lnAfectados = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    lnAfectados = SQLDC.pa_pro_ActualizarSolicitudTransferencia_Retiro(
                        pItem.sCodTransferencia,                        
                        pItem.sCodArguEstadoTransferencia,                        
                        pItem.sUsuarioSacOrigen,
                        pItem.dFechaProcesoRetiro,                        
                        pItem.SSIUsuario_Modificacion
                        

                    );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lnAfectados == 0 ? true : false;
        }
        public bool ActualizarIngreso(SolicitudTransferencia pItem)
        {
            int lnAfectados = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    lnAfectados = SQLDC.pa_pro_ActualizarSolicitudTransferencia_Ingreso(
                        pItem.sCodTransferencia,
                        pItem.sCodArguEstadoTransferencia,
                        pItem.sUsuarioSacDestino,
                        pItem.dFechaProcesoIngreso,
                        pItem.SSIUsuario_Modificacion


                    );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lnAfectados == 0 ? true : false;
        }
	#endregion 

	#region " /* Funciones Eliminar */ "

		/// <summary>
		/// Eliminar
		/// </summary>
		public  bool Eliminar(string sCodTransferencia)
		{
			int lnAfectados = -1;
			try
			{
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
				{

					lnAfectados = SQLDC.pa_mnt_EliminarSolicitudTransferencia(sCodTransferencia);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return lnAfectados == 0 ? true : false;
		}
	#endregion 
	}
}
