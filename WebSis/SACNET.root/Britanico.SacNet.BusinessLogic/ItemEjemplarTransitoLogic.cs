using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Britanico.SacNet.DataAccess;
using Oxinet.Tools;
using System.Transactions;
using Britanico.SacNet.BusinessEntities;

namespace Britanico.SacNet.BusinessLogic
{
    public class ItemEjemplarTransitoLogic
    {
        private ItemEjemplarTransitoData oItemEjemplarTransitoData = null;
        private ItemEjemplarData oItemEjemplarData = null;
        private ReturnValor oReturn =  null;
        public ItemEjemplarTransitoLogic()
        {
            oItemEjemplarTransitoData = new  ItemEjemplarTransitoData();
            oItemEjemplarData = new ItemEjemplarData();
            oReturn = new ReturnValor();
        }

        #region " /* Funciones Insertar */ "

        /// <summary>
        /// Ingresa un registro en la tabla [TableName]
        /// </summary>
        /// <param name="pItem"></param>
        public ReturnValor Registrar(ItemEjemplarTransito pItem)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = this.oItemEjemplarTransitoData.Registrar(pItem);
                    if (oReturn.Exitosa)
                    {
                        tx.Complete();
                        oReturn.Message = HelpMessage.Message(HelpMessage.TMessage.Registrar);
                    }
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
        /// Buscar todos los regitros de la tabla ItemEjemplar segun su pk enviado por parametro
        /// </summary>
        /// <returns>Item</returns>
        public List<ItemEjemplarTransito> Listar(Nullable<DateTime> p_dFechaDevolucionRealINI, Nullable<DateTime> p_dFechaDevolucionRealFIN, string p_sCodEjemplar, string pCodSac)
        {
            List<ItemEjemplarTransito> Lista = new List<ItemEjemplarTransito>();
            try
            {
                Lista = this.oItemEjemplarTransitoData.Listar(HelpDates.FormatFechaYMD(p_dFechaDevolucionRealINI), HelpDates.FormatFechaYMD(p_dFechaDevolucionRealFIN), p_sCodEjemplar, pCodSac);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Lista;
        }

        #endregion

        #region " /* Funciones Modificar */ "

        /// <summary>
        /// Modificar los registros de la tabla [TableName] que cumplan con los parametros de busqueda embiados
        /// </summary>
        /// <param name="pItem"></param>
        /// <returns></returns>
        public ReturnValor Actualizar(string p_sCodPrestamo, string p_sCodEjemplar, string p_SSIUsuario_Modificacion)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = oItemEjemplarTransitoData.ActualizarLlegadaDeEjemplar(p_sCodPrestamo, p_sCodEjemplar, p_SSIUsuario_Modificacion);
                    ItemEjemplar oItemEjemplar = new ItemEjemplar();
                    oItemEjemplar = new ItemEjemplarData().Buscar(p_sCodEjemplar);

                    bool ESTADO_EJEMPLAR = false;
                    if (!oItemEjemplar.bReservado)
                        ESTADO_EJEMPLAR = oItemEjemplarData.Actualizar_EstadoEjemplar(p_sCodEjemplar, HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoDisponibleEjemplar), p_SSIUsuario_Modificacion);
                    else
                        ESTADO_EJEMPLAR = oItemEjemplarData.Actualizar_EstadoEjemplar(p_sCodEjemplar, HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoEnReservaEjemplar), p_SSIUsuario_Modificacion);

                    if (oReturn.Exitosa && ESTADO_EJEMPLAR)
                    {
                        tx.Complete();
                        oReturn.Message = HelpMessage.Message(HelpMessage.TMessage.Editar);
                    }
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
