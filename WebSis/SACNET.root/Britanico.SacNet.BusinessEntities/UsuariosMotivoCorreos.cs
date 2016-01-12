using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Britanico.SacNet.BusinessEntities 
{ 
	/// <summary>
	/// Proyecto    : Modulo de Mantenimiento de : 
	/// Creacion    : CROM - Orlando Carril Ramírez
	/// Fecha       : 09/07/2010-11:33:49 
	/// Descripcion : Capa de Entidades 
	/// Archivo     : [Sacnet.UsuariosMotivoCorreos.cs]
	/// </summary>
	public class UsuariosMotivoCorreos
	{ 
		public  string sCodUsuario { get; set; }
		public  string sCodArguAccionMotivo { get; set; }
		public  string sNombre { get; set; }
		public  string sApellidos { get; set; }
		public  string sCorreoElectronico1 { get; set; }
		public  string sCorreoElectronico2 { get; set; }
		public  string sCodArguCargo { get; set; }
		public  bool bEstado { get; set; }

		public  string SSIUsuario_Creacion { get; set; }
		public  DateTime SSIFechaHora_Creacion { get; set; }
		public  string SSIUsuario_Modificacion { get; set; }
		public  DateTime SSIFechaHora_Modificacion { get; set; }
		public  string SSIHost { get; set; }

        public string sCodArguAccionMotivoNombre { get; set; }
        public string sCodArguCargoNombre { get; set; }
	} 
} 
