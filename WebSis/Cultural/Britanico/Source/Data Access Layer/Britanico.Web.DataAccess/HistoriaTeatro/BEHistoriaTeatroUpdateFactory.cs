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
    /// This factory class takes a BEHistoriaTeatro object and generates
    /// the dbcommand object needed to call the underlying update
    /// stored proc.
    /// </summary>
    internal class BEHistoriaTeatroUpdateFactory : IDbToBusinessEntityNameMapper, IUpdateFactory<BEHistoriaTeatro>
    {
        /// <summary>
        /// Creates the BEHistoriaTeatroUpdateFactory to build an update statement for
        /// the given BEHistoriaTeatro object.
        /// </summary>
        /// <param name="BEHistoriaTeatro">BEHistoriaTeatro to update into the database.</param>
        public BEHistoriaTeatroUpdateFactory()
        {
        }

        #region IUpdateFactory<BEHistoriaTeatro> Members

        public DbCommand ConstructUpdateCommand(Database db, BEHistoriaTeatro bEHistoriaTeatro)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMModificarHistoriaTeatro");

            db.AddInParameter(command, "histo_codi", DbType.Int32, bEHistoriaTeatro.histo_codi);

            if (bEHistoriaTeatro.histo_desc != null)
            {
                db.AddInParameter(command, "histo_desc", DbType.String, bEHistoriaTeatro.histo_desc);
            }
            db.AddInParameter(command, "histo_fech", DbType.DateTime, bEHistoriaTeatro.histo_fech);
            if (bEHistoriaTeatro.histo_imag != null)
            {
                db.AddInParameter(command, "histo_imag", DbType.String, bEHistoriaTeatro.histo_imag);
            }
            if (bEHistoriaTeatro.histo_titu != null)
            {
                db.AddInParameter(command, "histo_titu", DbType.String, bEHistoriaTeatro.histo_titu);
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
                case "histo_codi":
                    return "histo_codi";
                case "histo_desc":
                    return "histo_desc";
                case "histo_fech":
                    return "histo_fech";
                case "histo_imag":
                    return "histo_imag";
                case "histo_titu":
                    return "histo_titu";
                
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }
}

