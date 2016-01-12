using System;
using System.Configuration;
using System.Collections.Generic;
using System.Transactions;
using Britanico.SacNet.BusinessEntities ;
using Britanico.SacNet.DataAccess ;
using Oxinet.Tools;


namespace Britanico.SacNet.BusinessLogic
{
    /// <summary>
    /// 
    /// </summary>
    public class ItemEjemplarLogic
    {
        private ItemEjemplarData oItemEjemplarData = null;
        private ItemData oItemData = null;
        private ReturnValor oReturn =  null;
        public ItemEjemplarLogic()
        {
            oItemEjemplarData = new ItemEjemplarData();
            oItemData = new ItemData();
            oReturn = new ReturnValor();
        }

        #region " /* Funciones Insertar */ "

        /// <summary>
        /// Ingresa un registro en la tabla [TableName]
        /// </summary>
        /// <param name="pItem"></param>
        public ReturnValor Registrar(ItemEjemplar pItem)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = this.oItemEjemplarData.Registrar(pItem);
                    if (oReturn.Exitosa)
                    {
                        tx.Complete();
                        oReturn.Message = HelpMessage.Message(HelpMessage.TMessage.Registrar);
                    }

                    else
                        oReturn.Message = "El registro no tubo efecto";

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
        /// Buscar un regitro de la tabla ItemEjemplar segun su pk enviado por parametro
        /// </summary>
        /// <returns>Item</returns>
        public ItemEjemplar Buscar(string sCodEjemplar)
        {
            ItemEjemplar Item = new ItemEjemplar();
            try
            {
                Item = this.oItemEjemplarData.Buscar(sCodEjemplar);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Item;
        }

        public ItemEjemplar Buscar(string prm_sCodEjemplar, string prm_sCodSac)
        {
            ItemEjemplar Item = new ItemEjemplar();
            try
            {
                Item = this.oItemEjemplarData.Buscar(prm_sCodEjemplar, prm_sCodSac);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Item;
        }

        /// <summary>
        /// Lista todos los registros de la tabla ItemEjemplar
        /// <summary>
        /// <returns>List</returns>
        public List<ItemEjemplar> Listar(string pCodItem, string pCodSac, string pEstado)
        {
            List<ItemEjemplar> Lista = new List<ItemEjemplar>();
            try
            {
                Lista = this.oItemEjemplarData.Listar(pCodItem, pCodSac, pEstado);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Lista;
        }
        public List<ItemEjemplar> Listar_A_Dar_Alta(string pCodItem, string pCodSac)
        {
            List<ItemEjemplar> Lista = new List<ItemEjemplar>();
            try
            {
                Lista = this.oItemEjemplarData.Listar_A_DarAlta(pCodItem, pCodSac);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Lista;
        }
        public List<ItemEjemplar> Listar_A_Dar_Baja(string pCodItem, string pCodSac, string pCodArguEstadoABuscar)
        {
            List<ItemEjemplar> Lista = new List<ItemEjemplar>();
            try
            {
                Lista = this.oItemEjemplarData.Listar_A_DarBaja(pCodItem, pCodSac, pCodArguEstadoABuscar);

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
        public ReturnValor Actualizar(ItemEjemplar pItem)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = oItemEjemplarData.Actualizar(pItem);
                    if (oReturn.Exitosa)
                    {
                        tx.Complete();
                        oReturn.Message = HelpMessage.Message(HelpMessage.TMessage.Editar);
                    }
                    else
                        oReturn.Message = "La modificacion no tubo efecto";

                }
            }
            catch (Exception ex)
            {
                oReturn = HelpMessage.Message(ex);
            }
            return oReturn;
        }
        public ReturnValor ActualizarEjemplares_DarAlta(List<ItemEjemplar> pListaEjemplares)
        {
            try
            {
                string EstadoEnStockItem = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoEnStockItem);
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    foreach (ItemEjemplar item in pListaEjemplares)
                    {
                        oItemEjemplarData.Actualizar_Ejemplar_DarAlta(item.sCodEjemplar,item.sCodSac, item.sCodArguEstadoEjemplar, item.SSIUsuario_Modificacion);
                    }
                      oReturn.Exitosa = oItemData.ActualizarEstadoItem(pListaEjemplares[0].sCodItem, EstadoEnStockItem, pListaEjemplares[0].SSIUsuario_Modificacion);
                    if (oReturn.Exitosa)
                    {
                        tx.Complete();
                        oReturn.Message = HelpMessage.Message(HelpMessage.TMessage.Editar);
                    }
                    else
                        oReturn.Message = "La modificacion no tubo efecto";

                }
            }
            catch (Exception ex)
            {
                oReturn = HelpMessage.Message(ex);
            }
            return oReturn;
        }
        public ReturnValor ActualizarEjemplares_DarBaja(List<ItemEjemplar> pListaEjemplares)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope())
                {
                foreach (ItemEjemplar item in pListaEjemplares)
                {
                    oItemEjemplarData.Actualizar_Ejemplar_DarBaja(item.sCodEjemplar,item.sCodArguEstadoEjemplar, item.SSIUsuario_Modificacion);
                }
                oReturn.Exitosa = true;
                if (oReturn.Exitosa)
                {
                    tx.Complete();
                    oReturn.Message = HelpMessage.Message(HelpMessage.TMessage.Editar);
                }
                else
                    oReturn.Message = "La modificacion no tubo efecto";

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

        /// <summary>
        /// Eliminar
        /// </summary>
        public ReturnValor Eliminar(string sCodEjemplar)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = oItemEjemplarData.Eliminar(sCodEjemplar);
                    if (oReturn.Exitosa)
                    {
                        tx.Complete();
                        oReturn.Message = HelpMessage.Message(HelpMessage.TMessage.Eliminar);
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

        public ReturnValor DetectarEjemplarEnPrestamo(string prm_sCodEjemplar, ref Prestamo prmPrestamo)
        {
            try
            {
                Prestamo itemPrestamo = new Prestamo();
                string prmsCodPrestamo = null;
                oReturn.Exitosa = oItemEjemplarData.DetectarEjemplarEnPrestamo(prm_sCodEjemplar, ref prmsCodPrestamo);
                if (oReturn.Exitosa && prmsCodPrestamo != null)
                {
                    itemPrestamo = new PrestamoLogic().Buscar(prmsCodPrestamo);
                    prmPrestamo = itemPrestamo;
                }
            }
            catch (Exception ex)
            {
                oReturn = HelpMessage.Message(ex);
            }
            return oReturn;
        }

        public ReturnValor DetectarEjemplarEnReserva(string prm_sCodEjemplar, ref Prestamo prmPrestamo)
        {
            try
            {
                Prestamo itemPrestamo = new Prestamo();
                string prmsCodPrestamo = null;
                oReturn.Exitosa = oItemEjemplarData.DetectarEjemplarEnReserva(prm_sCodEjemplar, ref prmsCodPrestamo);
                if (oReturn.Exitosa && prmsCodPrestamo != null)
                {
                    itemPrestamo = new PrestamoLogic().Buscar(prmsCodPrestamo);
                    prmPrestamo = itemPrestamo;
                }
            }
            catch (Exception ex)
            {
                oReturn = HelpMessage.Message(ex);
            }
            return oReturn;
        }

        public ReturnValor DetectarUsuarioEnDevolucionPendiente(string prm_sCodUsuarioSAC, ref Prestamo prmPrestamo)
        {
            try
            {
                Prestamo itemPrestamo = new Prestamo();
                string prmsCodPrestamo = null;
                oReturn.Exitosa = oItemEjemplarData.DetectarUsuarioEnDevolucionPendiente(prm_sCodUsuarioSAC, ref prmsCodPrestamo);
                if (oReturn.Exitosa && prmsCodPrestamo != null)
                {
                    itemPrestamo = new PrestamoLogic().Buscar(prmsCodPrestamo);
                    prmPrestamo = itemPrestamo;
                }
            }
            catch (Exception ex)
            {
                oReturn = HelpMessage.Message(ex);
            }
            return oReturn;
        }

        public List<Prestamo> DetectarUsuarioEnDevolucionPendienteV2(string prm_sCodUsuarioSAC, string prmCodArguTipoPrestamo)
        {
            List<Prestamo> lstPrestamos = new List<Prestamo>();
            List<Prestamo> lstPrestamosDomi = new List<Prestamo>();
            try
            {
                lstPrestamos = oItemEjemplarData.DetectarUsuarioEnDevolucionPendienteV2(prm_sCodUsuarioSAC);
                foreach (Prestamo yPrestamo in lstPrestamos)
                    if (yPrestamo.sCodArguPrestamoEn == prmCodArguTipoPrestamo)
                        lstPrestamosDomi.Add(yPrestamo);
            }
            catch (Exception ex)
            {
                oReturn = HelpMessage.Message(ex);
            }
            return lstPrestamosDomi;
        }

        public ReturnValor DetectarUsuarioEnReservaPendiente(string prm_sCodUsuarioSAC, ref Prestamo prmPrestamo)
        {
            try
            {
                Prestamo itemPrestamo = new Prestamo();
                string prmsCodPrestamo = null;
                oReturn.Exitosa = oItemEjemplarData.DetectarUsuarioEnReservaPendiente(prm_sCodUsuarioSAC, ref prmsCodPrestamo);
                if (oReturn.Exitosa && prmsCodPrestamo != null)
                {
                    itemPrestamo = new PrestamoLogic().Buscar(prmsCodPrestamo);
                    prmPrestamo = itemPrestamo;
                }
            }
            catch (Exception ex)
            {
                oReturn = HelpMessage.Message(ex);
            }
            return oReturn;
        }
        public bool DetectarExisteEjemplar(string prm_sCodEjemplar)
        {
            bool pValor = false;
            try
            {
                pValor = oItemEjemplarData.DetectarExisteEjemplar(prm_sCodEjemplar);              
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pValor;
        }

    }
}
