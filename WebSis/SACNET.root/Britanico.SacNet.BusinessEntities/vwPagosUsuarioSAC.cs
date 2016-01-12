using System;

namespace Britanico.SacNet.BusinessEntities
{
    //-------------------------------------------------------------------
    //Archivo     : vwPagosUsuarioSAC.cs
    //Proyecto    : Britanico.SacNet.BusinessEntities
    //Creacion    : Orlando Carril 04/08/2010 - REQ:XXX
    //Descripcion : Entidad de Negocio
    //-------------------------------------------------------------------
    public class vwPagosUsuarioSAC
    {
        #region Entidadest

        public string CodUsuarioSAC { get; set; }
        public string UsuarioRealizoPago { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string EstablecimientoCodigo { get; set; }
        public Nullable<DateTime> FechaFacturacion { get; set; }
        public string EstablecimientoCodigoNombre { get; set; }
        public string TipoDocuNumero { get; set; }
        public string EstablecimientoCodNom { get; set; }
        #endregion

    }
}
