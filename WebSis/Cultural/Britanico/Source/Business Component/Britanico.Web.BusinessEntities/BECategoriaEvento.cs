using System;
using System.Collections.Generic;
using System.Text;

namespace Britanico.Web.BusinessEntities
{
    public partial class BECategoriaEvento
    {
        public BECategoriaEvento()
        {
        }

        public BECategoriaEvento(System.Int32 cate_codi, System.String cate_nomb)
        {
            this.cate_codiField = cate_codi;
            this.cate_nombField = cate_nomb;
        }

        private System.Int32 cate_codiField;

        public System.Int32 cate_codi
        {
            get { return this.cate_codiField; }
            set { this.cate_codiField = value; }
        }

        private System.String cate_nombField;

        public System.String cate_nomb
        {
            get { return this.cate_nombField; }
            set { this.cate_nombField = value; }
        }

    }
}

