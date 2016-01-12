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
    public class RolesOpcionesLogic
    {
        private RolesOpcionesData oRolesOpcionesData = null;
        private ReturnValor oReturn = null;
        public RolesOpcionesLogic()
        {
            oRolesOpcionesData = new RolesOpcionesData();
            oReturn = new ReturnValor();
        }

        #region " /* Funciones Insertar */ "

        /// <summary>
        /// Almacena el registro de un objeto de tipo [Tabla].
        /// </summary>
        /// <param name="pItem"></param>
        public ReturnValor Registrar(RolesOpciones pItem)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = oRolesOpcionesData.Registrar(pItem);
                    if (oReturn.Exitosa)
                    {
                        tx.Complete();
                        oReturn.Message = HelpMessage.Message(HelpMessage.TMessage.Registrar);
                    }
                    else
                        oReturn.Message = "El registro opción del rol no ha sido registrado.";
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
        public RolesOpciones Buscar(string p_CodigoRol, string p_CodigoOpcion)
        {
            RolesOpciones itemRolesOpcoines = new RolesOpciones();
            try
            {
                itemRolesOpcoines = oRolesOpcionesData.Buscar(p_CodigoRol, p_CodigoOpcion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itemRolesOpcoines;
        }

        /// <summary>
        /// Retorna un coleccion de registros de tipo [Tabla].
        /// <summary>
        /// <returns>List</returns>
        public List<RolesOpciones> Listar(string p_Codigo_Rol)
        {
            List<RolesOpciones> lista = new List<RolesOpciones>();
            try
            {
                lista = oRolesOpcionesData.Listar(p_Codigo_Rol);
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
        public ReturnValor Actualizar(RolesOpciones pItem)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = oRolesOpcionesData.Actualizar(pItem);
                    if (oReturn.Exitosa)
                    {
                        tx.Complete();
                        oReturn.Message = HelpMessage.Message(HelpMessage.TMessage.Editar);
                    }
                    else
                        oReturn.Message = "El registro opción del rol no ha sido actualizado.";
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

        public ReturnValor Eliminar(string p_CodigoOcion, string p_CodigoRol)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = oRolesOpcionesData.Eliminar(p_CodigoRol, p_CodigoOcion);
                    if (oReturn.Exitosa)
                    {
                        tx.Complete();
                        oReturn.Message = HelpMessage.Message(HelpMessage.TMessage.Eliminar);
                    }
                    else
                        oReturn.Message = "El registro opción del rol no ha sido eliminado.";
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
