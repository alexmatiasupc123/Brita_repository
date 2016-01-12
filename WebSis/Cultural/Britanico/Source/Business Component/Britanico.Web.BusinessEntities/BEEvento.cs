using System;
using System.Collections.Generic;
using System.Text;

namespace Britanico.Web.BusinessEntities
{
    public partial class BEEvento
    {
        public BEEvento()
        {
        }

        public BEEvento(System.Int32 sede_codi, System.Int32 even_codi, System.Int32 even_codr, System.String even_desc, System.DateTime even_fini, System.DateTime even_ffin, System.String even_nomb, System.String even_imag, System.Int32 even_tipo, System.String even_temp, System.Boolean even_dest, System.String even_aimg, System.String even_lfec)
        {
            this.sede_codiField = sede_codi;
            this.even_codiField = even_codi;
            this.even_codrField = even_codr;
            this.even_descField = even_desc;
            this.even_ffinField = even_ffin;
            this.even_finiField = even_fini;
            this.even_nombField = even_nomb;
            this.even_imagField = even_imag;
            this.even_tipoField = even_tipo;
            this.even_tempField = even_temp;
            this.even_destField = even_dest;
            this.even_aimgField = even_aimg;
            this.even_lfecField = even_lfec;
    
        }

        private System.Int32 sede_codiField;

        public System.Int32 sede_codi
        {
            get { return this.sede_codiField; }
            set { this.sede_codiField = value; }
        }

        private System.Int32 even_codiField;

        public System.Int32 even_codi
        {
            get { return this.even_codiField; }
            set { this.even_codiField = value; }
        }

        private System.Int32 even_codrField;

        public System.Int32 even_codr
        {
            get { return this.even_codrField; }
            set { this.even_codrField = value; }
        }

        private System.String even_descField;

        public System.String even_desc
        {
            get { return this.even_descField; }
            set { this.even_descField = value; }
        }

        private System.DateTime even_ffinField;

        public System.DateTime even_ffin
        {
            get { return this.even_ffinField; }
            set { this.even_ffinField = value; }
        }

        private System.DateTime even_finiField;

        public System.DateTime even_fini
        {
            get { return this.even_finiField; }
            set { this.even_finiField = value; }
        }

        private System.String even_nombField;

        public System.String even_nomb
        {
            get { return this.even_nombField; }
            set { this.even_nombField = value; }
        }

       
       private System.String even_imagField;

        public System.String even_imag
        {
            get { return this.even_imagField; }
            set { this.even_imagField = value; }
        }

        private System.Int32 even_tipoField;

        public System.Int32 even_tipo
        {
            get { return this.even_tipoField; }
            set { this.even_tipoField = value; }
        }

        private System.String even_tempField;

        public System.String even_temp
        {
            get { return this.even_tempField; }
            set { this.even_tempField = value; }
        }

        private System.Boolean even_destField;

        public System.Boolean even_dest
        {
            get { return this.even_destField; }
            set { this.even_destField = value; }
        }

        private System.String even_aimgField;

        public System.String even_aimg
        {
            get { return this.even_aimgField; }
            set { this.even_aimgField = value; }
        }
        private System.String even_lfecField;

        public System.String even_lfec
        {
            get { return this.even_lfecField; }
            set { this.even_lfecField = value; }
        }
    }
}

