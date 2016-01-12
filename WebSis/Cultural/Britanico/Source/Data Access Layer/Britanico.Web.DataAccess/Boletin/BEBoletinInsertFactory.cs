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
    /// A factory object that is responsible for taking a BEBoletin
    /// and generating the corresponding SQL to insert that
    /// BEBoletin into the database. It also includes a method
    /// to grab the returned ID from the call and updating the
    /// BEBoletin object with it.
    /// </summary>
    internal class BEBoletinInsertFactory : IDbToBusinessEntityNameMapper, IInsertFactory<BEBoletin>
    {
        /// <summary>
        /// Creates the BEBoletinInsertFactory to build an insert statement for
        /// the given BEBoletin object.
        /// </summary>
        /// <param name="BEBoletin">New BEBoletin to insert into the database.</param>
        public BEBoletinInsertFactory()
        {
        }

        #region IInsertFactory<BEBoletin> Members

        public DbCommand ConstructInsertCommand(Database db, BEBoletin bEBoletin)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMAgregarBoletin");

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
            db.AddOutParameter(command, "bole_codi", DbType.Int32, 4);
            return command;
        }

        public void SetNewID(Database db, DbCommand command, BEBoletin bEBoletin)
        {
            System.Int32 id1 = (System.Int32)(db.GetParameterValue(command, "bole_codi"));
            bEBoletin.bole_codi = id1;

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

