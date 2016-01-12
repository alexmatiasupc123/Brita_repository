using System;
using System.Collections.Generic;
using System.Text;

namespace Britanico.Web.BusinessEntities
{
    public partial class BEPublicaciones
    {
        public BEPublicaciones()
        {
        }

        public BEPublicaciones(System.Int32 publ_codi, System.String publ_desc, System.String publ_nomb, System.String publ_subt)
        {
            this.publ_codiField = publ_codi;
            this.publ_descField = publ_desc;
            this.publ_nombField = publ_nomb;
            this.publ_subtField = publ_subt;
        }

        private System.Int32 publ_codiField;

        public System.Int32 publ_codi
        {
            get { return this.publ_codiField; }
            set { this.publ_codiField = value; }
        }

        private System.String publ_descField;

        public System.String publ_desc
        {
            get { return this.publ_descField; }
            set { this.publ_descField = value; }
        }

        private System.String publ_nombField;

        public System.String publ_nomb
        {
            get { return this.publ_nombField; }
            set { this.publ_nombField = value; }
        }

        private System.String publ_subtField;

        public System.String publ_subt
        {
            get { return this.publ_subtField; }
            set { this.publ_subtField = value; }
        }

    }
}

