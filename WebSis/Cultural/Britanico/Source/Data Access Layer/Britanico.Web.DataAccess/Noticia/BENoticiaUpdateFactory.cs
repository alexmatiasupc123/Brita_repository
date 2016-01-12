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
    /// This factory class takes a BENoticia object and generates
    /// the dbcommand object needed to call the underlying update
    /// stored proc.
    /// </summary>
    internal class BENoticiaUpdateFactory : IDbToBusinessEntityNameMapper, IUpdateFactory<BENoticia>
    {
        /// <summary>
        /// Creates the BENoticiaUpdateFactory to build an update statement for
        /// the given BENoticia object.
        /// </summary>
        /// <param name="BENoticia">BENoticia to update into the database.</param>
        public BENoticiaUpdateFactory()
        {
        }

        #region IUpdateFactory<BENoticia> Members

        public DbCommand ConstructUpdateCommand(Database db, BENoticia bENoticia)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMModificarNoticia");

            db.AddInParameter(command, "noti_codi", DbType.Int32, bENoticia.noti_codi);
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
                case "noti_codi":
                    return "noti_codi";
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

