using System;
using System.Configuration;
using System.Collections.Generic;
using Britanico.SacNet.BusinessEntities;

namespace Britanico.SacNet.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    public class RolesOpcionesData
    {
        public string conexion = string.Empty;

        public RolesOpcionesData()
        {
            conexion = ConfigurationManager.ConnectionStrings["cnSacNET"].ConnectionString;
        }

        #region " /* Funciones Insertar */ "

        /// <summary>
        /// Almacena el registro de un objeto de tipo [Tabla].
        /// </summary>
        /// <param name="pItem"></param>
        public bool Registrar(RolesOpciones pItem)
        {
            int codigoRetorno = -1;
            try
            {
                using (_SEGURIDADDataContext SQLDC = new _SEGURIDADDataContext(conexion))
                {
                    codigoRetorno = SQLDC.pa_mnt_RegistrarRolesOpciones
                        (
                        pItem.CodigoRol,
                        pItem.CodigoOpcion,
                        pItem.Flag_Ver,
                        pItem.Flag_Eliminar,
                        pItem.Flag_Editar,
                        pItem.Flag_Nuevo,
                        pItem.SegUsuarioRegistro
                        );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        #endregion

        #region " /* Funciones Seleccionar */ "

        /// <summary>
        /// Retorna un clase de registros de tipo [Tabla].
        /// <summary>
        /// <returns>List</returns>
        public RolesOpciones Buscar(string p_CodigoRol, string p_CodigoOpcion)
        {
            RolesOpciones itemRolesOpciones = new RolesOpciones();
            try
            {
                using (_SEGURIDADDataContext SQLDC = new _SEGURIDADDataContext(conexion))
                {
                    var resul = SQLDC.pa_mnt_ListarRolesOpciones(p_CodigoRol, p_CodigoOpcion);
                    foreach (var item in resul)
                    {
                        itemRolesOpciones = new RolesOpciones()
                        {
                            CodigoRol = item.CodigoRol,
                            CodigoOpcion = item.CodigoOpcion,
                           
                            Flag_Ver = item.Flag_Ver,
                            Flag_Eliminar = item.Flag_Eliminar,
                            Flag_Editar = item.Flag_Editar,
                            Flag_Nuevo = item.Flag_Nuevo,
                            SegFechaRegistro = item.SegFechaRegistro,
                            SegFechaModifica = item.SegFechaModifica,
                            SegUsuarioRegistro = item.SegUsuarioRegistro,
                            SegUsuarioModifica = item.SegUsuarioModifica,
                            SegMaquina = item.SegMaquina,

                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itemRolesOpciones;
        }

        /// <summary>
        /// Retorna un coleccion de registros de tipo [Tabla].
        /// <summary>
        /// <returns>List</returns>
        public List<RolesOpciones> Listar(string p_CodigoRol)
        {
            List<RolesOpciones> lista = new List<RolesOpciones>();
            try
            {
                using (_SEGURIDADDataContext SQLDC = new _SEGURIDADDataContext(conexion))
                {
                    var resul = SQLDC.pa_mnt_ListarRolesOpciones(p_CodigoRol, string.Empty);
                    foreach (var item in resul)
                    {
                        lista.Add(new RolesOpciones()
                        {
                            CodigoRol = item.CodigoRol,
                            CodigoOpcion = item.CodigoOpcion,
                            CodigoOpcionPadre = item.CodigoPadre,
                            FlagMenu=item.FlagMenu.ToString(),
                            Flag_Ver = item.Flag_Ver,
                            Flag_Eliminar = item.Flag_Eliminar,
                            Flag_Editar = item.Flag_Editar,
                            Flag_Nuevo = item.Flag_Nuevo,
                            SegFechaRegistro = item.SegFechaRegistro,
                            SegFechaModifica = item.SegFechaModifica,
                            SegUsuarioRegistro = item.SegUsuarioRegistro,
                            SegUsuarioModifica = item.SegUsuarioModifica,
                            SegMaquina = item.SegMaquina,
                            CodigoOpcionNombre = item.CodigoOpcionNombre,
                            CodigoRolNombre = item.CodigoRolNombre
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        #endregion

        #region " /* Funciones Modificar */ "

        /// <summary>
        /// Almacena el registro de un objeto de tipo [Tabla].
        /// </summary>
        /// <param name="pItem"></param>
        public bool Actualizar(RolesOpciones pItem)
        {
            int codigoRetorno = -1;
            try
            {
                using (_SEGURIDADDataContext SQLDC = new _SEGURIDADDataContext(conexion))
                {
                    codigoRetorno = SQLDC.pa_mnt_ActualizarRolesOpciones
                        (
                        pItem.CodigoRol,
                        pItem.CodigoOpcion,
                        pItem.Flag_Ver,
                        pItem.Flag_Eliminar,
                        pItem.Flag_Editar,
                        pItem.Flag_Nuevo,
                        pItem.SegUsuarioModifica
                        );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        #endregion

        #region " /* Funciones Eliminar */ "

        public bool Eliminar(string p_CodigoRol, string p_CodigoOpcion)
        {
            int CodigoRetorno = -1;
            try
            {
                using (_SEGURIDADDataContext SQLDC = new _SEGURIDADDataContext(conexion))
                {
                    CodigoRetorno = SQLDC.pa_mnt_EliminarRolesOpciones(p_CodigoRol, p_CodigoOpcion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return CodigoRetorno == 0 ? true : false;
        }

        #endregion
    }
}
