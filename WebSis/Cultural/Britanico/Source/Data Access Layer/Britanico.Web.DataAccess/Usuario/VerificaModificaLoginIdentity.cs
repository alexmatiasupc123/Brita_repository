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
    internal class VerificaModificaLoginIdentity
    {
        public VerificaModificaLoginIdentity(System.Int32 id, System.String user)

        {
            this.userField = user;
            this.idField = id;
   
        }
        
		private System.String userField;		
		
		public System.String User
		{
			get { return this.userField; }
			set { this.userField = value; }
		}

        private System.Int32 idField;

        public System.Int32 Id
        {
            get { return this.idField; }
            set { this.idField = value; }
        }
     }
}

