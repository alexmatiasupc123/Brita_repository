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
	public class SolicitudTransferenciaLogic
	{
		private SolicitudTransferenciaData oSolicitudTransferenciaData = null;
        private SolicitudTransferenciaDetalleData oSolicitudTransferenciaDetalleData = null;
        private ItemEjemplarData oItemEjemplarData = null;
		private ReturnValor oReturn = null;
        string CodArguTransferenciaEjemplar = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoEnTransferenciaEjemplar);
		public SolicitudTransferenciaLogic()
		{
			oSolicitudTransferenciaData = new SolicitudTransferenciaData();
            oSolicitudTransferenciaDetalleData = new SolicitudTransferenciaDetalleData();
            oItemEjemplarData = new ItemEjemplarData();
			oReturn = new ReturnValor();
		}

	#region " /* Funciones Insertar */ "

		/// <summary>
		/// Ingresa un registro en la tabla [TableName]
		/// </summary>
		/// <param name="pItem"></param>
		public  ReturnValor Registrar(SolicitudTransferencia  pItem)
		{
			try
			{
                string CodigoRetorno = string.Empty;
				using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
				{
                    CodigoRetorno=this.oSolicitudTransferenciaData.Registrar(pItem);
                    if (pItem.ListaDetalleTransferencia != null)
                    {
                        foreach (SolicitudTransferenciaDetalle oitemDetalle in pItem.ListaDetalleTransferencia)
                        {
                            oitemDetalle.sCodTransferencia = CodigoRetorno;
                            oSolicitudTransferenciaDetalleData.Registrar(oitemDetalle);
                            oItemEjemplarData.Actualizar_EstadoEjemplar(oitemDetalle.sCodEjemplar, CodArguTransferenciaEjemplar, oitemDetalle.SSIUsuario_Creacion);
                            
                        }

                    }
                    oReturn.Exitosa = true;
                    oReturn.CodigoRetorno = CodigoRetorno;
                    if (oReturn.Exitosa)
                    {
                        tx.Complete();
                        oReturn.Message = HelpMessage.Message(HelpMessage.TMessage.Registrar);

                    }
                    else
                        oReturn.Message = "El registro no tubo efecto";
					
				}
			}
			catch (Exception ex)
			{
                oReturn = HelpMessage.Message(ex);
			}
			return oReturn;
		}
	#endregion 

	#region " /* Funciones Seleccionar */ "

		/// <summary>
		/// Buscar un regitro de la tabla SolicitudTransferencia segun su pk enviado por parametro
		/// </summary>
		/// <returns>Item</returns>
		public  SolicitudTransferencia Buscar(string sCodTransferencia,string sTipoRetiro_Ingreso)
		{
			 SolicitudTransferencia Item = new SolicitudTransferencia();
			try
			{
				Item = this.oSolicitudTransferenciaData.Buscar(sCodTransferencia);
                if (sTipoRetiro_Ingreso == "R" || sTipoRetiro_Ingreso == "T")
                    Item.ListaDetalleTransferencia = this.oSolicitudTransferenciaDetalleData.Listar(sCodTransferencia);
                else
                    Item.ListaDetalleTransferencia = this.oSolicitudTransferenciaDetalleData.ListarDetalleIngreso(sCodTransferencia);
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
        public List<SolicitudTransferencia> Listar(string pFechaSolicitudIni, string pFechaSolicitudFin, string pCodArguEstadoTransferencia, string pCodTransferencia, string pCodSacOrigen, string pCodSacDestino)
		{
			List<SolicitudTransferencia> Lista = new List<SolicitudTransferencia>();
			try
			{
                Lista = this.oSolicitudTransferenciaData.Listar(pFechaSolicitudIni, pFechaSolicitudFin, pCodArguEstadoTransferencia, pCodTransferencia, pCodSacOrigen, pCodSacDestino);
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
		public  ReturnValor Actualizar(SolicitudTransferencia  pItem)
		{
			try
			{
				using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
				{
					oSolicitudTransferenciaData.Actualizar(pItem);
                    if (pItem.ListaDetalleTransferencia != null)
                    {
                        oSolicitudTransferenciaDetalleData.Eliminar(pItem.sCodTransferencia, null);
                        foreach (SolicitudTransferenciaDetalle oitemDetalle in pItem.ListaDetalleTransferencia)
                        {
                            oitemDetalle.sCodTransferencia = pItem.sCodTransferencia;
                            oSolicitudTransferenciaDetalleData.Registrar(oitemDetalle);
                            oItemEjemplarData.Actualizar_EstadoEjemplar(oitemDetalle.sCodEjemplar, CodArguTransferenciaEjemplar, oitemDetalle.SSIUsuario_Modificacion);
                        }
                    }
                    oReturn.Exitosa = true;
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
        public ReturnValor Actualizar_Retiro(SolicitudTransferencia pItem)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oSolicitudTransferenciaData.ActualizarRetiro(pItem);
                    if (pItem.ListaDetalleTransferencia != null)
                    {
                        
                        foreach (SolicitudTransferenciaDetalle oitemDetalle in pItem.ListaDetalleTransferencia)
                        {                            
                            oSolicitudTransferenciaDetalleData.ActualizarRetiro(oitemDetalle);                            
                        }
                    }
                    oReturn.Exitosa = true;
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
        public ReturnValor Actualizar_Ingreso(SolicitudTransferencia pItem)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oSolicitudTransferenciaData.ActualizarIngreso(pItem);
                    if (pItem.ListaDetalleTransferencia != null)
                    {                        
                        foreach (SolicitudTransferenciaDetalle oitemDetalle in pItem.ListaDetalleTransferencia)
                        {
                            oSolicitudTransferenciaDetalleData.ActualizarIngreso(oitemDetalle);
                            oItemEjemplarData.Actualizar_EstadoEjemplar(oitemDetalle.sCodEjemplar,HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoDisponibleEjemplar), pItem.SSIUsuario_Modificacion);
                            oItemEjemplarData.Actualizar_SacEjemplar(oitemDetalle.sCodEjemplar,pItem.sCodSacDestino, pItem.SSIUsuario_Modificacion);
                        }
                    }
                    oReturn.Exitosa = true;
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
		public  ReturnValor Eliminar(string sCodTransferencia,string Usuario)
		{
			try
			{
				using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
				{
                    List<SolicitudTransferenciaDetalle> Lista = oSolicitudTransferenciaDetalleData.Listar(sCodTransferencia);
                    List<ItemEjemplar> ListaEjemplaresTrans = new List<ItemEjemplar>();
                    foreach (SolicitudTransferenciaDetalle itemTrans in Lista)
                    {
                        oItemEjemplarData.Actualizar_EstadoEjemplar(itemTrans.sCodEjemplar,HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoDisponibleEjemplar), Usuario);
                        
                    }
                    oSolicitudTransferenciaDetalleData.Eliminar(sCodTransferencia,null);
					oSolicitudTransferenciaData.Eliminar(sCodTransferencia);
                    oReturn.Exitosa = true;
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
