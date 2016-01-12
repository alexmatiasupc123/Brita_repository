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
    /// This factory class takes a BEProyecto object and generates
    /// the dbcommand object needed to call the underlying update
    /// stored proc.
    /// </summary>
    internal class BEProyectoUpdateFactory : IDbToBusinessEntityNameMapper, IUpdateFactory<BEProyecto>
    {
        /// <summary>
        /// Creates the BEProyectoUpdateFactory to build an update statement for
        /// the given BEProyecto object.
        /// </summary>
        /// <param name="BEProyecto">BEProyecto to update into the database.</param>
        public BEProyectoUpdateFactory()
        {
        }

        #region IUpdateFactory<BEProyecto> Members

        public DbCommand ConstructUpdateCommand(Database db, BEProyecto bEProyecto)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMModificarProyecto");

            db.AddInParameter(command, "proy_codi", DbType.Int32, bEProyecto.proy_codi);
            if (bEProyecto.proy_desc != null)
            {
                db.AddInParameter(command, "proy_desc", DbType.String, bEProyecto.proy_desc);
            }
            if (bEProyecto.proy_nomb != null)
            {
                db.AddInParameter(command, "proy_nomb", DbType.String, bEProyecto.proy_nomb);
            }
            if (bEProyecto.proy_subt != null)
            {
                db.AddInParameter(command, "proy_subt", DbType.String, bEProyecto.proy_subt);
            }

            if (bEProyecto.proy_imag != null)
            {
                db.AddInParameter(command, "proy_imag", DbType.String, bEProyecto.proy_imag);
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
                case "proy_codi":
                    return "proy_codi";
                case "proy_desc":
                    return "proy_desc";
                case "proy_nomb":
                    return "proy_nomb";
                case "proy_subt":
                    return "proy_subt";

                case "proy_imag":
                    return "proy_imag";

                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }
}

