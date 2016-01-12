using System;

namespace Britanico.SacNet.BusinessEntities
{
    //-------------------------------------------------------------------
    //Archivo     : vwUsuariosSAC.cs
    //Proyecto    : Britanico.SacNet.BusinessEntities
    //Creacion    : Orlando Carril 08/07/2010 - REQ:XXX
    //Descripcion : Entidad de Negocio
    //-------------------------------------------------------------------
    public class vwUsuariosSAC
    {
        #region Entidadest

        public string CodUsuarioSAC { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string CorreoElectronico { get; set; }
        public string CodLocalSAC { get; set; }
        public string CodLocalSACNombre { get; set; }
        public bool TieneFotografia { get; set; }
        public Nullable<DateTime> FechaFinalClases { get; set; }
        //public bool EsAlumno { get; set; }
        public string EsAlumno { get; set; }//ELVP:11-10-2011
        public bool EsMatriculado { get; set; }

        public string ApellidosNombres { get; set; }
        #endregion

    }
}
