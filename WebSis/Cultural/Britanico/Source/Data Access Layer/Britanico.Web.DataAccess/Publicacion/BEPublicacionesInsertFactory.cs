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
    /// A factory object that is responsible for taking a BEPublicaciones
    /// and generating the corresponding SQL to insert that
    /// BEPublicaciones into the database. It also includes a method
    /// to grab the returned ID from the call and updating the
    /// BEPublicaciones object with it.
    /// </summary>
    internal class BEPublicacionesInsertFactory : IDbToBusinessEntityNameMapper, IInsertFactory<BEPublicaciones>
    {
        /// <summary>
        /// Creates the BEPublicacionesInsertFactory to build an insert statement for
        /// the given BEPublicaciones object.
        /// </summary>
        /// <param name="BEPublicaciones">New BEPublicaciones to insert into the database.</param>
        public BEPublicacionesInsertFactory()
        {
        }

        #region IInsertFactory<BEPublicaciones> Members

        public DbCommand ConstructInsertCommand(Database db, BEPublicaciones bEPublicaciones)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMAgregarPublicacion");

            if (bEPublicaciones.publ_desc != null)
            {
                db.AddInParameter(command, "publ_desc", DbType.String, bEPublicaciones.publ_desc);
            }
            if (bEPublicaciones.publ_nomb != null)
            {
                db.AddInParameter(command, "publ_nomb", DbType.String, bEPublicaciones.publ_nomb);
            }
            if (bEPublicaciones.publ_subt != null)
            {
                db.AddInParameter(command, "publ_subt", DbType.String, bEPublicaciones.publ_subt);
            }
            db.AddOutParameter(command, "publ_codi", DbType.Int32, 4);
            return command;
        }

        public void SetNewID(Database db, DbCommand command, BEPublicaciones bEPublicaciones)
        {
            System.Int32 id1 = (System.Int32)(db.GetParameterValue(command, "publ_codi"));
            bEPublicaciones.publ_codi = id1;

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
                case "publ_desc":
                    return "publ_desc";
                case "publ_nomb":
                    return "publ_nomb";
                case "publ_subt":
                    return "publ_subt";
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }

}

