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
    /// A factory object that is responsible for taking a BENoticia
    /// and generating the corresponding SQL to insert that
    /// BENoticia into the database. It also includes a method
    /// to grab the returned ID from the call and updating the
    /// BENoticia object with it.
    /// </summary>
    internal class BENoticiaInsertFactory : IDbToBusinessEntityNameMapper, IInsertFactory<BENoticia>
    {
        /// <summary>
        /// Creates the BENoticiaInsertFactory to build an insert statement for
        /// the given BENoticia object.
        /// </summary>
        /// <param name="BENoticia">New BENoticia to insert into the database.</param>
        public BENoticiaInsertFactory()
        {
        }

        #region IInsertFactory<BENoticia> Members

        public DbCommand ConstructInsertCommand(Database db, BENoticia bENoticia)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMAgregarNoticia");

            if (bENoticia.noti_desc != null)
            {
                db.AddInParameter(command, "noti_desc", DbType.String, bENoticia.noti_desc);
            }
            db.AddInParameter(command, "noti_fech", DbType.DateTime, bENoticia.noti_fech);
            if (bENoticia.noti_imag != null)
            {
                db.AddInParameter(command, "noti_imag", DbType.String, bENoticia.noti_imag);
            }
            if (bENoticia.noti_subt != null)
            {
                db.AddInParameter(command, "noti_subt", DbType.String, bENoticia.noti_subt);
            }
            if (bENoticia.noti_titu != null)
            {
                db.AddInParameter(command, "noti_titu", DbType.String, bENoticia.noti_titu);
            }
            db.AddOutParameter(command, "noti_codi", DbType.Int32, 4);
            return command;
        }

        public void SetNewID(Database db, DbCommand command, BENoticia bENoticia)
        {
            System.Int32 id1 = (System.Int32)(db.GetParameterValue(command, "noti_codi"));
            bENoticia.noti_codi = id1;

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
                case "noti_desc":
                    return "noti_desc";
                case "noti_fech":
                    return "noti_fech";
                case "noti_imag":
                    return "noti_imag";
                case "noti_subt":
                    return "noti_subt";
                case "noti_titu":
                    return "noti_titu";
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }

}

