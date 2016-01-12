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
    internal class uspMListarXTituloCabeceraSelectionFactory : ISelectionFactory<System.String>
    {
        /// <summary>
        /// Creates the uspMListarRegistroCabeceraSelectionFactory to build a select statement for
        /// the given System.Int32.
        /// </summary>
        /// <param name="System.Int32">System.Int32 to select from the database.</param>      
        public uspMListarXTituloCabeceraSelectionFactory()
        {
        }

        #region ISelectionFactory<System.String> Members
        public DbCommand ConstructSelectCommand(Database db, System.String cabe_titu)
        {

            DbCommand command = db.GetStoredProcCommand("dbo.uspMListarXTituloCabecera");
            db.AddInParameter(command, "cabe_titu", DbType.String, cabe_titu);
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
                case "cabe_codi":
                    return "cabe_codi";
                case "cabe_titu":
                    return "cabe_titu";
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }
}

