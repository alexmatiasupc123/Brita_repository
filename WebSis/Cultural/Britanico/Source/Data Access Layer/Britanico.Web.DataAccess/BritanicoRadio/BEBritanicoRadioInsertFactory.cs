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
    /// A factory object that is responsible for taking a BEBritanicoRadio
    /// and generating the corresponding SQL to insert that
    /// BEBritanicoRadio into the database. It also includes a method
    /// to grab the returned ID from the call and updating the
    /// BEBritanicoRadio object with it.
    /// </summary>
    internal class BEBritanicoRadioInsertFactory : IDbToBusinessEntityNameMapper, IInsertFactory<BEBritanicoRadio>
    {
        /// <summary>
        /// Creates the BEBritanicoRadioInsertFactory to build an insert statement for
        /// the given BEBritanicoRadio object.
        /// </summary>
        /// <param name="BEBritanicoRadio">New BEBritanicoRadio to insert into the database.</param>
        public BEBritanicoRadioInsertFactory()
        {
        }

        #region IInsertFactory<BEBritanicoRadio> Members

        public DbCommand ConstructInsertCommand(Database db, BEBritanicoRadio bEBritanicoRadio)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMAgregarBritanicoRadio");

            if (bEBritanicoRadio.brad_cond != null)
            {
                db.AddInParameter(command, "brad_cond", DbType.String, bEBritanicoRadio.brad_cond);
            }
            if (bEBritanicoRadio.brad_desc != null)
            {
                db.AddInParameter(command, "brad_desc", DbType.String, bEBritanicoRadio.brad_desc);
            }
            if (bEBritanicoRadio.brad_hora != null)
            {
                db.AddInParameter(command, "brad_hora", DbType.String, bEBritanicoRadio.brad_hora);
            }
            if (bEBritanicoRadio.brad_nomb != null)
            {
                db.AddInParameter(command, "brad_nomb", DbType.String, bEBritanicoRadio.brad_nomb);
            }
            if (bEBritanicoRadio.brad_radio != null)
            {
                db.AddInParameter(command, "brad_radio", DbType.String, bEBritanicoRadio.brad_radio);
            }
            db.AddOutParameter(command, "brad_codi", DbType.Int32, 4);
            return command;
        }

        public void SetNewID(Database db, DbCommand command, BEBritanicoRadio bEBritanicoRadio)
        {
            System.Int32 id1 = (System.Int32)(db.GetParameterValue(command, "brad_codi"));
            bEBritanicoRadio.brad_codi = id1;

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
                case "brad_cond":
                    return "brad_cond";
                case "brad_desc":
                    return "brad_desc";
                case "brad_hora":
                    return "brad_hora";
                case "brad_nomb":
                    return "brad_nomb";
                case "brad_radio":
                    return "brad_radio";
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }

}

