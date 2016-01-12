using System;
using System.Collections.Generic;
using System.Text;

namespace Britanico.Web.BusinessEntities
{
    public partial class BEConcursoTemporada
    {
        public BEConcursoTemporada()
        {
        }
        
        public BEConcursoTemporada(System.Int32 conc_codi, System.String ctem_anio, System.String ctem_base, System.Int32 ctem_codi, System.Boolean ctem_dest, System.DateTime ctem_ffin, System.DateTime ctem_fini, System.String ctem_imag, System.String ctem_jura, System.String ctem_prem, System.String ctem_result, System.String ctem_temp, System.Int32 sede_codi, System.String ctem_aimg, System.String ctem_lfec)
        {
            this.conc_codiField = conc_codi;
            this.ctem_anioField = ctem_anio;
            this.ctem_baseField = ctem_base;
            this.ctem_codiField = ctem_codi;
            this.ctem_destField = ctem_dest;
            this.ctem_ffinField = ctem_ffin;
            this.ctem_finiField = ctem_fini;
            this.ctem_imagField = ctem_imag;
            this.ctem_juraField = ctem_jura;
            this.ctem_premField = ctem_prem;
            this.ctem_resultField = ctem_result;
            this.ctem_tempField = ctem_temp;
            this.sede_codiField = sede_codi;
            this.ctem_aimgField = ctem_aimg;
            this.ctem_lfecField = ctem_lfec;
        }
		
		private System.Int32 conc_codiField;		
		
	    public System.Int32 conc_codi
	    {
	        get { return this.conc_codiField; }
	        set { this.conc_codiField = value; }
	    }

		private System.String ctem_anioField;		
		
	    public System.String ctem_anio
	    {
	        get { return this.ctem_anioField; }
	        set { this.ctem_anioField = value; }
	    }

		private System.String ctem_baseField;		
		
	    public System.String ctem_base
	    {
	        get { return this.ctem_baseField; }
	        set { this.ctem_baseField = value; }
	    }

		private System.Int32 ctem_codiField;		
		
	    public System.Int32 ctem_codi
	    {
	        get { return this.ctem_codiField; }
	        set { this.ctem_codiField = value; }
	    }

		private System.Boolean ctem_destField;		
		
	    public System.Boolean ctem_dest
	    {
	        get { return this.ctem_destField; }
	        set { this.ctem_destField = value; }
	    }

		private System.DateTime ctem_ffinField;		
		
	    public System.DateTime ctem_ffin
	    {
	        get { return this.ctem_ffinField; }
	        set { this.ctem_ffinField = value; }
	    }

		private System.DateTime ctem_finiField;		
		
	    public System.DateTime ctem_fini
	    {
	        get { return this.ctem_finiField; }
	        set { this.ctem_finiField = value; }
	    }

		private System.String ctem_imagField;		
		
	    public System.String ctem_imag
	    {
	        get { return this.ctem_imagField; }
	        set { this.ctem_imagField = value; }
	    }

		private System.String ctem_juraField;		
		
	    public System.String ctem_jura
	    {
	        get { return this.ctem_juraField; }
	        set { this.ctem_juraField = value; }
	    }

		private System.String ctem_premField;		
		
	    public System.String ctem_prem
	    {
	        get { return this.ctem_premField; }
	        set { this.ctem_premField = value; }
	    }

		private System.String ctem_resultField;		
		
	    public System.String ctem_result
	    {
	        get { return this.ctem_resultField; }
	        set { this.ctem_resultField = value; }
	    }

		private System.String ctem_tempField;		
		
	    public System.String ctem_temp
	    {
	        get { return this.ctem_tempField; }
	        set { this.ctem_tempField = value; }
	    }

		private System.Int32 sede_codiField;		
		
	    public System.Int32 sede_codi
	    {
	        get { return this.sede_codiField; }
	        set { this.sede_codiField = value; }
	    }

        private System.String ctem_aimgField;

        public System.String ctem_aimg
        {
            get { return this.ctem_aimgField; }
            set { this.ctem_aimgField = value; }
        }

        private System.String ctem_lfecField;

        public System.String ctem_lfec
        {
            get { return this.ctem_lfecField; }
            set { this.ctem_lfecField = value; }
        }
    }
}

