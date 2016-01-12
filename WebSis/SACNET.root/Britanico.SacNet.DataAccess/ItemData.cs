using System;
using System.Configuration;
using System.Collections.Generic;
using Britanico.SacNet.BusinessEntities ;

namespace Britanico.SacNet.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    public class ItemData
    {
        public string conexion = string.Empty;
        public ItemData()
        {
            conexion = ConfigurationManager.ConnectionStrings["cnSacNET"].ConnectionString;
        }

        #region " /* Funciones Insertar */ "

        /// <summary>
        /// Ingresa un registro en la tabla Item
        /// </summary>
        /// <param name="pItem"></param>
        public bool Registrar(Item pItem)
        {
            int lnAfectados = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    lnAfectados = SQLDC.pa_mnt_RegistrarItem(
                        pItem.sCodItem,
                        pItem.sTitulo,
                        pItem.sEdicion,
                        pItem.sISBN,
                        pItem.sISSN,
                        pItem.sPieImprenta,
                        pItem.nPaginas,
                        pItem.sDuracion,
                        pItem.sResumen,
                        pItem.sCodArguTipoItem,
                        pItem.sCodArguAudiencia,
                        pItem.sCodArguGenero,
                        pItem.sCodArguEstadoItem,
                        pItem.sCodArguPrestamoEn,
                        pItem.sFormatoAdicional,
                        pItem.sIdioma,
                        pItem.fPrecioUnitario,
                        pItem.sCodArguProveedor,
                        pItem.sRequerimientoTecnico,
                        pItem.sFotografia,
                        pItem.sNotas,
                        pItem.sCodArguProcedencia,
                        pItem.sConferencia,
                        pItem.sPeriocidad,
                        pItem.sSerie,
                        pItem.sFuenteEn,
                        pItem.SSIUsuario_Creacion,
                        pItem.SSIHost
                        );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lnAfectados == 0 ? true : false;
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
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_mnt_BuscarItem(sCodItem);
                    foreach (var item in resul)
                    {
                        Item = new Item()
                        {
                            sCodItem = item.sCodItem,
                            sTitulo = item.sTitulo,
                            sEdicion = item.sEdicion,
                            sISBN = item.sISBN,
                            sISSN = item.sISSN,
                            sPieImprenta = item.sPieImprenta,
                            nPaginas = item.nPaginas,
                            sDuracion = item.sDuracion,
                            sResumen = item.sResumen,
                            sCodArguTipoItem = item.sCodArguTipoItem,
                            sCodArguAudiencia = item.sCodArguAudiencia,
                            sCodArguGenero = item.sCodArguGenero,
                            sCodArguEstadoItem = item.sCodArguEstadoItem,
                            sCodArguPrestamoEn = item.sCodArguPrestamoEn,
                            sFormatoAdicional = item.sFormatoAdicional,
                            sIdioma = item.sIdioma,
                            fPrecioUnitario = item.fPrecioUnitario,
                            sCodArguProveedor = item.sCodArguProveedor,
                            sRequerimientoTecnico = item.sRequerimientoTecnico,
                            sFotografia = item.sFotografia,
                            sNotas = item.sNotas,
                            sCodArguProcedencia = item.sCodArguProcedencia,
                            sConferencia = item.sConferencia,
                            sPeriocidad = item.sPeriocidad,
                            sSerie = item.sSerie,
                            sFuenteEn = item.sFuenteEn,
                            SSIUsuario_Creacion = item.SSIUsuario_Creacion,
                            SSIFechaHora_Creacion = item.SSIFechaHora_Creacion,
                            SSIUsuario_Modificacion = item.SSIUsuario_Modificacion,
                            SSIFechaHora_Modificacion = item.SSIFechaHora_Modificacion,
                            SSIHost = item.SSIHost

                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Item;
        }
        public Item BuscarDetalleItem(string sCodItem, string sCodSac, string sCodArguEstadoDisponible, string sCodArguEstadoEnPrestamo, string sCodArguEstadoEnReserva)
        {
            Item Item = new Item();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_pro_BuscarDetalleItem(sCodItem,sCodSac, sCodArguEstadoDisponible, sCodArguEstadoEnPrestamo,sCodArguEstadoEnReserva);
                    foreach (var itemDetalle in resul)
                    {
                        Item = new Item()
                        {
                            sCodItem = itemDetalle.sCodItem,
                            sTitulo = itemDetalle.sTitulo,                            
                            sPieImprenta = itemDetalle.sPieImprenta,                            
                            sDuracion = itemDetalle.sDuracion,
                            sResumen = itemDetalle.sResumen,
                            sCodArguTipoItem = itemDetalle.sCodArguTipoItem,
                            sCodArguAudiencia = itemDetalle.sCodArguAudiencia,
                            sCodArguGenero = itemDetalle.sCodArguGenero,                            
                            sRequerimientoTecnico = itemDetalle.sRequerimientoTecnico,
                            sFotografia = itemDetalle.sFotografia,
                            sNotas = itemDetalle.sNotas,
                            sFormatoAdicional = itemDetalle.sFormatoAdicional,
                            sCodArguAudienciaNombre = itemDetalle.CodArguNombreAudiencia,
                            sCodArguGeneroNombre = itemDetalle.CodArguNombreGenero,
                            sCantidadDisponibles=itemDetalle.CantidadDisponible.ToString(),
                            sCantidadEnPrestamo = itemDetalle.CantidadEnPrestamo.ToString(),
                            sCantidadEnReserva = itemDetalle.CantidadEnReserva.ToString()

                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Item;
        }

        public Item BuscarPorCodEjemplar(string prm_sCodEjemplar)
        {
            Item Item = new Item();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_pro_BuscarItemPorsCodEjemplar(prm_sCodEjemplar);
                    foreach (var item in resul)
                    {
                        Item = new Item()
                        {
                            sCodItem = item.sCodItem,
                            sTitulo = item.sTitulo,
                            sEdicion = item.sEdicion,
                            sISBN = item.sISBN,
                            sISSN = item.sISSN,
                            sPieImprenta = item.sPieImprenta,
                            nPaginas = item.nPaginas,
                            sDuracion = item.sDuracion,
                            sResumen = item.sResumen,
                            sCodArguTipoItem = item.sCodArguTipoItem,
                            sCodArguAudiencia = item.sCodArguAudiencia,
                            sCodArguGenero = item.sCodArguGenero,
                            sCodArguEstadoItem = item.sCodArguEstadoItem,
                            sCodArguPrestamoEn = item.sCodArguPrestamoEn,
                            sFormatoAdicional = item.sFormatoAdicional,
                            sIdioma = item.sIdioma,
                            fPrecioUnitario = item.fPrecioUnitario,
                            sCodArguProveedor = item.sCodArguProveedor,
                            sRequerimientoTecnico = item.sRequerimientoTecnico,
                            sFotografia = item.sFotografia,
                            sNotas = item.sNotas,
                            sCodArguProcedencia = item.sCodArguProcedencia,
                            sConferencia = item.sConferencia,
                            sPeriocidad = item.sPeriocidad,
                            sSerie = item.sSerie,
                            sFuenteEn = item.sFuenteEn,
                            SSIUsuario_Creacion = item.SSIUsuario_Creacion,
                            SSIFechaHora_Creacion = item.SSIFechaHora_Creacion,
                            SSIUsuario_Modificacion = item.SSIUsuario_Modificacion,
                            SSIFechaHora_Modificacion = item.SSIFechaHora_Modificacion,
                            SSIHost = item.SSIHost,
                            sCodArguAudienciaNombre = item.sCodArguAudienciaNombre,
                            sCodArguNombreEstadoItem = item.sCodArguEstadoItemNombre,
                            sCodArguGeneroNombre = item.sCodArguGeneroNombre,
                            sCodArguPrestamoEnNombre = item.sCodArguPrestamoEnNombre,
                            sCodArguProcedenciaNombre = item.sCodArguProcedencia,
                            sCodArguProveedorNombre = item.sCodArguProveedorNombre,
                            sCodArguTipoItemNombre = item.sCodArguTipoItemNombre,

                        };
                    }
                }
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
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_mnt_Listar_Item(pCodItem, pCodArguTipoItem, pCodSac, pTitulo, pCodArguAutor, pISBN, pISSN, pCodArguTema, pCodArguEstadoItem, pCodArguEstadoEjemplar);
                    foreach (var item in resul)
                    {
                        Lista.Add(new Item()
                        {
                            sCodItem = item.sCodItem,
                            sTitulo = item.sTitulo,
                            sEdicion = item.sEdicion,
                            sISBN = item.sISBN,
                            sISSN = item.sISSN,
                            sPieImprenta = item.sPieImprenta,
                            nPaginas = item.nPaginas,
                            sDuracion = item.sDuracion,
                            sResumen = item.sResumen,
                            sCodArguTipoItem = item.sCodArguTipoItem,
                            sCodArguAudiencia = item.sCodArguAudiencia,
                            sCodArguGenero = item.sCodArguGenero,
                            sCodArguEstadoItem = item.sCodArguEstadoItem,
                            sCodArguNombreEstadoItem = item.sCodArguNombreEstadoItem,
                            sCodArguPrestamoEn = item.sCodArguPrestamoEn,
                            sFormatoAdicional = item.sFormatoAdicional,
                            sIdioma = item.sIdioma,
                            fPrecioUnitario = item.fPrecioUnitario,
                            sCodArguProveedor = item.sCodArguProveedor,
                            sRequerimientoTecnico = item.sRequerimientoTecnico,
                            sFotografia = item.sFotografia,
                            sNotas = item.sNotas,
                            sCodArguProcedencia = item.sCodArguProcedencia,
                            sConferencia = item.sConferencia,
                            sPeriocidad = item.sPeriocidad,
                            sSerie = item.sSerie,
                            sFuenteEn = item.sFuenteEn,
                            sNombreAutores = item.CodArguNombreAutores,
                            sNombreTemas = item.CodArguNombreTemas,
                            sCodSac = item.sCodSac,
                            sCodSacNombre = item.NombreLocal,
                            SSIUsuario_Creacion = item.SSIUsuario_Creacion,
                            SSIFechaHora_Creacion = item.SSIFechaHora_Creacion,
                            SSIUsuario_Modificacion = item.SSIUsuario_Modificacion,
                            SSIFechaHora_Modificacion = item.SSIFechaHora_Modificacion,
                            SSIHost = item.SSIHost,
                            TotalEjemplares = item.TotalEjemplares == null ? 0 : Convert.ToInt32(item.TotalEjemplares),
                            sCodItemsCodSac = item.sCodItem + "&" + (item.sCodSac == null ? string.Empty : item.sCodSac)
                        });
                    }
                }
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
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_mnt_Listar_Item_DarAlta(pCodItem, pCodArguTipoItem, pCodSac, pTitulo, pCodArguAutor, pISBN, pISSN, pCodArguTema, pCodArguEstadoItem1, pCodArguEstadoItem2);
                    foreach (var item in resul)
                    {
                        Lista.Add(new Item()
                        {
                            sCodItem = item.sCodItem,
                            sTitulo = item.sTitulo,
                            sEdicion = item.sEdicion,
                            sISBN = item.sISBN,
                            sISSN = item.sISSN,
                            sPieImprenta = item.sPieImprenta,
                            nPaginas = item.nPaginas,
                            sDuracion = item.sDuracion,
                            sResumen = item.sResumen,
                            sCodArguTipoItem = item.sCodArguTipoItem,
                            sCodArguAudiencia = item.sCodArguAudiencia,
                            sCodArguGenero = item.sCodArguGenero,
                            sCodArguEstadoItem = item.sCodArguEstadoItem,
                            sCodArguNombreEstadoItem = item.sCodArguNombreEstadoItem,
                            sCodArguPrestamoEn = item.sCodArguPrestamoEn,
                            sFormatoAdicional = item.sFormatoAdicional,
                            sIdioma = item.sIdioma,
                            fPrecioUnitario = item.fPrecioUnitario,
                            sCodArguProveedor = item.sCodArguProveedor,
                            sRequerimientoTecnico = item.sRequerimientoTecnico,
                            sFotografia = item.sFotografia,
                            sNotas = item.sNotas,
                            sCodArguProcedencia = item.sCodArguProcedencia,
                            sConferencia = item.sConferencia,
                            sPeriocidad = item.sPeriocidad,
                            sSerie = item.sSerie,
                            sFuenteEn = item.sFuenteEn,
                            sNombreAutores = item.CodArguNombreAutores,
                            sNombreTemas = item.CodArguNombreTemas,
                            sCodSac = item.sCodSac,
                            sCodSacNombre = item.NombreLocal,
                            SSIUsuario_Creacion = item.SSIUsuario_Creacion,
                            SSIFechaHora_Creacion = item.SSIFechaHora_Creacion,
                            SSIUsuario_Modificacion = item.SSIUsuario_Modificacion,
                            SSIFechaHora_Modificacion = item.SSIFechaHora_Modificacion,
                            SSIHost = item.SSIHost,
                            TotalEjemplares = item.TotalEjemplares == null ? 0 : Convert.ToInt32(item.TotalEjemplares)

                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Lista;
        }
        public List<Item> ListarItem_DarBaja(string pCodItem, string pCodArguTipoItem, string pCodSac, string pTitulo, string pCodArguAutor, string pISBN, string pISSN, string pCodArguTema, string pCodArguEstadoItem, string pCodArguEstadoEjemplar)
        {
            List<Item> Lista = new List<Item>();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_mnt_Listar_Item_DarBaja(pCodItem, pCodArguTipoItem, pCodSac, pTitulo, pCodArguAutor, pISBN, pISSN, pCodArguTema, pCodArguEstadoItem, pCodArguEstadoEjemplar);
                    foreach (var item in resul)
                    {
                        Lista.Add(new Item()
                        {
                            sCodItem = item.sCodItem,
                            sTitulo = item.sTitulo,
                            sEdicion = item.sEdicion,
                            sISBN = item.sISBN,
                            sISSN = item.sISSN,
                            sPieImprenta = item.sPieImprenta,
                            nPaginas = item.nPaginas,
                            sDuracion = item.sDuracion,
                            sResumen = item.sResumen,
                            sCodArguTipoItem = item.sCodArguTipoItem,
                            sCodArguAudiencia = item.sCodArguAudiencia,
                            sCodArguGenero = item.sCodArguGenero,
                            sCodArguEstadoItem = item.sCodArguEstadoItem,
                            sCodArguNombreEstadoItem = item.sCodArguNombreEstadoItem,
                            sCodArguPrestamoEn = item.sCodArguPrestamoEn,
                            sFormatoAdicional = item.sFormatoAdicional,
                            sIdioma = item.sIdioma,
                            fPrecioUnitario = item.fPrecioUnitario,
                            sCodArguProveedor = item.sCodArguProveedor,
                            sRequerimientoTecnico = item.sRequerimientoTecnico,
                            sFotografia = item.sFotografia,
                            sNotas = item.sNotas,
                            sCodArguProcedencia = item.sCodArguProcedencia,
                            sConferencia = item.sConferencia,
                            sPeriocidad = item.sPeriocidad,
                            sSerie = item.sSerie,
                            sFuenteEn = item.sFuenteEn,
                            sNombreAutores = item.CodArguNombreAutores,
                            sNombreTemas = item.CodArguNombreTemas,
                            sCodSac = item.sCodSac,
                            sCodSacNombre = item.NombreLocal,
                            SSIUsuario_Creacion = item.SSIUsuario_Creacion,
                            SSIFechaHora_Creacion = item.SSIFechaHora_Creacion,
                            SSIUsuario_Modificacion = item.SSIUsuario_Modificacion,
                            SSIFechaHora_Modificacion = item.SSIFechaHora_Modificacion,
                            SSIHost = item.SSIHost,
                            TotalEjemplares = item.TotalEjemplares == null ? 0 : Convert.ToInt32(item.TotalEjemplares),
                            sCodItemsCodSac = item.sCodItem + "&" + (item.sCodSac == null ? string.Empty : item.sCodSac)
                        });
                    }
                }
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
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_pro_ListarAvanzada_CatalogoItem(pCodItem, pCodArguTipoItem, pCodSac, pTitulo, pCodArguAutor, pISBN, pISSN, pCodArguTema, pCodArguEstadoItem, pCodArguEstadoEjemplar_ABuscar);
                    foreach (var item in resul)
                    {
                        Lista.Add(new Item()
                        {
                            sCodItem = item.sCodItem,
                            sTitulo = item.sTitulo,
                            sNombreAutores = item.CodArguNombreAutores,
                            sNombreTemas = item.CodArguNombreTemas,
                            sCodSac = item.sCodSac,
                            sCodSacNombre = item.NombreLocal,
                            sCantidadDisponibles = item.CantidadDisponible.ToString()

                        });
                    }
                }
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
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_pro_ListarSimple_CatalogoItem(pTextoBusqueda, pCodSac, pCodArguEstadoEjemplar_ABuscar);
                    foreach (var item in resul)
                    {
                        Lista.Add(new Item()
                        {
                            sCodItem = item.sCodItem,
                            sTitulo = item.sTitulo,
                            sNombreAutores = item.CodArguNombreAutores,
                            sNombreTemas = item.CodArguNombreTemas,
                            sCodSac = item.sCodSac,
                            sCodSacNombre=item.NombreLocal,
                            sCantidadDisponibles = item.CantidadDisponible.ToString()

                        });
                    }
                }
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
        /// Modificar los registros de la tabla Item que cumplan con los parametros de busqueda embiados
        /// </summary>
        /// <param name="pItem"></param>
        /// <returns></returns>
        public bool Actualizar(Item pItem)
        {
            int lnAfectados = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    lnAfectados = SQLDC.pa_mnt_ActualizarItem(
                        pItem.sCodItem,
                        pItem.sTitulo,
                        pItem.sEdicion,
                        pItem.sISBN,
                        pItem.sISSN,
                        pItem.sPieImprenta,
                        pItem.nPaginas,
                        pItem.sDuracion,
                        pItem.sResumen,
                        pItem.sCodArguTipoItem,
                        pItem.sCodArguAudiencia,
                        pItem.sCodArguGenero,
                        pItem.sCodArguEstadoItem,
                        pItem.sCodArguPrestamoEn,
                        pItem.sFormatoAdicional,
                        pItem.sIdioma,
                        pItem.fPrecioUnitario,
                        pItem.sCodArguProveedor,
                        pItem.sRequerimientoTecnico,
                        pItem.sFotografia,
                        pItem.sNotas,
                        pItem.sCodArguProcedencia,
                        pItem.sConferencia,
                        pItem.sPeriocidad,
                        pItem.sSerie,
                        pItem.sFuenteEn,
                        pItem.SSIUsuario_Modificacion,
                        pItem.SSIHost

                    );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lnAfectados == 0 ? true : false;
        }
        #endregion

        #region " /* Funciones Eliminar */ "

        /// <summary>
        /// Eliminar
        /// </summary>
        public bool Eliminar(string sCodItem)
        {
            int lnAfectados = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {

                    lnAfectados = SQLDC.pa_mnt_EliminarItem(sCodItem);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lnAfectados == 0 ? true : false;
        }
        public bool EliminarEjemplar_XItem(string sCodItem)
        {
            int lnAfectados = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {

                    lnAfectados = SQLDC.pa_pro_EliminarItemEjemplar_xItem(sCodItem);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lnAfectados == 0 ? true : false;
        }
        public bool BuscarItem_ExisteMovimiento(string sCodItem)
        {
            bool? pValor = false;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {

                    SQLDC.pa_pro_BuscarItem_ExisteMovimiento(ref pValor, sCodItem);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Convert.ToBoolean(pValor);
        }
        public bool ActualizarEstadoItem(string sCodItem, string sCodArguEstado, string p_SSIUsuario_Modificacion)
        {
            int lnAfectados = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {

                    lnAfectados = SQLDC.pa_pro_Actualizar_EstadoItem(sCodItem, sCodArguEstado, p_SSIUsuario_Modificacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lnAfectados == 0 ? true : false;
        }
        #endregion
    }
}
