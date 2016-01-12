using System;
using System.Collections.Generic;
using System.Configuration;
using System.Transactions;
using System.Linq;

using Britanico.SacNet.BusinessEntities;
using Britanico.SacNet.DataAccess;
using Oxinet.Tools;

namespace Britanico.SacNet.BusinessLogic
{
    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 09/07/2010-11:33:49 
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [Maestras.TFeriadosLogic.cs]
    /// </summary>
    public class TFeriadosLogic
    {
        private TFeriadosData oTFeriadosData = null;
        private ReturnValor oReturnValor = null;

        public TFeriadosLogic()
        {
            oTFeriadosData = new TFeriadosData();
            oReturnValor = new ReturnValor();
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Maestras.TFeriados
        /// En la BASE de DATO la Tabla : [Maestras.TFeriados]
        /// <summary>
        /// <returns>List</returns>
        public List<TFeriados> Listar(string prm_Anio, string prm_Descripcion, bool? prm_Fijo, bool? prm_Estado)
        {
            List<TFeriados> miLista = new List<TFeriados>();
            try
            {
                miLista = oTFeriadosData.Listar(prm_Anio, prm_Descripcion, prm_Fijo, prm_Estado);
                foreach(TFeriados xTFeriados in miLista)
                {
                    if(!xTFeriados.bFijo)
                    {
                        string sFECHA_DATO = xTFeriados.sFeriado.Substring(6, 2) + "/" +
                                             xTFeriados.sFeriado.Substring(4, 2) + "/" +
                                             xTFeriados.sFeriado.Substring(0, 4);
                        xTFeriados.dFechaIndicada = Convert.ToDateTime(sFECHA_DATO);
                    }
                }

                var feriadoOrden = from x in miLista
                              orderby x.sDescripcion
                              select x;

                miLista = feriadoOrden.ToList<TFeriados>();
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
        public TFeriados Buscar(string prm_CodigoFeriado)
        {
            TFeriados miEntidad = new TFeriados();
            try
            {
                miEntidad = oTFeriadosData.Buscar(prm_CodigoFeriado);
                if (!miEntidad.bFijo)
                {
                    string sFECHA_DATO = miEntidad.sFeriado.Substring(6, 2) + "/" +
                                         miEntidad.sFeriado.Substring(4, 2) + "/" +
                                         miEntidad.sFeriado.Substring(0, 4);
                    miEntidad.dFechaIndicada = Convert.ToDateTime(sFECHA_DATO);
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
        public ReturnValor Registrar(TFeriados itemTFeriados)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    string sFeriadox = oTFeriadosData.BuscarPorFeriado(itemTFeriados.sFeriado).sFeriado;
                    if (sFeriadox == null)
                    {
                        oReturnValor.CodigoRetorno = oTFeriadosData.Registrar(itemTFeriados);
                        if (oReturnValor.CodigoRetorno != null)
                        {
                            oReturnValor.Exitosa = true;
                            tx.Complete();
                        }
                    }
                    else
                        oReturnValor.Message = "¡ Los datos del feriado no se ha registrado,  ya existe !";
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpMessage.Message(ex);
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo TFeriados
        /// En la BASE de DATO la Tabla : [Maestras.TFeriados]
        /// <summary>
        /// <param name = >itemTFeriados</param>
        public ReturnValor Actualizar(TFeriados itemTFeriados)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    List<TFeriados> listaTFeriados = new List<TFeriados>();
                    listaTFeriados = oTFeriadosData.Listar(string.Empty, string.Empty, null, null);
                    int CONTADOR = 0;
                    foreach (TFeriados kExamina in listaTFeriados)
                    {
                        if (kExamina.sFeriado.Substring(4, 4) == itemTFeriados.sFeriado.Substring(4, 4))
                            ++CONTADOR;
                    }
                    if (CONTADOR < 2)
                    {
                        oReturnValor.Exitosa = oTFeriadosData.Actualizar(itemTFeriados);
                        if (oReturnValor.Exitosa)
                        {
                            tx.Complete();
                        }
                    }
                    else
                        oReturnValor.Message = "¡ Los datos del feriado no se ha registrado,  ya existe !";
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpMessage.Message(ex);
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Maestras.TFeriados
        /// En la BASE de DATO la Tabla : [Maestras.TFeriados]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Eliminar(string prm_sCodRegistro)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oTFeriadosData.Eliminar(prm_sCodRegistro);
                    if (oReturnValor.Exitosa)
                    {
                        tx.Complete();
                    }
                    else
                        oReturnValor.Message = "¡ El Registro NO HA SIDO ELIMINADO !";
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpMessage.Message(ex);
            }
            return oReturnValor;
        }

        #endregion

    }
} 
