using System;
using System.Collections.Generic;
using System.Text;

namespace Britanico.Web.BusinessEntities
{
    public partial class BEGaleriaArchivo
    {
        public BEGaleriaArchivo()
        {
        }
        
        public BEGaleriaArchivo(System.Int32 arch_codi, System.String arch_desc, System.String arch_titu, System.Int32 padr_codi, System.Int32 padr_tipo, System.String arch_arch, System.String arch_tipo, System.String arch_link)
        {
            this.arch_codiField = arch_codi;
            this.arch_descField = arch_desc;
            this.arch_tituField = arch_titu;
            this.padr_codiField = padr_codi;//tipo puede ser galeria de eventos o galeria de galeria de arte
            this.padr_tipoField = padr_tipo;// aqui los codigos de eventos o galeria de arte
            this.arch_archField = arch_arch;
            this.arch_linkField = arch_link;
        }
		
		private System.Int32 arch_codiField;		
		
	    public System.Int32 arch_codi
	    {
	        get { return this.arch_codiField; }
	        set { this.arch_codiField = value; }
	    }

		private System.String arch_descField;		
		
	    public System.String arch_desc
	    {
	        get { return this.arch_descField; }
	        set { this.arch_descField = value; }
	    }

		private System.String arch_tituField;		
		
	    public System.String arch_titu
	    {
	        get { return this.arch_tituField; }
	        set { this.arch_tituField = value; }
	    }

		private System.Int32 padr_codiField;		
		
	    public System.Int32 padr_codi
	    {
	        get { return this.padr_codiField; }
	        set { this.padr_codiField = value; }
	    }

		private System.Int32 padr_tipoField;		
		
	    public System.Int32 padr_tipo
	    {
	        get { return this.padr_tipoField; }
	        set { this.padr_tipoField = value; }
	    }

        private System.String arch_archField;

        public System.String arch_arch
        {
            get { return this.arch_archField; }
            set { this.arch_archField = value; }
        }

        private System.String arch_tipoField;

        public System.String arch_tipo
        {
            get { return this.arch_tipoField; }
            set { this.arch_tipoField = value; }
        }

        private System.String arch_linkField;

        public System.String arch_link
        {
            get { return this.arch_linkField; }
            set { this.arch_linkField = value; }
        }


    }
}

