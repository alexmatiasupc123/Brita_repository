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
    /// This factory class takes a BEAgendaCultural object and generates
    /// the dbcommand object needed to call the underlying update
    /// stored proc.
    /// </summary>
    internal class BEAgendaCulturalUpdateFactory : IDbToBusinessEntityNameMapper, IUpdateFactory<BEAgendaCultural>
    {
        /// <summary>
        /// Creates the BEAgendaCulturalUpdateFactory to build an update statement for
        /// the given BEAgendaCultural object.
        /// </summary>
        /// <param name="BEAgendaCultural">BEAgendaCultural to update into the database.</param>
        public BEAgendaCulturalUpdateFactory()
        {
        }

        #region IUpdateFactory<BEAgendaCultural> Members

        public DbCommand ConstructUpdateCommand(Database db, BEAgendaCultural bEAgendaCultural)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMModificarAgendaCultural");

            db.AddInParameter(command, "agen_codi", DbType.Int32, bEAgendaCultural.agen_codi);

            if (bEAgendaCultural.agen_desc != null)
            {
                db.AddInParameter(command, "agen_desc", DbType.String, bEAgendaCultural.agen_desc);
            }
            db.AddInParameter(command, "agen_fech", DbType.DateTime, bEAgendaCultural.agen_fech);
            if (bEAgendaCultural.agen_imag != null)
            {
                db.AddInParameter(command, "agen_imag", DbType.String, bEAgendaCultural.agen_imag);
            }
            if (bEAgendaCultural.agen_titu != null)
            {
                db.AddInParameter(command, "agen_titu", DbType.String, bEAgendaCultural.agen_titu);
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
                case "agen_codi":
                    return "agen_codi";
                case "agen_desc":
                    return "agen_desc";
                case "agen_fech":
                    return "agen_fech";
                case "agen_imag":
                    return "agen_imag";
                case "agen_titu":
                    return "agen_titu";
                
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }
}

