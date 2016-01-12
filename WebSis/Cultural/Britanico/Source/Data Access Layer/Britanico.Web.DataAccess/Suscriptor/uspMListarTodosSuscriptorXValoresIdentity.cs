using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Britanico.Web.BusinessEntities;


namespace Britanico.Web.DataAccess
{
    /// <summary>
    /// This class is specifies the selection criteria
    /// for a Factory
    /// </summary>
    internal class uspMListarTodosSuscriptorXValoresIdentity
    {
        public uspMListarTodosSuscriptorXValoresIdentity(System.DateTime inicio, System.DateTime fin, System.Int32 estado)
        {
            
            this.inicioeField =  inicio;
            this.finField = fin;
            this.estadoField = estado;
         
        }

        private System.DateTime inicioeField;

        public System.DateTime inicio
        {
            get { return this.inicioeField; }
            set { this.inicioeField = value; }
        }


        private System.DateTime finField;

        public System.DateTime fin
        {
            get { return this.finField; }
            set { this.finField = value; }
        }

        private System.Int32 estadoField;

        public System.Int32 estado
        {
            get { return this.estadoField; }
            set { this.estadoField = value; }
        }

      

    }
}

