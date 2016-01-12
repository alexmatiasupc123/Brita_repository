using System;
using System.Collections.Generic;
using System.Configuration;

using Britanico.SacNet.BusinessEntities;

namespace Britanico.SacNet.DataAccess
{
    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 09/07/2010-11:33:49 
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Maestras.TFeriadosData.cs]
    /// </summary>
    public class TFeriadosData
    {
        private string conexion = string.Empty;

        public TFeriadosData()
        {
            conexion = ConfigurationManager.ConnectionStrings["cnSacNET"].ConnectionString;
        }
        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Maestras.TFeriados
        /// En la BASE de DATO la Tabla : [Maestras.TFeriados]
        /// <summary>
        /// <returns>List</returns>
        public List<TFeriados> Listar(string prm_Anio, string prm_Descripcion,bool? prm_Fijo, bool? prm_Estado)
        {
            List<TFeriados> miLista = new List<TFeriados>();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_mnt_ListarTFeriados(prm_Anio, prm_Descripcion,prm_Fijo, prm_Estado);
                    foreach (var item in resul)
                    {
                        miLista.Add(new TFeriados()
                        {
                            sCodRegistro=item.CodRegistro,
                            sFeriado = item.Feriado,
                            bFijo = item.Fijo,
                            sDescripcion = item.Descripcion,
                            bEstado = item.Estado,
                            SSIUsuario_Creacion = item.SSIUsuario_Creacion,
                            SSIFechaHora_Creacion = item.SSIFechaHora_Creacion,
                            SSIUsuario_Modificacion = item.SSIUsuario_Modificacion,
                            SSIFechaHora_Modificacion = item.SSIFechaHora_Modificacion,
                            SSIHost = item.SSIHost,
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
        /// Retorna una ENTIDAD de registro de la Entidad Maestras.TFeriados
        /// En la BASE de DATO la Tabla : [Maestras.TFeriados]
        /// <summary>
        /// <returns>Entidad</returns>
        public TFeriados Buscar(string prm_CodRegistro)
        {
            TFeriados miEntidad = new TFeriados();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_mnt_BuscarTFeriados(prm_CodRegistro);
                    foreach (var item in resul)
                    {
                        miEntidad = new TFeriados()
                        {
                            sCodRegistro = item.CodRegistro,
                            sFeriado = item.Feriado,
                            bFijo = item.Fijo,
                            sDescripcion = item.Descripcion,
                            bEstado = item.Estado,
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

        public TFeriados BuscarPorFeriado(string prm_Feriado)
        {
            TFeriados miEntidad = new TFeriados();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_mnt_BuscarTFeriadosPorFeriado(prm_Feriado);
                    foreach (var item in resul)
                    {
                        miEntidad = new TFeriados()
                        {
                            sCodRegistro = item.CodRegistro,
                            sFeriado = item.Feriado,
                            bFijo = item.Fijo,
                            sDescripcion = item.Descripcion,
                            bEstado = item.Estado,
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

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo TFeriados
        /// En la BASE de DATO la Tabla : [Maestras.TFeriados]
        /// <summary>
        /// <param name = >itemTFeriados</param>
        public string Registrar(TFeriados itemTFeriados)
        {
            string codigoRetorno = null;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    SQLDC.pa_mnt_RegistrarTFeriados(
                         ref codigoRetorno  ,
                        itemTFeriados.sFeriado,
                        itemTFeriados.bFijo,
                        itemTFeriados.sDescripcion,
                        itemTFeriados.bEstado,
                        itemTFeriados.SSIUsuario_Creacion,
                        itemTFeriados.SSIHost);
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo TFeriados
        /// En la BASE de DATO la Tabla : [Maestras.TFeriados]
        /// <summary>
        /// <param name = >itemTFeriados</param>
        public bool Actualizar(TFeriados itemTFeriados)
        {
            int codigoRetorno = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    codigoRetorno = SQLDC.pa_mnt_ActualizarTFeriados(
                        itemTFeriados.sCodRegistro,
                        itemTFeriados.sFeriado,
                        itemTFeriados.bFijo,
                        itemTFeriados.sDescripcion,
                        itemTFeriados.bEstado,
                        itemTFeriados.SSIUsuario_Modificacion);
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
        /// ELIMINA un registro de la Entidad Maestras.TFeriados
        /// En la BASE de DATO la Tabla : [Maestras.TFeriados]
        /// <summary>
        /// <returns>bool</returns>
        public bool Eliminar(string prm_sCodRegistro)
        {
            int codigoRetorno = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    codigoRetorno = SQLDC.pa_mnt_EliminarTFeriados(prm_sCodRegistro);
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
