using System;
using System.Collections.Generic;
using System.Text;

namespace Britanico.Web.BusinessEntities
{
    public partial class BEProducciones
    {
        public BEProducciones()
        {
        }

        public BEProducciones(System.String prod_anio, System.Int32 prod_codi, System.String prod_desc, System.String prod_nomb)
        {
            this.prod_anioField = prod_anio;
            this.prod_codiField = prod_codi;
            this.prod_descField = prod_desc;
            this.prod_nombField = prod_nomb;
        }

        private System.String prod_anioField;

        public System.String prod_anio
        {
            get { return this.prod_anioField; }
            set { this.prod_anioField = value; }
        }

        private System.Int32 prod_codiField;

        public System.Int32 prod_codi
        {
            get { return this.prod_codiField; }
            set { this.prod_codiField = value; }
        }

        private System.String prod_descField;

        public System.String prod_desc
        {
            get { return this.prod_descField; }
            set { this.prod_descField = value; }
        }

        private System.String prod_nombField;

        public System.String prod_nomb
        {
            get { return this.prod_nombField; }
            set { this.prod_nombField = value; }
        }

    }
}

