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
    /// This factory class takes a BEPublicaciones object and generates
    /// the dbcommand object needed to call the underlying update
    /// stored proc.
    /// </summary>
    internal class BEPublicacionesUpdateFactory : IDbToBusinessEntityNameMapper, IUpdateFactory<BEPublicaciones>
    {
        /// <summary>
        /// Creates the BEPublicacionesUpdateFactory to build an update statement for
        /// the given BEPublicaciones object.
        /// </summary>
        /// <param name="BEPublicaciones">BEPublicaciones to update into the database.</param>
        public BEPublicacionesUpdateFactory()
        {
        }

        #region IUpdateFactory<BEPublicaciones> Members

        public DbCommand ConstructUpdateCommand(Database db, BEPublicaciones bEPublicaciones)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMModificarPublicacion");

            db.AddInParameter(command, "publ_codi", DbType.Int32, bEPublicaciones.publ_codi);
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
                case "publ_codi":
                    return "publ_codi";
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

