using System;
using System.Collections.Generic;
using System.Text;

namespace Britanico.Web.BusinessEntities
{
    public partial class BECabecera
    {
        public BECabecera()
        {
        }

        public BECabecera(System.Int32 cabe_codi, System.String cabe_imag, System.String cabe_titu)
        {
            this.cabe_codiField = cabe_codi;
            this.cabe_imagField = cabe_imag;
            this.cabe_tituField = cabe_titu;
        }

        private System.Int32 cabe_codiField;

        public System.Int32 cabe_codi
        {
            get { return this.cabe_codiField; }
            set { this.cabe_codiField = value; }
        }


		private System.String cabe_imagField;		
		
	    public System.String cabe_imag
	    {
	        get { return this.cabe_imagField; }
	        set { this.cabe_imagField = value; }
	    }

        private System.String cabe_tituField;

        public System.String cabe_titu
        {
            get { return this.cabe_tituField; }
            set { this.cabe_tituField = value; }
        }
    }
}

