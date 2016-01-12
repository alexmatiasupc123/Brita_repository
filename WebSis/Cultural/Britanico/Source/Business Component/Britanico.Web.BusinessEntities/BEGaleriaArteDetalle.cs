using System;
using System.Collections.Generic;
using System.Text;

namespace Britanico.Web.BusinessEntities
{
    public partial class BEGaleriaArteDetalle
    {
        public BEGaleriaArteDetalle()
        {
        }

        public BEGaleriaArteDetalle(System.Int32 gade_codi, System.String gade_desc, System.DateTime gade_ffin, System.DateTime gade_fini, System.String gade_nomb, System.String gade_temp, System.Int32 gale_codi, System.String gade_imag, System.Boolean gade_dest, System.String gade_aimg, System.String gade_lfec)
        {
            this.gade_codiField = gade_codi;
            this.gade_descField = gade_desc;
            this.gade_ffinField = gade_ffin;
            this.gade_finiField = gade_fini;
            this.gade_nombField = gade_nomb;
            this.gade_tempField = gade_temp;
            this.gale_codiField = gale_codi;
            this.gade_imagField = gade_imag;
            this.gade_destField = gade_dest;
            this.gade_aimgField = gade_aimg;
            this.gade_lfecField = gade_lfec;
        }

        private System.Int32 gade_codiField;

        public System.Int32 gade_codi
        {
            get { return this.gade_codiField; }
            set { this.gade_codiField = value; }
        }

        private System.String gade_descField;

        public System.String gade_desc
        {
            get { return this.gade_descField; }
            set { this.gade_descField = value; }
        }

        private System.String gade_aimgField;

        public System.String gade_aimg
        {
            get { return this.gade_aimgField; }
            set { this.gade_aimgField = value; }
        }

        private System.DateTime gade_ffinField;

        public System.DateTime gade_ffin
        {
            get { return this.gade_ffinField; }
            set { this.gade_ffinField = value; }
        }

        private System.DateTime gade_finiField;

        public System.DateTime gade_fini
        {
            get { return this.gade_finiField; }
            set { this.gade_finiField = value; }
        }

        private System.String gade_nombField;

        public System.String gade_nomb
        {
            get { return this.gade_nombField; }
            set { this.gade_nombField = value; }
        }

        private System.String gade_tempField;

        public System.String gade_temp
        {
            get { return this.gade_tempField; }
            set { this.gade_tempField = value; }
        }

        private System.Int32 gale_codiField;

        public System.Int32 gale_codi
        {
            get { return this.gale_codiField; }
            set { this.gale_codiField = value; }
        }

        private System.String gade_imagField;

        public System.String gade_imag
        {
            get { return this.gade_imagField; }
            set { this.gade_imagField = value; }
        }

        private System.Boolean gade_destField;

        public System.Boolean gade_dest
        {

            get { return this.gade_destField; }
            set { this.gade_destField = value; }
        }

        private System.String gade_lfecField;

        public System.String gade_lfec
        {
            get { return this.gade_lfecField; }
            set { this.gade_lfecField = value; }
        }

    }
}

