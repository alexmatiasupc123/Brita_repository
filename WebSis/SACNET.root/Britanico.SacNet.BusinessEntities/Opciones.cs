using System;

namespace Britanico.SacNet.BusinessEntities
{
    
    /// <summary>
    /// Archivo     : Opciones.cs
    /// Proyecto    : Britanico.Sacnet.BusinessEntities
    /// Creacion    : orlando Carril(Oxinet) 12/10/2009 - REQ:XXX
    /// Fecha       : 12/10/2009
    /// Descripcion : Entidad de negocio
    /// </summary>
	public  class Opciones 
    {
		#region Entidadest
		public string CodigoOpcion { get; set; }
		public string CodigoPadre { get; set; }
		public string Nombre { get; set; }
        public string Enlace { get; set; }
		public string Descripcion { get; set; }
		public string FlagMenu { get; set; }
		public string Estado { get; set; }
		public DateTime SegFechaRegistro { get; set; }
		public DateTime SegFechaModifica { get; set; }
		public string SegUsuarioRegistro { get; set; }
		public string SegUsuarioModifica { get; set; }
		public string SegMaquina { get; set; }
		#endregion
		
	}
}
