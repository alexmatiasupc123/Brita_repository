﻿using System;
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
    internal class uspMListarRegistroGaleriaArteDetalleSelectionFactory : ISelectionFactory<System.Int32>
    {
        /// <summary>
        /// Creates the uspMListarRegistroGaleriaArteDetalleSelectionFactory to build a select statement for
        /// the given System.Int32.
        /// </summary>
        /// <param name="System.Int32">System.Int32 to select from the database.</param>      
        public uspMListarRegistroGaleriaArteDetalleSelectionFactory()
        {
        }

        #region ISelectionFactory<System.Int32> Members
        public DbCommand ConstructSelectCommand(Database db, System.Int32 gade_codi)
        {

            DbCommand command = db.GetStoredProcCommand("dbo.uspMListarRegistroGaleriaArteDetalle");
            db.AddInParameter(command, "gade_codi", DbType.Int32, gade_codi);
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
                case "gade_codi":
                    return "gade_codi";
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }
}
