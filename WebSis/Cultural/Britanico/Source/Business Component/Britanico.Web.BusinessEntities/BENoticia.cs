using System;
using System.Collections.Generic;
using System.Text;

namespace Britanico.Web.BusinessEntities
{
    public partial class BENoticia
    {
        public BENoticia()
        {
        }
        
        public BENoticia(System.Int32 noti_codi, System.String noti_desc, System.DateTime noti_fech, System.String noti_imag, System.String noti_subt, System.String noti_titu)
        {
            this.noti_codiField = noti_codi;
            this.noti_descField = noti_desc;
            this.noti_fechField = noti_fech;
            this.noti_imagField = noti_imag;
            this.noti_subtField = noti_subt;
            this.noti_tituField = noti_titu;
        }
		
		private System.Int32 noti_codiField;		
		
	    public System.Int32 noti_codi
	    {
	        get { return this.noti_codiField; }
	        set { this.noti_codiField = value; }
	    }

		private System.String noti_descField;		
		
	    public System.String noti_desc
	    {
	        get { return this.noti_descField; }
	        set { this.noti_descField = value; }
	    }

		private System.DateTime noti_fechField;		
		
	    public System.DateTime noti_fech
	    {
	        get { return this.noti_fechField; }
	        set { this.noti_fechField = value; }
	    }

		private System.String noti_imagField;		
		
	    public System.String noti_imag
	    {
	        get { return this.noti_imagField; }
	        set { this.noti_imagField = value; }
	    }

		private System.String noti_subtField;		
		
	    public System.String noti_subt
	    {
	        get { return this.noti_subtField; }
	        set { this.noti_subtField = value; }
	    }

		private System.String noti_tituField;		
		
	    public System.String noti_titu
	    {
	        get { return this.noti_tituField; }
	        set { this.noti_tituField = value; }
	    }

    }
}

