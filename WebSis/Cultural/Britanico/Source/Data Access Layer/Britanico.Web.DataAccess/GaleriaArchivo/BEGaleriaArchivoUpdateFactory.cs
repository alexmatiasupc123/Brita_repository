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
    /// This factory class takes a BEGaleriaArchivo object and generates
    /// the dbcommand object needed to call the underlying update
    /// stored proc.
    /// </summary>
    internal class BEGaleriaArchivoUpdateFactory : IDbToBusinessEntityNameMapper, IUpdateFactory<BEGaleriaArchivo>
    {
        /// <summary>
        /// Creates the BEGaleriaArchivoUpdateFactory to build an update statement for
        /// the given BEGaleriaArchivo object.
        /// </summary>
        /// <param name="BEGaleriaArchivo">BEGaleriaArchivo to update into the database.</param>
        public BEGaleriaArchivoUpdateFactory()
        {
        }

        #region IUpdateFactory<BEGaleriaArchivo> Members

        public DbCommand ConstructUpdateCommand(Database db, BEGaleriaArchivo bEGaleriaArchivo)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMModificarGaleriaArchivo");

            db.AddInParameter(command, "arch_codi", DbType.Int32, bEGaleriaArchivo.arch_codi);
            if (bEGaleriaArchivo.arch_desc != null)
            {
                db.AddInParameter(command, "arch_desc", DbType.String, bEGaleriaArchivo.arch_desc);
            }
            if (bEGaleriaArchivo.arch_titu != null)
            {
                db.AddInParameter(command, "arch_titu", DbType.String, bEGaleriaArchivo.arch_titu);
            }
            if (bEGaleriaArchivo.arch_arch != null)
            {
                db.AddInParameter(command, "arch_arch", DbType.String, bEGaleriaArchivo.arch_arch);  
            }
            if (bEGaleriaArchivo.arch_link != null)
            {
                db.AddInParameter(command, "arch_link", DbType.String, bEGaleriaArchivo.arch_link);
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
                case "arch_codi":
                    return "arch_codi";
                case "arch_desc":
                    return "arch_desc";
                case "arch_titu":
                    return "arch_titu";
                case "arch_arch":
                    return "arch_arch";
                case "arch_link":
                    return "arch_link";


                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }
}

