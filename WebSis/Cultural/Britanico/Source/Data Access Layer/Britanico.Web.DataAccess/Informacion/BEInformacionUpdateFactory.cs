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
    /// This factory class takes a BEInformacion object and generates
    /// the dbcommand object needed to call the underlying update
    /// stored proc.
    /// </summary>
    internal class BEInformacionUpdateFactory : IDbToBusinessEntityNameMapper, IUpdateFactory<BEInformacion>
    {
        /// <summary>
        /// Creates the BEInformacionUpdateFactory to build an update statement for
        /// the given BEInformacion object.
        /// </summary>
        /// <param name="BEInformacion">BEInformacion to update into the database.</param>
        public BEInformacionUpdateFactory()
        {
        }

        #region IUpdateFactory<BEInformacion> Members

        public DbCommand ConstructUpdateCommand(Database db, BEInformacion bEInformacion)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMModificarInformacion");

            db.AddInParameter(command, "info_codi", DbType.Int32, bEInformacion.info_codi);

            db.AddInParameter(command, "even_tipo", DbType.Int32, bEInformacion.even_tipo);  

            
            if (bEInformacion.info_titu != null)
            {
                db.AddInParameter(command, "info_titu", DbType.String, bEInformacion.info_titu);
            }
            if (bEInformacion.info_fech != null)
            {
                db.AddInParameter(command, "info_fech", DbType.String, bEInformacion.info_fech);
            }
            if (bEInformacion.info_desc != null)
            {
                db.AddInParameter(command, "info_desc", DbType.String, bEInformacion.info_desc);
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
                case "info_codi":
                    return "info_codi";
                case "info_titu":
                    return "info_titu";
                case "info_dec":
                    return "info_desc";
                case "info_fech":
                    return "info_fech";
                case "even_tipo":
                    return "even_tipo";
               
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }
}

