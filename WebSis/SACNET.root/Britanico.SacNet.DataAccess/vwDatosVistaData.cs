using System;
using System.Configuration;
using System.Collections.Generic;
using Britanico.SacNet.BusinessEntities ;

namespace Britanico.SacNet.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    public class vwDatosVistaData
    {
        public string conexion = string.Empty;
        
        public vwDatosVistaData()
        {
            conexion = ConfigurationManager.ConnectionStrings["cnSacNET"].ConnectionString;
        }

        #region " /* Funciones Seleccionar */ "

        /// <summary>
        /// Lista todos los Cursos del Usuario del SAC que esta MATRICULADO
        /// <summary>
        /// <returns>List</returns>
        public List<vwCursosUsuarioSAC> ListarvwCursosUsuarioSAC(string p_CodUsuarioSAC)
        {
            List<vwCursosUsuarioSAC> Lista = new List<vwCursosUsuarioSAC>();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_vw_Listarvw_CursosUsuarioSAC(p_CodUsuarioSAC);
                    foreach (var item in resul)
                    {
                        Lista.Add(new vwCursosUsuarioSAC()
                        {
                            Ciclo = item.Ciclo,
                            CodUsuarioSAC = item.CodUsuarioSAC,
                            Cursos = item.Cursos,
                            FechaFinalCiclo = item.FechaFinalCiclo,
                            FechaInicioCiclo = item.FechaInicioCiclo,
                            Horario = item.Horario,
                            EstadoDeCurso = item.EstadoDeCurso,
                            SubSistema = item.SubSistema,
                            Sabado = item.Sabado
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

        /// <summary>
        /// Lista todos los SACS QUE EXISTEN EN EL BRITÁNICO
        /// <summary>
        /// <returns>List</returns>
        public List<vwLocalesSAC> ListarvwLocalesSAC()
        {
            List<vwLocalesSAC> Lista = new List<vwLocalesSAC>();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_vw_Listarvw_LocalesSAC();
                    foreach (var item in resul)
                    {
                        Lista.Add(new vwLocalesSAC()
                        {
                            CodLocalSAC = item.CodLocalSAC.Trim(),
                            DiasPrestamo = item.DiasPrestamo == null ? 0 : Convert.ToInt32(item.DiasPrestamo),
                            NombreLocal = item.NombreLocal
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

        /// <summary>
        /// Lista todos los SACS QUE EXISTEN EN EL BRITÁNICO
        /// <summary>
        /// <returns>List</returns>
        public List<vwUsuariosSAC> Listarvw_UsuariosSAC()
        {
            List<vwUsuariosSAC> Lista = new List<vwUsuariosSAC>();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_vw_Listarvw_UsuariosSAC();
                    foreach (var item in resul)
                    {
                        Lista.Add(new vwUsuariosSAC()
                        {
                            CodLocalSAC = item.CodLocalSAC,
                            Apellidos = item.Apellidos,
                            CodUsuarioSAC = item.CodUsuarioSAC,
                            CorreoElectronico = item.CorreoElectronico,
                            //EsAlumno = item.EsAlumno=="A"?true:false,
                            EsAlumno = item.EsAlumno,//ELVP:11-10-2011
                            EsMatriculado = item.EsMatriculado == "S" ? true : false,
                            FechaFinalClases = item.FechaFinalClases,
                            CodLocalSACNombre = item.CodLocalSACNombre,
                            Nombres = item.Nombres,
                            TieneFotografia = item.TieneFotografia.ToString() == "S" ? true : false
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

        /// <summary>
        /// Lista todos los SACS QUE EXISTEN EN EL BRITÁNICO
        /// <summary>
        /// <returns>List</returns>
        public List<vwPagosUsuarioSAC> Listarvw_PagosUsuarioSAC(string p_CodUsuarioSAC)
        {
            List<vwPagosUsuarioSAC> Lista = new List<vwPagosUsuarioSAC>();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_vw_Listarvw_PagosUsuarioSAC(p_CodUsuarioSAC);
                    foreach (var item in resul)
                    {
                        Lista.Add(new vwPagosUsuarioSAC()
                        {
                            EstablecimientoCodigo = item.EstablecimientoCodigo,
                            CodUsuarioSAC = item.CodUsuarioSAC,
                            NumeroDocumento = item.NumeroDocumento,
                            TipoDocumento = item.TipoDocumento,
                            UsuarioRealizoPago = item.UsuarioRealizoPago,
                            FechaFacturacion = item.FechaFacturacion,
                            EstablecimientoCodigoNombre = item.EstablecimientoCodigoNombre,
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

        /// <summary>
        /// Lista todos los SACS QUE EXISTEN EN EL BRITÁNICO
        /// <summary>
        /// <returns>List</returns>
        public vwUsuariosSAC Buscarvw_UsuariosSAC(string prm_CodUsuarioSAC)
        {
            vwUsuariosSAC itemvwUsuariosSAC = new vwUsuariosSAC();
            try
            {
                using (_SacNetDataContext SQLDC = new _SacNetDataContext(conexion))
                {
                    var resul = SQLDC.pa_vw_Buscarvw_UsuariosSAC(prm_CodUsuarioSAC);
                    foreach (var item in resul)
                    {
                        itemvwUsuariosSAC = new vwUsuariosSAC()
                        {
                            CodLocalSAC = item.CodLocalSAC,
                            Apellidos = item.Apellidos,
                            CodUsuarioSAC = item.CodUsuarioSAC,
                            CorreoElectronico = item.CorreoElectronico,
                            //EsAlumno = item.EsAlumno == "A" ? true : false,
                            EsAlumno = item.EsAlumno,//ELVP:11-10-2011
                            EsMatriculado = item.EsMatriculado == "S" ? true : false,
                            FechaFinalClases = item.FechaFinalClases,
                            CodLocalSACNombre = item.CodLocalSACNombre,
                            Nombres = item.Nombres,
                            TieneFotografia = item.TieneFotografia.ToString() == "S" ? true : false,
                            ApellidosNombres = item.Apellidos + ", " + item.Nombres
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itemvwUsuariosSAC;
        }

        #endregion

    }
}
