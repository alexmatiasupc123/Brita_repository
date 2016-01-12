using System;
using System.Collections.Generic;
using System.Text;

namespace Britanico.Web.BusinessEntities
{
    public partial class BEBritanicoRadio
    {
        public BEBritanicoRadio()
        {
        }

        public BEBritanicoRadio(System.Int32 brad_codi, System.String brad_cond, System.String brad_desc, System.String brad_hora, System.String brad_nomb, System.String brad_radio)
        {
            this.brad_codiField = brad_codi;
            this.brad_condField = brad_cond;
            this.brad_descField = brad_desc;
            this.brad_horaField = brad_hora;
            this.brad_nombField = brad_nomb;
            this.brad_radioField = brad_radio;
        }

        private System.Int32 brad_codiField;

        public System.Int32 brad_codi
        {
            get { return this.brad_codiField; }
            set { this.brad_codiField = value; }
        }

        private System.String brad_condField;

        public System.String brad_cond
        {
            get { return this.brad_condField; }
            set { this.brad_condField = value; }
        }

        private System.String brad_descField;

        public System.String brad_desc
        {
            get { return this.brad_descField; }
            set { this.brad_descField = value; }
        }

        private System.String brad_horaField;

        public System.String brad_hora
        {
            get { return this.brad_horaField; }
            set { this.brad_horaField = value; }
        }

        private System.String brad_nombField;

        public System.String brad_nomb
        {
            get { return this.brad_nombField; }
            set { this.brad_nombField = value; }
        }

        private System.String brad_radioField;

        public System.String brad_radio
        {
            get { return this.brad_radioField; }
            set { this.brad_radioField = value; }
        }

    }
}

