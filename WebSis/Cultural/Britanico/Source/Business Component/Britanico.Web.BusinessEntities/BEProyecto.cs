using System;
using System.Collections.Generic;
using System.Text;

namespace Britanico.Web.BusinessEntities
{
    public partial class BEProyecto
    {
        public BEProyecto()
        {
        }

        public BEProyecto(System.Int32 proy_codi, System.String proy_desc, System.String proy_nomb, System.String proy_subt, System.String proy_imag)
        {
            this.proy_codiField = proy_codi;
            this.proy_descField = proy_desc;
            this.proy_nombField = proy_nomb;
            this.proy_subtField = proy_subt;
            this.proy_imagField = proy_imag;
        }

        private System.Int32 proy_codiField;

        public System.Int32 proy_codi
        {
            get { return this.proy_codiField; }
            set { this.proy_codiField = value; }
        }

        private System.String proy_descField;

        public System.String proy_desc
        {
            get { return this.proy_descField; }
            set { this.proy_descField = value; }
        }

        private System.String proy_imagField;

        public System.String proy_imag
        {
            get { return this.proy_imagField; }
            set { this.proy_imagField = value; }
        }


        private System.String proy_nombField;

        public System.String proy_nomb
        {
            get { return this.proy_nombField; }
            set { this.proy_nombField = value; }
        }

        private System.String proy_subtField;

        public System.String proy_subt
        {
            get { return this.proy_subtField; }
            set { this.proy_subtField = value; }
        }

    }
}

