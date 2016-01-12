using System;
using System.Collections.Generic;
using System.Configuration;

using Britanico.SacNet.BusinessEntities;

namespace Britanico.SacNet.DataAccess
{
    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 14/07/2010-11:03:42 
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Sacnet.PrestamoData.cs]
    /// </summary>
    public class PrestamoData
    {
        private string conexion = string.Empty;
        
        public PrestamoData()
        {
            conexion = ConfigurationManager.ConnectionStrings["cnSacNET"].ConnectionString;
        }
       
        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Sacnet.Prestamo
        /// En la BASE de DATO la Tabla : [Sacnet.Prestamo]
        /// <summary>
        /// <returns>List</returns>
        public List<Prestamo> ListarTodos(string prm_sCodSac, string prm_dFechaProcesoINI, string prm_dFechaProcesoFIN, string prm_sCodUsuarioSAC, string prm_sCodUsuarioSACNombre, string prm_sCodEjemplar, string prm_sCodEjemplarTitulo, bool? prm_sCodArguEstado, string prm_sCodArguPrestamoEn, bool? prm_bCarnet)
        {
            List<Prestamo> miLista = new List<Prestamo>();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    SQLDC.CommandTimeout = 0;
                    var resul = SQLDC.pa_pro_ListarMovimientos(prm_sCodSac, prm_dFechaProcesoINI, prm_dFechaProcesoFIN, prm_sCodUsuarioSAC, prm_sCodUsuarioSACNombre, prm_sCodEjemplar, prm_sCodEjemplarTitulo, prm_sCodArguEstado, prm_sCodArguPrestamoEn, prm_bCarnet);
                    foreach (var item in resul)
                    {
                        miLista.Add(new Prestamo()
                        {
                            sCodPrestamo = item.sCodPrestamo,
                            sCodUsuarioSAC = item.sCodUsuarioSAC,
                            sCodEjemplar = item.sCodEjemplar,
                            sCodSac = item.sCodSac,
                            sCodSacUsuario = item.sCodSacUsuario,
                            dFechaSolicitudReserva = item.dFechaSolicitudReserva,
                            dFechaInicioReserva = item.dFechaInicioReserva,
                            dFechaPrestamo = item.dFechaPrestamo,
                            sCodArguPrestamoEn = item.sCodArguPrestamoEn,
                            bCarnet = item.bCarnet,
                            dFechaDevolucionEstimada = item.dFechaDevolucionEstimada,
                            dFechaDevolucionReal = item.dFechaDevolucionReal,
                            sCodSacDevuelto = item.sCodSacDevuelto,
                            sCodArguPrestamoEnNombre = item.sCodArguPrestamoEnNombre,
                            sCodEjemplarNombreTitulo = item.sCodEjemplarNombreTitulo,
                            sCodSacDevueltoNombre = item.sCodSacDevueltoNombre,
                            sCodSacNombre = item.sCodSacNombre,
                            sCodSacUsuarioNombre = item.sCodSacUsuarioNombre,
                            sCodUsuarioSACNombres = item.sCodSacUsuarioSACNombre,
                            SSIUsuario_Creacion = item.SSIUsuario_Creacion,
                            SSIFechaHora_Creacion = item.SSIFechaHora_Creacion,
                            SSIUsuario_Modificacion = item.SSIUsuario_Modificacion,
                            SSIFechaHora_Modificacion = item.SSIFechaHora_Modificacion,
                            SSIHost = item.SSIHost,
                            sCodEjemplarCodigoItem = item.sCodEjemplarsCodItem,
                            sAbreviaturaSac = item.sAbreviaturaSac,
                            sEstadoRegistro = item.dFechaSolicitudReserva != null ?
                            (item.dFechaPrestamo != null ?
                            (item.dFechaDevolucionReal != null ? "Reserva/Préstamo/Devolución" : "Reserva/Préstamo") : "Reserva") :
                            (item.dFechaDevolucionReal == null ? "Préstamo" : "Préstamo/Devolución"),
                            bATiempo = item.dFechaDevolucionReal != null ? item.dFechaDevolucionReal <= item.dFechaDevolucionEstimada ? true : false : true,
                            bRenovacion = item.bRenovacion != null ? item.bRenovacion: false,
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miLista;
        }

        public List<Prestamo> ListarPrestamos(string prm_sCodSac, string prm_dFechaProcesoINI, string prm_dFechaProcesoFIN, string prm_sCodUsuarioSAC, string prm_sCodUsuarioSACNombre, string prm_sCodEjemplar, string prm_sCodEjemplarTitulo, bool? prm_sCodArguEstado, string prm_sCodArguPrestamoEn, bool? prm_bCarnet)
        {
            List<Prestamo> miLista = new List<Prestamo>();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_pro_ListarMovimientosPrestamos(prm_sCodSac, prm_dFechaProcesoINI, prm_dFechaProcesoFIN, prm_sCodUsuarioSAC, prm_sCodUsuarioSACNombre, prm_sCodEjemplar, prm_sCodEjemplarTitulo, prm_sCodArguEstado, prm_sCodArguPrestamoEn, prm_bCarnet);
                    foreach (var item in resul)
                    {
                        miLista.Add(new Prestamo()
                        {
                            sCodPrestamo = item.sCodPrestamo,
                            sCodUsuarioSAC = item.sCodUsuarioSAC,
                            sCodEjemplar = item.sCodEjemplar,
                            sCodSac = item.sCodSac,
                            sCodSacUsuario = item.sCodSacUsuario,
                            dFechaSolicitudReserva = item.dFechaSolicitudReserva,
                            dFechaInicioReserva = item.dFechaInicioReserva,
                            dFechaPrestamo = item.dFechaPrestamo,
                            sCodArguPrestamoEn = item.sCodArguPrestamoEn,
                            bCarnet = item.bCarnet,
                            dFechaDevolucionEstimada = item.dFechaDevolucionEstimada,
                            dFechaDevolucionReal = item.dFechaDevolucionReal,
                            sCodSacDevuelto = item.sCodSacDevuelto,
                            sCodArguPrestamoEnNombre = item.sCodArguPrestamoEnNombre,
                            sCodEjemplarNombreTitulo = item.sCodEjemplarNombreTitulo,
                            sCodSacDevueltoNombre = item.sCodSacDevueltoNombre,
                            sCodSacNombre = item.sCodSacNombre,
                            sCodSacUsuarioNombre = item.sCodSacUsuarioNombre,
                            sCodUsuarioSACNombres = item.sCodSacUsuarioSACNombre,
                            SSIUsuario_Creacion = item.SSIUsuario_Creacion,
                            SSIFechaHora_Creacion = item.SSIFechaHora_Creacion,
                            SSIUsuario_Modificacion = item.SSIUsuario_Modificacion,
                            SSIFechaHora_Modificacion = item.SSIFechaHora_Modificacion,
                            SSIHost = item.SSIHost,
                            sCodEjemplarCodigoItem = item.sCodEjemplarsCodItem,
                            sAbreviaturaSac = item.sAbreviaturaSac,
                            //sEstadoRegistro = item.dFechaSolicitudReserva != null ? "En Reserva" : item.dFechaDevolucionReal == null ? "En Préstamo" : "Devuelto",
                            sEstadoRegistro = item.dFechaSolicitudReserva != null ?
                            (item.dFechaPrestamo != null ?
                            (item.dFechaDevolucionReal != null ? "Reserva/Préstamo/Devolución" : "Reserva/Préstamo") : "Reserva") :
                            (item.dFechaDevolucionReal == null ? "Préstamo" : "Préstamo/Devolución"),
                            bATiempo = item.dFechaDevolucionReal != null ? item.dFechaDevolucionReal <= item.dFechaDevolucionEstimada ? true : false : false
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miLista;
        }

        public List<Prestamo> ListarReservas(string prm_sCodSac, string prm_dFechaProcesoINI, string prm_dFechaProcesoFIN, string prm_sCodUsuarioSAC, string prm_sCodUsuarioSACNombre, string prm_sCodEjemplar, string prm_sCodEjemplarTitulo, bool? prm_sCodArguEstado, string prm_sCodArguPrestamoEn, bool? prm_bCarnet)
        {
            List<Prestamo> miLista = new List<Prestamo>();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    prm_sCodArguPrestamoEn = prm_sCodArguPrestamoEn.Length == 0 ? " " : prm_sCodArguPrestamoEn;
                    var resul = SQLDC.pa_pro_ListarMovimientosReservas(prm_sCodSac, prm_dFechaProcesoINI, prm_dFechaProcesoFIN, prm_sCodUsuarioSAC, prm_sCodUsuarioSACNombre, prm_sCodEjemplar, prm_sCodEjemplarTitulo, prm_sCodArguEstado, prm_bCarnet); //prm_sCodArguPrestamoEn,
                    foreach (var item in resul)
                    {
                        miLista.Add(new Prestamo()
                        {
                            sCodPrestamo = item.sCodPrestamo,
                            sCodUsuarioSAC = item.sCodUsuarioSAC,
                            sCodEjemplar = item.sCodEjemplar,
                            sCodSac = item.sCodSac,
                            sCodSacUsuario = item.sCodSacUsuario,
                            dFechaSolicitudReserva = item.dFechaSolicitudReserva,
                            dFechaInicioReserva = item.dFechaInicioReserva,
                            dFechaPrestamo = item.dFechaPrestamo,
                            sCodArguPrestamoEn = item.sCodArguPrestamoEn,
                            bCarnet = item.bCarnet,
                            dFechaDevolucionEstimada = item.dFechaDevolucionEstimada,
                            dFechaDevolucionReal = item.dFechaDevolucionReal,
                            sCodSacDevuelto = item.sCodSacDevuelto,
                            sCodArguPrestamoEnNombre = item.sCodArguPrestamoEnNombre, //?string.Empty:item.sCodArguPrestamoEnNombre.ToString()
                            sCodEjemplarNombreTitulo = item.sCodEjemplarNombreTitulo,
                            sCodSacDevueltoNombre = item.sCodSacDevueltoNombre,
                            sCodSacNombre = item.sCodSacNombre,
                            sCodSacUsuarioNombre = item.sCodSacUsuarioNombre,
                            sCodUsuarioSACNombres = item.sCodSacUsuarioSACNombre,
                            SSIUsuario_Creacion = item.SSIUsuario_Creacion,
                            SSIFechaHora_Creacion = item.SSIFechaHora_Creacion,
                            SSIUsuario_Modificacion = item.SSIUsuario_Modificacion,
                            SSIFechaHora_Modificacion = item.SSIFechaHora_Modificacion,
                            SSIHost = item.SSIHost,
                            sCodEjemplarCodigoItem = item.sCodEjemplarsCodItem,
                            sAbreviaturaSac = item.sAbreviaturaSac,
                            sEstadoRegistro = item.dFechaSolicitudReserva != null ?
                            (item.dFechaPrestamo != null ?
                            (item.dFechaDevolucionReal != null ? "Reserva/Préstamo/Devolución" : "Reservado/Préstamo") : "Reservado") :
                            (item.dFechaDevolucionReal == null ? "Préstamo" : "Préstamo/Devolución"),
                            bATiempo = item.dFechaDevolucionReal != null ? (item.dFechaDevolucionReal <= item.dFechaDevolucionEstimada ? true : false) : false
                              
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miLista;
        }
        
        public List<Prestamo> ListarDevoluciones(string prm_sCodSac, string prm_dFechaProcesoINI, string prm_dFechaProcesoFIN, string prm_sCodUsuarioSAC, string prm_sCodUsuarioSACNombre, string prm_sCodEjemplar, string prm_sCodEjemplarTitulo, bool? prm_sCodArguEstado, string prm_sCodArguPrestamoEn, bool? prm_bCarnet)
        {
            List<Prestamo> miLista = new List<Prestamo>();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_pro_ListarMovimientosDevoluciones(prm_sCodSac, prm_dFechaProcesoINI, prm_dFechaProcesoFIN, prm_sCodUsuarioSAC, prm_sCodUsuarioSACNombre, prm_sCodEjemplar, prm_sCodEjemplarTitulo, prm_sCodArguEstado, prm_sCodArguPrestamoEn, prm_bCarnet);
                    foreach (var item in resul)
                    {
                        miLista.Add(new Prestamo()
                        {
                            sCodPrestamo = item.sCodPrestamo,
                            sCodUsuarioSAC = item.sCodUsuarioSAC,
                            sCodEjemplar = item.sCodEjemplar,
                            sCodSac = item.sCodSac,
                            sCodSacUsuario = item.sCodSacUsuario,
                            dFechaSolicitudReserva = item.dFechaSolicitudReserva,
                            dFechaInicioReserva = item.dFechaInicioReserva,
                            dFechaPrestamo = item.dFechaPrestamo,
                            sCodArguPrestamoEn = item.sCodArguPrestamoEn,
                            bCarnet = item.bCarnet,
                            dFechaDevolucionEstimada = item.dFechaDevolucionEstimada,
                            dFechaDevolucionReal = item.dFechaDevolucionReal,
                            sCodSacDevuelto = item.sCodSacDevuelto,
                            sCodArguPrestamoEnNombre = item.sCodArguPrestamoEnNombre,
                            sCodEjemplarNombreTitulo = item.sCodEjemplarNombreTitulo,
                            sCodSacDevueltoNombre = item.sCodSacDevueltoNombre,
                            sCodSacNombre = item.sCodSacNombre,
                            sCodSacUsuarioNombre = item.sCodSacUsuarioNombre,
                            sCodUsuarioSACNombres = item.sCodSacUsuarioSACNombre,
                            SSIUsuario_Creacion = item.SSIUsuario_Creacion,
                            SSIFechaHora_Creacion = item.SSIFechaHora_Creacion,
                            SSIUsuario_Modificacion = item.SSIUsuario_Modificacion,
                            SSIFechaHora_Modificacion = item.SSIFechaHora_Modificacion,
                            SSIHost = item.SSIHost,
                            sCodEjemplarCodigoItem = item.sCodEjemplarsCodItem,
                            sAbreviaturaSac = item.sAbreviaturaSac,
                            sEstadoRegistro = item.dFechaSolicitudReserva != null ?
                            (item.dFechaPrestamo != null ?
                            (item.dFechaDevolucionReal != null ? "Reserva/Préstamo/Devolución" : "Reservado/Préstamo") : "Reservado") :
                            (item.dFechaDevolucionReal == null ? "Préstamo" : "Préstamo/Devolución"),
                            bATiempo = item.dFechaDevolucionReal != null ? item.dFechaDevolucionReal <= item.dFechaDevolucionEstimada ? true : false : false
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miLista;
        }

        public List<Prestamo> ListarSinDevoluciones(string prm_sCodSac, string prm_dFechaProcesoINI, string prm_dFechaProcesoFIN, string prm_sCodUsuarioSAC, string prm_sCodUsuarioSACNombre, string prm_sCodEjemplar, string prm_sCodEjemplarTitulo, bool? prm_sCodArguEstado, string prm_sCodArguPrestamoEn, bool? prm_bCarnet)
        {
            List<Prestamo> miLista = new List<Prestamo>();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_pro_ListarMovimientosSinDevoluciones(prm_sCodSac, prm_dFechaProcesoINI, prm_dFechaProcesoFIN, prm_sCodUsuarioSAC, prm_sCodUsuarioSACNombre, prm_sCodEjemplar, prm_sCodEjemplarTitulo, prm_sCodArguEstado, prm_sCodArguPrestamoEn, prm_bCarnet);
                    foreach (var item in resul)
                    {
                        miLista.Add(new Prestamo()
                        {
                            sCodPrestamo = item.sCodPrestamo,
                            sCodUsuarioSAC = item.sCodUsuarioSAC,
                            sCodEjemplar = item.sCodEjemplar,
                            sCodSac = item.sCodSac,
                            sCodSacUsuario = item.sCodSacUsuario,
                            dFechaSolicitudReserva = item.dFechaSolicitudReserva,
                            dFechaInicioReserva = item.dFechaInicioReserva,
                            dFechaPrestamo = item.dFechaPrestamo,
                            sCodArguPrestamoEn = item.sCodArguPrestamoEn,
                            bCarnet = item.bCarnet,
                            dFechaDevolucionEstimada = item.dFechaDevolucionEstimada,
                            dFechaDevolucionReal = item.dFechaDevolucionReal,
                            sCodSacDevuelto = item.sCodSacDevuelto,
                            sCodArguPrestamoEnNombre = item.sCodArguPrestamoEnNombre,
                            sCodEjemplarNombreTitulo = item.sCodEjemplarNombreTitulo,
                            sCodSacDevueltoNombre = item.sCodSacDevueltoNombre,
                            sCodSacNombre = item.sCodSacNombre,
                            sCodSacUsuarioNombre = item.sCodSacUsuarioNombre,
                            sCodUsuarioSACNombres = item.sCodSacUsuarioSACNombre,
                            SSIUsuario_Creacion = item.SSIUsuario_Creacion,
                            SSIFechaHora_Creacion = item.SSIFechaHora_Creacion,
                            SSIUsuario_Modificacion = item.SSIUsuario_Modificacion,
                            SSIFechaHora_Modificacion = item.SSIFechaHora_Modificacion,
                            SSIHost = item.SSIHost,
                            sCodEjemplarCodigoItem = item.sCodEjemplarsCodItem,
                            sAbreviaturaSac = item.sAbreviaturaSac,
                            sEstadoRegistro = item.dFechaSolicitudReserva != null ?
                            (item.dFechaPrestamo != null ?
                            (item.dFechaDevolucionReal != null ? "Reserva/Préstamo/Devolución" : "Reservado/Préstamo") : "Reservado") :
                            (item.dFechaDevolucionReal == null ? "Préstamo" : "Préstamo/Devolución"),
                            bATiempo = item.dFechaDevolucionReal != null ? item.dFechaDevolucionReal <= item.dFechaDevolucionEstimada ? true : false : false
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miLista;
        }

        public List<Prestamo> ListarReservasSolicitadas(string prm_sCodSac, string prm_dFechaProcesoINI, string prm_dFechaProcesoFIN, string prm_sCodUsuarioSAC, string prm_sCodUsuarioSACNombre, string prm_sCodEjemplar, string prm_sCodEjemplarTitulo, bool? prm_sCodArguEstado, string prm_sCodArguPrestamoEn, bool? prm_bCarnet)
        {
            List<Prestamo> miLista = new List<Prestamo>();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    prm_sCodArguPrestamoEn = prm_sCodArguPrestamoEn.Length == 0 ? " " : prm_sCodArguPrestamoEn;
                    var resul = SQLDC.pa_pro_ListarMovimientosReservasSolicitada(prm_sCodSac, prm_dFechaProcesoINI, prm_dFechaProcesoFIN, prm_sCodUsuarioSAC, prm_sCodUsuarioSACNombre, prm_sCodEjemplar, prm_sCodEjemplarTitulo, prm_sCodArguEstado, prm_bCarnet); //prm_sCodArguPrestamoEn,
                    foreach (var item in resul)
                    {
                        miLista.Add(new Prestamo()
                        {
                            sCodPrestamo = item.sCodPrestamo,
                            sCodUsuarioSAC = item.sCodUsuarioSAC,
                            sCodEjemplar = item.sCodEjemplar,
                            sCodSac = item.sCodSac,
                            sCodSacUsuario = item.sCodSacUsuario,
                            dFechaSolicitudReserva = item.dFechaSolicitudReserva,
                            dFechaInicioReserva = item.dFechaInicioReserva,
                            dFechaPrestamo = item.dFechaPrestamo,
                            sCodArguPrestamoEn = item.sCodArguPrestamoEn,
                            bCarnet = item.bCarnet,
                            dFechaDevolucionEstimada = item.dFechaDevolucionEstimada,
                            dFechaDevolucionReal = item.dFechaDevolucionReal,
                            sCodSacDevuelto = item.sCodSacDevuelto,
                            sCodArguPrestamoEnNombre = item.sCodArguPrestamoEnNombre, //?string.Empty:item.sCodArguPrestamoEnNombre.ToString()
                            sCodEjemplarNombreTitulo = item.sCodEjemplarNombreTitulo,
                            sCodSacDevueltoNombre = item.sCodSacDevueltoNombre,
                            sCodSacNombre = item.sCodSacNombre,
                            sCodSacUsuarioNombre = item.sCodSacUsuarioNombre,
                            sCodUsuarioSACNombres = item.sCodSacUsuarioSACNombre,
                            SSIUsuario_Creacion = item.SSIUsuario_Creacion,
                            SSIFechaHora_Creacion = item.SSIFechaHora_Creacion,
                            SSIUsuario_Modificacion = item.SSIUsuario_Modificacion,
                            SSIFechaHora_Modificacion = item.SSIFechaHora_Modificacion,
                            SSIHost = item.SSIHost,
                            sCodEjemplarCodigoItem = item.sCodEjemplarsCodItem,
                            sAbreviaturaSac = item.sAbreviaturaSac,
                            sEstadoRegistro = item.dFechaSolicitudReserva != null ?
                            (item.dFechaPrestamo != null ?
                            (item.dFechaDevolucionReal != null ? "Reservado-Préstamo-Devuelto" : "Reservado-Préstamo") : "Reservado") :
                            (item.dFechaDevolucionReal == null ? "Préstamo" : "Préstamo-Devuelto"),
                            bATiempo = item.dFechaDevolucionReal != null ? (item.dFechaDevolucionReal <= item.dFechaDevolucionEstimada ? true : false) : false

                        });
                    }
                }
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
        /// Retorna una ENTIDAD de registro de la Entidad Sacnet.Prestamo
        /// En la BASE de DATO la Tabla : [Sacnet.Prestamo]
        /// <summary>
        /// <returns>Entidad</returns>
        public Prestamo Buscar(string prm_sCodPrestamo)
        {
            Prestamo miEntidad = new Prestamo();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_mnt_BuscarPrestamo(prm_sCodPrestamo);
                    foreach (var item in resul)
                    {
                        miEntidad = new Prestamo()
                        {
                            sCodPrestamo = item.sCodPrestamo,
                            sCodUsuarioSAC = item.sCodUsuarioSAC,
                            sCodEjemplar = item.sCodEjemplar,
                            sCodSac = item.sCodSac,
                            sCodSacUsuario = item.sCodSacUsuario,
                            dFechaSolicitudReserva = item.dFechaSolicitudReserva,
                            dFechaInicioReserva = item.dFechaInicioReserva,
                            dFechaPrestamo = item.dFechaPrestamo,
                            sCodArguPrestamoEn = item.sCodArguPrestamoEn,
                            bCarnet = item.bCarnet,
                            dFechaDevolucionEstimada = item.dFechaDevolucionEstimada,
                            dFechaDevolucionReal = item.dFechaDevolucionReal,
                            sCodSacDevuelto = item.sCodSacDevuelto,
                            sCodArguPrestamoEnNombre = item.sCodArguPrestamoEnNombre,
                            sCodEjemplarNombreTitulo = item.sCodEjemplarNombreTitulo,
                            sCodSacDevueltoNombre = item.sCodSacDevueltoNombre,
                            sCodSacNombre = item.sCodSacNombre,
                            sCodSacUsuarioNombre = item.sCodSacUsuarioNombre,
                            sCodUsuarioSACNombres = item.sCodSacUsuarioSACNombre,
                            SSIUsuario_Creacion = item.SSIUsuario_Creacion,
                            SSIFechaHora_Creacion = item.SSIFechaHora_Creacion,
                            SSIUsuario_Modificacion = item.SSIUsuario_Modificacion,
                            SSIFechaHora_Modificacion = item.SSIFechaHora_Modificacion,
                            SSIHost = item.SSIHost,
                            sCodEjemplarCodigoItem = item.sCodEjemplarsCodItem,
                            sEstadoRegistro = item.dFechaSolicitudReserva != null ?
                            (item.dFechaPrestamo != null ?
                            (item.dFechaDevolucionReal != null ? "Reservado-Préstamo-Devuelto" : "Reservado-Préstamo") : "Reservado") :
                            (item.dFechaDevolucionReal == null ? "Préstamo" : "Préstamo-Devuelto"),
                            bATiempo = item.dFechaDevolucionReal != null ? item.dFechaDevolucionReal <= item.dFechaDevolucionEstimada ? true : false : false
                        };
                    }
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo Prestamo
        /// En la BASE de DATO la Tabla : [Sacnet.Prestamo]
        /// <summary>
        /// <param name = >itemPrestamo</param>
        public string RegistrarPrestamo(Prestamo itemPrestamo)
        {
            string codigoRetorno = null;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    SQLDC.pa_pro_RegistrarPrestamo(
                        ref codigoRetorno,
                        itemPrestamo.sCodUsuarioSAC,
                        itemPrestamo.sCodEjemplar,
                        itemPrestamo.sCodSac,
                        itemPrestamo.sCodSacUsuario,
                        itemPrestamo.sCodArguPrestamoEn,
                        itemPrestamo.bCarnet,
                        itemPrestamo.dFechaDevolucionEstimada,
                        itemPrestamo.SSIUsuario_Creacion,
                        itemPrestamo.SSIHost,
                        itemPrestamo.sCodPrestamoOrigen,
                        itemPrestamo.bRenovacion);//ELVP:22-09-2011
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno ;
        }

        public string RegistrarReserva(Prestamo itemPrestamo)
        {
            string codigoRetorno = null;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    SQLDC.pa_pro_RegistrarReserva(
                        ref codigoRetorno,
                        itemPrestamo.sCodUsuarioSAC,
                        itemPrestamo.sCodEjemplar,
                        itemPrestamo.sCodSac,
                        itemPrestamo.sCodSacUsuario,
                        itemPrestamo.SSIUsuario_Creacion,
                        itemPrestamo.SSIHost,
                        itemPrestamo.sCodArguPrestamoEn);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Prestamo
        /// En la BASE de DATO la Tabla : [Sacnet.Prestamo]
        /// <summary>
        /// <param name = >itemPrestamo</param>
        public bool RegistrarPrestamoDesdeReserva(Prestamo itemPrestamo)
        {
            int codigoRetorno = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    codigoRetorno = SQLDC.pa_pro_RegistrarPrestamoDesdeReserva(
                        itemPrestamo.sCodPrestamo,
                        itemPrestamo.sCodUsuarioSAC,
                        itemPrestamo.sCodArguPrestamoEn,
                        itemPrestamo.bCarnet,
                        itemPrestamo.dFechaDevolucionEstimada,
                        itemPrestamo.SSIUsuario_Modificacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        public bool RegistrarDevolucion(Prestamo itemPrestamo)
        {
            int codigoRetorno = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    codigoRetorno = SQLDC.pa_pro_RegistrarDevolucion(
                        itemPrestamo.sCodPrestamo,
                        itemPrestamo.sCodUsuarioSAC,
                        itemPrestamo.sCodEjemplar,
                        itemPrestamo.sCodSacDevuelto,
                        itemPrestamo.SSIUsuario_Modificacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        public bool ActivarReservaDePrestamo(string prm_sCodPrestamo)
        {
            int codigoRetorno = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    codigoRetorno = SQLDC.pa_pro_ActivarReservaDePrestamo(prm_sCodPrestamo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        public int DetectarCantidadEjemplarPorUsuarioEnPrestamo(string prm_sCodUsuarioSAC)
        {
            int? CantidadEjemplarPorUsuario = null;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                   SQLDC.pa_pro_DetectarCantidadEjemplarPorUsuarioEnPrestamo(prm_sCodUsuarioSAC,  ref CantidadEjemplarPorUsuario );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return CantidadEjemplarPorUsuario == null ? 0 : Convert.ToInt32(CantidadEjemplarPorUsuario);
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        /// <summary>
        /// ELIMINA un registro de la Entidad Sacnet.Prestamo
        /// En la BASE de DATO la Tabla : [Sacnet.Prestamo]
        /// <summary>
        /// <returns>bool</returns>
        public bool Eliminar(string prm_sCodPrestamo)
        {
            int codigoRetorno = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    codigoRetorno = SQLDC.pa_mnt_EliminarPrestamo(prm_sCodPrestamo);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        #endregion

       
    }
} 
