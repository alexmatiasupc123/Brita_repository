using System;
using System.Collections.Generic;
using System.Text;

namespace Britanico.Web.BusinessEntities
{
    public partial class BEBanner
    {
        public BEBanner()
        {
        }

        public BEBanner(System.Int32 bann_codi, System.Int32 bann_esta, System.DateTime bann_fech, System.String bann_imag, System.String bann_titu, System.String bann_link, System.String bann_dfec, System.Boolean bann_fpri, System.Boolean bann_redsocial)
        {
            this.bann_codiField = bann_codi;
            this.bann_estaField = bann_esta;
            this.bann_fechField = bann_fech;
            this.bann_imagField = bann_imag;
            this.bann_tituField = bann_titu;
            this.bann_dfecField = bann_dfec;
            this.bann_fpriField = bann_fpri;
            this.bann_redsocialField = bann_redsocial;
        }

        private System.Int32 bann_codiField;

        public System.Int32 bann_codi
        {
            get { return this.bann_codiField; }
            set { this.bann_codiField = value; }
        }

        private System.Int32 bann_estaField;

        public System.Int32 bann_esta
        {
            get { return this.bann_estaField; }
            set { this.bann_estaField = value; }
        }

        private System.DateTime bann_fechField;

        public System.DateTime bann_fech
        {
            get { return this.bann_fechField; }
            set { this.bann_fechField = value; }
        }

        private System.String bann_imagField;

        public System.String bann_imag
        {
            get { return this.bann_imagField; }
            set { this.bann_imagField = value; }
        }

        private System.String bann_tituField;

        public System.String bann_titu
        {
            get { return this.bann_tituField; }
            set { this.bann_tituField = value; }
        }

        private System.String bann_linkField;

        public System.String bann_link
        {
            get { return this.bann_linkField; }
            set { this.bann_linkField = value; }
        }

        private System.String bann_dfecField;

        public System.String bann_dfec
        {
            get { return this.bann_dfecField; }
            set { this.bann_dfecField = value; }
        }

        private System.Boolean bann_fpriField;

        public System.Boolean bann_fpri
        {
            get { return this.bann_fpriField; }
            set { this.bann_fpriField = value; }
        }

        private System.Boolean bann_redsocialField;

        public System.Boolean bann_redsocial
        {
            get { return this.bann_redsocialField; }
            set { this.bann_redsocialField = value; }
        }

    }
}

