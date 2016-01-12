using System;

namespace Britanico.SacNet.BusinessEntities
{
    //-------------------------------------------------------------------
    //Archivo     : ItemEjemplar.cs
    //Proyecto    : Britanico.SacNet.BusinessEntities
    //Creacion    : Carlos Gaitán 17/09/2012 - Altiris #29833
    //Descripcion : Entidad de Negocio
    //-------------------------------------------------------------------
    public class ItemEjemplar1
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

        #endregion

    }
}
