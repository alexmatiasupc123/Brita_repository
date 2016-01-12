using System;
using System.Collections.Generic;
using System.Configuration;

using Britanico.SacNet.BusinessEntities;

namespace Britanico.SacNet.DataAccess
{
    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 09/02/2011-11:42:42 
    /// Descripcion : Capa de Datos 
    /// Archivo     : [Sacnet.ReservaData.cs]
    /// </summary>
    public class ReservaData
    {
        private string conexion = string.Empty;

        public ReservaData()
        {
            conexion = ConfigurationManager.ConnectionStrings["cnSacNET"].ConnectionString;
        }
       
        #region /* Proceso de SELECT ALL */

        /// <summary>
        /// Retorna un LISTA de registros de la Entidad Sacnet.Prestamo
        /// En la BASE de DATO la Tabla : [Sacnet.Prestamo]
        /// <summary>
        /// <returns>List</returns>
        //public List<Reserva> ListarTodos(string prm_sCodSac, string prm_dFechaProcesoINI, string prm_dFechaProcesoFIN, string prm_sCodUsuarioSAC, string prm_sCodUsuarioSACNombre, string prm_sCodItem, string prm_sCodItemTitulo, bool? prm_bSucedido)
        //{
        //    List<Reserva> miLista = new List<Reserva>();
        //    try
        //    {
        //        using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
        //        {
        //            var resul = SQLDC.pa_mnt_ListarReserva(prm_sCodSac, prm_dFechaProcesoINI, prm_dFechaProcesoFIN, prm_sCodUsuarioSAC, prm_sCodUsuarioSACNombre, prm_sCodItem, prm_sCodItemTitulo,  prm_bSucedido);
        //            foreach (var item in resul)
        //            {
        //                miLista.Add(new Reserva()
        //                {
        //                    sCodReserva = item.sCodReserva,
        //                    bSucedido = item.bSucedido,
        //                    dFechaReserva = item.dFechaReserva,
        //                    sCodPrestamo = item.sCodPrestamo,

        //                    sCodUsuarioSAC = item.sCodUsuarioSAC,
        //                    sCodUsuarioSACNombre = item.sCodUsuarioSACNombre,
        //                    sCodSacUsuario = item.sCodSacUsuario,
                            
        //                    sCodItem = item.sCodItem,
        //                    sCodItemNombreTitulo = item.sCodItemNombreTitulo,
                            
        //                    sCodSac = item.sCodSac,
        //                    sCodSacNombre = item.sCodSacNombre,
                            
        //                    dFechaInicioReserva = item.dFechaInicioReserva,
        //                    SSIUsuario_Creacion = item.SSIUsuario_Creacion,
        //                    SSIFechaHora_Creacion = item.SSIFechaHora_Creacion,
        //                    SSIUsuario_Modificacion = item.SSIUsuario_Modificacion,
        //                    SSIFechaHora_Modificacion = item.SSIFechaHora_Modificacion,
        //                    SSIHost = item.SSIHost,
                            
        //                });
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return miLista;
        //}

        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        /// <summary>
        /// Retorna una ENTIDAD de registro de la Entidad Sacnet.Reserva
        /// En la BASE de DATO la Tabla : [Sacnet.Reserva]
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
        /// Almacena el registro de una ENTIDAD de registro de Tipo Reserva
        /// En la BASE de DATO la Tabla : [Sacnet.Reserva]
        /// <summary>
        /// <param name = >itemReserva</param>
        //public string RegistrarReserva(Reserva itemReserva)
        //{
        //    string codigoRetorno = null;
        //    try
        //    {
        //        using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
        //        {
        //            SQLDC.pa_mnt_RegistrarReserva(
        //                ref codigoRetorno,
        //                itemReserva.sCodSac,
        //                itemReserva.sCodUsuarioSAC,
        //                itemReserva.sCodItem,
        //                itemReserva.sCodSacUsuario,
        //                itemReserva.SSIUsuario_Creacion
        //                );
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return codigoRetorno ;
        //}

        #endregion

        #region /* Proceso de UPDATE RECORD */

        /// <summary>
        /// Almacena el registro de una ENTIDAD de registro de Tipo Reserva
        /// En la BASE de DATO la Tabla : [Sacnet.Reserva]
        /// <summary>
        /// <param name = >itemReserva</param>
        //public bool ActualizarReserva(Reserva itemReserva)
        //{
        //    int codigoRetorno = -1;
        //    try
        //    {
        //        using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
        //        {
        //            codigoRetorno = SQLDC.pa_mnt_ActualizarReservaSucede(
        //                itemReserva.sCodReserva,
        //                itemReserva.sCodPrestamo,
        //                itemReserva.SSIUsuario_Modificacion);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return codigoRetorno == 0 ? true : false;
        //}

        #endregion
       
    }
} 
