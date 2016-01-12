using System;
using System.Collections.Generic;
using System.Configuration;

using Britanico.SacNet.BusinessEntities;

namespace Britanico.SacNet.DataAccess
{
    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 09/07/2010-11:33:49 
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Sacnet.UsuariosMotivoCorreosData.cs]
    /// </summary>
    public class UsuariosMotivoCorreosData
    {
        private string conexion = string.Empty;
        public UsuariosMotivoCorreosData()
        {
            conexion = ConfigurationManager.ConnectionStrings["cnSacNET"].ConnectionString;
        }

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo UsuariosMotivoCorreos
        /// En la BASE de DATO la Tabla : [Sacnet.UsuariosMotivoCorreos]
        /// <summary>
        /// <param name = >itemUsuariosMotivoCorreos</param>
        public string Registrar(UsuariosMotivoCorreos itemUsuariosMotivoCorreos)
        {
            string codigoRetorno = null;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    SQLDC.pa_mnt_RegistrarUsuariosMotivoCorreos(
                    ref codigoRetorno,
                    itemUsuariosMotivoCorreos.sCodArguAccionMotivo,
                    itemUsuariosMotivoCorreos.sNombre,
                    itemUsuariosMotivoCorreos.sApellidos,
                    itemUsuariosMotivoCorreos.sCorreoElectronico1,
                    itemUsuariosMotivoCorreos.sCorreoElectronico2,
                    itemUsuariosMotivoCorreos.sCodArguCargo,
                    itemUsuariosMotivoCorreos.bEstado,
                    itemUsuariosMotivoCorreos.SSIUsuario_Creacion,
                    itemUsuariosMotivoCorreos.SSIHost);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo UsuariosMotivoCorreos
        /// En la BASE de DATO la Tabla : [Sacnet.UsuariosMotivoCorreos]
        /// <summary>
        /// <param name = >itemUsuariosMotivoCorreos</param>
        public bool Actualizar(UsuariosMotivoCorreos itemUsuariosMotivoCorreos)
        {
            int codigoRetorno = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    codigoRetorno = SQLDC.pa_mnt_ActualizarUsuariosMotivoCorreos(
                        itemUsuariosMotivoCorreos.sCodUsuario,
                        itemUsuariosMotivoCorreos.sCodArguAccionMotivo,
                        itemUsuariosMotivoCorreos.sNombre,
                        itemUsuariosMotivoCorreos.sApellidos,
                        itemUsuariosMotivoCorreos.sCorreoElectronico1,
                        itemUsuariosMotivoCorreos.sCorreoElectronico2,
                        itemUsuariosMotivoCorreos.sCodArguCargo,
                        itemUsuariosMotivoCorreos.bEstado,
                        itemUsuariosMotivoCorreos.SSIUsuario_Modificacion,
                        itemUsuariosMotivoCorreos.SSIHost);
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
        /// ELIMINA un registro de la Entidad Sacnet.UsuariosMotivoCorreos
        /// En la BASE de DATO la Tabla : [Sacnet.UsuariosMotivoCorreos]
        /// <summary>
        /// <returns>bool</returns>
        public bool Eliminar(string prm_sCodUsuario, string prm_sCodArguAccionMotivo)
        {
            int codigoRetorno = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    codigoRetorno = SQLDC.pa_mnt_EliminarUsuariosMotivoCorreos(prm_sCodUsuario, prm_sCodArguAccionMotivo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        #endregion

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
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_mnt_ListarUsuariosMotivoCorreos(prm_sApellidos, prm_sCodArguCargo, prm_sCodArguAccionMotivo, prm_bEstado);
                    foreach (var item in resul)
                    {
                        miLista.Add(new UsuariosMotivoCorreos()
                        {
                            sCodUsuario = item.sCodUsuario,
                            sCodArguAccionMotivo = item.sCodArguAccionMotivo,
                            sNombre = item.sNombre,
                            sApellidos = item.sApellidos,
                            sCorreoElectronico1 = item.sCorreoElectronico1,
                            sCorreoElectronico2 = item.sCorreoElectronico2,
                            sCodArguCargo = item.sCodArguCargo,
                            bEstado = item.bEstado,
                            SSIUsuario_Creacion = item.SSIUsuario_Creacion,
                            SSIFechaHora_Creacion = item.SSIFechaHora_Creacion,
                            SSIUsuario_Modificacion = item.SSIUsuario_Modificacion,
                            SSIFechaHora_Modificacion = item.SSIFechaHora_Modificacion,
                            SSIHost = item.SSIHost,
                            sCodArguCargoNombre = item.sCodArguCargoNombre,
                            sCodArguAccionMotivoNombre = item.sCodArguAccionMotivoNombre,
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
        /// Retorna una ENTIDAD de registro de la Entidad Sacnet.UsuariosMotivoCorreos
        /// En la BASE de DATO la Tabla : [Sacnet.UsuariosMotivoCorreos]
        /// <summary>
        /// <returns>Entidad</returns>
        public UsuariosMotivoCorreos Buscar(string prm_sCodUsuario, string prm_sCodArguAccionMotivo)
        {
            UsuariosMotivoCorreos miEntidad = new UsuariosMotivoCorreos();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_mnt_BuscarUsuariosMotivoCorreos(prm_sCodUsuario, prm_sCodArguAccionMotivo);
                    foreach (var item in resul)
                    {
                        miEntidad = new UsuariosMotivoCorreos()
                        {
                            sCodUsuario = item.sCodUsuario,
                            sCodArguAccionMotivo = item.sCodArguAccionMotivo,
                            sNombre = item.sNombre,
                            sApellidos = item.sApellidos,
                            sCorreoElectronico1 = item.sCorreoElectronico1,
                            sCorreoElectronico2 = item.sCorreoElectronico2,
                            sCodArguCargo = item.sCodArguCargo,
                            bEstado = item.bEstado,
                            SSIUsuario_Creacion = item.SSIUsuario_Creacion,
                            SSIFechaHora_Creacion = item.SSIFechaHora_Creacion,
                            SSIUsuario_Modificacion = item.SSIUsuario_Modificacion,
                            SSIFechaHora_Modificacion = item.SSIFechaHora_Modificacion,
                            SSIHost = item.SSIHost,

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

       
    }
} 
