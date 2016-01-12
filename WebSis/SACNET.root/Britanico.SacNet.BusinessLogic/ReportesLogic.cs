using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Britanico.SacNet.BusinessEntities;
using Britanico.SacNet.DataAccess;

namespace Britanico.SacNet.BusinessLogic
{
    public class ReportesLogic
    {
        private ReportesData oReportesData = null;
        public ReportesLogic()
		{
            oReportesData = new ReportesData();
		}

        #region " /* Funciones Seleccionar */ "


        public List<Reportes> RankigTitulos(string pCodSac, string pCodTipoMaterial, string pFechaInicio, string pFechaFin, string pTipoMovimiento, int pCantidad ,string pOrder)
        {
            List<Reportes> Lista = new List<Reportes>();
            List<Reportes> ListaOrder = new List<Reportes>();
            try
            {
                Lista = this.oReportesData.RankigTitulos(pCodSac, pCodTipoMaterial, pFechaInicio, pFechaFin, pTipoMovimiento);
                vwDatosVistaLogic ovwDatosVistaLogic = new vwDatosVistaLogic();
             
                if (Lista.Count > 0)
                {
                    if(pOrder == "1")
                    {
                        if (pCodSac == null)
                        {
                            foreach (var itemSAC in ovwDatosVistaLogic.ListarvwLocalesSAC())
                            {
                                ListaOrder.AddRange(Lista.Where(x => x.CodSAC == itemSAC.CodLocalSAC).OrderBy(x => x.CantMovimiento).Take(pCantidad).ToList());
                            }

                        }
                        else 
                        {
                            ListaOrder = Lista.OrderBy(x => x.CantMovimiento).Take(pCantidad).ToList();
                        }
                    }
                    else
                    {
                        if (pCodSac == null)
                        {
                            foreach (var itemSAC in ovwDatosVistaLogic.ListarvwLocalesSAC())
                            {
                                ListaOrder.AddRange(Lista.Where(x => x.CodSAC == itemSAC.CodLocalSAC).OrderByDescending(x => x.CantMovimiento).Take(pCantidad).ToList());
                            }

                        }
                        else
                        {
                            ListaOrder = Lista.OrderByDescending(x => x.CantMovimiento).Take(pCantidad).ToList();
                        }
                    }
                   
                }

               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaOrder;
        }
        
        public List<Reportes> TitulosMayorRetraso(string pCodSac, string pCodTipoMaterial, string pFechaInicio, string pFechaFin,  string pOrder)
        {
            List<Reportes> Lista = new List<Reportes>();
            List<Reportes> ListaOrder = new List<Reportes>();
            try
            {
                Lista = this.oReportesData.TitulosMayorRetraso(pCodSac, pCodTipoMaterial, pFechaInicio, pFechaFin);
                vwDatosVistaLogic ovwDatosVistaLogic = new vwDatosVistaLogic();

                if (Lista.Count > 0)
                {
                    if (pOrder == "1")
                    {
                        if (pCodSac == null)
                        {
                            foreach (var itemSAC in ovwDatosVistaLogic.ListarvwLocalesSAC())
                            {
                                ListaOrder.AddRange(Lista.Where(x => x.CodSAC == itemSAC.CodLocalSAC).OrderBy(x => x.Retrasos).ToList());
                            }

                        }
                        else
                        {
                            ListaOrder = Lista.OrderBy(x => x.Retrasos).ToList();
                        }
                    }
                    else
                    {
                        if (pCodSac == null)
                        {
                            foreach (var itemSAC in ovwDatosVistaLogic.ListarvwLocalesSAC())
                            {
                                ListaOrder.AddRange(Lista.Where(x => x.CodSAC == itemSAC.CodLocalSAC).OrderByDescending(x => x.Retrasos).ToList());
                            }

                        }
                        else
                        {
                            ListaOrder = Lista.OrderByDescending(x => x.Retrasos).ToList();
                        }
                    }

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaOrder;
        }
       
        public List<Reportes> RankingUsuarios(string pCodSac, string pCodTipoUsuario, string pFechaInicio, string pFechaFin, int pCantidad, string pOrder)
        {
            List<Reportes> Lista = new List<Reportes>();
            List<Reportes> ListaOrder = new List<Reportes>();
            try
            {
                Lista = this.oReportesData.RankingUsuarios(pCodSac, pCodTipoUsuario, pFechaInicio, pFechaFin);
                vwDatosVistaLogic ovwDatosVistaLogic = new vwDatosVistaLogic();

                if (Lista.Count > 0)
                {
                    if (pOrder == "1")
                    {
                        if (pCodSac == null)
                        {
                            foreach (var itemSAC in ovwDatosVistaLogic.ListarvwLocalesSAC())
                            {
                                ListaOrder.AddRange(Lista.Where(x => x.CodSAC == itemSAC.CodLocalSAC).OrderBy(x => x.Prestamos).Take(pCantidad).ToList());
                            }

                        }
                        else
                        {
                            ListaOrder = Lista.OrderBy(x => x.Prestamos).Take(pCantidad).ToList();
                        }
                    }
                    else
                    {
                        if (pCodSac == null)
                        {
                            foreach (var itemSAC in ovwDatosVistaLogic.ListarvwLocalesSAC())
                            {
                                ListaOrder.AddRange(Lista.Where(x => x.CodSAC == itemSAC.CodLocalSAC).OrderByDescending(x => x.Prestamos).Take(pCantidad).ToList());
                            }

                        }
                        else
                        {
                            ListaOrder = Lista.OrderByDescending(x => x.Prestamos).Take(pCantidad).ToList();
                        }
                    }

                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaOrder;
        }
       
        public List<Reportes> UsuariosXSacXPeriodo(string pCodSac, string pCodTipoUsuario, string pFechaInicio, string pFechaFin)
        {
            List<Reportes> Lista = new List<Reportes>();
            List<Reportes> ListaOrder = new List<Reportes>();
            try
            {
                Lista = oReportesData.RankingUsuarios(pCodSac, pCodTipoUsuario, pFechaInicio, pFechaFin);
                if (Lista.Count > 0)
                {        
                     ListaOrder = Lista.OrderBy(x => x.Prestamos).ToList();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaOrder;
        }

        public List<Reportes> CarnetsXSAC(string pCodSac, string pCodEstadoCarnet, string pFechaInicio, string pFechaFin)
        {
            List<Reportes> Lista = new List<Reportes>();
            List<Reportes> ListaOrder = new List<Reportes>();
            try
            {
                Lista = oReportesData.CarnetsXSAC(pCodSac, pCodEstadoCarnet, pFechaInicio, pFechaFin);
                if (Lista.Count > 0)
                {
                    ListaOrder = Lista.OrderBy(x => x.CodUsuarioSAC).ToList();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaOrder;
        }
        
        public List<Reportes> MovimientoXPeriodoDetallado(string pCodSac, string pFechaInicio, string pFechaFin, string pTipoMovimiento, string pCodTipoMaterial)
        {
            List<Reportes> Lista = new List<Reportes>();            
            try
            {
                Lista = this.oReportesData.MovimientoXPeriodoDetallado(pCodSac, pFechaInicio, pFechaFin, pTipoMovimiento, pCodTipoMaterial);                

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Lista;
        }

        public List<Reportes> MovimientosXPeriodoConsolidado(string pCodSac, string pCodTipoMaterial, string pFechaInicio, string pFechaFin, string pTipoMovimiento)
        {
            List<Reportes> Lista = new List<Reportes>();
            List<Reportes> ListaOrder = new List<Reportes>();
            try
            {
                Lista = this.oReportesData.RankigTitulos(pCodSac, pCodTipoMaterial, pFechaInicio, pFechaFin, pTipoMovimiento);

                if (Lista.Count > 0)
                {
  
                     ListaOrder = Lista.OrderBy(x => x.CantMovimiento).ToList();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaOrder;
        }

        public List<Reportes> StockXSAC(string pCodSac, string pCodTipoMaterial)
        {
            List<Reportes> Lista = new List<Reportes>();
           
            try
            {
                Lista = this.oReportesData.StockXSAC(pCodSac, pCodTipoMaterial);
 
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Lista;
        }

        public List<Reportes> StockXSACDet(string pCodSac, string pCodTipoMaterial)
        {
            List<Reportes> Lista = new List<Reportes>();

            try
            {
                Lista = this.oReportesData.StockXSACDet(pCodSac, pCodTipoMaterial);

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
