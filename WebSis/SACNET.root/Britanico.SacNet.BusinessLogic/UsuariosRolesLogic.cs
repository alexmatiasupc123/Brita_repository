using System;
using System.Configuration;
using System.Collections.Generic;
using System.Transactions;

using Britanico.SacNet.BusinessEntities;
using Britanico.SacNet.DataAccess;
using Oxinet.Tools;

namespace Britanico.SacNet.BusinessLogic
{
    /// <summary>
    /// 
    /// </summary>
    public class UsuariosRolesLogic
    {
        private UsuariosRolesData oUsuariosRolesData = null;
        private ReturnValor oReturn = null;
        public UsuariosRolesLogic()
        {
            oUsuariosRolesData = new UsuariosRolesData();
            oReturn = new ReturnValor();
        }

        #region " /* Funciones Insertar */ "

        /// <summary>
        /// Almacena el registro de un objeto de tipo [Tabla].
        /// </summary>
        /// <param name="pItem"></param>
        public ReturnValor Registrar(UsuariosRoles pItem)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = oUsuariosRolesData.Registrar(pItem);
                    if (oReturn.Exitosa)
                    {
                        tx.Complete();
                        oReturn.Message = HelpMessage.Message(HelpMessage.TMessage.Registrar);
                    }
                    else
                        oReturn.Message = "El registro de rol para el usuario no ha sido registrado.";
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
        /// Retorna un coleccion de registros de tipo [Tabla].
        /// <summary>
        /// <returns>List</returns>
        public UsuariosRoles Buscar(string p_CodigoUsuario, string p_CodigoRol)
        {
            UsuariosRoles itemUsuariosRoles = new UsuariosRoles();
            try
            {
                itemUsuariosRoles = oUsuariosRolesData.Buscar(p_CodigoUsuario, p_CodigoRol);
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
                lista = oUsuariosRolesData.Listar(p_CodigoUsuario);
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
        public ReturnValor Actualizar(UsuariosRoles pItem)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = oUsuariosRolesData.Actualizar(pItem);
                    if (oReturn.Exitosa)
                    {
                        tx.Complete();
                        oReturn.Message = HelpMessage.Message(HelpMessage.TMessage.Editar);
                    }
                    else
                        oReturn.Message = "El registro de rol para el usuario no ha sido actualizado.";
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

        public ReturnValor Eliminar(string p_CodigoUsuario, string p_CodigoRol)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = oUsuariosRolesData.Eliminar(p_CodigoUsuario, p_CodigoRol);
                    if (oReturn.Exitosa)
                    {
                        tx.Complete();
                        oReturn.Message = HelpMessage.Message(HelpMessage.TMessage.Eliminar);
                    }
                    else
                        oReturn.Message = "El registro de rol para el usuario no ha sido eliminado.";
                }
            }
            catch (Exception ex)
            {
                oReturn = HelpMessage.Message(ex);
            }
            return oReturn;
        }

        #endregion


        public List<Usuarios> DetectarLogin(string CodigoUsuario)
        {
            List<Usuarios> lstUsuarios = new List<Usuarios>();
            try
            {
                lstUsuarios = oUsuariosRolesData.DetectarLogin(CodigoUsuario);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstUsuarios;
        }
        public Usuarios DetectarUsuario(string CodigoUsuario,string CodRol)
        {
            Usuarios item = new Usuarios();
            UsuariosData oUsuData = new UsuariosData();
            List<Usuarios> lstUsuarios = new List<Usuarios>();
            try
            {
              
                item = oUsuData.Buscar(CodigoUsuario);
                item.CodigoRol = CodRol;
                item.RolOpcionesMenus = oUsuariosRolesData.mListarPorSistemaYRol(CodRol);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return item;
        }
        public bool DetectarLoginPassword(string CodUsuario, string Contrasenia)
        {
            bool Detectado = false;
            try
            {
                Detectado = oUsuariosRolesData.DetectarLoginPassword(CodUsuario, Contrasenia);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Detectado;
        }

        /// <summary>
        /// Retorna un coleccion de registros de tipo [Tabla].
        /// </summary>
        /// <param name="CodRol"></param>
        /// <returns>Lista</returns>
        public List<RolesOpciones> mListarPorSistemaYRol(string CodigoRol)
        {
            List<RolesOpciones> lista = new List<RolesOpciones>();
            try
            {
                lista = oUsuariosRolesData.mListarPorSistemaYRol(CodigoRol);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }
    }
}
