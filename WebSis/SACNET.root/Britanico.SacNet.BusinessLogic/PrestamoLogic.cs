using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Configuration;
using System.Transactions;
using System.Collections;

using Britanico.SacNet.BusinessEntities;
using Britanico.SacNet.DataAccess;
using Oxinet.Tools;
using System.Data;

namespace Britanico.SacNet.BusinessLogic
{
    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 14/07/2010-11:03:43 
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [Sacnet.PrestamoLogic.cs]
    /// </summary>
    public class PrestamoLogic
    {
        private PrestamoData oPrestamoData = null;
        private ReservaData oReservaData = null;
        private ItemEjemplarData oItemEjemplarData = null;
        private ReturnValor oReturnValor = null;

        public PrestamoLogic()
        {
            oPrestamoData = new PrestamoData();
            oReservaData = new ReservaData();
            oItemEjemplarData = new ItemEjemplarData();
            oReturnValor = new ReturnValor();
        }

        /// <summary>
        /// Describen el tipo de OPERACION
        /// </summary>
        public enum TipoDeOperacion
        {
            OperPrestamo,
            OperReserva,
            OperDevolucion,
            OperSinDevolucion,
            OperTodos,
            OperRenovacion//ELVP: 26-09-2011
        }

        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Sacnet.Prestamo
        /// En la BASE de DATO la Tabla : [Sacnet.Prestamo]
        /// <summary>
        /// <returns>List</returns>
        public List<Prestamo> Listar(string prm_sCodSac, Nullable<DateTime> prm_dFechaProcesoINI, Nullable<DateTime> prm_dFechaProcesoFIN, string prm_sCodUsuarioSAC, string prm_sCodUsuarioSACNombre, string prm_sCodEjemplar, string prm_sCodEjemplarTitulo, bool? prm_sCodArguEstado, string prm_sCodArguPrestamoEn, bool? prm_bCarnet, TipoDeOperacion itemTipoDeOperacion)
        {
            List<Prestamo> miLista = new List<Prestamo>();
            List<Prestamo> miListaNueva = new List<Prestamo>();
            try
            {
                if (itemTipoDeOperacion == TipoDeOperacion.OperTodos)
                    miLista = oPrestamoData.ListarTodos(prm_sCodSac, HelpDates.FormatFechaYMD(prm_dFechaProcesoINI), HelpDates.FormatFechaYMD(prm_dFechaProcesoFIN), prm_sCodUsuarioSAC, prm_sCodUsuarioSACNombre, prm_sCodEjemplar, prm_sCodEjemplarTitulo, prm_sCodArguEstado, prm_sCodArguPrestamoEn, prm_bCarnet);
                else if (itemTipoDeOperacion == TipoDeOperacion.OperReserva)
                    miLista = oPrestamoData.ListarReservas(prm_sCodSac, HelpDates.FormatFechaYMD(prm_dFechaProcesoINI), HelpDates.FormatFechaYMD(prm_dFechaProcesoFIN), prm_sCodUsuarioSAC, prm_sCodUsuarioSACNombre, prm_sCodEjemplar, prm_sCodEjemplarTitulo, prm_sCodArguEstado, prm_sCodArguPrestamoEn, prm_bCarnet);
                else if (itemTipoDeOperacion == TipoDeOperacion.OperPrestamo)
                    miLista = oPrestamoData.ListarPrestamos(prm_sCodSac, HelpDates.FormatFechaYMD(prm_dFechaProcesoINI), HelpDates.FormatFechaYMD(prm_dFechaProcesoFIN), prm_sCodUsuarioSAC, prm_sCodUsuarioSACNombre, prm_sCodEjemplar, prm_sCodEjemplarTitulo, prm_sCodArguEstado, prm_sCodArguPrestamoEn, prm_bCarnet);
                else if (itemTipoDeOperacion == TipoDeOperacion.OperDevolucion)
                    miLista = oPrestamoData.ListarDevoluciones(prm_sCodSac, HelpDates.FormatFechaYMD(prm_dFechaProcesoINI), HelpDates.FormatFechaYMD(prm_dFechaProcesoFIN), prm_sCodUsuarioSAC, prm_sCodUsuarioSACNombre, prm_sCodEjemplar, prm_sCodEjemplarTitulo, prm_sCodArguEstado, prm_sCodArguPrestamoEn, prm_bCarnet);
                else if (itemTipoDeOperacion == TipoDeOperacion.OperSinDevolucion)
                    miLista = oPrestamoData.ListarSinDevoluciones(prm_sCodSac, HelpDates.FormatFechaYMD(prm_dFechaProcesoINI), HelpDates.FormatFechaYMD(prm_dFechaProcesoFIN), prm_sCodUsuarioSAC, prm_sCodUsuarioSACNombre, prm_sCodEjemplar, prm_sCodEjemplarTitulo, prm_sCodArguEstado, prm_sCodArguPrestamoEn, prm_bCarnet);

                
                foreach (Prestamo xitem in miLista)
                {
                    if (xitem.dFechaPrestamo == null)
                    {
                        xitem.dFechaPrestamo = xitem.dFechaSolicitudReserva;
                        miListaNueva.Add(xitem);
                    }
                    if (xitem.sCodArguPrestamoEnNombre != string.Empty)
                        miListaNueva.Add(xitem);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miListaNueva;
        }

        public Prestamo BuscarReservasSolicitadas(string prm_sCodSac, string prm_sCodEjemplar, PrestamoLogic.TipoDeOperacion prm_TipoDeOperacion)
        {
            List<Prestamo> miLista = new List<Prestamo>();
            Prestamo miPrestamo = new Prestamo();
            try
            {
                miLista = oPrestamoData.ListarReservasSolicitadas(prm_sCodSac, string.Empty, string.Empty, string.Empty, string.Empty, prm_sCodEjemplar, string.Empty, false, string.Empty, null);
                List<Prestamo> listaReservasNN = new List<Prestamo>();
                foreach (Prestamo jPrestamo in miLista)
                {
                    if (jPrestamo.dFechaPrestamo == null)
                        if (jPrestamo.dFechaInicioReserva == null)
                            listaReservasNN.Add(jPrestamo);
                }

                if (listaReservasNN.Count == 1)
                    miPrestamo = listaReservasNN[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miPrestamo;
        }

        // SE COMENTO POR EL RETROCESO DEL DESARROLLO
        //public Reserva BuscarReservasSolicitadas(string prm_sCodSac, string prm_sCodItem, string prm_sCodUsuarioSAC)
        //{
        //    List<Reserva> miLista = new List<Reserva>();
        //    Reserva miReserva = new Reserva();
        //    try
        //    {
        //        miLista = oReservaData.ListarTodos(prm_sCodSac, string.Empty, string.Empty, prm_sCodUsuarioSAC, string.Empty, prm_sCodItem, string.Empty, false);
        //        List<Reserva> listaReservasNN = new List<Reserva>();
        //        foreach (Reserva jReserva in miLista)
        //        {
        //            if (jReserva.sCodPrestamo == null)
        //                if (jReserva.dFechaInicioReserva == null)
        //                    listaReservasNN.Add(jReserva);
        //        }

        //        if (listaReservasNN.Count == 1)
        //            miReserva = listaReservasNN[0];
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return miReserva;
        //}

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Sacnet.Prestamo
        /// En la BASE de DATO la Tabla : [Sacnet.Prestamo]
        /// <summary>
        /// <returns>Entidad</returns>
        public Prestamo Buscar(string prm_sCodPrestamo)
        {
            Prestamo miEntidad = new Prestamo();
            try
            {
                miEntidad = oPrestamoData.Buscar(prm_sCodPrestamo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miEntidad;
        }

        public int DetectarCantidadEjemplarPorUsuarioEnPrestamo(string prm_sCodUsuarioSAC)
        {
            int CantidadEjemplarPorUsuario;
            try
            {
                CantidadEjemplarPorUsuario = oPrestamoData.DetectarCantidadEjemplarPorUsuarioEnPrestamo(prm_sCodUsuarioSAC);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return CantidadEjemplarPorUsuario;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Prestamo
        /// En la BASE de DATO la Tabla : [Sacnet.Prestamo]
        /// <summary>
        /// <param name = >itemPrestamo</param>
        public ReturnValor RegistrarOperaciones(Prestamo itemPrestamo, TipoDeOperacion itemTipoDeOperacion)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (itemTipoDeOperacion == TipoDeOperacion.OperPrestamo)
                    {
                        oReturnValor.Exitosa = oItemEjemplarData.Actualizar_EstadoEjemplar(itemPrestamo.sCodEjemplar, HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoEnPrestamoEjemplar), itemPrestamo.SSIUsuario_Modificacion);
                        oReturnValor.CodigoRetorno = oPrestamoData.RegistrarPrestamo(itemPrestamo);
                        
                    }
                    else if (itemTipoDeOperacion == TipoDeOperacion.OperReserva)
                    {
                        
                        oReturnValor.CodigoRetorno = oPrestamoData.RegistrarReserva(itemPrestamo);
                        
                        ItemEjemplar itemItemEjemplar = new ItemEjemplar();
                        ItemEjemplarLogic oItemEjemplarLogic = new ItemEjemplarLogic();

                        itemItemEjemplar = oItemEjemplarLogic.Buscar(itemPrestamo.sCodEjemplar);
                        if (itemItemEjemplar.sCodArguEstadoEjemplar == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoDisponibleEjemplar))
                            oReturnValor.Exitosa = oItemEjemplarData.Actualizar_EstadoEjemplarReservDisp(itemPrestamo.sCodEjemplar, HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoEnReservaEjemplar),true, itemPrestamo.SSIUsuario_Modificacion);
                        else
                            oReturnValor.Exitosa = oItemEjemplarData.Actualizar_ReservarEjemplar(itemPrestamo.sCodEjemplar, true, itemPrestamo.SSIUsuario_Modificacion);
                    }
                    if (oReturnValor.CodigoRetorno != null)
                    {
                        oReturnValor.Exitosa = true;
                        oReturnValor.Message = HelpMessage.Message(HelpMessage.TMessage.Registrar);
                        tx.Complete();
                    }
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo Prestamo
        /// En la BASE de DATO la Tabla : [Sacnet.Prestamo]
        /// <summary>
        /// <param name = >itemPrestamo</param>
        public ReturnValor ActualizarOperaciones(Prestamo itemPrestamo, TipoDeOperacion itemTipoDeOperacion, DateTime FechaFinSuspension)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (itemTipoDeOperacion == TipoDeOperacion.OperPrestamo)
                    {
                        oReturnValor.Exitosa = oPrestamoData.RegistrarPrestamoDesdeReserva(itemPrestamo);
                        oReturnValor.Exitosa = oItemEjemplarData.Actualizar_EstadoEjemplar(itemPrestamo.sCodEjemplar, HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoEnPrestamoEjemplar), itemPrestamo.SSIUsuario_Modificacion);
                        oReturnValor.Exitosa = oItemEjemplarData.Actualizar_EstadoEjemplarReserv(itemPrestamo.sCodEjemplar, false, itemPrestamo.SSIUsuario_Modificacion);
                    }
                    else if (itemTipoDeOperacion == TipoDeOperacion.OperDevolucion)
                    {
                        oReturnValor.Exitosa = oPrestamoData.RegistrarDevolucion(itemPrestamo);
                        ItemEjemplar oItemEjemplar = new ItemEjemplar();
                        oItemEjemplar = oItemEjemplarData.Buscar(itemPrestamo.sCodEjemplar);
                        if (itemPrestamo.sCodSac == itemPrestamo.sCodSacDevuelto)
                        {
                            if (!oItemEjemplar.bReservado)
                                oReturnValor.Exitosa = oItemEjemplarData.Actualizar_EstadoEjemplar(itemPrestamo.sCodEjemplar, HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoDisponibleEjemplar), itemPrestamo.SSIUsuario_Modificacion);
                            else
                                oReturnValor.Exitosa = oItemEjemplarData.Actualizar_EstadoEjemplar(itemPrestamo.sCodEjemplar, HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoEnReservaEjemplar), itemPrestamo.SSIUsuario_Modificacion);
                        }
                        else
                        {
                            oReturnValor.Exitosa = oItemEjemplarData.Actualizar_EstadoEjemplar(itemPrestamo.sCodEjemplar, HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoEnTransitoEjemplar), itemPrestamo.SSIUsuario_Modificacion);

                            ItemEjemplarTransitoData oItemEjemplarTransitoData = new ItemEjemplarTransitoData();
                            ItemEjemplarTransito xTransito = new ItemEjemplarTransito
                            {
                                sCodEjemplar = itemPrestamo.sCodEjemplar,
                                sCodPrestamo = itemPrestamo.sCodPrestamo,
                                SSIUsuario_Creacion = itemPrestamo.SSIUsuario_Modificacion,
                                SSIHost = itemPrestamo.SSIHost
                            };
                            oReturnValor.Exitosa = oItemEjemplarTransitoData.Registrar(xTransito);

                        }
                        DateTime FechaDevolucion = itemPrestamo.dFechaDevolucionEstimada.Value.AddDays(Convert.ToInt32(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.DefaultDiasToleran)));
                        DateTime FechaInicioSuspension = DateTime.Now.AddDays(Convert.ToInt32(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.DefaultDiasToleran)));
                        if (DateTime.Today > FechaDevolucion)
                        {
                            UsuariosBloqueadosData oUsuariosBloqueadosData = new UsuariosBloqueadosData();
                            UsuariosBloqueados itemUsuariosBloqueados = new UsuariosBloqueados
                            {
                                bEstado = true,
                                sCodUsuarioSAC = itemPrestamo.sCodUsuarioSAC,
                                dFechaBloqueoON = FechaInicioSuspension,
                                dFechaBloqueoOFF = FechaFinSuspension,
                                SSIUsuario_Creacion = itemPrestamo.SSIUsuario_Modificacion,
                                SSIHost = itemPrestamo.SSIHost,
                            };
                            List<UsuariosBloqueados> listaUsuariosBloqueados = new List<UsuariosBloqueados>();
                            listaUsuariosBloqueados = oUsuariosBloqueadosData.Listar(string.Empty, string.Empty, itemPrestamo.sCodUsuarioSAC, true);

                            foreach (UsuariosBloqueados jkl in listaUsuariosBloqueados)
                            {
                                jkl.SSIUsuario_Modificacion = itemPrestamo.SSIUsuario_Modificacion;
                                oReturnValor.Exitosa = oUsuariosBloqueadosData.DesactivartUsuariosBloqueados(jkl);
                            }

                            oReturnValor.CodigoRetorno = oUsuariosBloqueadosData.Registrar(itemUsuariosBloqueados);
                        }
                        
                    }//Fin OperDevolucion

                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessage.Message(HelpMessage.TMessage.Editar);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpMessage.Message(ex);
            }
            return oReturnValor;
        }

        //***ELVP: 26-09-2011 Registrar Renovación***
        public ReturnValor ActualizarOperacionesRenovacion(Prestamo itemPrestamo_Prestamo, TipoDeOperacion itemTipoDeOperacion, DateTime FechaFinSuspension, Prestamo itemPrestamo_Devolucion)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    if (itemTipoDeOperacion == TipoDeOperacion.OperRenovacion)//ELVP: 26-09-2011 Renovación
                    {
                        //DEVOLUCIÓN
                        oReturnValor.Exitosa = oPrestamoData.RegistrarDevolucion(itemPrestamo_Devolucion);
                        ItemEjemplar oItemEjemplar = new ItemEjemplar();
                        oItemEjemplar = oItemEjemplarData.Buscar(itemPrestamo_Devolucion.sCodEjemplar);
                        if (itemPrestamo_Devolucion.sCodSac == itemPrestamo_Devolucion.sCodSacDevuelto)
                        {
                            if (!oItemEjemplar.bReservado)
                                oReturnValor.Exitosa = oItemEjemplarData.Actualizar_EstadoEjemplar(itemPrestamo_Devolucion.sCodEjemplar, HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoDisponibleEjemplar), itemPrestamo_Devolucion.SSIUsuario_Modificacion);
                            else
                                oReturnValor.Exitosa = oItemEjemplarData.Actualizar_EstadoEjemplar(itemPrestamo_Devolucion.sCodEjemplar, HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoEnReservaEjemplar), itemPrestamo_Devolucion.SSIUsuario_Modificacion);
                        }
                        else
                        {
                            oReturnValor.Exitosa = oItemEjemplarData.Actualizar_EstadoEjemplar(itemPrestamo_Devolucion.sCodEjemplar, HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoEnTransitoEjemplar), itemPrestamo_Devolucion.SSIUsuario_Modificacion);

                            ItemEjemplarTransitoData oItemEjemplarTransitoData = new ItemEjemplarTransitoData();
                            ItemEjemplarTransito xTransito = new ItemEjemplarTransito
                            {
                                sCodEjemplar = itemPrestamo_Devolucion.sCodEjemplar,
                                sCodPrestamo = itemPrestamo_Devolucion.sCodPrestamo,
                                SSIUsuario_Creacion = itemPrestamo_Devolucion.SSIUsuario_Modificacion,
                                SSIHost = itemPrestamo_Devolucion.SSIHost
                            };
                            oReturnValor.Exitosa = oItemEjemplarTransitoData.Registrar(xTransito);

                        }
                        DateTime FechaDevolucion = itemPrestamo_Devolucion.dFechaDevolucionEstimada.Value.AddDays(Convert.ToInt32(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.DefaultDiasToleran)));
                        DateTime FechaInicioSuspension = DateTime.Now.AddDays(Convert.ToInt32(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.DefaultDiasToleran)));
                        if (DateTime.Today > FechaDevolucion)
                        {
                            UsuariosBloqueadosData oUsuariosBloqueadosData = new UsuariosBloqueadosData();
                            UsuariosBloqueados itemUsuariosBloqueados = new UsuariosBloqueados
                            {
                                bEstado = true,
                                sCodUsuarioSAC = itemPrestamo_Devolucion.sCodUsuarioSAC,
                                dFechaBloqueoON = FechaInicioSuspension,
                                dFechaBloqueoOFF = FechaFinSuspension,
                                SSIUsuario_Creacion = itemPrestamo_Devolucion.SSIUsuario_Modificacion,
                                SSIHost = itemPrestamo_Devolucion.SSIHost,
                            };
                            List<UsuariosBloqueados> listaUsuariosBloqueados = new List<UsuariosBloqueados>();
                            listaUsuariosBloqueados = oUsuariosBloqueadosData.Listar(string.Empty, string.Empty, itemPrestamo_Devolucion.sCodUsuarioSAC, true);

                            foreach (UsuariosBloqueados jkl in listaUsuariosBloqueados)
                            {
                                jkl.SSIUsuario_Modificacion = itemPrestamo_Devolucion.SSIUsuario_Modificacion;
                                oReturnValor.Exitosa = oUsuariosBloqueadosData.DesactivartUsuariosBloqueados(jkl);
                            }

                            oReturnValor.CodigoRetorno = oUsuariosBloqueadosData.Registrar(itemUsuariosBloqueados);
                        }

                        //PRÉSTAMO
                        oReturnValor.Exitosa = oItemEjemplarData.Actualizar_EstadoEjemplar(itemPrestamo_Prestamo.sCodEjemplar, HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoEnPrestamoEjemplar), itemPrestamo_Prestamo.SSIUsuario_Modificacion);
                        oReturnValor.CodigoRetorno = oPrestamoData.RegistrarPrestamo(itemPrestamo_Prestamo);

                    }

                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = "¡ La renovación fue realizada con éxito !";//HelpMessage.Message(HelpMessage.TMessage.Registrar);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpMessage.Message(ex);
            }
            return oReturnValor;
        }
        //*******************************************

        public ReturnValor ActivarReservaDePrestamo(string prm_sCodPrestamo)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oPrestamoData.ActivarReservaDePrestamo(prm_sCodPrestamo);
                    if (oReturnValor.Exitosa)
                        tx.Complete();
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
        /// ELIMINA un registro de la Entidad Sacnet.Prestamo
        /// En la BASE de DATO la Tabla : [Sacnet.Prestamo]
        /// <summary>
        /// <returns>bool</returns>
        public ReturnValor Eliminar(string prm_sCodPrestamo)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oPrestamoData.Eliminar(prm_sCodPrestamo);
                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessage.Message(HelpMessage.TMessage.Eliminar);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpMessage.Message(ex);
            }
            return oReturnValor;
        }

        #endregion


        #region " /* Funciones Seleccionar */ "
        
        //SE RETROCEDIO DEBIDO AL AVISO
        /// <summary>
        /// Retorna un coleccion de registros de tipo [Tabla].
        /// <summary>
        /// <returns>List</returns>
        //public List<Reserva> ListarReserva(string prm_sCodSac, Nullable<DateTime> prm_dFechaProcesoINI, Nullable<DateTime> prm_dFechaProcesoFIN, string prm_sCodUsuarioSAC, string prm_sCodUsuarioSACNombre, string prm_sCodItem, string prm_sCodItemTitulo, bool? prm_bSucedido)
        //{
        //    List<Reserva> lista = new List<Reserva>();
        //    try
        //    {
        //        lista = oReservaData.ListarTodos(prm_sCodSac, HelpDates.FormatFechaYMD(prm_dFechaProcesoINI), HelpDates.FormatFechaYMD(prm_dFechaProcesoFIN), prm_sCodUsuarioSAC, prm_sCodUsuarioSACNombre, prm_sCodItem, prm_sCodItemTitulo, prm_bSucedido);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return lista;
        //}

        #endregion

        #region " /* Funciones Insertar */ "
        // SE RETROCEDIO DEBIDO AL AVISO - PLOP!
        /// <summary>
        /// Almacena el registro de un objeto de tipo [Tabla].
        /// </summary>
        /// <param name="pItem"></param>
        //public ReturnValor RegistrarReserva(Reserva pItem)
        //{
        //    try
        //    {
        //        using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
        //        {
        //            oReturnValor.CodigoRetorno = this.oReservaData.RegistrarReserva(pItem);
        //            if (oReturnValor.CodigoRetorno != null)
        //            {
        //                oReturnValor.Exitosa = true;
        //                oReturnValor.Message = HelpMessage.Message(HelpMessage.TMessage.Registrar);
        //                tx.Complete();
        //            }
        //            else
        //                oReturnValor.Message = "El registro de reserva no ha sido registrado.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        oReturnValor = HelpMessage.Message(ex);
        //    }
        //    return oReturnValor;
        //}

        #endregion

        #region " /* Funciones Modificar */ "
        // SE RETROCEDIO DEBIDO AL AVISO - PLOP!
        /// <summary>
        /// Almacena el registro de un objeto de tipo [Reserva].
        /// </summary>
        /// <param name="pItem"></param>
        //public ReturnValor ActualizarReserva(Reserva pItem)
        //{
        //    try
        //    {
        //        using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
        //        {
        //            oReturnValor.Exitosa = oReservaData.ActualizarReserva(pItem);
        //            if (oReturnValor.Exitosa)
        //            {
        //                tx.Complete();
        //                oReturnValor.Message = HelpMessage.Message(HelpMessage.TMessage.Editar);
        //            }
        //            else
        //                oReturnValor.Message = "El registro de reserva no ha sido actualizado.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        oReturnValor = HelpMessage.Message(ex);
        //    }
        //    return oReturnValor;
        //}

        #endregion

    }
} 
