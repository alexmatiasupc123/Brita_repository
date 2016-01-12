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
    /// This factory class takes a BESede object and generates
    /// the dbcommand object needed to call the underlying update
    /// stored proc.
    /// </summary>
    internal class BESedeUpdateFactory : IDbToBusinessEntityNameMapper, IUpdateFactory<BESede>
    {
        /// <summary>
        /// Creates the BESedeUpdateFactory to build an update statement for
        /// the given BESede object.
        /// </summary>
        /// <param name="BESede">BESede to update into the database.</param>
        public BESedeUpdateFactory()
        {
        }

        #region IUpdateFactory<BESede> Members

        public DbCommand ConstructUpdateCommand(Database db, BESede bESede)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMModificarSede");

            db.AddInParameter(command, "sede_codi", DbType.Int32, bESede.sede_codi);
            if (bESede.sede_dire != null)
            {
                db.AddInParameter(command, "sede_dire", DbType.String, bESede.sede_dire);
            }
            if (bESede.sede_nomb != null)
            {
                db.AddInParameter(command, "sede_nomb", DbType.String, bESede.sede_nomb);
            }
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
                case "sede_codi":
                    return "sede_codi";
                case "sede_dire":
                    return "sede_dire";
                case "sede_nomb":
                    return "sede_nomb";
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }
}

