using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Britanico.SacNet.BusinessEntities;

namespace Britanico.SacNet.DataAccess
{
    public class ReportesData
    {

        
		public string conexion = string.Empty;
        public ReportesData()
		{
            conexion = ConfigurationManager.ConnectionStrings["cnSacNET"].ConnectionString;
		}

        
        #region " /* Funciones Seleccionar */ "

        /// <summary>
        /// Reportes
        /// <summary>
        /// <returns>List</returns>
        public List<Reportes> RankigTitulos(string pCodSac , string CodTipoMaterial,string FechaInicio , string FechaFin , string TipoMovimiento )
        {
            List<Reportes> Lista = new List<Reportes>();
            try
            {
                using (_ReportesDataContext SQLDC = new _ReportesDataContext(conexion))
                {
                    var resul = SQLDC.pa_rep_RankingTitulos(pCodSac, CodTipoMaterial, FechaInicio, FechaFin, Convert.ToChar(TipoMovimiento));
                    foreach (var item in resul)
                    {
                        Lista.Add(new Reportes()
                        {
                            CodSAC = item.CodSAC,
                            SAC = item.SAC,
                            CodItem = item.CodItem,
                            Item = item.Item,
                            TipoMaterial = item.TipoMaterial,
                            CantEjemplar =item.Ejemplares,
                            CantMovimiento =item.Movimientos

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
        public List<Reportes> TitulosMayorRetraso(string pCodSac, string CodTipoMaterial, string FechaInicio, string FechaFin)
        {
            List<Reportes> Lista = new List<Reportes>();
            try
            {
                using (_ReportesDataContext SQLDC = new _ReportesDataContext(conexion))
                {
                    var resul = SQLDC.pa_rep_TitulosMayorRetraso(pCodSac, CodTipoMaterial, FechaInicio, FechaFin);
                    foreach (var item in resul)
                    {
                        Lista.Add(new Reportes()
                        {
                            CodSAC = item.CodSAC,
                            SAC = item.SAC,
                            CodItem = item.CodItem,
                            Item = item.Item,
                            TipoMaterial = item.TipoMaterial,
                            Retrasos = item.Retrasos,
                            DiasRetrasos = item.DiasRetrasos

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
        public List<Reportes> RankingUsuarios(string pCodSac, string pCodTipoUsuario, string FechaInicio, string FechaFin)
        {
            List<Reportes> Lista = new List<Reportes>();
            try
            {
                using (_ReportesDataContext SQLDC = new _ReportesDataContext(conexion))
                {
                    var resul = SQLDC.pa_rep_RankingUsuarios(pCodSac, pCodTipoUsuario, FechaInicio, FechaFin);
                    foreach (var item in resul)
                    {
                        Lista.Add(new Reportes()
                        {
                            CodSAC = item.CodSAC.Trim(),
                            SAC = item.SAC,
                            TipoUsuario = item.TipoUsuario,
                            CodUsuario = item.CodUsuario,
                            Usuario = item.Usuario,
                            EnSala = item.EnSala,
                            EnDomicilio = item.EnDomicilio,
                            Prestamos = item.Prestamos

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

        public List<Reportes> CarnetsXSAC(string pCodSac, string pCodEstadoCarnet, string FechaInicio, string FechaFin)
        {
            List<Reportes> Lista = new List<Reportes>();
            try
            {
                using (_ReportesDataContext SQLDC = new _ReportesDataContext(conexion))
                {
                    SQLDC.CommandTimeout = 0;
                    var resul = SQLDC.pa_rep_CarnetsXSAC(pCodSac, pCodEstadoCarnet, FechaInicio, FechaFin);
                    
                    foreach (var item in resul)
                    {
                        Lista.Add(new Reportes()
                        {
                            SAC = item.SAC,
                            EstadoCarnet = item.EstadoCarnet,
                            CodUsuario = item.CodUsuario,
                            Usuario = item.Usuario,
                          
                            Curso = item.Curso,
                            Horario = item.Horario,
                            Aula = item.Aula,
                            Subsistema = item.Subsistema

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

        public List<Reportes> MovimientoXPeriodoDetallado(string pCodSac, string FechaInicio, string FechaFin, string TipoMovimiento, string CodTipoMaterial)
        {
            List<Reportes> Lista = new List<Reportes>();
            try
            {
                using (_ReportesDataContext SQLDC = new _ReportesDataContext(conexion))
                {
                    var resul = SQLDC.pa_rep_MovimientoXPeriodoDetallado(pCodSac, CodTipoMaterial,TipoMovimiento, FechaInicio, FechaFin);
                    foreach (var item in resul)
                    {
                        Lista.Add(new Reportes()
                        {
                            CodSAC = item.CodSAC,
                            SAC = item.SAC,                            
                            CodItem = item.CodItem,
                            Item=item.Item,
                            TipoMaterial=item.TipoMaterial,
                            CodEjemplar = item.CodEjemplar,
                            FechaMovimiento = Convert.ToDateTime(item.FechaMovimiento),
                            TipoMovimiento = item.TipoMovimiento,
                            TipoPrestamo = item.PrestamoEn,
                            CodUsuarioSAC = item.CodUsuarioSAC

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
        public List<Reportes> StockXSAC(string pCodSac, string CodTipoMaterial)
        {
            List<Reportes> Lista = new List<Reportes>();
            try
            {
                using (_ReportesDataContext SQLDC = new _ReportesDataContext(conexion))
                {
                    var resul = SQLDC.pa_rep_StockXSAC(pCodSac, CodTipoMaterial);
                    foreach (var item in resul)
                    {
                        Lista.Add(new Reportes()
                        {
                            CodSAC = item.CodSAC,
                            SAC = item.SAC,
                            CodItem = item.CodItem,
                            Item = item.Item,
                            FormatoAdicional = item.FormatoAdicional,
                            Prestados = item.Prestados,
                            Reservados = item.Reservados,
                            Disponibles = item.Disponibles,
                            Asignados = item.Asignados,
                            sCodArguTema = item.sCodArguTema,
                            Tema = item.Tema
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

        public List<Reportes> StockXSACDet(string pCodSac, string CodTipoMaterial)
        {
            List<Reportes> Lista = new List<Reportes>();
            try
            {
                using (_ReportesDataContext SQLDC = new _ReportesDataContext(conexion))
                {
                    var resul = SQLDC.pa_rep_StockXSACDet(pCodSac, CodTipoMaterial);
                    foreach (var item in resul)
                    {
                        Lista.Add(new Reportes()
                        {
                            CodSAC = item.CodSAC,
                            SAC = item.SAC,
                            CodItem = item.CodItem,
                            Item = item.Item,
                            Ejemplar = item.Ejemplar,
                            FormatoAdicional = item.FormatoAdicional,
                            Prestados = item.Prestados,
                            Reservados = item.Reservados,
                            Disponibles = item.Disponibles,
                            Asignados = item.Asignados,
                            sCodArguTema = item.sCodArguTema,
                            Tema = item.Tema
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
    }
}
