using System;
using System.Collections.Generic;
using System.Text;

namespace Britanico.Web.BusinessEntities
{
    public partial class BEInformacion
    {
        public BEInformacion()
        {
        }

        public BEInformacion(System.Int32 info_codi, System.String info_titu, System.String info_desc, System.String info_fech, System.Int32 even_tipo)
        {
            this.info_codiField = info_codi;
            this.info_fechField = info_fech;
            this.info_tituField = info_titu;
            this.info_descField = info_desc;
            this.even_tipoField = even_tipo;
         
        }

        private System.Int32 info_codiField;

        public System.Int32 info_codi
        {
            get { return this.info_codiField; }
            set { this.info_codiField = value; }
        }

        private System.Int32 even_tipoField;

        public System.Int32 even_tipo
        {
            get { return this.even_tipoField; }
            set { this.even_tipoField = value; }
        }


        private System.String info_tituField;

        public System.String info_titu
        {
            get { return this.info_tituField; }
            set { this.info_tituField = value; }
        }

        private System.String info_descField;

        public System.String info_desc
        {
            get { return this.info_descField; }
            set { this.info_descField = value; }
        }

        private System.String info_fechField;

        public System.String info_fech
        {
            get { return this.info_fechField; }
            set { this.info_fechField = value; }
        }

    }
}

