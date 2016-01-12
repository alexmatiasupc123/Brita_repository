using System;
using System.Configuration;
using System.Collections.Generic;
using Britanico.SacNet.BusinessEntities;

namespace Britanico.SacNet.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    public class RolesData
    {
        public string conexion = string.Empty;
        public RolesData()
        {
            conexion = ConfigurationManager.ConnectionStrings["cnAtenea"].ConnectionString;
        }

        #region " /* Funciones Insertar */ "

        /// <summary>
        /// Almacena el registro de un objeto de tipo [Tabla].
        /// </summary>
        /// <param name="pItem"></param>
        public string Registrar(Roles pItem)
		{
			string codigoRetorno = "";
			try
			{
				using (_SEGURIDADDataContext SQLDC = new _SEGURIDADDataContext(conexion))
				{
					SQLDC.pa_mnt_RegistrarRoles
                        (
						ref codigoRetorno,
						pItem.NombreRol,
						pItem.DescripcionRol,
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
        /// Retorna un coleccion de registros de tipo [Tabla].
        /// <summary>
        /// <returns>List</returns>
        public Roles Buscar(string p_CodigoRol)
        {
            Roles ItemRoles = new Roles();
            try
            {
                using (_SEGURIDADDataContext SQLDC = new _SEGURIDADDataContext(conexion))
                {
                    var resul = SQLDC.pa_mnt_BuscarRoles(p_CodigoRol);
                    foreach (var item in resul)
                    {
                        ItemRoles =(new Roles()
                        {
                            CodigoRol = item.CodigoRol,
                            NombreRol = item.NombreRol,
                            DescripcionRol = item.DescripcionRol,
                            Estado = item.Estado.ToString(),
                            SegFechaRegistro = item.SegFechaRegistro,
                            SegFechaModifica = item.SegFechaModifica,
                            SegUsuarioRegistro = item.SegUsuarioRegistro,
                            SegUsuarioModifica = item.SegUsuarioModifica,
                            SegMaquina = item.SegMaquina,
                             TodosLosCentros = item.TodosLosCentros
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ItemRoles;
        }

        /// <summary>
        /// Retorna un coleccion de registros de tipo [Tabla].
        /// <summary>
        /// <returns>List</returns>
        public List<Roles> Listar(string p_NombreRol, string p_DescripcionRol)
        {
            List<Roles> lista = new List<Roles>();
            try
            {
                using (_SEGURIDADDataContext SQLDC = new _SEGURIDADDataContext(conexion))
                {
                    var resul = SQLDC.pa_mnt_ListarRoles(p_NombreRol, p_DescripcionRol);
                    foreach (var item in resul)
                    {
                        lista.Add(new Roles()
                        {
                            CodigoRol = item.CodigoRol,
                            NombreRol = item.NombreRol,
                            DescripcionRol = item.DescripcionRol,
                            Estado = item.Estado.ToString(),
                            SegFechaRegistro = item.SegFechaRegistro,
                            SegFechaModifica = item.SegFechaModifica,
                            SegUsuarioRegistro = item.SegUsuarioRegistro,
                            SegUsuarioModifica = item.SegUsuarioModifica,
                            SegMaquina = item.SegMaquina,
                             TodosLosCentros = item.TodosLosCentros
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
        /// Actualiza el registro de un objeto de tipo [Tabla].
        /// </summary>
        /// <param name="pItem"></param>
        /// <returns></returns>
        public bool Actualizar(Roles pItem)
        {
            int CodigoRetorno = -1;
            try
            {
                using (_SEGURIDADDataContext SQLDC = new _SEGURIDADDataContext(conexion))
                {
                    CodigoRetorno = SQLDC.pa_mnt_ActualizarRoles
                        (
                        pItem.CodigoRol,
                        pItem.NombreRol,
                        pItem.DescripcionRol,
                        Convert.ToChar(pItem.Estado),
                        pItem.SegUsuarioModifica
                );

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return CodigoRetorno == 0 ? true : false;
        }

        #endregion

        #region " /* Funciones Eliminar */ "

        public bool Eliminar(string CodigoRol)
        {
            int CodigoRetorno = -1;
            try
            {
                using (_SEGURIDADDataContext SQLDC = new _SEGURIDADDataContext(conexion))
                {
                    CodigoRetorno = SQLDC.pa_mnt_EliminarRoles(CodigoRol);
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
