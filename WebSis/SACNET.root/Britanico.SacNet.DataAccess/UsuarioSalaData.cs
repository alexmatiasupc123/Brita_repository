using System;
using System.Collections.Generic;
using System.Configuration;

using Britanico.SacNet.BusinessEntities;

namespace Britanico.SacNet.DataAccess
{
    public class UsuarioSalaData
    {
        private string conexion = string.Empty;
        
        public UsuarioSalaData()
        {
            conexion = ConfigurationManager.ConnectionStrings["cnSacNET"].ConnectionString;
        }
       
        #region /* Proceso de SELECT ALL */

        public List<UsuarioSala> ListarTodos(string prm_sCodSac, string prm_dFechaINI, string prm_dFechaFIN, string prm_sCodUsuarioSAC, string prm_sCodUsuarioSACNombre)
        {
            List<UsuarioSala> miLista = new List<UsuarioSala>();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_pro_ListarUsuarioSala(prm_sCodSac, prm_dFechaINI, prm_dFechaFIN, prm_sCodUsuarioSAC, prm_sCodUsuarioSACNombre);
                    foreach (var item in resul)
                    {
                        miLista.Add(new UsuarioSala()
                        {
                            sCodRegistro = item.sCodRegistro,
                            sCodUsuarioSAC = item.sCodUsuarioSAC,
                            sCodSac = item.sCodSac,
                            sCodSacUsuario = item.sCodSacUsuario,
                            dFechaInicio = item.dFechaInicio,
                            dFechaFin = item.dFechaFin,
                            bSala = item.bSala,
                            sObservaciones = item.sObservaciones,
                            sCodSacNombre = item.sCodSacNombre,
                            sCodSacUsuarioNombre = item.sCodSacUsuarioNombre,
                            sUsuarioSACNombre = item.sUsuarioSACNombre,
                            SSIUsuario_Creacion = item.SSIUsuario_Creacion,
                            SSIFechaHora_Creacion = item.SSIFechaHora_Creacion,
                            SSIUsuario_Modificacion = item.SSIUsuario_Modificacion,
                            SSIFechaHora_Modificacion = item.SSIFechaHora_Modificacion,
                            SSIHost = item.SSIHost,
                            sAbreviaturaSacRegistro = item.sAbreviaturaSacRegistro,
                            sAbreviaturaSacUsuario = item.sAbreviaturaSacUsuario
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

        public UsuarioSala BuscarRegistroUsuarioSala(string prm_sCodRegistro)
        {
            UsuarioSala miEntidad = new UsuarioSala();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_pro_BuscarRegistroUsuarioSala(prm_sCodRegistro);
                    foreach (var item in resul)
                    {
                        miEntidad = new UsuarioSala()
                        {
                            sCodRegistro = item.sCodRegistro,
                            sCodUsuarioSAC = item.sCodUsuarioSAC,
                            sApellidos = item.sApellidos,
                            sNombres = item.sNombres,
                            sCodSac = item.sCodSac,
                            sCodSacUsuario = item.sCodSacUsuario,
                            sCodSacNombre = item.sCodSacNombre,
                            sCodSacUsuarioNombre = item.sCodSacUsuarioNombre,
                            dFechaInicio = item.dFechaInicio,
                            dFechaFin = item.dFechaFin,
                            bSala = item.bSala,
                            SSIUsuario_Creacion = item.SSIUsuario_Creacion,
                            SSIFechaHora_Creacion = item.SSIFechaHora_Creacion,
                            SSIUsuario_Modificacion = item.SSIUsuario_Modificacion,
                            SSIFechaHora_Modificacion = item.SSIFechaHora_Modificacion,
                            SSIHost = item.SSIHost,
                            sAbreviaturaSacRegistro = item.sAbreviaturaSacRegistro,
                            sAbreviaturaSacUsuario = item.sAbreviaturaSacUsuario
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

        public UsuarioSala BuscarRegistroUsuarioSala_x_Usuario(string prm_sCodUsuarioSac)
        {
            UsuarioSala miEntidad = new UsuarioSala();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_pro_BuscarRegistroUsuarioSala_x_Usuario(prm_sCodUsuarioSac);
                    foreach (var item in resul)
                    {
                        miEntidad = new UsuarioSala()
                        {
                            sCodRegistro = item.sCodRegistro,
                            sCodUsuarioSAC = item.sCodUsuarioSAC,
                            sApellidos = item.sApellidos,
                            sNombres = item.sNombres,
                            sCodSac = item.sCodSac,
                            sCodSacUsuario = item.sCodSacUsuario,
                            sCodSacNombre = item.sCodSacNombre,
                            sCodSacUsuarioNombre = item.sCodSacUsuarioNombre,
                            dFechaInicio = item.dFechaInicio,
                            dFechaFin = item.dFechaFin,
                            bSala = item.bSala,
                            SSIUsuario_Creacion = item.SSIUsuario_Creacion,
                            SSIFechaHora_Creacion = item.SSIFechaHora_Creacion,
                            SSIUsuario_Modificacion = item.SSIUsuario_Modificacion,
                            SSIFechaHora_Modificacion = item.SSIFechaHora_Modificacion,
                            SSIHost = item.SSIHost,
                            sAbreviaturaSacRegistro = item.sAbreviaturaSacRegistro,
                            sAbreviaturaSacUsuario = item.sAbreviaturaSacUsuario
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

        public string RegistrarUsuarioSala(UsuarioSala item)
        {
            string codigoRetorno = null;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    SQLDC.pa_pro_RegistrarUsuarioSala(
                        ref codigoRetorno,
                        item.sCodUsuarioSAC,
                        item.sCodSac,
                        item.sCodSacUsuario,
                        item.dFechaInicio,
                        item.sObservaciones,
                        item.SSIUsuario_Creacion,
                        item.SSIHost);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno ;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        public bool RegistrarUsuarioSala_Salida(UsuarioSala item)
        {
            int codigoRetorno = -1;
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    codigoRetorno = SQLDC.pa_pro_RegistrarUsuarioSala_Salida(
                        item.sCodRegistro,
                        item.dFechaInicio,
                        item.dFechaFin,
                        item.sObservaciones,
                        item.SSIUsuario_Modificacion);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return codigoRetorno == 0 ? true : false;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        //public bool Eliminar(string prm_sCodPrestamo)
        //{
        //    int codigoRetorno = -1;
        //    try
        //    {
        //        using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
        //        {
        //            codigoRetorno = SQLDC.pa_mnt_EliminarPrestamo(prm_sCodPrestamo);
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
