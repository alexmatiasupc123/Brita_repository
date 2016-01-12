using System;
using System.Collections.Generic;
using System.Text;

namespace Britanico.Web.BusinessEntities
{
    public partial class BESede
    {
        public BESede()
        {
        }

        public BESede(System.Int32 sede_codi, System.String sede_dire, System.String sede_nomb)
        {
            this.sede_codiField = sede_codi;
            this.sede_direField = sede_dire;
            this.sede_nombField = sede_nomb;
        }

        private System.Int32 sede_codiField;

        public System.Int32 sede_codi
        {
            get { return this.sede_codiField; }
            set { this.sede_codiField = value; }
        }

        private System.String sede_direField;

        public System.String sede_dire
        {
            get { return this.sede_direField; }
            set { this.sede_direField = value; }
        }

        private System.String sede_nombField;

        public System.String sede_nomb
        {
            get { return this.sede_nombField; }
            set { this.sede_nombField = value; }
        }

    }
}

