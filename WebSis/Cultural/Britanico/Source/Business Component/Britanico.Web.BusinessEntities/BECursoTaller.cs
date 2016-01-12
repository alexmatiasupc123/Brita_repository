using System;
using System.Collections.Generic;
using System.Text;

namespace Britanico.Web.BusinessEntities
{
    public partial class BECursoTaller
    {
        public BECursoTaller()
        {
        }
        
        public BECursoTaller(System.Int32 curs_codi, System.String curs_desc, System.String curs_diri, System.DateTime curs_fini, System.String curs_hora, System.String curs_info, System.Decimal curs_prec, System.String curs_prev, System.String curs_prof, System.String curs_titu, System.Int32 sede_codi, System.Int32 segm_codi,  System.String curs_imag, System.Boolean curs_dest, System.DateTime curs_ffin, System.String  curs_aimg, System.String curs_lfec)
        {
            this.curs_codiField = curs_codi;
            this.curs_descField = curs_desc;
            this.curs_diriField = curs_diri;
            this.curs_finiField = curs_fini;
            this.curs_horaField = curs_hora;
            this.curs_infoField = curs_info;
            this.curs_precField = curs_prec;
            this.curs_prevField = curs_prev;
            this.curs_profField = curs_prof;
            this.curs_tituField = curs_titu;
            this.sede_codiField = sede_codi;
            this.segm_codiField = segm_codi;
            this.curs_imagField = curs_imag;
            this.curs_destField = curs_dest;
            this.curs_ffinField = curs_ffin;
            this.curs_aimgField = curs_aimg;
            this.curs_lfecField = curs_lfec;
        }
		
		private System.Int32 curs_codiField;		
		
	    public System.Int32 curs_codi
	    {
	        get { return this.curs_codiField; }
	        set { this.curs_codiField = value; }
	    }

		private System.String curs_descField;		
		
	    public System.String curs_desc
	    {
	        get { return this.curs_descField; }
	        set { this.curs_descField = value; }
	    }

		private System.String curs_diriField;		
		
	    public System.String curs_diri
	    {
	        get { return this.curs_diriField; }
	        set { this.curs_diriField = value; }
	    }

		private System.DateTime curs_finiField;		
		
	    public System.DateTime curs_fini
	    {
	        get { return this.curs_finiField; }
	        set { this.curs_finiField = value; }
	    }

		private System.String curs_horaField;		
		
	    public System.String curs_hora
	    {
	        get { return this.curs_horaField; }
	        set { this.curs_horaField = value; }
	    }

        private System.String curs_aimgField;

        public System.String curs_aimg
        {
            get { return this.curs_aimgField; }
            set { this.curs_aimgField = value; }
        }

		private System.String curs_infoField;		
		
	    public System.String curs_info
	    {
	        get { return this.curs_infoField; }
	        set { this.curs_infoField = value; }
	    }

		private System.Decimal curs_precField;		
		
	    public System.Decimal curs_prec
	    {
	        get { return this.curs_precField; }
	        set { this.curs_precField = value; }
	    }

		private System.String curs_prevField;		
		
	    public System.String curs_prev
	    {
	        get { return this.curs_prevField; }
	        set { this.curs_prevField = value; }
	    }

		private System.String curs_profField;		
		
	    public System.String curs_prof
	    {
	        get { return this.curs_profField; }
	        set { this.curs_profField = value; }
	    }

		private System.String curs_tituField;		
		
	    public System.String curs_titu
	    {
	        get { return this.curs_tituField; }
	        set { this.curs_tituField = value; }
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


        private System.String curs_imagField;

        public System.String curs_imag
        {
            get { return this.curs_imagField; }
            set { this.curs_imagField = value; }
        }

        private System.Boolean curs_destField;

        public System.Boolean curs_dest
        {

            get { return this.curs_destField; }
            set { this.curs_destField = value; }
        }

        private System.DateTime curs_ffinField;

        public System.DateTime curs_ffin
        {

            get { return this.curs_ffinField; }
            set { this.curs_ffinField = value; }
        }

        private System.String curs_lfecField;

        public System.String curs_lfec
        {
            get { return this.curs_lfecField; }
            set { this.curs_lfecField = value; }
        }

    }
}

