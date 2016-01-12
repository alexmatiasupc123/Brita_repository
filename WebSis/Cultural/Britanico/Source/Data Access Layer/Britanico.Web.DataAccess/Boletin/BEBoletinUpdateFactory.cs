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
    /// This factory class takes a BEBoletin object and generates
    /// the dbcommand object needed to call the underlying update
    /// stored proc.
    /// </summary>
    internal class BEBoletinUpdateFactory : IDbToBusinessEntityNameMapper, IUpdateFactory<BEBoletin>
    {
        /// <summary>
        /// Creates the BEBoletinUpdateFactory to build an update statement for
        /// the given BEBoletin object.
        /// </summary>
        /// <param name="BEBoletin">BEBoletin to update into the database.</param>
        public BEBoletinUpdateFactory()
        {
        }

        #region IUpdateFactory<BEBoletin> Members

        public DbCommand ConstructUpdateCommand(Database db, BEBoletin bEBoletin)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMModificarBoletin");

            db.AddInParameter(command, "bole_codi", DbType.Int32, bEBoletin.bole_codi);
            db.AddInParameter(command, "bole_fech", DbType.DateTime, bEBoletin.bole_fech);
            if (bEBoletin.bole_nomb != null)
            {
                db.AddInParameter(command, "bole_nomb", DbType.String, bEBoletin.bole_nomb);
            }
            db.AddInParameter(command, "bole_publ", DbType.Boolean, bEBoletin.bole_publ);
            if (bEBoletin.bole_titu != null)
            {
                db.AddInParameter(command, "bole_titu", DbType.String, bEBoletin.bole_titu);
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
                case "bole_codi":
                    return "bole_codi";
                case "bole_fech":
                    return "bole_fech";
                case "bole_nomb":
                    return "bole_nomb";
                case "bole_publ":
                    return "bole_publ";
                case "bole_titu":
                    return "bole_titu";
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }
}

