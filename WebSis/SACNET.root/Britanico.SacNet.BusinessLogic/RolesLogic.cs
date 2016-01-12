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
    public class RolesLogic
    {
        private RolesData oRolesData = null;
        private ReturnValor oReturn = null;
        public RolesLogic()
        {
            oRolesData = new RolesData();
            oReturn = new ReturnValor();
        }

        #region " /* Funciones Insertar */ "

        /// <summary>
        /// Almacena el registro de un objeto de tipo [Tabla].
        /// </summary>
        /// <param name="pItem"></param>
        public ReturnValor Registrar(Roles pItem)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.CodigoRetorno = this.oRolesData.Registrar(pItem);
                    if (oReturn.CodigoRetorno != null)
                    {
                        oReturn.Exitosa = true;
                        oReturn.Message = HelpMessage.Message(HelpMessage.TMessage.Registrar);
                        tx.Complete();
                    }
                    else
                        oReturn.Message = "El registro de rol no ha sido registrado.";
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
        /// Retorna un objeto de registros de tipo Opciones.
        /// </summary>
        /// <returns>Lista</returns>
        public Roles Buscar(string p_CodigoRol)
        {
            Roles itemRol = new Roles();
            try
            {
                itemRol = oRolesData.Buscar(p_CodigoRol);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itemRol;
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
                lista = oRolesData.Listar(p_NombreRol, p_DescripcionRol);
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
        public ReturnValor Actualizar(Roles pItem)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = oRolesData.Actualizar(pItem);
                    if (oReturn.Exitosa)
                    {
                        tx.Complete();
                        oReturn.Message = HelpMessage.Message(HelpMessage.TMessage.Editar);
                    }
                    else
                        oReturn.Message = "El registro de rol no ha sido actualizado.";
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

        public ReturnValor Eliminar(string p_CodigoRol)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = oRolesData.Eliminar(p_CodigoRol);
                    if (oReturn.Exitosa)
                    {
                        tx.Complete();
                        oReturn.Message = HelpMessage.Message(HelpMessage.TMessage.Eliminar);
                    }
                    else
                        oReturn.Message = "El registro de rol no ha sido eliminado.";
                }
            }
            catch (Exception ex)
            {
                oReturn = HelpMessage.Message(ex);
            }
            return oReturn;
        }

        #endregion
    }
}
