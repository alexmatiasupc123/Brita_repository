using System;
using System.Collections.Generic;
using System.Configuration;

using Britanico.SacNet.BusinessEntities;

namespace Britanico.SacNet.DataAccess
{
    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 14/07/2010-11:03:41 
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Sacnet.SolicitudCarnetData.cs]
    /// </summary>
    public class SolicitudCarnetData
    {
        private string conexion = string.Empty;

        public SolicitudCarnetData()
        {
            conexion = ConfigurationManager.ConnectionStrings["cnSacNET"].ConnectionString;
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Sacnet.SolicitudCarnet
        /// En la BASE de DATO la Tabla : [Sacnet.SolicitudCarnet]
        /// <summary>
        /// <returns>List</returns>
        public List<SolicitudCarnet> Listar(string prm_dFechaProcesoINI, string prm_dFechaProcesoFIN, string prm_sCodUsuarioSAC, string prm_sNombresUsuarioSAC, string prm_sEstablecimientoCodigo, string prm_sCodArguEstado1, string prm_sCodArguEstado2)
        {
            List<SolicitudCarnet> miLista = new List<SolicitudCarnet>();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_mnt_ListarSolicitudCarnet(prm_dFechaProcesoINI, prm_dFechaProcesoFIN, prm_sCodUsuarioSAC, prm_sNombresUsuarioSAC, prm_sEstablecimientoCodigo, prm_sCodArguEstado1, prm_sCodArguEstado2);
                    foreach (var item in resul)
                    {
                        miLista.Add(new SolicitudCarnet()
                        {
                            sCodSolicitud = item.sCodSolicitud,
                            sCodUsuarioSAC = item.sCodUsuarioSAC,
                            sNombresUsuarioSAC = item.sNombresUsuarioSAC,
                            sApellidosUsuarioSAC = item.sApellidosUsuarioSAC,
                            dFechaProceso = item.dFechaProceso,
                            sCodArguEstado = item.sCodArguEstado,
                            sUsuario = item.sUsuario,
                            sTipoDocumento = item.sTipoDocumento.ToString().Trim(),
                            sNumeroDocumento = item.sNumeroDocumento.ToString().Trim(),
                            sEstablecimientoCodigo = item.sEstablecimientoCodigo,
                            bFotografia = item.bFotografia,
                            bDuplicado = item.bDuplicado,
                            dFechaSolicitaImpresion = item.dFechaSolicitaImpresion,
                            dFechaImpresion = item.dFechaImpresion,
                            dFechaEntregaSAC = item.dFechaEntregaSAC,
                            dFechaEntregaUsuario = item.dFechaEntregaUsuario,
                            sUsuarioSolicitaImpresion = item.sUsuarioSolicitaImpresion,
                            sUsuarioImpresion = item.sUsuarioImpresion,
                            sUsuarioEntregaSAC = item.sUsuarioEntregaSAC,
                            sUsuarioEntregaUsuario = item.sUsuarioEntregaUsuario,
                            SSIUsuario_Creacion = item.SSIUsuario_Creacion,
                            SSIFechaHora_Creacion = item.SSIFechaHora_Creacion,
                            SSIUsuario_Modificacion = item.SSIUsuario_Modificacion,
                            SSIFechaHora_Modificacion = item.SSIFechaHora_Modificacion,
                            SSIHost = item.SSIHost,
                            sCodArguEstadoNombre = item.sCodArguEstadoNombre,
                            sEstablecimientoCodigoNombre = item.sEstablecimientoCodigoNombre,
                            sCodLocalSACSolicita = item.sCodLocalSACSolicita,
                            sCodLocalSACSolicitaNombre = item.sCodLocalSACSolicitaNombre,
                            sCodLocalSACUsuario = item.sCodLocalSACUsuario,
                            sCodLocalSACUsuarioNombre = item.sCodLocalSACUsuarioNombre,
                            sApellidosNombresUsuarioSAC = item.sApellidosUsuarioSAC + ", " + item.sNombresUsuarioSAC,
                            sistemaSubsistema = item.sistemaSubsistema,
                        });
                    }
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

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Sacnet.SolicitudCarnet
        /// En la BASE de DATO la Tabla : [Sacnet.SolicitudCarnet]
        /// <summary>
        /// <returns>Entidad</returns>
        public SolicitudCarnet Buscar(string prm_sCodSolicitud)
        {
            SolicitudCarnet miEntidad = new SolicitudCarnet();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_mnt_BuscarSolicitudCarnet(prm_sCodSolicitud);
                    foreach (var item in resul)
                    {
                        miEntidad = new SolicitudCarnet()
                        {
                            sCodSolicitud = item.sCodSolicitud,
                            sCodUsuarioSAC = item.sCodUsuarioSAC,
                            sNombresUsuarioSAC = item.sNombresUsuarioSAC,
                            sApellidosUsuarioSAC = item.sApellidosUsuarioSAC,
                            dFechaProceso = item.dFechaProceso,
                            sCodArguEstado = item.sCodArguEstado,
                            sUsuario = item.sUsuario,
                            sTipoDocumento = item.sTipoDocumento.ToString().Trim(),
                            sNumeroDocumento = item.sNumeroDocumento.ToString().Trim(),
                            sEstablecimientoCodigo = item.sEstablecimientoCodigo,
                            bFotografia = item.bFotografia,
                            bDuplicado = item.bDuplicado,
                            dFechaSolicitaImpresion = item.dFechaSolicitaImpresion,
                            dFechaImpresion = item.dFechaImpresion,
                            dFechaEntregaSAC = item.dFechaEntregaSAC,
                            dFechaEntregaUsuario = item.dFechaEntregaUsuario,
                            sUsuarioSolicitaImpresion = item.sUsuarioSolicitaImpresion,
                            sUsuarioImpresion = item.sUsuarioImpresion,
                            sUsuarioEntregaSAC = item.sUsuarioEntregaSAC,
                            sUsuarioEntregaUsuario = item.sUsuarioEntregaUsuario,
                            SSIUsuario_Creacion = item.SSIUsuario_Creacion,
                            SSIFechaHora_Creacion = item.SSIFechaHora_Creacion,
                            SSIUsuario_Modificacion = item.SSIUsuario_Modificacion,
                            SSIFechaHora_Modificacion = item.SSIFechaHora_Modificacion,
                            SSIHost = item.SSIHost,
                            sCodArguEstadoNombre = item.sCodArguEstadoNombre,
                            sEstablecimientoCodigoNombre = item.sEstablecimientoCodigoNombre,
                            sCodLocalSACSolicita = item.sCodLocalSACSolicita,
                            sCodLocalSACSolicitaNombre = item.sCodLocalSACSolicitaNombre,
                            sCodLocalSACUsuario = item.sCodLocalSACUsuario,
                            sCodLocalSACUsuarioNombre = item.sCodLocalSACUsuarioNombre,
                            sCorreoElectronico = item.CorreoElectronico,//ELVP: 15-07-2011
                            sApellidosNombresUsuarioSAC = item.sApellidosUsuarioSAC + ", " + item.sNombresUsuarioSAC,
                            nTotalEmitidos = item.TotalEmitidos == null ? 0 : Convert.ToInt32(item.TotalEmitidos)
                        };
                    }
                }
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
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_pro_BuscarSolicitudCarnetsCodUsuarioSAC(prm_sCodUsuarioSAC);
                    foreach (var item in resul)
                    {
                        miEntidad = new SolicitudCarnet()
                        {
                            sCodSolicitud = item.sCodSolicitud,
                            sCodUsuarioSAC = item.sCodUsuarioSAC,
                            sNombresUsuarioSAC = item.sNombresUsuarioSAC,
                            sApellidosUsuarioSAC = item.sApellidosUsuarioSAC,
                            dFechaProceso = item.dFechaProceso,
                            sCodArguEstado = item.sCodArguEstado,
                            sUsuario = item.sUsuario,
                            sTipoDocumento = item.sTipoDocumento.ToString().Trim(),
                            sNumeroDocumento = item.sNumeroDocumento.ToString().Trim(),
                            sEstablecimientoCodigo = item.sEstablecimientoCodigo,
                            bFotografia = item.bFotografia,
                            bDuplicado = item.bDuplicado,
                            dFechaSolicitaImpresion = item.dFechaSolicitaImpresion,
                            dFechaImpresion = item.dFechaImpresion,
                            dFechaEntregaSAC = item.dFechaEntregaSAC,
                            dFechaEntregaUsuario = item.dFechaEntregaUsuario,
                            sUsuarioSolicitaImpresion = item.sUsuarioSolicitaImpresion,
                            sUsuarioImpresion = item.sUsuarioImpresion,
                            sUsuarioEntregaSAC = item.sUsuarioEntregaSAC,
                            sUsuarioEntregaUsuario = item.sUsuarioEntregaUsuario,
                            SSIUsuario_Creacion = item.SSIUsuario_Creacion,
                            SSIFechaHora_Creacion = item.SSIFechaHora_Creacion,
                            SSIUsuario_Modificacion = item.SSIUsuario_Modificacion,
                            SSIFechaHora_Modificacion = item.SSIFechaHora_Modificacion,
                            SSIHost = item.SSIHost,
                            sCodArguEstadoNombre = item.sCodArguEstadoNombre,
                            sEstablecimientoCodigoNombre = item.sEstablecimientoCodigoNombre,
                            sCodLocalSACSolicita = item.sCodLocalSACSolicita,
                            sCodLocalSACSolicitaNombre = item.sCodLocalSACSolicitaNombre,
                            sCodLocalSACUsuario = item.sCodLocalSACUsuario,
                            sCodLocalSACUsuarioNombre = item.sCodLocalSACUsuarioNombre,
                            sApellidosNombresUsuarioSAC = item.sApellidosUsuarioSAC + ", " + item.sNombresUsuarioSAC,
                            nTotalEmitidos = item.TotalEmitidos == null ? 0 : Convert.ToInt32(item.TotalEmitidos)
                        };
                    }
                }
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
        /// <param name="itemSolicitudCarnet">itemSolicitudCarnet</param>
        public string Registrar(SolicitudCarnet itemSolicitudCarnet)
        {
            string codigoRetorno = null;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                        SQLDC.pa_mnt_RegistrarSolicitudCarnet(
                        ref codigoRetorno,
                        itemSolicitudCarnet.sCodUsuarioSAC,
                        itemSolicitudCarnet.sNombresUsuarioSAC,
                        itemSolicitudCarnet.sApellidosUsuarioSAC,
                        itemSolicitudCarnet.dFechaProceso,
                        itemSolicitudCarnet.sCodArguEstado,
                        itemSolicitudCarnet.sCodLocalSACSolicita,
                        itemSolicitudCarnet.sCodLocalSACUsuario,
                        itemSolicitudCarnet.sUsuario,
                        itemSolicitudCarnet.sTipoDocumento,
                        itemSolicitudCarnet.sNumeroDocumento,
                        itemSolicitudCarnet.sEstablecimientoCodigo,
                        itemSolicitudCarnet.bFotografia,
                        itemSolicitudCarnet.bDuplicado,
                        itemSolicitudCarnet.SSIUsuario_Modificacion,
                        itemSolicitudCarnet.SSIHost, 
                        itemSolicitudCarnet.sCorreoElectronico);//ELVP: 15-07-2011
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno ;
        }

        public bool RegistrarHistoria(SolicitudCarnet itemSolicitudCarnet)
        {
            int codigoRetorno = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    codigoRetorno = SQLDC.pa_mnt_RegistrarSolicitudCarnetHistoria(
                     itemSolicitudCarnet.sCodSolicitud,
                     itemSolicitudCarnet.sCodUsuarioSAC,
                     itemSolicitudCarnet.sNombresUsuarioSAC,
                     itemSolicitudCarnet.sApellidosUsuarioSAC,
                     itemSolicitudCarnet.dFechaProceso,
                     itemSolicitudCarnet.sCodArguEstado,
                     itemSolicitudCarnet.sCodLocalSACSolicita,
                     itemSolicitudCarnet.sCodLocalSACUsuario,
                     itemSolicitudCarnet.sUsuario,
                     itemSolicitudCarnet.sTipoDocumento,
                     itemSolicitudCarnet.sNumeroDocumento,
                     itemSolicitudCarnet.sEstablecimientoCodigo,
                     itemSolicitudCarnet.bFotografia,
                     itemSolicitudCarnet.bDuplicado,
                     itemSolicitudCarnet.dFechaSolicitaImpresion,
                     itemSolicitudCarnet.dFechaImpresion,
                     itemSolicitudCarnet.dFechaEntregaSAC,
                     itemSolicitudCarnet.dFechaEntregaUsuario,
                     itemSolicitudCarnet.sUsuarioSolicitaImpresion,
                     itemSolicitudCarnet.sUsuarioImpresion,
                     itemSolicitudCarnet.sUsuarioEntregaSAC,
                     itemSolicitudCarnet.sUsuarioEntregaUsuario,
                     itemSolicitudCarnet.SSIUsuario_Creacion,
                     itemSolicitudCarnet.SSIFechaHora_Creacion,
                     itemSolicitudCarnet.SSIUsuario_Modificacion,
                     itemSolicitudCarnet.SSIFechaHora_Modificacion,
                     itemSolicitudCarnet.SSIHost);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo SolicitudCarnet
        /// En la BASE de DATO la Tabla : [Sacnet.SolicitudCarnet]
        /// <summary>
        /// <param name = >itemSolicitudCarnet</param>
        public bool ActualizarSolicitudCarnet(SolicitudCarnet itemSolicitudCarnet)
        {
            int codigoRetorno = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    codigoRetorno = SQLDC.pa_mnt_ActualizarSolicitudCarnet(
                        itemSolicitudCarnet.sCodSolicitud,
                        itemSolicitudCarnet.sCodUsuarioSAC,
                        itemSolicitudCarnet.sNombresUsuarioSAC,
                        itemSolicitudCarnet.sApellidosUsuarioSAC,
                        itemSolicitudCarnet.sCodArguEstado,
                        itemSolicitudCarnet.sUsuario,
                        itemSolicitudCarnet.sTipoDocumento,
                        itemSolicitudCarnet.sNumeroDocumento,
                        itemSolicitudCarnet.sEstablecimientoCodigo,
                        itemSolicitudCarnet.bFotografia,
                        itemSolicitudCarnet.bDuplicado,
                        itemSolicitudCarnet.dFechaSolicitaImpresion,
                        itemSolicitudCarnet.sUsuarioSolicitaImpresion,
                        itemSolicitudCarnet.SSIUsuario_Modificacion,
                        itemSolicitudCarnet.sCorreoElectronico);//ELVP: 15-07-2011
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        public bool ActualizarSolicitudCarnetImpreso(SolicitudCarnet itemSolicitudCarnet)
        {
            int codigoRetorno = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    codigoRetorno = SQLDC.pa_mnt_ActualizarSolicitudCarnetImpreso(
                        itemSolicitudCarnet.sCodSolicitud,
                        itemSolicitudCarnet.sCodArguEstado,
                        DateTime.Now,
                        itemSolicitudCarnet.sUsuarioImpresion,
                        itemSolicitudCarnet.SSIUsuario_Modificacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        public bool ActualizarSolicitudCarnetEntregaSAC(SolicitudCarnet itemSolicitudCarnet)
        {
            int codigoRetorno = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    codigoRetorno = SQLDC.pa_mnt_ActualizarSolicitudCarnetEntregaSAC(
                        itemSolicitudCarnet.sCodSolicitud,
                        itemSolicitudCarnet.sCodArguEstado,
                        DateTime.Now,
                        itemSolicitudCarnet.sUsuarioEntregaSAC,
                        itemSolicitudCarnet.SSIUsuario_Modificacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        public bool ActualizarSolicitudCarnetEntregaUsuario(SolicitudCarnet itemSolicitudCarnet)
        {
            int codigoRetorno = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    codigoRetorno = SQLDC.pa_mnt_ActualizarSolicitudCarnetEntregaUsuario(
                        itemSolicitudCarnet.sCodSolicitud,
                        itemSolicitudCarnet.sCodArguEstado,
                        DateTime.Now,
                        itemSolicitudCarnet.sUsuarioEntregaUsuario,
                        itemSolicitudCarnet.SSIUsuario_Modificacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        public bool ActualizarSolicitudCarnetDuplicado(SolicitudCarnet itemSolicitudCarnet)
        {
            int codigoRetorno = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    codigoRetorno = SQLDC.pa_pro_ActualizarSolicitudCarnetDuplicado(
                        itemSolicitudCarnet.sCodSolicitud,
                        itemSolicitudCarnet.sCodUsuarioSAC,
                        itemSolicitudCarnet.sNombresUsuarioSAC,
                        itemSolicitudCarnet.sApellidosUsuarioSAC,
                        itemSolicitudCarnet.sCodArguEstado,
                        itemSolicitudCarnet.sUsuario,
                        itemSolicitudCarnet.SSIUsuario_Modificacion,
                        itemSolicitudCarnet.SSIHost);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        public bool ActualizarSolicitudCarnetCambiaEstado(SolicitudCarnet itemSolicitudCarnet)
        {
            int codigoRetorno = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    codigoRetorno = SQLDC.pa_pro_ActualizarSolicitudCarnetCambiaEstado(
                        itemSolicitudCarnet.sCodSolicitud,
                        itemSolicitudCarnet.sCodArguEstado,
                        itemSolicitudCarnet.SSIUsuario_Modificacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        //ELVP: 15-07-2011
        public bool ActualizarCorreoElectronico(SolicitudCarnet itemSolicitudCarnet)
        {
            int codigoRetorno = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    codigoRetorno = SQLDC.pa_mnt_ActualizarCorreoElectronico(
                        itemSolicitudCarnet.sCodSolicitud,
                        itemSolicitudCarnet.sCorreoElectronico);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Sacnet.SolicitudCarnet
        /// En la BASE de DATO la Tabla : [Sacnet.SolicitudCarnet]
        /// <summary>
        /// <returns>bool</returns>
        public bool Eliminar(string prm_sCodSolicitud)
        {
            int codigoRetorno = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    codigoRetorno = SQLDC.pa_mnt_EliminarSolicitudCarnet(prm_sCodSolicitud);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        #endregion

    }
} 
