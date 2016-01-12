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
    /// This factory class takes a BEBritanicoRadio object and generates
    /// the dbcommand object needed to call the underlying update
    /// stored proc.
    /// </summary>
    internal class BEBritanicoRadioUpdateFactory : IDbToBusinessEntityNameMapper, IUpdateFactory<BEBritanicoRadio>
    {
        /// <summary>
        /// Creates the BEBritanicoRadioUpdateFactory to build an update statement for
        /// the given BEBritanicoRadio object.
        /// </summary>
        /// <param name="BEBritanicoRadio">BEBritanicoRadio to update into the database.</param>
        public BEBritanicoRadioUpdateFactory()
        {
        }

        #region IUpdateFactory<BEBritanicoRadio> Members

        public DbCommand ConstructUpdateCommand(Database db, BEBritanicoRadio bEBritanicoRadio)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMModificarBritanicoRadio");

            db.AddInParameter(command, "brad_codi", DbType.Int32, bEBritanicoRadio.brad_codi);
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
                case "brad_codi":
                    return "brad_codi";
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

