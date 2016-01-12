using System;
using System.Configuration;
using System.Collections.Generic;
using Britanico.SacNet.BusinessEntities;

namespace Britanico.SacNet.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    public class OpcionesData
    {
        public string conexion = string.Empty;

        public OpcionesData()
        {
            conexion = ConfigurationManager.ConnectionStrings["cnSacNET"].ConnectionString;
        }

        #region " /* Funciones Insertar */ "

        /// <summary>
        /// Almacena el registro de un objeto de tipo [Tabla].
        /// </summary>
        /// <param name="pItem"></param>
        public string Registrar(Opciones pItem)
        {
            string codigoRetorno = "";
            try
            {
                using (_SEGURIDADDataContext SQLDC = new _SEGURIDADDataContext(conexion))
                {
                    SQLDC.pa_mnt_RegistrarOpciones
                        (
                        ref codigoRetorno,
                        pItem.CodigoPadre,
                        pItem.Nombre,
                        pItem.Descripcion,
                        pItem.Enlace,
                        Convert.ToChar(pItem.FlagMenu),
                        Convert.ToChar(pItem.Estado),
                        pItem.SegUsuarioRegistro
                        );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno;
        }

        #endregion

        #region " /* Funciones Seleccionar */ "

        /// <summary>
        /// Retorna una clase de registros de tipo [Tabla].
        /// <summary>
        /// <returns>List</returns>
        public Opciones Buscar(string p_CodigoOpcion)
        {
            Opciones itemOpciones = new Opciones();
            try
            {
                using (_SEGURIDADDataContext SQLDC = new _SEGURIDADDataContext(conexion))
                {
                    var resul = SQLDC.pa_mnt_BuscarOpciones(p_CodigoOpcion);
                    foreach (var item in resul)
                    {
                        itemOpciones = new Opciones()
                        {
                            CodigoOpcion = item.CodigoOpcion,
                            CodigoPadre = item.CodigoPadre,
                            Nombre = item.Nombre,
                            Descripcion = item.Descripcion,
                            Enlace = item.Enlace,
                            FlagMenu = item.FlagMenu.ToString(),
                            Estado = item.Estado.ToString(),
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
            return itemOpciones;
        }

        /// <summary>
        /// Retorna un coleccion de registros de tipo [Tabla].
        /// <summary>
        /// <returns>List</returns>
        public List<Opciones> Listar(string Nombre, string Descripcion)
        {
            List<Opciones> lista = new List<Opciones>();
            try
            {
                using (_SEGURIDADDataContext SQLDC = new _SEGURIDADDataContext(conexion))
                {
                    var resul = SQLDC.pa_mnt_ListarOpciones(Nombre,Descripcion);
                    foreach (var item in resul)
                    {
                        lista.Add(new Opciones()
                        {
                            CodigoOpcion = item.CodigoOpcion,
                            CodigoPadre = item.CodigoPadre,
                            Nombre = item.Nombre,
                            Descripcion = item.Descripcion,
                            Enlace = item.Enlace,
                            FlagMenu = item.FlagMenu.ToString(),
                            Estado = item.Estado.ToString(),
                            SegFechaRegistro = item.SegFechaRegistro,
                            SegFechaModifica = item.SegFechaModifica,
                            SegUsuarioRegistro = item.SegUsuarioRegistro,
                            SegUsuarioModifica = item.SegUsuarioModifica,
                            SegMaquina = item.SegMaquina,

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

        public List<Opciones> Listar(string p_CodigoRol)
        {
            List<Opciones> lista = new List<Opciones>();
            try
            {
                using (_SEGURIDADDataContext SQLDC = new _SEGURIDADDataContext(conexion))
                {
                    var resul = SQLDC.pa_pro_ListarMenuPorRolUsuario(p_CodigoRol);
                    foreach (var item in resul)
                    {
                        lista.Add(new Opciones()
                        {
                            CodigoOpcion = item.CodigoOpcion,
                            CodigoPadre = item.CodigoPadre,
                            Nombre = item.Nombre,
                            Descripcion = item.Descripcion,
                            Enlace = item.Enlace,
                            FlagMenu = item.FlagMenu.ToString()
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
        /// ACTUALIZA el registro de un objeto de tipo [Tabla].
        /// </summary>
        /// <param name="pItem"></param>
        public bool Actualizar(Opciones pItem)
        {
            int codigoRetorno = -1;
            try
            {
                using (_SEGURIDADDataContext SQLDC = new _SEGURIDADDataContext(conexion))
                {
                    codigoRetorno = SQLDC.pa_mnt_ActualizarOpciones
                        (
                        pItem.CodigoOpcion,
                        pItem.CodigoPadre,
                        pItem.Nombre,
                        pItem.Descripcion,
                        pItem.Enlace,
                        Convert.ToChar(pItem.FlagMenu),
                        Convert.ToChar(pItem.Estado),
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

        /// <summary>
        /// ELIMINA el registro de un objeto de tipo [Tabla].
        /// </summary>
        /// <param name="pItem"></param>
        public bool Eliminar(string p_CodigoOpcion)
        {
            int CodigoRetorno = -1;
            try
            {
                using (_SEGURIDADDataContext SQLDC = new _SEGURIDADDataContext(conexion))
                {
                    CodigoRetorno = SQLDC.pa_mnt_EliminarOpciones(p_CodigoOpcion);
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
