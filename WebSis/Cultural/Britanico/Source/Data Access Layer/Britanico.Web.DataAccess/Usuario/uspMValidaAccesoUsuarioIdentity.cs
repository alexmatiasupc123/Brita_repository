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
    internal class uspMValidaAccesoUsuarioIdentity
    {
        public uspMValidaAccesoUsuarioIdentity(System.String usuario, System.String clave)

        {
            this.usuarioField = usuario;
            this.claveField = clave;
         
          
        
        }

   
		private System.String usuarioField;		
		
		public System.String Usuario
		{
            get { return this.usuarioField; }
            set { this.usuarioField = value; }
		}
		
		private System.String claveField;

        public System.String Clave
		{
            get { return this.claveField; }
            set { this.claveField = value; }
		}
      
    }
}

