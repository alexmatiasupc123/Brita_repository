using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Britanico.SacNet.BusinessEntities
{
    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 14/07/2010-11:03:41 
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Sacnet.SolicitudCarnet.cs]
    /// </summary>
    public class SolicitudCarnet
    {
        public string sCodSolicitud { get; set; }
        public string sCodLocalSACSolicita { get; set; }

        public string sCodUsuarioSAC { get; set; }
        public string sCodLocalSACUsuario { get; set; }
        public string sNombresUsuarioSAC { get; set; }
        public string sApellidosUsuarioSAC { get; set; }

        public DateTime dFechaProceso { get; set; }
        public string sCodArguEstado { get; set; }

        public string sUsuario { get; set; }
        public string sTipoDocumento { get; set; }
        public string sNumeroDocumento { get; set; }
        public string sEstablecimientoCodigo { get; set; }

        public bool bFotografia { get; set; }
        public bool bDuplicado { get; set; }

        public Nullable<DateTime> dFechaSolicitaImpresion { get; set; }
        public Nullable<DateTime> dFechaImpresion { get; set; }
        public Nullable<DateTime> dFechaEntregaSAC { get; set; }
        public Nullable<DateTime> dFechaEntregaUsuario { get; set; }
        public string sUsuarioSolicitaImpresion { get; set; }
        public string sUsuarioImpresion { get; set; }
        public bool bCarnetImpresion { get; set; }
        public string sUsuarioEntregaSAC { get; set; }
        public string sUsuarioEntregaUsuario { get; set; }

        public string SSIUsuario_Creacion { get; set; }
        public DateTime SSIFechaHora_Creacion { get; set; }
        public string SSIUsuario_Modificacion { get; set; }
        public DateTime SSIFechaHora_Modificacion { get; set; }
        public string SSIHost { get; set; }

        public string sCodArguEstadoNombre { get; set; }
        public string sEstablecimientoCodigoNombre { get; set; }
        public string sCodLocalSACSolicitaNombre { get; set; }
        public string sCodLocalSACUsuarioNombre { get; set; }

        public string sApellidosNombresUsuarioSAC { get; set; }
        public int nTotalEmitidos { get; set; }

        public string TipoDocuNumero { get; set; }

        public string sCorreoElectronico { get; set; }//ELVP:15-07-2011
        public string sistemaSubsistema { get; set; }//ELVP:05-10-2011
    }
} 
