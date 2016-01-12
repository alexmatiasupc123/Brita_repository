using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Britanico.SacNet.BusinessEntities
{
    /// <summary>
    /// Proyecto    :  Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 10/02/2011-11:34:41 
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Sacnet.Reserva.cs]
    /// </summary>
    public class Reserva
    {
        public string sCodReserva { get; set; }
        public string sCodSac { get; set; }
        public DateTime dFechaReserva { get; set; }
        public string sCodUsuarioSAC { get; set; }
        public string sCodItem { get; set; }
        public string sCodSacUsuario { get; set; }
        public string sCodPrestamo { get; set; }
        public bool bSucedido { get; set; }
        public Nullable<DateTime> dFechaInicioReserva { get; set; }
        
        public string SSIUsuario_Creacion { get; set; }
        public DateTime SSIFechaHora_Creacion { get; set; }
        public string SSIUsuario_Modificacion { get; set; }
        public DateTime SSIFechaHora_Modificacion { get; set; }
        public string SSIHost { get; set; }

        public string sCodUsuarioSACNombre { get; set; }
        public string sCodSacNombre { get; set; }
        public string sCodItemNombreTitulo { get; set; }
       
    }
} 
