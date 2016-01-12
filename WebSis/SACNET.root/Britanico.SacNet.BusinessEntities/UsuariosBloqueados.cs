using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Britanico.SacNet.BusinessEntities
{
    /// <summary>
    /// Proyecto    : Modulo de Mantenimiento de : 
    /// Creacion    : CROM - Orlando Carril Ramírez
    /// Fecha       : 14/07/2010-11:03:41 
    /// Descripcion : Capa de Entidades 
    /// Archivo     : [Sacnet.UsuariosBloqueados.cs]
    /// </summary>
    public class UsuariosBloqueados
    {
        public string sCodRegistro { get; set; }
        public string sCodUsuarioSAC { get; set; }
        public DateTime dFechaBloqueoON { get; set; }
        public DateTime dFechaBloqueoOFF { get; set; }
        public bool bEstado { get; set; }
        public string SSIUsuario_Creacion { get; set; }
        public DateTime SSIFechaHora_Creacion { get; set; }
        public string SSIUsuario_Modificacion { get; set; }
        public DateTime SSIFechaHora_Modificacion { get; set; }
        public string SSIHost { get; set; }

        public string sCodUsuarioSACApellidosNombre { get; set; }
    }
} 
