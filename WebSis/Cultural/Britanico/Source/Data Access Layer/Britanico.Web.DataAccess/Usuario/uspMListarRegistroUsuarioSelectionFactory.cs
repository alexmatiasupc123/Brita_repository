using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Britanico.Web.BusinessEntities;
using Britanico.Web.DataAccess.Generic;
using System.Globalization;

namespace Britanico.Web.DataAccess
{
    /// <summary>
    /// This class is responsible for turning a selection criteria
    /// into a select statement and database query parameters.
    /// </summary>
    internal class uspMListarRegistroUsuarioSelectionFactory : ISelectionFactory<uspMListarRegistroUsuarioIdentity>
    {
        /// <summary>
        /// Creates the uspMListarRegistroUsuarioSelectionFactory to build a select statement for
        /// the given uspMListarRegistroUsuarioIdentity.
        /// </summary>
        /// <param name="uspMListarRegistroUsuarioIdentity">uspMListarRegistroUsuarioIdentity to select from the database.</param>      
        public uspMListarRegistroUsuarioSelectionFactory()
        {
        }

		#region ISelectionFactory<uspMListarRegistroUsuarioIdentity> Members
		public DbCommand ConstructSelectCommand(Database db, uspMListarRegistroUsuarioIdentity uspMListarRegistroUsuarioIdentity)
		{
 		
            DbCommand command = db.GetStoredProcCommand("dbo.uspMListarRegistroUsuario");
			db.AddInParameter(command, "user", DbType.Int32, uspMListarRegistroUsuarioIdentity.User);

            return command;
        }
        #endregion
        
        #region IDbToBusinessEntityNameMapper Members
        /// <summary>
        /// Maps a field name in the database (usually a parameter name for a stored proc)
        /// to the corresponding business entity property name.
        /// </summary>
        /// <remarks>This method is intended for error message handling, not for reflection.</remarks>
        /// <param name="dbParameter">Name of field/parameter that the database knows about.</param>
        /// <returns>Corresponding business entity field name.</returns>
        public string MapDbParameterToBusinessEntityProperty(string dbParameter)
        {
            switch (dbParameter)
            {
				
				case "user":
					return "user";

				default:
					throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
			}
        }
        #endregion  
    }
}

