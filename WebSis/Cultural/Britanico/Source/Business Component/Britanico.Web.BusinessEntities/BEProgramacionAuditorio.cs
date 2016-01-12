using System;
using System.Collections.Generic;
using System.Text;

namespace Britanico.Web.BusinessEntities
{
    public partial class BEProgramacionAuditorio
    {
        public BEProgramacionAuditorio()
        {
        }
        
        public BEProgramacionAuditorio(System.Int32 prog_codi, System.String prog_desc, System.Boolean prog_dest, System.String prog_deta, System.DateTime prog_ffin, System.DateTime prog_fini, System.String prog_imag, System.String prog_temp, System.String prog_titu, System.Int32 sede_codi, System.String prog_aimg, System.String prog_lfec, System.String sede_nomb)
        {
            this.prog_codiField = prog_codi;
            this.prog_descField = prog_desc;
            this.prog_destField = prog_dest;
            this.prog_detaField = prog_deta;
            this.prog_ffinField = prog_ffin;
            this.prog_finiField = prog_fini;
            this.prog_imagField = prog_imag;
            this.prog_tempField = prog_temp;
            this.prog_tituField = prog_titu;
            this.sede_codiField = sede_codi;
            this.prog_aimgField = prog_aimg;
            this.prog_lfecField = prog_lfec;
            this.sede_nombField = sede_nomb;
        }
		
		private System.Int32 prog_codiField;		
		
	    public System.Int32 prog_codi
	    {
	        get { return this.prog_codiField; }
	        set { this.prog_codiField = value; }
	    }

		private System.String prog_descField;		
		
	    public System.String prog_desc
	    {
	        get { return this.prog_descField; }
	        set { this.prog_descField = value; }
	    }

		private System.Boolean prog_destField;		
		
	    public System.Boolean prog_dest
	    {
	        get { return this.prog_destField; }
	        set { this.prog_destField = value; }
	    }

		private System.String prog_detaField;		
		
	    public System.String prog_deta
	    {
	        get { return this.prog_detaField; }
	        set { this.prog_detaField = value; }
	    }

		private System.DateTime prog_ffinField;		
		
	    public System.DateTime prog_ffin
	    {
	        get { return this.prog_ffinField; }
	        set { this.prog_ffinField = value; }
	    }

		private System.DateTime prog_finiField;		
		
	    public System.DateTime prog_fini
	    {
	        get { return this.prog_finiField; }
	        set { this.prog_finiField = value; }
	    }

		private System.String prog_imagField;		
		
	    public System.String prog_imag
	    {
	        get { return this.prog_imagField; }
	        set { this.prog_imagField = value; }
	    }

		private System.String prog_tempField;		
		
	    public System.String prog_temp
	    {
	        get { return this.prog_tempField; }
	        set { this.prog_tempField = value; }
	    }

		private System.String prog_tituField;		
		
	    public System.String prog_titu
	    {
	        get { return this.prog_tituField; }
	        set { this.prog_tituField = value; }
	    }

		private System.Int32 sede_codiField;		
		
	    public System.Int32 sede_codi
	    {
	        get { return this.sede_codiField; }
	        set { this.sede_codiField = value; }
	    }

        private System.String prog_aimgField;

        public System.String prog_aimg
        {
            get { return this.prog_aimgField; }
            set { this.prog_aimgField = value; }
        }

        private System.String prog_lfecField;

        public System.String prog_lfec
        {
            get { return this.prog_lfecField; }
            set { this.prog_lfecField = value; }
        }

        private System.String sede_nombField;

        public System.String sede_nomb
        {
            get { return this.sede_nombField; }
            set { this.sede_nombField = value; }
        }

    }
}

