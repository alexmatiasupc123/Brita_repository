using System;
using System.Collections.Generic;
namespace Britanico.SacNet.BusinessEntities {
	//-------------------------------------------------------------------
	//Archivo     : SolicitudTransferencia.cs
	//Proyecto    : Britanico.SacNet.BusinessEntities
	//Creacion    : Luis Chavarria08/07/2010 - REQ:XXX
	//Descripcion : Entidad de Negocio
	//-------------------------------------------------------------------
	public  class SolicitudTransferencia {
		#region Entidadest
		public string sCodTransferencia { get; set; }
        public DateTime dFechaProcesoSolicitud { get; set; }
		public string sCodArguEstadoTransferencia { get; set; }
		public string sUsuarioSolicitante { get; set; }
		public string sCodSacOrigen { get; set; }
		public string sUsuarioSacOrigen { get; set; }
		public DateTime? dFechaProcesoRetiro { get; set; }
		public string sCodSacDestino { get; set; }
		public string sUsuarioSacDestino { get; set; }
		public DateTime? dFechaProcesoIngreso { get; set; }
		public string SSIUsuario_Creacion { get; set; }
		public DateTime SSIFechaHora_Creacion { get; set; }
		public string SSIUsuario_Modificacion { get; set; }
		public DateTime SSIFechaHora_Modificacion { get; set; }
		public string SSIHost { get; set; }
        public List<SolicitudTransferenciaDetalle> ListaDetalleTransferencia { get; set; }
        public string sCodArguNombreEstadoTransferencia { get; set; }
        public string sNombreLocalOrigen { get; set; }
        public string sNombreLocalDestino { get; set; }
		#endregion
		
	}
}
