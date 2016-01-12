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
    /// Archivo     : [Sacnet.Prestamo.cs]
    /// </summary>
    public class Prestamo
    {
        public string sCodPrestamo { get; set; }
        public string sCodUsuarioSAC { get; set; }
        public string sCodEjemplar { get; set; }

        public string sCodSac { get; set; }
        public string sCodSacUsuario { get; set; }

        public Nullable<DateTime> dFechaSolicitudReserva { get; set; }
        public Nullable<DateTime> dFechaInicioReserva { get; set; }

        public Nullable<DateTime> dFechaPrestamo { get; set; }
        public string sCodArguPrestamoEn { get; set; }
        public bool bCarnet { get; set; }
        public Nullable<DateTime> dFechaDevolucionEstimada { get; set; }
        public Nullable<DateTime> dFechaDevolucionReal { get; set; }
        public string sCodSacDevuelto { get; set; }

        public string SSIUsuario_Creacion { get; set; }
        public DateTime SSIFechaHora_Creacion { get; set; }
        public string SSIUsuario_Modificacion { get; set; }
        public DateTime SSIFechaHora_Modificacion { get; set; }
        public string SSIHost { get; set; }

        public string sCodUsuarioSACNombres { get; set; }
        public string sCodSacNombre { get; set; }
        public string sCodSacUsuarioNombre { get; set; }
        public string sCodSacDevueltoNombre { get; set; }
        public string sCodEjemplarNombreTitulo { get; set; }
        public string sCodArguPrestamoEnNombre { get; set; }
        public string sCodEjemplarCodigoItem { get; set; }
        public string sEstadoRegistro { get; set; }
        public bool bATiempo { get; set; }

        public string sAbreviaturaSac { get; set; }//ELVP:08-08-2011
        public string sCodPrestamoOrigen { get; set; }//ELVP:22-09-2011
        public bool bRenovacion { get; set; }//ELVP:22-09-2011
    }
} 
