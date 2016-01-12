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
    /// A factory object that is responsible for taking a BESede
    /// and generating the corresponding SQL to insert that
    /// BESede into the database. It also includes a method
    /// to grab the returned ID from the call and updating the
    /// BESede object with it.
    /// </summary>
    internal class BESedeInsertFactory : IDbToBusinessEntityNameMapper, IInsertFactory<BESede>
    {
        /// <summary>
        /// Creates the BESedeInsertFactory to build an insert statement for
        /// the given BESede object.
        /// </summary>
        /// <param name="BESede">New BESede to insert into the database.</param>
        public BESedeInsertFactory()
        {
        }

        #region IInsertFactory<BESede> Members

        public DbCommand ConstructInsertCommand(Database db, BESede bESede)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMAgregarSede");

            if (bESede.sede_dire != null)
            {
                db.AddInParameter(command, "sede_dire", DbType.String, bESede.sede_dire);
            }
            if (bESede.sede_nomb != null)
            {
                db.AddInParameter(command, "sede_nomb", DbType.String, bESede.sede_nomb);
            }
            db.AddOutParameter(command, "sede_codi", DbType.Int32, 4);
            return command;
        }

        public void SetNewID(Database db, DbCommand command, BESede bESede)
        {
            System.Int32 id1 = (System.Int32)(db.GetParameterValue(command, "sede_codi"));
            bESede.sede_codi = id1;

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
                case "sede_dire":
                    return "sede_dire";
                case "sede_nomb":
                    return "sede_nomb";
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }

}

