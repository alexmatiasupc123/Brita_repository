using System;
using System.Collections.Generic;
using System.Text;

namespace Britanico.Web.BusinessEntities
{
    public partial class BESegmentoPublico
    {
        public BESegmentoPublico()
        {
        }

        public BESegmentoPublico(System.Int32 segm_codi, System.String segm_nomb)
        {
            this.segm_codiField = segm_codi;
            this.segm_nombField = segm_nomb;
        }

        private System.Int32 segm_codiField;

        public System.Int32 segm_codi
        {
            get { return this.segm_codiField; }
            set { this.segm_codiField = value; }
        }

        private System.String segm_nombField;

        public System.String segm_nomb
        {
            get { return this.segm_nombField; }
            set { this.segm_nombField = value; }
        }

    }
}

