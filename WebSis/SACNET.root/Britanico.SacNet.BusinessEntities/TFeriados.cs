using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Britanico.SacNet.BusinessEntities
{
    //-------------------------------------------------------------------
    //Archivo     : TFeriados.cs
    //Proyecto    : Britanico.SacNet.BusinessEntities
    //Creacion    : Luis Chavarria08/07/2010 - REQ:XXX
    //Descripcion : Entidad de Negocio
    //-------------------------------------------------------------------
    public class TFeriados
    {
        #region Entidadest

        public string sCodRegistro { get; set; }
        public string sFeriado { get; set; }

        public bool bFijo { get; set; }
        public string sDescripcion { get; set; }
        public bool bEstado { get; set; }

        public Nullable<DateTime> dFechaIndicada { get; set; }

        public string SSIUsuario_Creacion { get; set; }
        public DateTime SSIFechaHora_Creacion { get; set; }
        public string SSIUsuario_Modificacion { get; set; }
        public DateTime SSIFechaHora_Modificacion { get; set; }
        public string SSIHost { get; set; }

        #endregion

    }
}
