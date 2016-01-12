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
    /// This factory class takes a BECabecera object and generates
    /// the dbcommand object needed to call the underlying update
    /// stored proc.
    /// </summary>
    internal class BECabeceraUpdateFactory : IDbToBusinessEntityNameMapper, IUpdateFactory<BECabecera>
    {
        /// <summary>
        /// Creates the BECabeceraUpdateFactory to build an update statement for
        /// the given BECabecera object.
        /// </summary>
        /// <param name="BECabecera">BECabecera to update into the database.</param>
        public BECabeceraUpdateFactory()
        {
        }

        #region IUpdateFactory<BECabecera> Members

        public DbCommand ConstructUpdateCommand(Database db, BECabecera bECabecera)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMModificarCabecera");

            db.AddInParameter(command, "cabe_codi", DbType.Int32, bECabecera.cabe_codi);
            if (bECabecera.cabe_imag != null)
            {
                db.AddInParameter(command, "cabe_imag", DbType.String, bECabecera.cabe_imag);
            }
            if (bECabecera.cabe_titu != null)
            {
                db.AddInParameter(command, "cabe_titu", DbType.String, bECabecera.cabe_titu);
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
                case "cabe_codi":
                    return "cabe_codi";
                case "cabe_titu":
                    return "cabe_titu";
                case "cabe_imag":
                    return "cabe_imag";
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }
}

