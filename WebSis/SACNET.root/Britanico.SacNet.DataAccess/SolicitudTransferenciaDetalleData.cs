using System;
using System.Configuration;
using System.Collections.Generic;
using Britanico.SacNet.BusinessEntities ;

namespace Britanico.SacNet.DataAccess
{
	/// <summary>
	/// 
	/// </summary>
	public class SolicitudTransferenciaDetalleData
	{
		public string conexion = string.Empty;
		public SolicitudTransferenciaDetalleData()
		{
            conexion = ConfigurationManager.ConnectionStrings["cnSacNET"].ConnectionString;
		}

	#region " /* Funciones Insertar */ "

		/// <summary>
		/// Ingresa un registro en la tabla SolicitudTransferenciaDetalle
		/// </summary>
		/// <param name="pItem"></param>
		public  bool Registrar(SolicitudTransferenciaDetalle  pItem)

		{
			int lnAfectados = -1;
			try
			{
				using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
				{
                    lnAfectados = SQLDC.pa_mnt_RegistrarSolicitudTransferenciaDetalle(
						pItem.sCodTransferencia,
						pItem.sCodEjemplar,
						pItem.bAprobacionRetiro,
						pItem.bAprobacionIngreso,
						pItem.SSIUsuario_Creacion,						
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
	#endregion 

	#region " /* Funciones Seleccionar */ "

		/// <summary>
		/// Lista todos los registros de la tabla SolicitudTransferenciaDetalle
		/// <summary>
		/// <returns>List</returns>
		public  List<SolicitudTransferenciaDetalle> Listar(string pCodTransferencia)
		{
			List<SolicitudTransferenciaDetalle> Lista = new List<SolicitudTransferenciaDetalle>();
			try
			{
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
				{
                    var resul = SQLDC.pa_mnt_ListarSolicitudTransferenciaDetalle(pCodTransferencia);
					foreach (var item in resul)
					{
						Lista.Add(new SolicitudTransferenciaDetalle()
						{
							sCodTransferencia = item.sCodTransferencia,
							sCodEjemplar = item.sCodEjemplar,
                            sCodItem = item.sCodItem,
                            sTituloItem=item.sTitulo,
							bAprobacionRetiro = item.bAprobacionRetiro,
							bAprobacionIngreso = item.bAprobacionIngreso,
							SSIUsuario_Creacion = item.SSIUsuario_Creacion,
							SSIFechaHora_Creacion = item.SSIFechaHora_Creacion,
							SSIUsuario_Modificacion = item.SSIUsuario_Modificacion,
							SSIFechaHora_Modificacion = item.SSIFechaHora_Modificacion,
							SSIHost = item.SSIHost,
                            sCodSacNombre = item.NombreLocal,
                            sCodSac=item.CodLocalSAC

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
        public List<SolicitudTransferenciaDetalle> ListarDetalleIngreso(string pCodTransferencia)
        {
            List<SolicitudTransferenciaDetalle> Lista = new List<SolicitudTransferenciaDetalle>();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_mnt_ListarSolicitudTransferenciaDetalle_Ingreso(pCodTransferencia);
                    foreach (var item in resul)
                    {
                        Lista.Add(new SolicitudTransferenciaDetalle()
                        {
                            sCodTransferencia = item.sCodTransferencia,
                            sCodEjemplar = item.sCodEjemplar,
                            sCodItem = item.sCodItem,
                            sTituloItem = item.sTitulo,
                            bAprobacionRetiro = item.bAprobacionRetiro,
                            bAprobacionIngreso = item.bAprobacionIngreso,
                            SSIUsuario_Creacion = item.SSIUsuario_Creacion,
                            SSIFechaHora_Creacion = item.SSIFechaHora_Creacion,
                            SSIUsuario_Modificacion = item.SSIUsuario_Modificacion,
                            SSIFechaHora_Modificacion = item.SSIFechaHora_Modificacion,
                            SSIHost = item.SSIHost,
                            sCodSacNombre = item.NombreLocal

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
		/// Modificar los registros de la tabla SolicitudTransferenciaDetalle que cumplan con los parametros de busqueda embiados
		/// </summary>
		/// <param name="pItem"></param>
		/// <returns></returns>
		public  bool Actualizar(SolicitudTransferenciaDetalle  pItem)
		{
			int lnAfectados = -1;
			try
			{
				using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
				{
					lnAfectados = SQLDC.pa_mnt_ActualizarSolicitudTransferenciaDetalle(
						pItem.sCodTransferencia,
						pItem.sCodEjemplar,
						pItem.bAprobacionRetiro,
						pItem.bAprobacionIngreso,						
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
        public bool ActualizarRetiro(SolicitudTransferenciaDetalle pItem)
        {
            int lnAfectados = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    lnAfectados = SQLDC.pa_pro_ActualizarSolicitudTransferenciaDetalle_Retiro(
                        pItem.sCodTransferencia,
                        pItem.sCodEjemplar,
                        pItem.bAprobacionRetiro,                        
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
        public bool ActualizarIngreso(SolicitudTransferenciaDetalle pItem)
        {
            int lnAfectados = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    lnAfectados = SQLDC.pa_pro_ActualizarSolicitudTransferenciaDetalle_Ingreso(
                        pItem.sCodTransferencia,
                        pItem.sCodEjemplar,
                        pItem.bAprobacionIngreso,
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
		public  bool Eliminar(string sCodTransferencia, string sCodEjemplar)
		{
			int lnAfectados = -1;
			try
			{
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
				{

					lnAfectados = SQLDC.pa_mnt_EliminarSolicitudTransferenciaDetalle(sCodTransferencia, sCodEjemplar);
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
