using System;
using System.Collections.Generic;
using System.Text;

namespace Britanico.Web.BusinessEntities
{
    public partial class BEConcurso
    {
        public BEConcurso()
        {
        }

        public BEConcurso(System.Int32 conc_codi, System.String conc_desc, System.String conc_nomb, System.String conc_subt)
        {
            this.conc_codiField = conc_codi;
            this.conc_descField = conc_desc;
            this.conc_nombField = conc_nomb;
            this.conc_subtField = conc_subt;
        }

        private System.Int32 conc_codiField;

        public System.Int32 conc_codi
        {
            get { return this.conc_codiField; }
            set { this.conc_codiField = value; }
        }

        private System.String conc_descField;

        public System.String conc_desc
        {
            get { return this.conc_descField; }
            set { this.conc_descField = value; }
        }

        private System.String conc_nombField;

        public System.String conc_nomb
        {
            get { return this.conc_nombField; }
            set { this.conc_nombField = value; }
        }

        private System.String conc_subtField;

        public System.String conc_subt
        {
            get { return this.conc_subtField; }
            set { this.conc_subtField = value; }
        }

    }
}

