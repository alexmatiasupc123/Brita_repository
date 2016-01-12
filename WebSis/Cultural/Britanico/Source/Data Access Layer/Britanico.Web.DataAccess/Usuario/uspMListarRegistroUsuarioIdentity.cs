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
    internal class uspMListarRegistroUsuarioIdentity
    {
        public uspMListarRegistroUsuarioIdentity(System.Int32 user)

        {
            this.userField = user;
   
        }
        
		private System.Int32 userField;		
		
		public System.Int32 User
		{
			get { return this.userField; }
			set { this.userField = value; }
		}
     }
}

