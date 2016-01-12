using System;
using System.Configuration;
using System.Collections.Generic;
using Britanico.SacNet.BusinessEntities;

namespace Britanico.SacNet.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    public class UsuariosRolesData
    {
        public string conexion = string.Empty;
        public UsuariosRolesData()
        {
            conexion = ConfigurationManager.ConnectionStrings["cnAtenea"].ConnectionString;
        }

        #region " /* Funciones Insertar */ "

        /// <summary>
        /// Almacena el registro de un objeto de tipo [Tabla].
        /// </summary>
        /// <param name="pItem"></param>
        public bool Registrar(UsuariosRoles pItem)
        {
            int codigoRetorno = -1;
            try
            {
                using (_SEGURIDADDataContext SQLDC = new _SEGURIDADDataContext(conexion))
                {
                    codigoRetorno = SQLDC.pa_mnt_RegistrarUsuariosRoles
                        (
                        pItem.CodigoUsuario,
                        pItem.CodigoRol,
                        pItem.Estado,
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
        /// Retorna un coleccion de registros de tipo [Tabla].
        /// <summary>
        /// <returns>List</returns>
        public UsuariosRoles Buscar(string p_CodigoUsuario, string p_CodigoRol)
        {
            UsuariosRoles itemUsuariosRoles = new UsuariosRoles();
            try
            {
                using (_SEGURIDADDataContext SQLDC = new _SEGURIDADDataContext(conexion))
                {
                    var resul = SQLDC.pa_mnt_BuscarUsuariosRoles(p_CodigoUsuario, p_CodigoRol);
                    foreach (var item in resul)
                    {
                        itemUsuariosRoles = new UsuariosRoles()
                        {
                            CodigoUsuario = item.CodigoUsuario,
                            CodigoRol = item.CodigoRol,
                            Estado = item.Estado,
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
            return itemUsuariosRoles;
        }

        /// <summary>
        /// Retorna un coleccion de registros de tipo [Tabla].
        /// <summary>
        /// <returns>List</returns>
        public List<UsuariosRoles> Listar(string p_CodigoUsuario)
        {
            List<UsuariosRoles> lista = new List<UsuariosRoles>();
            try
            {
                using (_SEGURIDADDataContext SQLDC = new _SEGURIDADDataContext(conexion))
                {
                    var resul = SQLDC.pa_mnt_ListarUsuariosRoles(p_CodigoUsuario);
                    foreach (var item in resul)
                    {
                        lista.Add(new UsuariosRoles()
                        {
                            CodigoUsuario = item.CodigoUsuario,
                            CodigoRol = item.CodigoRol,
                            Estado = item.Estado,
                            SegFechaRegistro = item.SegFechaRegistro,
                            SegFechaModifica = item.SegFechaModifica,
                            SegUsuarioRegistro = item.SegUsuarioRegistro,
                            SegUsuarioModifica = item.SegUsuarioModifica,
                            SegMaquina = item.SegMaquina,
                            CodigoRolNombre = item.CodigoRolNombre,
                            CodigoUsuarioNombre = item.CodigoUsuarioNombre
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
        public bool Actualizar(UsuariosRoles pItem)
        {
            int codigoRetorno = -1;
            try
            {
                using (_SEGURIDADDataContext SQLDC = new _SEGURIDADDataContext(conexion))
                {
                    codigoRetorno = SQLDC.pa_mnt_ActualizarUsuariosRoles
                        (
                        pItem.CodigoUsuario,
                        pItem.CodigoRol,
                        pItem.Estado,
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

        public bool Eliminar(string p_CodigoUsuario, string p_CodigoRol)
        {
            int CodigoRetorno = -1;
            try
            {
                using (_SEGURIDADDataContext SQLDC = new _SEGURIDADDataContext(conexion))
                {
                    CodigoRetorno = SQLDC.pa_mnt_EliminarUsuariosRoles(p_CodigoUsuario, p_CodigoRol);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return CodigoRetorno == 0 ? true : false;
        }

        #endregion

        public List<Usuarios> DetectarLogin(string CodigoUsuario)
        {
            List<Usuarios> lstUsuarios = new List<Usuarios>();
            try
            {
                using (_SEGURIDADDataContext SQLDC = new _SEGURIDADDataContext(conexion))
                {
                    var resul = SQLDC.pa_pro_DetectarLogin(CodigoUsuario);
                    foreach (var item in resul)
                    {
                        lstUsuarios.Add(new Usuarios()
                        {
                            LoginUsuario = item.LoginUsuario,
                            ApellidosUsuario = item.ApellidosUsuario,
                            NombresUsuario = item.NombresUsuario,                            
                        
                            CodigoRol = item.CodigoRol,
                            CodigoRolNombre = item.CodigoRolNombre
                            
                        }
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstUsuarios;
        }

        public bool DetectarLoginPassword(string CodUsuario, string Contrasenia)
        {
            int cantidad = 0;
            try
            {
                using (_SEGURIDADDataContext SQLDC = new _SEGURIDADDataContext(conexion))
                {
                    var resul = SQLDC.pa_pro_DetectarLoginPassword(CodUsuario, Contrasenia);

                    foreach (var item in resul)
                        cantidad = Convert.ToInt32(item.Cantidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return cantidad > 0 ? true : false;
        }

        /// <summary>
        /// Retorna un coleccion de registros de tipo [Tabla].
        /// </summary>
        /// <param name="CodRol"></param>
        /// <returns>Lista</returns>
        public List<RolesOpciones> mListarPorSistemaYRol(string CodRol)
        {
            List<RolesOpciones> lista = new List<RolesOpciones>();
            try
            {
                using (_SEGURIDADDataContext SQLDC = new _SEGURIDADDataContext(conexion))
                {
                    var resul = SQLDC.pa_pro_ListarRolOpcion(CodRol);
                    foreach (var item in resul)
                    {
                        lista.Add(new RolesOpciones()
                        {
                            CodigoRol = item.CodigoOpcion,
                            CodigoOpcion = item.CodigoOpcion,
                            CodigoOpcionNombre = item.Nombre,
                            CodigoOpcionPadre = item.CodigoPadre,
                            FlagMenu=item.FlagMenu.ToString(),
                            Flag_Ver = item.Flag_Ver,
                            Flag_Eliminar = item.Flag_Eliminar,
                            Flag_Editar = item.Flag_Editar,
                            Flag_Nuevo = item.Flag_Nuevo,
                            SegUsuarioRegistro = item.SegUsuarioRegistro,
                            SegFechaRegistro = Convert.ToDateTime(item.SegFechaRegistro),
                             SegMaquina = item.SegMaquina,
                            CodigoOpcionEnlace = item.Enlace == "" ? "" :item.Enlace,
                            Tipo = item.Tipo
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
    }
}
