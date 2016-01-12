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
    /// A factory object that is responsible for taking a BESuscriptor
    /// and generating the corresponding SQL to insert that
    /// BESuscriptor into the database. It also includes a method
    /// to grab the returned ID from the call and updating the
    /// BESuscriptor object with it.
    /// </summary>
    internal class BESuscriptorInsertFactory : IDbToBusinessEntityNameMapper, IInsertFactory<BESuscriptor>
    {
        /// <summary>
        /// Creates the BESuscriptorInsertFactory to build an insert statement for
        /// the given BESuscriptor object.
        /// </summary>
        /// <param name="BESuscriptor">New BESuscriptor to insert into the database.</param>
        public BESuscriptorInsertFactory()
        {
        }

        #region IInsertFactory<BESuscriptor> Members

        public DbCommand ConstructInsertCommand(Database db, BESuscriptor bESuscriptor)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMAgregarSuscriptor");

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
            db.AddOutParameter(command, "susc_codi", DbType.Int32, 4);
            return command;
        }

        public void SetNewID(Database db, DbCommand command, BESuscriptor bESuscriptor)
        {
            System.Int32 id1 = (System.Int32)(db.GetParameterValue(command, "susc_codi"));
            bESuscriptor.susc_codi = id1;

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

