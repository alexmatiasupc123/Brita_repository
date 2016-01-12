using System;
using System.Collections.Generic;
using System.Configuration;

using Britanico.SacNet.BusinessEntities;

namespace Britanico.SacNet.DataAccess
{
    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 14/07/2010-11:03:41 
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Sacnet.UsuariosBloqueadosData.cs]
    /// </summary>
    public class UsuariosBloqueadosData
    {
        private string conexion = string.Empty;
        public UsuariosBloqueadosData()
        {
            conexion = ConfigurationManager.ConnectionStrings["cnSacNET"].ConnectionString;
        }
        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Sacnet.UsuariosBloqueados
        /// En la BASE de DATO la Tabla : [Sacnet.UsuariosBloqueados]
        /// <summary>
        /// <returns>List</returns>
        public List<UsuariosBloqueados> Listar(string prm_dFechaProcesoINI, string prm_dFechaProcesoFIN, string prm_sCodUsuarioSAC, bool prm_bEstado)
        {
            List<UsuariosBloqueados> miLista = new List<UsuariosBloqueados>();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_mnt_ListarUsuariosBloqueados(prm_dFechaProcesoINI, prm_dFechaProcesoFIN, prm_sCodUsuarioSAC, prm_bEstado);
                    foreach (var item in resul)
                    {
                        miLista.Add(new UsuariosBloqueados()
                        {
                            sCodUsuarioSAC = item.sCodUsuarioSAC,
                            dFechaBloqueoON = item.dFechaBloqueoON,
                            dFechaBloqueoOFF = item.dFechaBloqueoOFF,
                            bEstado = item.bEstado,
                            SSIUsuario_Creacion = item.SSIUsuario_Creacion,
                            SSIFechaHora_Creacion = item.SSIFechaHora_Creacion,
                            SSIUsuario_Modificacion = item.SSIUsuario_Modificacion,
                            SSIFechaHora_Modificacion = item.SSIFechaHora_Modificacion,
                            SSIHost = item.SSIHost,
                            sCodRegistro = item.sCodRegistro,
                            sCodUsuarioSACApellidosNombre = item.sCodUsuarioSACApellidosNombre
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


        #region /* Proceso de INSERT RECORD */

        
        /// <summary>
        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo UsuariosBloqueados
        /// En la BASE de DATO la Tabla : [Sacnet.UsuariosBloqueados]
        /// </summary>
        /// <param name="itemUsuariosBloqueados"></param>
        /// <returns></returns>
        public string Registrar(UsuariosBloqueados itemUsuariosBloqueados)
        {
            string codigoRetorno = null;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                     SQLDC.pa_mnt_RegistrarUsuariosBloqueados(
                         ref codigoRetorno,
                        itemUsuariosBloqueados.sCodUsuarioSAC,
                        itemUsuariosBloqueados.dFechaBloqueoON,
                        itemUsuariosBloqueados.dFechaBloqueoOFF,
                        itemUsuariosBloqueados.bEstado,
                        itemUsuariosBloqueados.SSIUsuario_Creacion,
                        itemUsuariosBloqueados.SSIHost);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno;
        }
      
        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo UsuariosBloqueados
        /// En la BASE de DATO la Tabla : [Sacnet.UsuariosBloqueados]
        /// <summary>
        /// <param name = >itemUsuariosBloqueados</param>
        public bool DesactivartUsuariosBloqueados(UsuariosBloqueados itemUsuariosBloqueados)
        {
            int codigoRetorno = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    codigoRetorno = SQLDC.pa_pro_DesactivarUsuariosBloqueados(
                        itemUsuariosBloqueados.sCodRegistro,
                        itemUsuariosBloqueados.sCodUsuarioSAC,
                        itemUsuariosBloqueados.SSIUsuario_Modificacion);
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
