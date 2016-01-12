using System;
using System.Collections.Generic;
using System.Text;

namespace Britanico.Web.BusinessEntities
{
    public partial class BEBoletin
    {
        public BEBoletin()
        {
        }

        public BEBoletin(System.Int32 bole_codi, System.DateTime bole_fech, System.String bole_nomb, System.Boolean bole_publ, System.String bole_titu)
        {
            this.bole_codiField = bole_codi;
            this.bole_fechField = bole_fech;
            this.bole_nombField = bole_nomb;
            this.bole_publField = bole_publ;
            this.bole_tituField = bole_titu;
        }

        private System.Int32 bole_codiField;

        public System.Int32 bole_codi
        {
            get { return this.bole_codiField; }
            set { this.bole_codiField = value; }
        }

        private System.DateTime bole_fechField;

        public System.DateTime bole_fech
        {
            get { return this.bole_fechField; }
            set { this.bole_fechField = value; }
        }

        private System.String bole_nombField;

        public System.String bole_nomb
        {
            get { return this.bole_nombField; }
            set { this.bole_nombField = value; }
        }

        private System.Boolean bole_publField;

        public System.Boolean bole_publ
        {
            get { return this.bole_publField; }
            set { this.bole_publField = value; }
        }

        private System.String bole_tituField;

        public System.String bole_titu
        {
            get { return this.bole_tituField; }
            set { this.bole_tituField = value; }
        }

    }
}

