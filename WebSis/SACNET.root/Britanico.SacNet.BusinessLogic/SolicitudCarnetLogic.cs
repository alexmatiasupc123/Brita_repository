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
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 14/07/2010-11:03:42 
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [Sacnet.SolicitudCarnetLogic.cs]
    /// </summary>
    public class SolicitudCarnetLogic
    {
        private SolicitudCarnetData oSolicitudCarnetData = null;
        private ReturnValor oReturnValor = null;
        public SolicitudCarnetLogic()
        {
            oSolicitudCarnetData = new SolicitudCarnetData();
            oReturnValor = new ReturnValor();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Sacnet.SolicitudCarnet
        /// En la BASE de DATO la Tabla : [Sacnet.SolicitudCarnet]
        /// <summary>
        /// <returns>List</returns>
        public List<SolicitudCarnet> Listar(Nullable<DateTime> prm_dFechaProcesoINI, Nullable<DateTime> prm_dFechaProcesoFIN,
                                          string prm_sCodUsuarioSAC, string prm_sNombresUsuarioSAC,
                                          string prm_sEstablecimientoCodigo, string prm_sCodArguEstado1,
                                          string prm_sCodArguEstado2)
        {
            List<SolicitudCarnet> miLista = new List<SolicitudCarnet>();
            try
            {
                miLista = oSolicitudCarnetData.Listar(HelpDates.FormatFechaYMD(prm_dFechaProcesoINI), HelpDates.FormatFechaYMD(prm_dFechaProcesoFIN),
                                                                    prm_sCodUsuarioSAC, prm_sNombresUsuarioSAC,
                                                                    prm_sEstablecimientoCodigo, prm_sCodArguEstado1,
                                                                    prm_sCodArguEstado2);

                foreach (SolicitudCarnet qSolicitudCarnet in miLista)
                {
                    string xTipDoc = string.Empty;
                    string xNumDoc = string.Empty;

                    xTipDoc = qSolicitudCarnet.sTipoDocumento == null ? string.Empty : qSolicitudCarnet.sTipoDocumento;
                    xNumDoc = qSolicitudCarnet.sNumeroDocumento == null ? string.Empty : qSolicitudCarnet.sNumeroDocumento;

                    qSolicitudCarnet.TipoDocuNumero = xTipDoc + " - " + xNumDoc;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miLista;
        }

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        public SolicitudCarnet Buscar(string prm_sCodSolicitud)
        {
            SolicitudCarnet miEntidad = new SolicitudCarnet();
            try
            {
                miEntidad = oSolicitudCarnetData.Buscar(prm_sCodSolicitud);

                string xTipDoc = string.Empty;
                string xNumDoc = string.Empty;

                 xTipDoc = miEntidad.sTipoDocumento == null ? string.Empty :  miEntidad.sTipoDocumento ;
                 xNumDoc = miEntidad.sNumeroDocumento == null ? string.Empty : miEntidad.sNumeroDocumento;

                 miEntidad.TipoDocuNumero = xTipDoc + " _ " + xNumDoc;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miEntidad;
        }

        public SolicitudCarnet BuscarPorCodUsuarioSAC(string prm_sCodUsuarioSAC)
        {
            SolicitudCarnet miEntidad = new SolicitudCarnet();
            try
            {
                miEntidad = oSolicitudCarnetData.BuscarPorCodUsuarioSAC(prm_sCodUsuarioSAC);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo SolicitudCarnet
        /// En la BASE de DATO la Tabla : [Sacnet.SolicitudCarnet]
        /// <summary>
        /// <param name = >itemSolicitudCarnet</param>
        public ReturnValor Registrar(SolicitudCarnet itemSolicitudCarnet)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {

                    //SolicitudCarnet miEntidad = new SolicitudCarnet();
                    //miEntidad = oSolicitudCarnetData.BuscarPorCodUsuarioSAC(itemSolicitudCarnet.sCodUsuarioSAC);
                    //if (miEntidad.sCodUsuarioSAC == null)
                    //{
                    oReturnValor.CodigoRetorno = oSolicitudCarnetData.Registrar(itemSolicitudCarnet);
                    itemSolicitudCarnet.sCodSolicitud = oReturnValor.CodigoRetorno;

                    //ELVP: 15-07-2011
                    oReturnValor.Exitosa = true; //oSolicitudCarnetData.ActualizarCorreoElectronico(itemSolicitudCarnet);

                    if (oReturnValor.CodigoRetorno != null && oReturnValor.Exitosa)
                    {
                        oReturnValor.Exitosa = true;
                        oReturnValor.Message = HelpMessage.Message(HelpMessage.TMessage.Registrar);
                        tx.Complete();
                    }
                    //}
                    //else
                    //{
                    //    if (miEntidad.sCodArguEstado == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoCarneP05))
                    //    {
                    //        oReturnValor.Exitosa = oSolicitudCarnetData.RegistrarHistoria(miEntidad);
                    //        itemSolicitudCarnet.sCodSolicitud = miEntidad.sCodSolicitud;
                    //        oReturnValor.Exitosa = oSolicitudCarnetData.ActualizarSolicitudCarnetDuplicado(itemSolicitudCarnet);
                    //    }
                    //    else
                    //        itemSolicitudCarnet.bDuplicado = false;
                        //itemSolicitudCarnet.sCodSolicitud = miEntidad.sCodSolicitud;
                        //oReturnValor.Exitosa = oSolicitudCarnetData.ActualizarSolicitudCarnet(itemSolicitudCarnet);
                        //if (oReturnValor.Exitosa)
                        //{
                        //    oReturnValor.Message = HelpMessage.Message(HelpMessage.TMessage.Editar);
                        //    tx.Complete();
                        //}
                        //else
                        //    oReturnValor.Message = "¡ Los Datos NO se han ACTUALIZADO !";

                    //}
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpMessage.Message(ex);
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo SolicitudCarnet
        /// En la BASE de DATO la Tabla : [Sacnet.SolicitudCarnet]
        /// <summary>
        /// <param name = >itemSolicitudCarnet</param>
        public ReturnValor ActualizarSolicitudCarnet(SolicitudCarnet itemSolicitudCarnet, int pPasoEstado)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    switch (pPasoEstado)
                    {
                        case 1: // 1
                            oReturnValor.Exitosa = oSolicitudCarnetData.ActualizarSolicitudCarnet(itemSolicitudCarnet);

                            if (oReturnValor.Exitosa)
                            {
                                //ELVP: 15-07-2011
                                oReturnValor.Exitosa = true; //oSolicitudCarnetData.ActualizarCorreoElectronico(itemSolicitudCarnet);
                                
                            }
                            else
                                break;

                            break;
                        case 2: // 2
                            oReturnValor.Exitosa = oSolicitudCarnetData.ActualizarSolicitudCarnetImpreso(itemSolicitudCarnet);
                            break;
                        case 3://3
                            oReturnValor.Exitosa = oSolicitudCarnetData.ActualizarSolicitudCarnetEntregaSAC(itemSolicitudCarnet);
                            break;
                        case 4://4
                            oReturnValor.Exitosa = oSolicitudCarnetData.ActualizarSolicitudCarnetEntregaUsuario(itemSolicitudCarnet);
                            break;
                        case 5: //5
                            oReturnValor.Exitosa = oSolicitudCarnetData.ActualizarSolicitudCarnetCambiaEstado(itemSolicitudCarnet);
                            break;
                    }
                    
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessage.Message(HelpMessage.TMessage.Editar);
                        tx.Complete();
                    }
                    else
                        oReturnValor.Message = "¡ Los Datos NO HAN sido ACTUALIZADO !";
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpMessage.Message(ex);
            }
            return oReturnValor;
        }

        //ELVP: 15-07-2011
        public ReturnValor ActualizarSolicitudCarnet(List<SolicitudCarnet> lstSolicitudCarnet)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    foreach (SolicitudCarnet objSolicitudCarnet in lstSolicitudCarnet)
                    {
                        oReturnValor.Exitosa = oSolicitudCarnetData.ActualizarSolicitudCarnet(objSolicitudCarnet);

                        if (!oReturnValor.Exitosa)
                            break;
                    }

                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessage.Message(HelpMessage.TMessage.Editar);
                        tx.Complete();
                    }
                    else
                        oReturnValor.Message = "¡ Los Datos NO HAN sido ACTUALIZADO !";
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpMessage.Message(ex);
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Sacnet.SolicitudCarnet
        /// En la BASE de DATO la Tabla : [Sacnet.SolicitudCarnet]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Eliminar(string prm_sCodSolicitud)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oSolicitudCarnetData.Eliminar(prm_sCodSolicitud);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessage.Message( HelpMessage.TMessage.Eliminar);
                        tx.Complete();
                    }
                    else
                        oReturnValor.Message = "¡ El Registro NO HA SIDO ELIMINADO !";
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpMessage.Message(ex);
            }
            return oReturnValor;
        }
        #endregion

    }
} 
