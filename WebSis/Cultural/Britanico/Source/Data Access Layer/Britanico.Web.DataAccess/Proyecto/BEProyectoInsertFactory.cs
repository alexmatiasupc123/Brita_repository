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
    /// A factory object that is responsible for taking a BEProyecto
    /// and generating the corresponding SQL to insert that
    /// BEProyecto into the database. It also includes a method
    /// to grab the returned ID from the call and updating the
    /// BEProyecto object with it.
    /// </summary>
    internal class BEProyectoInsertFactory : IDbToBusinessEntityNameMapper, IInsertFactory<BEProyecto>
    {
        /// <summary>
        /// Creates the BEProyectoInsertFactory to build an insert statement for
        /// the given BEProyecto object.
        /// </summary>
        /// <param name="BEProyecto">New BEProyecto to insert into the database.</param>
        public BEProyectoInsertFactory()
        {
        }

        #region IInsertFactory<BEProyecto> Members

        public DbCommand ConstructInsertCommand(Database db, BEProyecto bEProyecto)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMAgregarProyecto");

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


            db.AddOutParameter(command, "proy_codi", DbType.Int32, 4);
            return command;
        }

        public void SetNewID(Database db, DbCommand command, BEProyecto bEProyecto)
        {
            System.Int32 id1 = (System.Int32)(db.GetParameterValue(command, "proy_codi"));
            bEProyecto.proy_codi = id1;

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

