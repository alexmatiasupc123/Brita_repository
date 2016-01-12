using System;
using System.Configuration;
using System.Collections.Generic;
using Britanico.SacNet.BusinessEntities ;

namespace Britanico.SacNet.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    public class ItemEjemplarData
    {
        public string conexion = string.Empty;
        public ItemEjemplarData()
        {
            conexion = ConfigurationManager.ConnectionStrings["cnSacNET"].ConnectionString;
        }

        #region " /* Funciones Insertar */ "

        /// <summary>
        /// Ingresa un registro en la tabla ItemEjemplar
        /// </summary>
        /// <param name="pItem"></param>
        public bool Registrar(ItemEjemplar pItem)
        {
            int lnAfectados = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    lnAfectados = SQLDC.pa_mnt_RegistrarItemEjemplar(
                        pItem.sCodItem,
                        pItem.sCodEjemplar,
                        pItem.sCodSac,
                        pItem.sNotas,
                        pItem.sCodArguEstadoEjemplar == string.Empty ? null : pItem.sCodArguEstadoEjemplar,
                        pItem.bReservado,
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
        /// Buscar un regitro de la tabla ItemEjemplar segun su pk enviado por parametro
        /// </summary>
        /// <returns>Item</returns>
        public ItemEjemplar Buscar(string sCodEjemplar)
        {
            ItemEjemplar Item = new ItemEjemplar();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_mnt_BuscarItemEjemplar(sCodEjemplar);
                    foreach (var item in resul)
                    {
                        Item = new ItemEjemplar()
                        {
                            sCodItem = item.sCodItem,
                            sCodEjemplar = item.sCodEjemplar,
                            sCodSac = item.sCodSac,
                            sNotas = item.sNotas,
                            sCodArguEstadoEjemplar = item.sCodArguEstadoEjemplar,
                            bReservado = item.bReservado,
                            SSIUsuario_Creacion = item.SSIUsuario_Creacion,
                            SSIFechaHora_Creacion = item.SSIFechaHora_Creacion,
                            SSIUsuario_Modificacion = item.SSIUsuario_Modificacion,
                            SSIFechaHora_Modificacion = item.SSIFechaHora_Modificacion,
                            SSIHost = item.SSIHost,
                            sCodArguNombreEstadoEjemplar = item.sCodArguEstadoEjemplarNombre,
                            dFechaAsignaSAC = item.dFechaAsignaSAC
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

        public ItemEjemplar Buscar(string prm_sCodEjemplar, string prm_sCodSac)
        {
            ItemEjemplar Item = new ItemEjemplar();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_pro_BuscarItemEjemplarEnSAC(prm_sCodEjemplar, prm_sCodSac);
                    foreach (var item in resul)
                    {
                        Item = new ItemEjemplar()
                        {
                            sCodItem = item.sCodItem,
                            sCodEjemplar = item.sCodEjemplar,
                            sCodSac = item.sCodSac,
                            sNotas = item.sNotas,
                            sCodArguEstadoEjemplar = item.sCodArguEstadoEjemplar,
                            bReservado = item.bReservado,
                            SSIUsuario_Creacion = item.SSIUsuario_Creacion,
                            SSIFechaHora_Creacion = item.SSIFechaHora_Creacion,
                            SSIUsuario_Modificacion = item.SSIUsuario_Modificacion,
                            SSIFechaHora_Modificacion = item.SSIFechaHora_Modificacion,
                            SSIHost = item.SSIHost,
                            sCodArguNombreEstadoEjemplar = item.sCodArguEstadoEjemplarNombre,
                            dFechaAsignaSAC = item.dFechaAsignaSAC
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

        public List<ItemEjemplar> BuscarXItem(string prm_sCodItem, string prm_sCodSac)
        {
            List<ItemEjemplar> ListaEjemplares = new List<ItemEjemplar>();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_pro_BuscarEjemplarPorItem(prm_sCodItem, prm_sCodSac);
                    foreach (var itemEjemplar in resul)
                    {
                        ListaEjemplares.Add(new ItemEjemplar()
                        {
                            sCodItem = itemEjemplar.sCodItem,
                            sCodEjemplar = itemEjemplar.sCodEjemplar,
                            sCodSac = itemEjemplar.sCodSac,
                            sCodSacNombre = itemEjemplar.NombreLocal,
                            sNotas = itemEjemplar.sNotas,
                            dFechaPrestamo = itemEjemplar.dFechaPrestamo,
                            dFechaDevolucionEstimada = itemEjemplar.dFechaDevolucionEstimada,
                            sCodArguNombreEstadoEjemplar = itemEjemplar.sCodArguNombreEstadoEjemplar,
                            sCodEjemplarTitulo = itemEjemplar.sCodEjemplarTitulo,
                            sCodArguEstadoEjemplar = itemEjemplar.sCodArguEstadoEjemplar,
                            bReservado = itemEjemplar.bReservado,
                            SSIFechaHora_Creacion = itemEjemplar.SSIFechaHora_Creacion,
                            SSIFechaHora_Modificacion = itemEjemplar.SSIFechaHora_Modificacion,
                            SSIHost = itemEjemplar.SSIHost,
                            SSIUsuario_Creacion = itemEjemplar.SSIUsuario_Creacion,
                            SSIUsuario_Modificacion = itemEjemplar.SSIUsuario_Modificacion,
                            dFechaAsignaSAC = itemEjemplar.dFechaAsignaSAC
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaEjemplares;
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
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_mnt_Listar_ItemEjemplar(pCodItem, pCodSac, pEstado);
                    foreach (var item in resul)
                    {
                        Lista.Add(new ItemEjemplar()
                        {
                            sCodItem = item.sCodItem,
                            sCodEjemplar = item.sCodEjemplar,
                            sCodSac = item.sCodSac,
                            sCodSacNombre = item.NombreLocal,
                            sNotas = item.sNotas,
                            sCodArguEstadoEjemplar = item.sCodArguEstadoEjemplar,
                            sCodArguNombreEstadoEjemplar = item.CodArguNombreEstadoEjemplar,
                            bReservado = item.bReservado,
                            sEstadoReg = false,
                            SSIUsuario_Creacion = item.SSIUsuario_Creacion,
                            SSIFechaHora_Creacion = item.SSIFechaHora_Creacion,
                            SSIUsuario_Modificacion = item.SSIUsuario_Modificacion,
                            SSIFechaHora_Modificacion = item.SSIFechaHora_Modificacion,
                            SSIHost = item.SSIHost,
                            dFechaAsignaSAC = item.dFechaAsignaSAC

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

        //***CGA 17-09-2012***
        //Saca una lista de ejemplares para mostrar en el menú Lista Ejemplares
        public List<ItemEjemplar1> ListarEjemplar(string pCodItem, string pCodArguTipoItem, string pCodSac, string pTitulo, string pCodArguAutor, string pISBN, string pISSN, string pCodArguTema, string pCodArguEstadoEjemplar, string pCodEjemplar)
        {
            List<ItemEjemplar1> Lista = new List<ItemEjemplar1>();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_pro_Listar_Ejemplares(pCodItem, pCodArguTipoItem, pCodSac, pTitulo, pCodArguAutor, pISBN, pISSN, pCodArguTema, pCodArguEstadoEjemplar, pCodEjemplar);
                    foreach (var item in resul)
                    {
                        Lista.Add(new ItemEjemplar1()
                        {
                            sCodItem = item.sCodItem,
                            sTitulo = item.sTitulo,
                            sCodArguTipoItem = item.sCodArguTipoItem,
                            sCodSac = item.sCodSac,
                            sCodSacNombre = item.sCodSacNombre,
                            sCodEjemplar = item.sCodEjemplar,
                            sCodArguEstadoEjemplar = item.sCodArguEstadoEjemplar,
                            sEstadoEjemplar = item.sEstadoEjemplar
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
        //******--

        //ESALDARRIAGA 14/01/2012

        public List<ItemEjemplar_Alumno> ListarEjemplar_Alumno(string pCodItem, string pCodArguTipoItem, string pCodSac, string pTitulo, string pCodArguAutor, string pISBN, string pISSN, string pCodArguTema, string pCodArguEstadoEjemplar, string pCodEjemplar)
        { 
            List<ItemEjemplar_Alumno> Lista = new List<ItemEjemplar_Alumno>();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_pro_Listar_Ejemplares_Usuario(pCodItem, pCodArguTipoItem, pCodSac, pTitulo, pCodArguAutor, pISBN, pISSN, pCodArguTema, pCodArguEstadoEjemplar, pCodEjemplar);
                    foreach (var item in resul)
                    {
                        Lista.Add(new ItemEjemplar_Alumno()
                        {
                            sCodItem = item.sCodItem,
                            sTitulo = item.sTitulo,
                            sCodArguTipoItem = item.sCodArguTipoItem,
                            sCodSac = item.sCodSac,
                            sCodSacNombre = item.sCodSacNombre,
                            sCodEjemplar = item.sCodEjemplar,
                            sCodArguEstadoEjemplar = item.sCodArguEstadoEjemplar,
                            sEstadoEjemplar = item.sEstadoEjemplar,
                            sNombre = item.sNombre,
                            sCurso = item.sCurso,
                            sAula = item.sAula,
                            sHorario = item.sHorario,
                            dFechaDevolucionEstimada = Convert.ToDateTime(item.dFechaDevolucionEstimada)
                            
                        });
                    }
                }
            }
            catch (Exception ex)
            { throw ex; }
            return Lista;
        }

        // FIN ESALDARRIAGA 14/01/2012

        public List<ItemEjemplar> Listar_A_DarAlta(string pCodItem, string pCodSac)
        {
            List<ItemEjemplar> Lista = new List<ItemEjemplar>();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_mnt_Listar_ItemEjemplar_DarAlta(pCodItem, pCodSac);
                    foreach (var item in resul)
                    {
                        Lista.Add(new ItemEjemplar()
                        {
                            sCodItem = item.sCodItem,
                            sCodEjemplar = item.sCodEjemplar,
                            sCodSac = item.sCodSac,
                            sCodSacNombre = item.NombreLocal,
                            sNotas = item.sNotas,
                            sCodArguEstadoEjemplar = item.sCodArguEstadoEjemplar,
                            sCodArguNombreEstadoEjemplar = item.CodArguNombreEstadoEjemplar,
                            bReservado = item.bReservado,
                            sEstadoReg = false,
                            SSIUsuario_Creacion = item.SSIUsuario_Creacion,
                            SSIFechaHora_Creacion = item.SSIFechaHora_Creacion,
                            SSIUsuario_Modificacion = item.SSIUsuario_Modificacion,
                            SSIFechaHora_Modificacion = item.SSIFechaHora_Modificacion,
                            SSIHost = item.SSIHost,
                            dFechaAsignaSAC = item.dFechaAsignaSAC
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
        public List<ItemEjemplar> Listar_A_DarBaja(string pCodItem, string pCodSac,string pCodArguEstadoABuscar)
        {
            List<ItemEjemplar> Lista = new List<ItemEjemplar>();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_mnt_Listar_ItemEjemplar_DarBaja(pCodItem, pCodSac, pCodArguEstadoABuscar);
                    foreach (var item in resul)
                    {
                        Lista.Add(new ItemEjemplar()
                        {
                            sCodItem = item.sCodItem,
                            sCodEjemplar = item.sCodEjemplar,
                            sCodSac = item.sCodSac,
                            sCodSacNombre = item.NombreLocal,
                            sNotas = item.sNotas,
                            sCodArguEstadoEjemplar = item.sCodArguEstadoEjemplar,
                            sCodArguNombreEstadoEjemplar = item.CodArguNombreEstadoEjemplar,
                            bReservado = item.bReservado,
                            sEstadoReg = false,
                            SSIUsuario_Creacion = item.SSIUsuario_Creacion,
                            SSIFechaHora_Creacion = item.SSIFechaHora_Creacion,
                            SSIUsuario_Modificacion = item.SSIUsuario_Modificacion,
                            SSIFechaHora_Modificacion = item.SSIFechaHora_Modificacion,
                            SSIHost = item.SSIHost,
                            dFechaAsignaSAC = item.dFechaAsignaSAC
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
        /// Modificar los registros de la tabla ItemEjemplar que cumplan con los parametros de busqueda embiados
        /// </summary>
        /// <param name="pItem"></param>
        /// <returns></returns>
        public bool Actualizar(ItemEjemplar pItem)
        {
            int lnAfectados = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    lnAfectados = SQLDC.pa_mnt_ActualizarItemEjemplar(
                        pItem.sCodItem,
                        pItem.sCodEjemplar,
                        pItem.sCodSac,
                        pItem.sNotas,
                        pItem.sCodArguEstadoEjemplar == string.Empty ? null : pItem.sCodArguEstadoEjemplar,
                        pItem.bReservado,
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
        public bool Eliminar(string sCodEjemplar)
        {
            int lnAfectados = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {

                    lnAfectados = SQLDC.pa_mnt_EliminarItemEjemplar(sCodEjemplar);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lnAfectados == 0 ? true : false;
        }
        #endregion

        public bool DetectarEjemplarEnPrestamo(string prm_sCodEjemplar, ref string prmsCodPrestamo)
        {
            int codigoRetorno = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_pro_DetectarEjemplarEnPrestamo(prm_sCodEjemplar);
                    foreach (var item in resul)
                    {
                        codigoRetorno = item.SiEstaPrestado == null ? 0 : Convert.ToInt32(item.SiEstaPrestado);
                        prmsCodPrestamo = item.sCodPrestamo;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? false : true;
        }

        public bool DetectarEjemplarEnReserva(string prm_sCodEjemplar, ref string prmsCodPrestamo)
        {
            int codigoRetorno = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    int CONTADOR = 0;
                    var resul = SQLDC.pa_pro_DetectarEjemplarEnReserva(prm_sCodEjemplar);
                    foreach (var item in resul)
                    {
                        codigoRetorno = item.SiEstaReserva == null ? 0 : Convert.ToInt32(item.SiEstaReserva);
                        prmsCodPrestamo = item.sCodPrestamo;
                        ++CONTADOR;
                    }
                    if (CONTADOR == 0)
                        codigoRetorno = 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? false : true;
        }
        
        public bool DetectarUsuarioEnDevolucionPendiente(string prm_sCodUsuarioSAC, ref string prmsCodPrestamo)
        {
            int codigoRetorno = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_pro_DetectarUsuarioEnDevolucionPendiente(prm_sCodUsuarioSAC);
                    foreach (var item in resul)
                    {
                        codigoRetorno = item.SiEstaPendiente == null ? 0 : Convert.ToInt32(item.SiEstaPendiente);
                        prmsCodPrestamo = item.sCodPrestamo;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? false : true;
        }

        public List<Prestamo> DetectarUsuarioEnDevolucionPendienteV2(string prm_sCodUsuarioSAC)
        { 
            List<Prestamo> prmlstPrestamos = new List<Prestamo>();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion)) 
                {
                    Prestamo xPrestamo;
                    var resul = SQLDC.pa_pro_DetectarUsuarioEnDevolucionPendienteV2(prm_sCodUsuarioSAC);
                    foreach (var item in resul)
                    {
                        xPrestamo = new Prestamo
                        {
                            sCodArguPrestamoEn = item.sCodArguPrestamoEn,
                            sCodArguPrestamoEnNombre = item.sCodArguPrestamoEnNombre,
                            dFechaDevolucionEstimada = item.dFechaDevolucionEstimada,
                            sCodEjemplar = item.sCodEjemplar,
                            sCodPrestamo = item.sCodPrestamo,
                            sCodUsuarioSAC = item.sCodUsuarioSAC,
                        };
                        prmlstPrestamos.Add(xPrestamo);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return prmlstPrestamos;
        }

        public bool DetectarUsuarioEnReservaPendiente(string prm_sCodUsuarioSAC, ref string prmsCodPrestamo)
        {
            int codigoRetorno = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_pro_DetectarUsuarioEnReservaPendiente(prm_sCodUsuarioSAC);
                    foreach (var item in resul)
                    {
                        codigoRetorno = item.SiEstaPendiente == null ? 0 : Convert.ToInt32(item.SiEstaPendiente);
                        prmsCodPrestamo = item.sCodPrestamo;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? false : codigoRetorno == -1 ? false : true;
        }
 
        public bool DetectarExisteEjemplar(string prm_sCodEjemplar)
        {
            int codigoRetorno = -1;
            bool? pValor=false;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    codigoRetorno = SQLDC.pa_pro_DetectarExisteEjemplar(prm_sCodEjemplar, ref pValor);
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Convert.ToBoolean(pValor);
        }

        public bool Actualizar_EstadoEjemplar(string prm_sCodEjemplar, string p_sCodArguEstadoEjemplar, string p_SSIUsuario_Modificacion)
        {
            int codigoRetorno = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    codigoRetorno = SQLDC.pa_pro_Actualizar_EstadoEjemplar(prm_sCodEjemplar, p_sCodArguEstadoEjemplar, p_SSIUsuario_Modificacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }
 
        public bool Actualizar_Ejemplar_DarAlta(string prm_sCodEjemplar, string prm_sCodSac, string p_sCodArguEstadoEjemplar, string p_SSIUsuario_Modificacion)
        {
            int codigoRetorno = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    codigoRetorno = SQLDC.pa_pro_Actualizar_Ejemplar_DarAlta(prm_sCodEjemplar, prm_sCodSac, p_sCodArguEstadoEjemplar, p_SSIUsuario_Modificacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        public bool Actualizar_Ejemplar_DarBaja(string prm_sCodEjemplar,string p_sCodArguEstadoEjemplar, string p_SSIUsuario_Modificacion)
 
       {
            int codigoRetorno = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    codigoRetorno = SQLDC.pa_pro_Actualizar_Ejemplar_DarBaja(prm_sCodEjemplar,p_sCodArguEstadoEjemplar, p_SSIUsuario_Modificacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }
    
        public bool Actualizar_EstadoEjemplarReserv(string prm_sCodEjemplar, bool p_bReservado, string p_SSIUsuario_Modificacion)
        {
            int codigoRetorno = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    codigoRetorno = SQLDC.pa_pro_Actualizar_EstadoEjemplarRSV(prm_sCodEjemplar, p_SSIUsuario_Modificacion, p_bReservado);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }
     
        public bool Actualizar_EstadoEjemplarReservDisp(string prm_sCodEjemplar, string p_sCodArguEstadoEjemplar, bool p_bReservado, string p_SSIUsuario_Modificacion)
        {
            int codigoRetorno = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    codigoRetorno = SQLDC.pa_pro_Actualizar_EstadoEjemplarRSV_DISP(prm_sCodEjemplar,p_sCodArguEstadoEjemplar, p_SSIUsuario_Modificacion, p_bReservado);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        public bool Actualizar_ReservarEjemplar(string prm_sCodEjemplar, bool p_bReservado, string p_SSIUsuario_Modificacion)
        {
            int codigoRetorno = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    codigoRetorno = SQLDC.pa_pro_ReservarItemEjemplar(prm_sCodEjemplar, p_bReservado, p_SSIUsuario_Modificacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }
 
        public bool Actualizar_SacEjemplar(string prm_sCodEjemplar, string p_sCodSac, string p_SSIUsuario_Modificacion)
        {
            int codigoRetorno = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    codigoRetorno = SQLDC.pa_pro_Actualizar_SAC_Ejemplar(prm_sCodEjemplar,p_sCodSac, p_SSIUsuario_Modificacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }
    }
}
