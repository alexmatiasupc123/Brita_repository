using System;
using System.Collections.Generic;
namespace Britanico.SacNet.BusinessEntities
{
    /// <summary>
    /// Archivo     : Usuarios.cs
    /// Proyecto    : Britanico.SacNet.BusinessEntities
    /// Creacion    : orlando Carril(Oxinet) 12/10/2009 - REQ:XXX
    /// Fecha       : 12/10/2009
    /// Descripcion : Entidad de negocio
    /// </summary>
    public class Usuarios
    {
        #region Entidadest
        public string LoginUsuario { get; set; }
       
        public string PasswordUsuario { get; set; }
        public string ApellidosUsuario { get; set; }
        public string NombresUsuario { get; set; }
        public string CodPersona { get; set; }
        public string ApellidosyNombres { get; set; }
        public string CodigoRol { get; set; }
        public string CodigoRolNombre { get; set; }
        public string TipoUsuario { get; set; } //Alumno o Profesor.
        public List<RolesOpciones> RolOpcionesMenus { get; set; }
        #endregion

    }
}
