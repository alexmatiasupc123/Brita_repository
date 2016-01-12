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
    /// A class that converts a BEInformacion
    /// into a DbCommand that will delete
    /// that BEInformacion.
    /// </summary>
    internal class BEInformacionDeleteFactory : IDeleteFactory<System.Int32>
    {
        /// <summary>
        /// Creates the BEInformacionDeleteFactory to build a delete statement for
        /// the given System.Int32.
        /// </summary>
        /// <param name="System.Int32">System.Int32 to delete from the database.</param>    
        public BEInformacionDeleteFactory()
        {
        }

        #region IDeleteFactory<System.Int32> Members
        public DbCommand ConstructDeleteCommand(Database db, System.Int32 info_codi)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMEliminarInformacion");
            db.AddInParameter(command, "info_codi", DbType.Int32, info_codi);
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
                case "info_codi":
                    return "info_codi";
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }
}

