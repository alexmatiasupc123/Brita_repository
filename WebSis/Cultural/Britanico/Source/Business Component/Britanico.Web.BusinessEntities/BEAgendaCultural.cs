using System;
using System.Collections.Generic;
using System.Text;

namespace Britanico.Web.BusinessEntities
{
    public partial class BEAgendaCultural
    {
        public BEAgendaCultural()
        {
        }

        public BEAgendaCultural(System.Int32 agen_codi, System.String agen_desc, System.DateTime agen_fech, System.String agen_imag, System.String agen_titu)
        {
            this.agen_codiField = agen_codi;
            this.agen_descField = agen_desc;
            this.agen_fechField = agen_fech;
            this.agen_imagField = agen_imag;
            this.agen_tituField = agen_titu;
        }

        private System.Int32 agen_codiField;

        public System.Int32 agen_codi
        {
            get { return this.agen_codiField; }
            set { this.agen_codiField = value; }
        }


		private System.String agen_descField;		
		
	    public System.String agen_desc
	    {
	        get { return this.agen_descField; }
	        set { this.agen_descField = value; }
	    }

		private System.DateTime agen_fechField;		
		
	    public System.DateTime agen_fech
	    {
	        get { return this.agen_fechField; }
	        set { this.agen_fechField = value; }
	    }

		private System.String agen_imagField;		
		
	    public System.String agen_imag
	    {
	        get { return this.agen_imagField; }
	        set { this.agen_imagField = value; }
	    }

        private System.String agen_tituField;

        public System.String agen_titu
        {
            get { return this.agen_tituField; }
            set { this.agen_tituField = value; }
        }
    }
}

