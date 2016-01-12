using System;
using System.Collections.Generic;
using System.Text;

namespace Britanico.Web.BusinessEntities
{
    public partial class BESuscriptor
    {
        public BESuscriptor()
        {
        }

        public BESuscriptor(System.Int32 susc_codi, System.Int32 susc_esta, System.DateTime susc_fech, System.String susc_mail, System.String susc_nomb)
        {
            this.susc_codiField = susc_codi;
            this.susc_estaField = susc_esta;
            this.susc_fechField = susc_fech;
            this.susc_mailField = susc_mail;
            this.susc_nombField = susc_nomb;
        }

        private System.Int32 susc_codiField;

        public System.Int32 susc_codi
        {
            get { return this.susc_codiField; }
            set { this.susc_codiField = value; }
        }

        private System.Int32 susc_estaField;

        public System.Int32 susc_esta
        {
            get { return this.susc_estaField; }
            set { this.susc_estaField = value; }
        }

        private System.DateTime susc_fechField;

        public System.DateTime susc_fech
        {
            get { return this.susc_fechField; }
            set { this.susc_fechField = value; }
        }

        private System.String susc_mailField;

        public System.String susc_mail
        {
            get { return this.susc_mailField; }
            set { this.susc_mailField = value; }
        }

        private System.String susc_nombField;

        public System.String susc_nomb
        {
            get { return this.susc_nombField; }
            set { this.susc_nombField = value; }
        }

    }
}

