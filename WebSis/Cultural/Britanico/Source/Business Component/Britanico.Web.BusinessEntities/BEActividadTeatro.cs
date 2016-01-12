using System;
using System.Collections.Generic;
using System.Text;

namespace Britanico.Web.BusinessEntities
{
    public partial class BEActividadTeatro
    {
        public BEActividadTeatro()
        {
        }
        
        public BEActividadTeatro(System.Int32 sede_codi, System.Int32 segm_codi, System.Int32 teat_codi, System.String teat_desc, System.Boolean teat_dest, System.String teat_entr, System.DateTime teat_fint, System.String teat_imag, System.DateTime teat_init, System.String teat_temp, System.String teat_titu, System.String teat_subt, System.String teat_aimg, System.String teat_lfec)
        {
            this.sede_codiField = sede_codi;
            this.segm_codiField = segm_codi;
            this.teat_codiField = teat_codi;
            this.teat_descField = teat_desc;
            this.teat_destField = teat_dest;
            this.teat_entrField = teat_entr;
            this.teat_fintField = teat_fint;
            this.teat_imagField = teat_imag;
            this.teat_initField = teat_init;
            this.teat_tempField = teat_temp;
            this.teat_tituField = teat_titu;
            this.teat_subtField = teat_subt;
            this.teat_aimgField = teat_aimg;
            this.teat_lfecField = teat_lfec;

        }
		
		private System.Int32 sede_codiField;		
		
	    public System.Int32 sede_codi
	    {
	        get { return this.sede_codiField; }
	        set { this.sede_codiField = value; }
	    }

		private System.Int32 segm_codiField;		
		
	    public System.Int32 segm_codi
	    {
	        get { return this.segm_codiField; }
	        set { this.segm_codiField = value; }
	    }

		private System.Int32 teat_codiField;		
		
	    public System.Int32 teat_codi
	    {
	        get { return this.teat_codiField; }
	        set { this.teat_codiField = value; }
	    }

		private System.String teat_descField;		
		
	    public System.String teat_desc
	    {
	        get { return this.teat_descField; }
	        set { this.teat_descField = value; }
	    }

        private System.String teat_aimgField;

        public System.String teat_aimg
        {
            get { return this.teat_aimgField; }
            set { this.teat_aimgField = value; }
        }


		private System.Boolean teat_destField;		
		
	    public System.Boolean teat_dest
	    {
	        get { return this.teat_destField; }
	        set { this.teat_destField = value; }
	    }

		private System.String teat_entrField;		
		
	    public System.String teat_entr
	    {
	        get { return this.teat_entrField; }
	        set { this.teat_entrField = value; }
	    }

		private System.DateTime teat_fintField;		
		
	    public System.DateTime teat_fint
	    {
	        get { return this.teat_fintField; }
	        set { this.teat_fintField = value; }
	    }

		private System.String teat_imagField;		
		
	    public System.String teat_imag
	    {
	        get { return this.teat_imagField; }
	        set { this.teat_imagField = value; }
	    }

		private System.DateTime teat_initField;		
		
	    public System.DateTime teat_init
	    {
	        get { return this.teat_initField; }
	        set { this.teat_initField = value; }
	    }

		private System.String teat_tempField;		
		
	    public System.String teat_temp
	    {
	        get { return this.teat_tempField; }
	        set { this.teat_tempField = value; }
	    }

		private System.String teat_tituField;		
		
	    public System.String teat_titu
	    {
	        get { return this.teat_tituField; }
	        set { this.teat_tituField = value; }
	    }

        private System.String teat_subtField;

        public System.String teat_subt
        {
            get { return this.teat_subtField; }
            set { this.teat_subtField = value; }
        }

        private System.String teat_lfecField;

        public System.String teat_lfec
        {
            get { return this.teat_lfecField; }
            set { this.teat_lfecField = value; }
        }

    }
}

