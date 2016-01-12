using System;

namespace Britanico.SacNet.BusinessEntities
{

    /// <summary>
    /// Archivo     : Roles.cs
    /// Proyecto    : Britanico.SacNet.BusinessEntities
    /// Creacion    : orlando Carril(Oxinet) 12/10/2009 - REQ:XXX
    /// Fecha       : 12/10/2009
    /// Descripcion : Entidad de negocio
    /// </summary>
	public  class Roles 
    {
		#region Entidadest

		public string CodigoRol { get; set; }
		public string NombreRol { get; set; }
		public string DescripcionRol { get; set; }
        public string Estado { get; set; }
		public DateTime SegFechaRegistro { get; set; }
		public DateTime SegFechaModifica { get; set; }
		public string SegUsuarioRegistro { get; set; }
		public string SegUsuarioModifica { get; set; }
		public string SegMaquina { get; set; }
        public bool TodosLosCentros { get; set; }
        #endregion
		
	}
}
