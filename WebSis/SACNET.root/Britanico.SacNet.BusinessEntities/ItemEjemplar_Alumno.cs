using System;

namespace Britanico.SacNet.BusinessEntities
{
    //-------------------------------------------------------------------
    //Archivo     : ItemEjemplar_Alumno.cs
    //Proyecto    : Britanico.SacNet.BusinessEntities
    //Creacion    : Eduardo Saldarriaga 14/01/2013 - Altiris #30503
    //Descripcion : Entidad de Negocio
    //-------------------------------------------------------------------

    public class ItemEjemplar_Alumno
    {
        #region Entidadest

        public string sCodItem { get; set; }
        public string sCodEjemplar { get; set; }
        public string sTitulo { get; set; }
        public string sCodSac { get; set; }
        public string sCodSacNombre { get; set; }
        public string sCodArguEstadoEjemplar { get; set; }
        public string sCodArguTipoItem { get; set; }
        public string sEstadoEjemplar { get; set; }

        public string sNombre { get; set; }
        public string sCurso { get; set; }
        public string sHorario { get; set; }
        public string sAula { get; set; }
        public DateTime dFechaDevolucionEstimada { get; set; }

        #endregion

    }

}