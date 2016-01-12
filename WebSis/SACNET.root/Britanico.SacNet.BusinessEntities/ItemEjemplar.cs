using System;

namespace Britanico.SacNet.BusinessEntities
{
    //-------------------------------------------------------------------
    //Archivo     : ItemEjemplar.cs
    //Proyecto    : Britanico.SacNet.BusinessEntities
    //Creacion    : Luis Chavarria08/07/2010 - REQ:XXX
    //Descripcion : Entidad de Negocio
    //-------------------------------------------------------------------
    public class ItemEjemplar
    {
        #region Entidadest

        public string sCodItem { get; set; }
        public string sCodEjemplar { get; set; }
        public string sCodSac { get; set; }
        public string sNotas { get; set; }
        public string sCodArguEstadoEjemplar { get; set; }
        public bool bReservado { get; set; }
        public bool sEstadoReg { get; set; } //True: Nuevo Registro, False: Modificacion
        public string SSIUsuario_Creacion { get; set; }
        public DateTime SSIFechaHora_Creacion { get; set; }
        public string SSIUsuario_Modificacion { get; set; }
        public DateTime SSIFechaHora_Modificacion { get; set; }
        public string SSIHost { get; set; }

        public Nullable<DateTime> dFechaAsignaSAC { get; set; }
        public Nullable<DateTime> dFechaPrestamo { get; set; }
        public Nullable<DateTime> dFechaDevolucionEstimada { get; set; }
        public string sCodSacNombre { get; set; }
        public string sCodEjemplarTitulo { get; set; }
        public string sCodArguNombreEstadoEjemplar { get; set; }

        #endregion

    }
}
