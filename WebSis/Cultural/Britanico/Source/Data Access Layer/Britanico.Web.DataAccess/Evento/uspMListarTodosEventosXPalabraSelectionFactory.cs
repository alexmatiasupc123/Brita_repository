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
    internal class uspMListarTodosEventosXPalabraSelectionFactory : ISelectionFactory<System.String>
    {
        /// <summary>
        /// Creates the uspMListarTodosDataSelectionFactory to build a select statement for
        /// the given System.Int32.
        /// </summary>
        /// <param name="System.Int32">System.Int32 to select from the database.</param>      
        public uspMListarTodosEventosXPalabraSelectionFactory()
        {
        }

        #region ISelectionFactory<System.String> Members
        public DbCommand ConstructSelectCommand(Database db, System.String criterio)
        {

            DbCommand command = db.GetStoredProcCommand("dbo.uspMListarTodosEventosXPalabra");
            db.AddInParameter(command, "criterio", DbType.String, criterio);
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
                case "criterio":
                    return "criterio";
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }
}

