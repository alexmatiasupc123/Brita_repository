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
    /// This factory class takes a BESuscriptor object and generates
    /// the dbcommand object needed to call the underlying update
    /// stored proc.
    /// </summary>
    internal class BESuscriptorUpdateFactory : IDbToBusinessEntityNameMapper, IUpdateFactory<BESuscriptor>
    {
        /// <summary>
        /// Creates the BESuscriptorUpdateFactory to build an update statement for
        /// the given BESuscriptor object.
        /// </summary>
        /// <param name="BESuscriptor">BESuscriptor to update into the database.</param>
        public BESuscriptorUpdateFactory()
        {
        }

        #region IUpdateFactory<BESuscriptor> Members

        public DbCommand ConstructUpdateCommand(Database db, BESuscriptor bESuscriptor)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMModificarSuscriptor");

            db.AddInParameter(command, "susc_codi", DbType.Int32, bESuscriptor.susc_codi);
            db.AddInParameter(command, "susc_esta", DbType.Int32, bESuscriptor.susc_esta);
            db.AddInParameter(command, "susc_fech", DbType.DateTime, bESuscriptor.susc_fech);
            if (bESuscriptor.susc_mail != null)
            {
                db.AddInParameter(command, "susc_mail", DbType.String, bESuscriptor.susc_mail);
            }
            if (bESuscriptor.susc_nomb != null)
            {
                db.AddInParameter(command, "susc_nomb", DbType.String, bESuscriptor.susc_nomb);
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
                case "susc_codi":
                    return "susc_codi";
                case "susc_esta":
                    return "susc_esta";
                case "susc_fech":
                    return "susc_fech";
                case "susc_mail":
                    return "susc_mail";
                case "susc_nomb":
                    return "susc_nomb";
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }
}

