using System;
using System.Collections.Generic;
using System.Text;

namespace Britanico.Web.BusinessEntities
{
    public partial class BEGaleriaArte
    {
        public BEGaleriaArte()
        {
        }

        public BEGaleriaArte(System.Int32 gale_codi, System.String gale_desc, System.String gale_nomb, System.Int32 sede_codi, System.String sede_nomb)
        {
            this.gale_codiField = gale_codi;
            this.gale_descField = gale_desc;
            this.gale_nombField = gale_nomb;
            this.sede_codiField = sede_codi;
            this.sede_nombField = sede_nomb;
        }

        private System.Int32 gale_codiField;

        public System.Int32 gale_codi
        {
            get { return this.gale_codiField; }
            set { this.gale_codiField = value; }
        }

        private System.String gale_descField;

        public System.String gale_desc
        {
            get { return this.gale_descField; }
            set { this.gale_descField = value; }
        }

        private System.String gale_nombField;

        public System.String gale_nomb
        {
            get { return this.gale_nombField; }
            set { this.gale_nombField = value; }
        }

        private System.Int32 sede_codiField;

        public System.Int32 sede_codi
        {
            get { return this.sede_codiField; }
            set { this.sede_codiField = value; }
        }

        private System.String sede_nombField;

        public System.String sede_nomb
        {
            get { return this.sede_nombField; }
            set { this.sede_nombField = value; }
        }
    }
}

