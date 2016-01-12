using System;

namespace Britanico.SacNet.BusinessEntities
{
    //-------------------------------------------------------------------
    //Archivo     : ItemEjemplarTransito.cs
    //Proyecto    : Britanico.SacNet.BusinessEntities
    //Creacion    : Orlando Carril 11/10/2010 - REQ:XXX
    //Descripcion : Entidad de Negocio
    //-------------------------------------------------------------------
    public class ItemEjemplarTransito
    {
        #region Entidadest

        public string sCodPrestamo { get; set; }
        public string sCodEjemplar { get; set; }
        public Nullable<DateTime> dFechaLlegadaSAC { get; set; }
        
        public string SSIUsuario_Creacion { get; set; }
        public DateTime SSIFechaHora_Creacion { get; set; }
        public string SSIUsuario_Modificacion { get; set; }
        public DateTime SSIFechaHora_Modificacion { get; set; }
        public string SSIHost { get; set; }

        public string sCodSac { get; set; }
        public string sCodSacNombre { get; set; }
        public string sCodSacDevuelto { get; set; }
        public string sCodSacDevueltoNombre { get; set; }
        public Nullable<DateTime> dFechaDevolucionReal { get; set; }
        public string sCodItem { get; set; }

        #endregion

    }
}
