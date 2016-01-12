using System;
using System.Collections.Generic;
using System.Text;

namespace Britanico.Web.BusinessEntities
{
    public partial class BEAnio
    {
        public BEAnio()
        {
        }

        public BEAnio(System.Int32 anio)
        {
            this.anioField = anio;
        }

        private System.Int32 anioField;

        public System.Int32 anio
        {
            get { return this.anioField; }
            set { this.anioField = value; }
        }

   
    }
}

