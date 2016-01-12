using System;

namespace Britanico.SacNet.BusinessEntities
{
    /// <summary>
    /// Archivo     : UsuariosRoles.cs
    /// Proyecto    : Britanico.SacNet.BusinessEntities
    /// Creacion    : orlando Carril(Oxinet) 12/10/2009 - REQ:XXX
    /// Fecha       : 12/10/2009
    /// Descripcion : Entidad de negocio
    /// </summary>
    public class UsuariosRoles
    {
        #region Entidadest

        public string CodigoUsuario { get; set; }
        public string CodigoRol { get; set; }
        public bool Estado { get; set; }
        public DateTime SegFechaRegistro { get; set; }
        public DateTime SegFechaModifica { get; set; }
        public string SegUsuarioRegistro { get; set; }
        public string SegUsuarioModifica { get; set; }
        public string SegMaquina { get; set; }

        public string CodigoUsuarioNombre { get; set; }
        public string CodigoRolNombre { get; set; }
        #endregion

    }
}
