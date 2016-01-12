using System;

namespace Britanico.SacNet.BusinessEntities {
	//-------------------------------------------------------------------
	//Archivo     : ItemActor.cs
	//Proyecto    : Britanico.SacNet.BusinessEntities
	//Creacion    : Luis Chavarria08/07/2010 - REQ:XXX
	//Descripcion : Entidad de Negocio
	//-------------------------------------------------------------------
	public  class ItemActor {
		#region Entidadest
		public string sCodItem { get; set; }
		public string sCodArguActor { get; set; }
        public string sCodArguNombreActor { get; set; }
		public bool bActivo { get; set; } // A nivel de aplicacion se usa para ver si el registro es nuevo(para registro) o actualizacion Nuevo=true
		public string SSIUsuario_Creacion { get; set; }
		public DateTime SSIFechaHora_Creacion { get; set; }
		public string SSIUsuario_Modificacion { get; set; }
		public DateTime SSIFechaHora_Modificacion { get; set; }
		public string SSIHost { get; set; }
		#endregion
		
	}
}
