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
    public class ItemLogic
    {
        private ItemData oItemData = null;

        private ItemTemaData oItemTemaData = null;
        private ItemActorData oItemActorData = null;
        private ItemAutorData oItemAutorData = null;
        private ItemEjemplarData oItemEjemplarData = null;
        //private ItemEjemplar1 oItemEjemplarData1 = null;
        private ItemAutorInstitucionalData oItemAutorInstitucionalData = null;
        private ReturnValor oReturn = null;
        public ItemLogic()
        {
            oItemData = new ItemData();
            oItemTemaData = new ItemTemaData();
            oItemActorData = new ItemActorData();
            oItemAutorData = new ItemAutorData();
            oItemAutorInstitucionalData = new ItemAutorInstitucionalData();
            oItemEjemplarData = new ItemEjemplarData();
            //oItemEjemplarData1 = new ItemEjemplar1();
            oReturn = new ReturnValor();
        }

        #region " /* Funciones Insertar */ "

        /// <summary>
        /// Ingresa un registro en la tabla [TableName]
        /// </summary>
        /// <param name="pItem"></param>
        public ReturnValor Registrar(Item pItem)
        {

            try
            {

                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    this.oItemData.Registrar(pItem);
                    if (pItem.ListaActores != null)
                    {
                        foreach (ItemActor oitemActor in pItem.ListaActores)
                        {
                            if (oitemActor.bActivo)
                            {
                                oitemActor.sCodItem = pItem.sCodItem;
                                oItemActorData.Registrar(oitemActor);
                            }

                        }
                    }
                    if (pItem.ListaAutores != null)
                    {
                        foreach (ItemAutor oitemAutor in pItem.ListaAutores)
                        {
                            if (oitemAutor.bEstado)
                            {
                                oitemAutor.sCodItem = pItem.sCodItem;
                                oItemAutorData.Registrar(oitemAutor);
                            }

                        }
                    }
                    if (pItem.ListaAutoresInstitucionales != null)
                    {
                        foreach (ItemAutor oitemAutorInstitucionales in pItem.ListaAutoresInstitucionales)
                        {
                            if (oitemAutorInstitucionales.bEstado)
                            {
                                oitemAutorInstitucionales.sCodItem = pItem.sCodItem;
                                oItemAutorInstitucionalData.Registrar(oitemAutorInstitucionales);
                            }

                        }
                    }
                    if (pItem.ListaTemas != null)
                    {
                        foreach (ItemTema oitemAutorTema in pItem.ListaTemas)
                        {
                            if (oitemAutorTema.bEstado)
                            {
                                oitemAutorTema.sCodItem = pItem.sCodItem;
                                oItemTemaData.Registrar(oitemAutorTema);
                            }

                        }
                    }
                    if (pItem.ListaEjemplares != null)
                    {
                        foreach (ItemEjemplar oitemEjemplar in pItem.ListaEjemplares)
                        {
                            oitemEjemplar.sCodItem = pItem.sCodItem;
                            oItemEjemplarData.Registrar(oitemEjemplar);
                        }
                    }
                    oReturn.Exitosa = true;
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
        /// Buscar un regitro de la tabla Item segun su pk enviado por parametro
        /// </summary>
        /// <returns>Item</returns>
        public Item Buscar(string sCodItem)
        {
            Item Item = new Item();
            try
            {
                Item = this.oItemData.Buscar(sCodItem);
                Item.ListaActores = this.oItemActorData.Listar(sCodItem);
                Item.ListaAutores = this.oItemAutorData.Listar(sCodItem);
                Item.ListaAutoresInstitucionales = this.oItemAutorInstitucionalData.Listar(sCodItem);
                Item.ListaTemas = this.oItemTemaData.Listar(sCodItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Item;
        }

        /// <summary>
        /// Buscar un regitro de la tabla Item segun el Codigo de Ejemplar enviado por parametro
        /// </summary>
        /// <returns>Item</returns>
        public Item BuscarPorCodEjemplar(string prm_sCodEjemplar)
        {
            Item Item = new Item();
            try
            {
                Item = oItemData.BuscarPorCodEjemplar(prm_sCodEjemplar);
                if (Item.sCodItem != null)
                {
                    Item.ListaActores = this.oItemActorData.Listar(Item.sCodItem);
                    Item.ListaAutores = this.oItemAutorData.Listar(Item.sCodItem);
                    Item.ListaAutoresInstitucionales = this.oItemAutorInstitucionalData.Listar(Item.sCodItem);
                    Item.ListaTemas = this.oItemTemaData.Listar(Item.sCodItem);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Item;
        }
        public Item BuscarDetalleItem(string prm_sCodItem, string prm_sCodSac, string sCodArguEstadoDisponible, string sCodArguEstadoEnPrestamo, string sCodArguEstadoEnReserva)
        {
            Item Item = new Item();
            try
            {
                Item = this.oItemData.BuscarDetalleItem(prm_sCodItem,prm_sCodSac, sCodArguEstadoDisponible, sCodArguEstadoEnPrestamo, sCodArguEstadoEnReserva);
                Item.ListaActores = this.oItemActorData.Listar(prm_sCodItem);
                Item.ListaAutores = this.oItemAutorData.Listar(prm_sCodItem);
                Item.ListaTemas = this.oItemTemaData.Listar(prm_sCodItem);
                Item.ListaEjemplares = this.oItemEjemplarData.BuscarXItem(prm_sCodItem, prm_sCodSac);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Item;
        }

        /// <summary>
        /// Lista todos los registros de la tabla Item
        /// <summary>
        /// <returns>List</returns>
        public List<Item> Listar(string pCodItem, string pCodArguTipoItem, string pCodSac, string pTitulo, string pCodArguAutor, string pISBN, string pISSN, string pCodArguTema, string pCodArguEstadoItem, string pCodArguEstadoEjemplar)
        {
            List<Item> Lista = new List<Item>();
            try
            {
                Lista = this.oItemData.Listar(pCodItem, pCodArguTipoItem, pCodSac, pTitulo, pCodArguAutor, pISBN, pISSN, pCodArguTema, pCodArguEstadoItem, pCodArguEstadoEjemplar);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Lista;
        }
        public List<Item> ListarItem_DarAlta(string pCodItem, string pCodArguTipoItem, string pCodSac, string pTitulo, string pCodArguAutor, string pISBN, string pISSN, string pCodArguTema, string pCodArguEstadoItem1, string pCodArguEstadoItem2)
        {
            List<Item> Lista = new List<Item>();
            try
            {
                Lista = this.oItemData.ListarItem_DarAlta(pCodItem, pCodArguTipoItem, pCodSac, pTitulo, pCodArguAutor, pISBN, pISSN, pCodArguTema, pCodArguEstadoItem1, pCodArguEstadoItem2);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Lista;
        }

        public List<Item> Listar_DarBaja(string pCodItem, string pCodArguTipoItem, string pCodSac, string pTitulo, string pCodArguAutor, string pISBN, string pISSN, string pCodArguTema, string pCodArguEstadoItem, string pCodArguEstadoEjemplar)
        {
            List<Item> Lista = new List<Item>();
            try
            {
                Lista = this.oItemData.ListarItem_DarBaja(pCodItem, pCodArguTipoItem, pCodSac, pTitulo, pCodArguAutor, pISBN, pISSN, pCodArguTema, pCodArguEstadoItem, pCodArguEstadoEjemplar);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Lista;
        }

        public List<Item> ListarCatalogo_Avanzada(string pCodItem, string pCodArguTipoItem, string pCodSac, string pTitulo, string pCodArguAutor, string pISBN, string pISSN, string pCodArguTema, string pCodArguEstadoItem, string pCodArguEstadoEjemplar_ABuscar)
        {
            List<Item> Lista = new List<Item>();
            try
            {
                Lista = this.oItemData.ListarCatalogo_Avanzada(pCodItem, pCodArguTipoItem, pCodSac, pTitulo, pCodArguAutor, pISBN, pISSN, pCodArguTema, pCodArguEstadoItem, pCodArguEstadoEjemplar_ABuscar);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Lista;
        }
        public List<Item> ListarCatalogo_Simple(string pTextoBusqueda, string pCodSac, string pCodArguEstadoEjemplar_ABuscar)
        {
            List<Item> Lista = new List<Item>();
            try
            {
                Lista = this.oItemData.ListarCatalogo_Simple(pTextoBusqueda, pCodSac, pCodArguEstadoEjemplar_ABuscar);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Lista;
        }

        //***CGA 17-09-2012***
        public List<ItemEjemplar1> ListarEjemplar(string pCodItem, string pCodArguTipoItem, string pCodSac, string pTitulo, string pCodArguAutor, string pISBN, string pISSN, string pCodArguTema, string pCodArguEstadoEjemplar, string pCodEjemplar)
        {
            List<ItemEjemplar1> Lista = new List<ItemEjemplar1>();
            try
            {
                Lista = this.oItemEjemplarData.ListarEjemplar(pCodItem, pCodArguTipoItem, pCodSac, pTitulo, pCodArguAutor, pISBN, pISSN, pCodArguTema, pCodArguEstadoEjemplar, pCodEjemplar);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Lista;
        }
        //******--

        //***ESALDARRIAGA 14-01-2013***
        public List<ItemEjemplar_Alumno> ListarEjemplar_Alumno(string pCodItem, string pCodArguTipoItem, string pCodSac, string pTitulo, string pCodArguAutor, string pISBN, string pISSN, string pCodArguTema, string pCodArguEstadoEjemplar, string pCodEjemplar)
        {
            List<ItemEjemplar_Alumno> Lista = new List<ItemEjemplar_Alumno>();
            try
            {
                Lista = this.oItemEjemplarData.ListarEjemplar_Alumno(pCodItem, pCodArguTipoItem, pCodSac, pTitulo, pCodArguAutor, pISBN, pISSN, pCodArguTema, pCodArguEstadoEjemplar, pCodEjemplar);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Lista;
        }
        //******--

        #endregion

        #region " /* Funciones Modificar */ "

        /// <summary>
        /// Modificar los registros de la tabla [TableName] que cumplan con los parametros de busqueda embiados
        /// </summary>
        /// <param name="pItem"></param>
        /// <returns></returns>
        public ReturnValor Actualizar(Item pItem)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oItemData.Actualizar(pItem);
                    if (pItem.ListaActores != null)
                    {
                        foreach (ItemActor oitemActor in pItem.ListaActores)
                        {
                            if (oitemActor.bActivo) //nuevos
                            {
                                oitemActor.sCodItem = pItem.sCodItem;
                                oItemActorData.Registrar(oitemActor);
                            }
                            

                        }
                    }
                    if (pItem.ListaAutores != null)
                    {
                        foreach (ItemAutor oitemAutor in pItem.ListaAutores)
                        {
                            if (oitemAutor.bEstado)
                            {
                                oitemAutor.sCodItem = pItem.sCodItem;
                                oItemAutorData.Registrar(oitemAutor);
                            }

                        }
                    }
                    if (pItem.ListaAutoresInstitucionales != null)
                    {
                        foreach (ItemAutor oitemAutorInstitucionales in pItem.ListaAutoresInstitucionales)
                        {
                            if (oitemAutorInstitucionales.bEstado)
                            {
                                oitemAutorInstitucionales.sCodItem = pItem.sCodItem;
                                oItemAutorInstitucionalData.Registrar(oitemAutorInstitucionales);
                            }

                        }
                    }
                    if (pItem.ListaTemas != null)
                    {
                        foreach (ItemTema oitemAutorTema in pItem.ListaTemas)
                        {
                            if (oitemAutorTema.bEstado)
                            {
                                oitemAutorTema.sCodItem = pItem.sCodItem;
                                oItemTemaData.Registrar(oitemAutorTema);
                            }

                        }
                    }
                    if (pItem.ListaEjemplares != null)
                    {
                        foreach (ItemEjemplar oitemEjemplar in pItem.ListaEjemplares)
                        {
                            if (oitemEjemplar.sEstadoReg == true)
                            {
                                oitemEjemplar.sCodItem = pItem.sCodItem;
                                oItemEjemplarData.Registrar(oitemEjemplar);
                            }
                            //else if (oitemEjemplar.sEstadoReg == false)
                            //{
                            //    oitemEjemplar.sCodItem = pItem.sCodItem;
                            //    oItemEjemplarData.Actualizar(oitemEjemplar);
                            //}

                        }
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
        public ReturnValor Eliminar(string sCodItem)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oItemActorData.Eliminar(sCodItem, null);
                    oItemAutorData.Eliminar(sCodItem, null);
                    oItemAutorInstitucionalData.Eliminar(sCodItem, null);
                    oItemTemaData.Eliminar(sCodItem, null);
                    oItemData.EliminarEjemplar_XItem(sCodItem);
                    oItemData.Eliminar(sCodItem);
                    oReturn.Exitosa = true;
                    if (oReturn.Exitosa)
                    {
                        tx.Complete();
                        oReturn.Message = HelpMessage.Message(HelpMessage.TMessage.Eliminar);
                    }
                    else
                        oReturn.Message = "La eliminación no tubo efecto";
                }
            }
            catch (Exception ex)
            {
                oReturn = HelpMessage.Message(ex);
            }
            return oReturn;
        }
        public bool BuscarItem_ExisteMovimiento(string sCodItem)
        {
            bool pValor;
            try
            {
                pValor = this.oItemData.BuscarItem_ExisteMovimiento(sCodItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return pValor;
        }
        public ReturnValor ActualizarEstadoItem(string sCodItem, string sCodArguEstado, string p_SSIUsuario_Modificacion)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = oItemData.ActualizarEstadoItem(sCodItem, sCodArguEstado, p_SSIUsuario_Modificacion);
                    if (oReturn.Exitosa)
                    {
                        tx.Complete();
                        oReturn.Message = HelpMessage.Message(HelpMessage.TMessage.Editar);
                    }
                    else
                        oReturn.Message = "La eliminación no tubo efecto";
                }
            }
            catch (Exception ex)
            {
                oReturn = HelpMessage.Message(ex);
            }
            return oReturn;
        }
        #endregion

        #region " /* Funciones Item-Temas */ "

        /// <summary>
        /// Ingresa un registro en la tabla [TableName]
        /// </summary>
        /// <param name="pItem"></param>
        /// 
        public ReturnValor RegistrarTema(ItemTema pItem)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = this.oItemTemaData.Registrar(pItem);
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
        public List<ItemTema> ListarTemas(string pCodItem)
        {
            List<ItemTema> Lista = new List<ItemTema>();
            try
            {
                Lista = this.oItemTemaData.Listar(pCodItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Lista;
        }
        public ReturnValor EliminarTema(string sCodItem, string sCodArguTema)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = this.oItemTemaData.Eliminar(sCodItem, sCodArguTema);
                    if (oReturn.Exitosa)
                    {
                        tx.Complete();
                        oReturn.Message = HelpMessage.Message(HelpMessage.TMessage.Eliminar);
                    }
                    else
                        oReturn.Message = "La eliminación no tubo efecto";
                }
            }
            catch (Exception ex)
            {
                oReturn = HelpMessage.Message(ex);
            }
            return oReturn;
        }
        #endregion

        #region " /* Funciones Item-ACTOR */ "

        /// <summary>
        /// Ingresa un registro en la tabla [ITEM-ACTOR]
        /// </summary>
        /// <param name="pItem"></param>
        /// 
        public List<ItemActor> ListarActor(string pCodItem)
        {
            List<ItemActor> Lista = new List<ItemActor>();
            try
            {
                Lista = this.oItemActorData.Listar(pCodItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Lista;
        }
        public ReturnValor EliminarActor(string sCodItem, string sCodArguActor)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = this.oItemActorData.Eliminar(sCodItem, sCodArguActor);
                    if (oReturn.Exitosa)
                    {
                        tx.Complete();
                        oReturn.Message = HelpMessage.Message(HelpMessage.TMessage.Eliminar);
                    }
                    else
                        oReturn.Message = "La eliminación no tubo efecto";
                }
            }
            catch (Exception ex)
            {
                oReturn = HelpMessage.Message(ex);
            }
            return oReturn;
        }

        #endregion
        #region " /* Funciones Item-AUTOR */ "

        /// <summary>
        /// Ingresa un registro en la tabla [ITEM-AUTOR]
        /// </summary>
        /// <param name="pItem"></param>
        /// 
        public List<ItemAutor> ListarAutor(string pCodItem)
        {
            List<ItemAutor> Lista = new List<ItemAutor>();
            try
            {
                Lista = this.oItemAutorData.Listar(pCodItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Lista;
        }
        public ReturnValor EliminarAutor(string sCodItem, string sCodArguAutor)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = this.oItemAutorData.Eliminar(sCodItem, sCodArguAutor);
                    if (oReturn.Exitosa)
                    {
                        tx.Complete();
                        oReturn.Message = HelpMessage.Message(HelpMessage.TMessage.Eliminar);
                    }
                    else
                        oReturn.Message = "La eliminación no tubo efecto";
                }
            }
            catch (Exception ex)
            {
                oReturn = HelpMessage.Message(ex);
            }
            return oReturn;
        }

        #endregion
        #region " /* Funciones Item-AUTOR INSTITUCIONAL*/ "

        /// <summary>
        /// Ingresa un registro en la tabla [ITEM-AUTOR]
        /// </summary>
        /// <param name="pItem"></param>
        /// 
        public List<ItemAutor> ListarAutorInstitucional(string pCodItem)
        {
            List<ItemAutor> Lista = new List<ItemAutor>();
            try
            {
                Lista = this.oItemAutorInstitucionalData.Listar(pCodItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Lista;
        }
        public ReturnValor EliminarAutorInstitucional(string sCodItem, string sCodArguAutor)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturn.Exitosa = this.oItemAutorInstitucionalData.Eliminar(sCodItem, sCodArguAutor);
                    if (oReturn.Exitosa)
                    {
                        tx.Complete();
                        oReturn.Message = HelpMessage.Message(HelpMessage.TMessage.Eliminar);
                    }
                    else
                        oReturn.Message = "La eliminación no tubo efecto";
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
