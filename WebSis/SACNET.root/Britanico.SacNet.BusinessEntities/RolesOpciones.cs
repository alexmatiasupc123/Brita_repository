using System;

namespace Britanico.SacNet.BusinessEntities
{
    /// <summary>
    /// Archivo     : RolesOpciones.cs
    /// Proyecto    : Britanico.SacNet.BusinessEntities
    /// Creacion    : orlando Carril(Oxinet) 12/10/2009 - REQ:XXX
    /// Fecha       : 12/10/2009
    /// Descripcion : Entidad de negocio
    /// </summary>
    public class RolesOpciones
    {
        #region Entidadest
        public string CodigoRol { get; set; }
        public string CodigoOpcion { get; set; }
        public string CodigoOpcionPadre { get; set; }
        public bool Flag_Ver { get; set; }
        public bool Flag_Eliminar { get; set; }
        public bool Flag_Editar { get; set; }
        public bool Flag_Nuevo { get; set; }
        public Nullable<DateTime> SegFechaRegistro { get; set; }
        public Nullable<DateTime> SegFechaModifica { get; set; }
        public string SegUsuarioRegistro { get; set; }
        public string SegUsuarioModifica { get; set; }
        public string SegMaquina { get; set; }

        public string CodigoRolNombre { get; set; }
        public string CodigoOpcionNombre { get; set; }
        public string CodigoOpcionEnlace { get; set; }
        public string FlagMenu { get; set; }
        public string Tipo { get; set; }
        #endregion

    }
}
