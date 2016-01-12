using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Britanico.SacNet.BusinessEntities
{
    public class UsuarioSala
    {
        public string sCodRegistro { get; set; }
        public string sCodUsuarioSAC { get; set; }

        public string sUsuarioSACNombre { get; set; }
        public string sApellidos { get; set; }
        public string sNombres { get; set; }

        public string sCodSac { get; set; }
        public string sCodSacNombre { get; set; }
        public string sCodSacUsuario { get; set; }
        public string sCodSacUsuarioNombre { get; set; }

        public Nullable<DateTime> dFechaInicio { get; set; }
        public Nullable<DateTime> dFechaFin { get; set; }
        public Nullable<bool> bSala { get; set; }
        public string sObservaciones { get; set; }

        public string SSIUsuario_Creacion { get; set; }
        public Nullable<DateTime> SSIFechaHora_Creacion { get; set; }
        public string SSIUsuario_Modificacion { get; set; }
        public Nullable<DateTime> SSIFechaHora_Modificacion { get; set; }
        public string SSIHost { get; set; }

        public string sAbreviaturaSacRegistro { get; set; }
        public string sAbreviaturaSacUsuario { get; set; }
    }
} 
