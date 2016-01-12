using System;

namespace Britanico.SacNet.BusinessEntities {
	//-------------------------------------------------------------------
	//Archivo     : SolicitudTransferenciaDetalle.cs
	//Proyecto    : Britanico.SacNet.BusinessEntities
	//Creacion    : Luis Chavarria08/07/2010 - REQ:XXX
	//Descripcion : Entidad de Negocio
	//-------------------------------------------------------------------
	public  class SolicitudTransferenciaDetalle {
		#region Entidadest
		public string sCodTransferencia { get; set; }
		public string sCodEjemplar { get; set; }
		public bool bAprobacionRetiro { get; set; }
		public bool bAprobacionIngreso { get; set; }
		public string SSIUsuario_Creacion { get; set; }
		public DateTime SSIFechaHora_Creacion { get; set; }
		public string SSIUsuario_Modificacion { get; set; }
		public DateTime SSIFechaHora_Modificacion { get; set; }
		public string SSIHost { get; set; }

        public string sCodSac{ get; set; }
        public string sCodSacNombre { get; set; }
        public string sCodItem { get; set; }
        public string sTituloItem { get; set; }
        
		#endregion
		
	}
}
