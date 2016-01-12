using System;
using System.Collections.Generic;
using System.Text;

using Britanico.SacNet.DataAccess;
using Britanico.SacNet.BusinessEntities;

namespace Britanico.SacNet.BusinessLogic
{
    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 09/07/2010-11:33:49 
    /// Descripcion : Capa de Lógica 
    /// Archivo     : [vwDatosVistaLogic.cs]
    /// </summary>
    public class vwDatosVistaLogic
    {
        private vwDatosVistaData ovwDatosVistaData = null;

        public vwDatosVistaLogic()
        {
            ovwDatosVistaData = new  vwDatosVistaData();
        }

        public List<vwCursosUsuarioSAC> ListarvwCursosUsuarioSAC(string p_CodUsuarioSAC)
        {
            List<vwCursosUsuarioSAC> miLista = new List<vwCursosUsuarioSAC>();
            try
            {
                miLista = ovwDatosVistaData.ListarvwCursosUsuarioSAC(p_CodUsuarioSAC);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miLista;
        }

        public List<vwLocalesSAC> ListarvwLocalesSAC()
        {
            List<vwLocalesSAC> miLista = new List<vwLocalesSAC>();
            try
            {
                miLista = ovwDatosVistaData.ListarvwLocalesSAC();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miLista;
        }

        public List<vwUsuariosSAC> Listarvw_UsuariosSAC()
        {
            List<vwUsuariosSAC> miLista = new List<vwUsuariosSAC>();
            try
            {
                miLista = ovwDatosVistaData.Listarvw_UsuariosSAC();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miLista;
        }

        public List<vwPagosUsuarioSAC> Listarvw_PagosUsuarioSAC(string p_CodUsuarioSAC)
        {
            List<vwPagosUsuarioSAC> miLista = new List<vwPagosUsuarioSAC>();
            try
            {
                miLista = ovwDatosVistaData.Listarvw_PagosUsuarioSAC(p_CodUsuarioSAC);
                string xTipDoc = string.Empty;
                string xNumDoc = string.Empty;
                string xCodSac = string.Empty;
                string xNomSac = string.Empty;
                foreach (vwPagosUsuarioSAC xPagos in miLista)
                {
                    xTipDoc = xPagos.TipoDocumento == null ? string.Empty : xPagos.TipoDocumento;
                    xNumDoc = xPagos.NumeroDocumento == null ? string.Empty : xPagos.NumeroDocumento;
                    xPagos.TipoDocuNumero = xTipDoc + " - " + xNumDoc;

                    xCodSac = xPagos.EstablecimientoCodigo == null ? string.Empty : xPagos.EstablecimientoCodigo;
                    xNomSac = xPagos.EstablecimientoCodigoNombre == null ? string.Empty : xPagos.EstablecimientoCodigoNombre;
                    xPagos.EstablecimientoCodNom = xCodSac + " - " + xNomSac;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miLista;
        }

        public vwUsuariosSAC Buscarvw_UsuariosSAC(string prm_CodUsuarioSAC)
        {
            vwUsuariosSAC itemvwUsuariosSAC = new vwUsuariosSAC();
            try
            {
                itemvwUsuariosSAC = ovwDatosVistaData.Buscarvw_UsuariosSAC(prm_CodUsuarioSAC);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return itemvwUsuariosSAC;
        }

    }
}
