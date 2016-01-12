using System;
using System.Collections.Generic;
using System.Text;

namespace Britanico.Web.BusinessEntities
{
    public partial class BEMuestraGaleria
    {
        public BEMuestraGaleria()
        {
        }

        public BEMuestraGaleria(System.Int32 mues_codi, System.String mues_desc, System.String mues_nomb, System.Int32 gale_codi, System.String mues_imag, System.String gale_nomb, System.Int32 mues_anio)
        {
            this.mues_codiField = mues_codi;
            this.mues_descField = mues_desc;
            this.mues_nombField = mues_nomb;
            this.gale_codiField = gale_codi;
            this.mues_imagField = mues_imag;
            this.gale_nombField = gale_nomb;
            this.mues_anioField = mues_anio;
        }

        private System.Int32 mues_codiField;

        public System.Int32 mues_codi
        {
            get { return this.mues_codiField; }
            set { this.mues_codiField = value; }
        }

        private System.Int32 mues_anioField;

        public System.Int32 mues_anio
        {
            get { return this.mues_anioField; }
            set { this.mues_anioField = value; }
        }


        private System.String mues_descField;

        public System.String mues_desc
        {
            get { return this.mues_descField; }
            set { this.mues_descField = value; }
        }


        private System.String gale_nombField;

        public System.String gale_nomb
        {
            get { return this.gale_nombField; }
            set { this.gale_nombField = value; }
        }



        private System.String mues_nombField;

        public System.String mues_nomb
        {
            get { return this.mues_nombField; }
            set { this.mues_nombField = value; }
        }


        private System.Int32 gale_codiField;

        public System.Int32 gale_codi
        {
            get { return this.gale_codiField; }
            set { this.gale_codiField = value; }
        }

        private System.String mues_imagField;

        public System.String mues_imag
        {
            get { return this.mues_imagField; }
            set { this.mues_imagField = value; }
        }



    }
}

