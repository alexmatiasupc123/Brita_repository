using System;
using System.Collections.Generic;
using System.Text;

namespace Britanico.Web.BusinessEntities
{
    public partial class BEHistoriaTeatro
    {
        public BEHistoriaTeatro()
        {
        }

        public BEHistoriaTeatro(System.Int32 histo_codi, System.String histo_desc, System.DateTime histo_fech, System.String histo_imag, System.String histo_titu)
        {
            this.histo_codiField = histo_codi;
            this.histo_descField = histo_desc;
            this.histo_fechField = histo_fech;
            this.histo_imagField = histo_imag;
            this.histo_tituField = histo_titu;
        }

        private System.Int32 histo_codiField;

        public System.Int32 histo_codi
        {
            get { return this.histo_codiField; }
            set { this.histo_codiField = value; }
        }


		private System.String histo_descField;		
		
	    public System.String histo_desc
	    {
	        get { return this.histo_descField; }
	        set { this.histo_descField = value; }
	    }

		private System.DateTime histo_fechField;		
		
	    public System.DateTime histo_fech
	    {
	        get { return this.histo_fechField; }
	        set { this.histo_fechField = value; }
	    }

		private System.String histo_imagField;		
		
	    public System.String histo_imag
	    {
	        get { return this.histo_imagField; }
	        set { this.histo_imagField = value; }
	    }

        private System.String histo_tituField;

        public System.String histo_titu
        {
            get { return this.histo_tituField; }
            set { this.histo_tituField = value; }
        }
    }
}

