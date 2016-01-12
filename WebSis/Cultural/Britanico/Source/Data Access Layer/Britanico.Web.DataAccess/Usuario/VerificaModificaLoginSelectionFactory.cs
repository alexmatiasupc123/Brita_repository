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
    internal class VerificaModificaLoginSelectionFactory : ISelectionFactory<VerificaModificaLoginIdentity>
    {
        /// <summary>
        /// Creates the VerificaModificaLoginSelectionFactory to build a select statement for
        /// the given VerificaModificaLoginIdentity.
        /// </summary>
        /// <param name="VerificaModificaLoginIdentity">VerificaModificaLoginIdentity to select from the database.</param>      
        public VerificaModificaLoginSelectionFactory()
        {
        }

		#region ISelectionFactory<VerificaModificaLoginIdentity> Members
		public DbCommand ConstructSelectCommand(Database db, VerificaModificaLoginIdentity VerificaModificaLoginIdentity)
		{
 		
            DbCommand command = db.GetStoredProcCommand("dbo.VerificaActualizaLogin");
			db.AddInParameter(command, "user", DbType.String, VerificaModificaLoginIdentity.User);
            db.AddInParameter(command, "id", DbType.Int32, VerificaModificaLoginIdentity.Id);

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

                case "id":
                    return "id";

				default:
					throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
			}
        }
        #endregion  
    }
}

