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
    /// A class that converts a BEProgramacionAuditorio
    /// into a DbCommand that will delete
    /// that BEProgramacionAuditorio.
    /// </summary>
    internal class BEProgramacionAuditorioDeleteFactory : IDeleteFactory<System.Int32>
    {
        /// <summary>
        /// Creates the BEProgramacionAuditorioDeleteFactory to build a delete statement for
        /// the given System.Int32.
        /// </summary>
        /// <param name="System.Int32">System.Int32 to delete from the database.</param>    
        public BEProgramacionAuditorioDeleteFactory()
        {
        }

        #region IDeleteFactory<System.Int32> Members
        public DbCommand ConstructDeleteCommand(Database db, System.Int32 prog_codi)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMEliminarProgramacionAuditorio");
            db.AddInParameter(command, "prog_codi", DbType.Int32, prog_codi);
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
                case "prog_codi":
                    return "prog_codi";
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }
}
