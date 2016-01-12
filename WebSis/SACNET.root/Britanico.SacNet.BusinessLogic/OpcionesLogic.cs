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
    public class OpcionesLogic
    {
        private OpcionesData oOpcionesData = null;
        private ReturnValor oReturn = null;
        public OpcionesLogic()
        {
            oOpcionesData = new OpcionesData();
            oReturn = new ReturnValor();
        }

        #region " /* Funciones Insertar */ "

        /// <summary>
        /// Almacena el registro de un objeto de tipo [Tabla].
        /// </summary>
        /// <param name="pItem"></param>
        public ReturnValor Registrar(Opciones pItem)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.CodigoRetorno = oOpcionesData.Registrar(pItem);
                    if (oReturn.CodigoRetorno != null)
                    {
                        oReturn.Exitosa = true;
                        tx.Complete();
                        oReturn.Message = HelpMessage.Message(HelpMessage.TMessage.Registrar);
                    }
                    else
                        oReturn.Message = "El registro de opciones no ha sido registrado.";
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
        public Opciones Buscar(string p_CodigoOpcion)
        {
            Opciones itemOpcion = new Opciones();
            try
            {
                itemOpcion = oOpcionesData.Buscar(p_CodigoOpcion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itemOpcion;
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
                lista = oOpcionesData.Listar(Nombre, Descripcion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lista;
        }

        /// <summary>
        /// Retorna un lista de opciones seleccionada por el rol del USUSRIO
        /// </summary>
        /// <param name="p_CodigoRol"></param>
        /// <returns></returns>
        public List<Opciones> Listar(string p_CodigoRol)
        {
            List<Opciones> lista = new List<Opciones>();
            try
            {
                lista = oOpcionesData.Listar(p_CodigoRol);
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
        public ReturnValor Actualizar(Opciones pItem)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = oOpcionesData.Actualizar(pItem);
                    if (oReturn.Exitosa)
                    {
                        tx.Complete();
                        oReturn.Message = HelpMessage.Message(HelpMessage.TMessage.Editar);
                    }
                    else
                        oReturn.Message = "El registro de opciones no ha sido actualizado.";
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

        public ReturnValor Eliminar(string p_CodigoOpcion)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = oOpcionesData.Eliminar(p_CodigoOpcion);
                    if (oReturn.Exitosa)
                    {
                        tx.Complete();
                        oReturn.Message = HelpMessage.Message(HelpMessage.TMessage.Eliminar);
                    }
                    else
                        oReturn.Message = "El registro de opciones no ha sido eliminado.";
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
