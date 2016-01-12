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
    /// A factory object that is responsible for taking a BEBanner
    /// and generating the corresponding SQL to insert that
    /// BEBanner into the database. It also includes a method
    /// to grab the returned ID from the call and updating the
    /// BEBanner object with it.
    /// </summary>
    internal class BEBannerInsertFactory : IDbToBusinessEntityNameMapper, IInsertFactory<BEBanner>
    {
        /// <summary>
        /// Creates the BEBannerInsertFactory to build an insert statement for
        /// the given BEBanner object.
        /// </summary>
        /// <param name="BEBanner">New BEBanner to insert into the database.</param>
        public BEBannerInsertFactory()
        {
        }

        #region IInsertFactory<BEBanner> Members

        public DbCommand ConstructInsertCommand(Database db, BEBanner bEBanner)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMAgregarBanner");

            db.AddInParameter(command, "bann_esta", DbType.Int32, bEBanner.bann_esta);
            db.AddInParameter(command, "bann_fech", DbType.DateTime, bEBanner.bann_fech);
            if (bEBanner.bann_imag != null)
            {
                db.AddInParameter(command, "bann_imag", DbType.String, bEBanner.bann_imag);
            }
            if (bEBanner.bann_titu != null)
            {
                db.AddInParameter(command, "bann_titu", DbType.String, bEBanner.bann_titu);
            }
            if (bEBanner.bann_link != null)
            {
                db.AddInParameter(command, "bann_link", DbType.String, bEBanner.bann_link);
            }

            if (bEBanner.bann_dfec != null)
            {
                db.AddInParameter(command, "bann_dfec", DbType.String, bEBanner.bann_dfec);
            }


            db.AddInParameter(command, "bann_fpri", DbType.Boolean, bEBanner.bann_fpri);
            db.AddInParameter(command, "bann_redsocial", DbType.Boolean, bEBanner.bann_redsocial);


            db.AddOutParameter(command, "bann_codi", DbType.Int32, 4);
            return command;
        }

        public void SetNewID(Database db, DbCommand command, BEBanner bEBanner)
        {
            System.Int32 id1 = (System.Int32)(db.GetParameterValue(command, "bann_codi"));
            bEBanner.bann_codi = id1;

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
                case "bann_esta":
                    return "bann_esta";
                case "bann_fech":
                    return "bann_fech";
                case "bann_imag":
                    return "bann_imag";
                case "bann_titu":
                    return "bann_titu";
                case "bann_link":
                    return "bann_link";
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }

}

