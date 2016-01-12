using System;

namespace Britanico.SacNet.BusinessEntities
{
    //-------------------------------------------------------------------
    //Archivo     : ItemTema.cs
    //Proyecto    : Britanico.SacNet.BusinessEntities
    //Creacion    : Luis Chavarria08/07/2010 - REQ:XXX
    //Descripcion : Entidad de Negocio
    //-------------------------------------------------------------------
    public class ItemTema
    {
        #region Entidadest

        public string sCodItem { get; set; }
        public string sCodArguTema { get; set; }
        public string sCodArguNombreTema { get; set; }
        public bool bEstado { get; set; }
        public string SSIUsuario_Creacion { get; set; }
        public DateTime SSIFechaHora_Creacion { get; set; }
        public string SSIUsuario_Modificacion { get; set; }
        public DateTime SSIFechaHora_Modificacion { get; set; }
        public string SSIHost { get; set; }

        #endregion

    }
}
