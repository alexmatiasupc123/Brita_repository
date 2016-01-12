using System;
using System.Configuration;
using System.Collections.Generic;
using System.Transactions;
using Britanico.SacNet.BusinessEntities ;
using Britanico.SacNet.DataAccess ;
using Oxinet.Tools;

namespace Britanico.SacNet.BusinessLogic
{
	/// <summary>
	/// 
	/// </summary>
	public class SolicitudTransferenciaDetalleLogic
	{
		private SolicitudTransferenciaDetalleData oSolicitudTransferenciaDetalleData = null;
        private ItemEjemplarData oItemEjemplarData = null;
		private ReturnValor oReturn = null;
		public SolicitudTransferenciaDetalleLogic()
		{
			oSolicitudTransferenciaDetalleData = new SolicitudTransferenciaDetalleData();
            oItemEjemplarData = new ItemEjemplarData();
			oReturn = new ReturnValor();
		}

	

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
                Lista = this.oSolicitudTransferenciaDetalleData.Listar(pCodTransferencia);
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
                Lista = this.oSolicitudTransferenciaDetalleData.ListarDetalleIngreso(pCodTransferencia);
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
		/// Modificar los registros de la tabla [TableName] que cumplan con los parametros de busqueda embiados
		/// </summary>
		/// <param name="pItem"></param>
		/// <returns></returns>
		public  ReturnValor Actualizar(SolicitudTransferenciaDetalle  pItem)
		{
			try
			{
				using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
				{
					oReturn.Exitosa = oSolicitudTransferenciaDetalleData.Actualizar(pItem);
                    if (oReturn.Exitosa)
                    {
                        tx.Complete();
                        oReturn.Message = HelpMessage.Message(HelpMessage.TMessage.Editar);
                    }
                    else
                        oReturn.Message = "La modificacion no tubo efecto";
				}
			}
			catch (Exception ex)
			{
                oReturn = HelpMessage.Message(ex);
			}
			return oReturn;
		}
	#endregion 

	#region " /* Funciones Eliminar */ "

		/// <summary>
		/// Eliminar
		/// </summary>
        public ReturnValor Eliminar(string sCodTransferencia, string sCodEjemplar, string Usuario)
		{
			try
			{
				using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
				{

                    oItemEjemplarData.Actualizar_EstadoEjemplar(sCodEjemplar,HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoDisponibleEjemplar), Usuario);
					oReturn.Exitosa = oSolicitudTransferenciaDetalleData.Eliminar(sCodTransferencia, sCodEjemplar);
                    if (oReturn.Exitosa)
                    {
                        tx.Complete();
                        oReturn.Message = HelpMessage.Message(HelpMessage.TMessage.Eliminar);
                    }
                    else
                        oReturn.Message = "La eliminación no tubo efecto";
				}
			}
			catch (Exception ex)
			{
                oReturn = HelpMessage.Message(ex);
			}
			return oReturn;
		}
	#endregion 
	}
}
