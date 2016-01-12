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
    /// A factory object that is responsible for taking a BEGaleriaArchivo
    /// and generating the corresponding SQL to insert that
    /// BEGaleriaArchivo into the database. It also includes a method
    /// to grab the returned ID from the call and updating the
    /// BEGaleriaArchivo object with it.
    /// </summary>
    internal class BEGaleriaArchivoInsertFactory : IDbToBusinessEntityNameMapper, IInsertFactory<BEGaleriaArchivo>
    {
        /// <summary>
        /// Creates the BEGaleriaArchivoInsertFactory to build an insert statement for
        /// the given BEGaleriaArchivo object.
        /// </summary>
        /// <param name="BEGaleriaArchivo">New BEGaleriaArchivo to insert into the database.</param>
        public BEGaleriaArchivoInsertFactory()
        {
        }

        #region IInsertFactory<BEGaleriaArchivo> Members

        public DbCommand ConstructInsertCommand(Database db, BEGaleriaArchivo bEGaleriaArchivo)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMAgregarGaleriaArchivo");

            if (bEGaleriaArchivo.arch_desc != null)
            {
                db.AddInParameter(command, "arch_desc", DbType.String, bEGaleriaArchivo.arch_desc);
            }

            if (bEGaleriaArchivo.arch_titu != null)
            {
                db.AddInParameter(command, "arch_titu", DbType.String, bEGaleriaArchivo.arch_titu);
            }

            db.AddInParameter(command, "padr_codi", DbType.Int32, bEGaleriaArchivo.padr_codi);
           
            if (bEGaleriaArchivo.padr_tipo != null)
            {
                db.AddInParameter(command, "padr_tipo", DbType.String, bEGaleriaArchivo.padr_tipo);
            }

            db.AddInParameter(command, "arch_arch", DbType.String, bEGaleriaArchivo.arch_arch);

            db.AddInParameter(command, "arch_tipo", DbType.String, bEGaleriaArchivo.arch_tipo);

            if (bEGaleriaArchivo.arch_link != null)
            {
                db.AddInParameter(command, "arch_link", DbType.String, bEGaleriaArchivo.arch_link);
            }
            
            db.AddOutParameter(command, "arch_codi", DbType.Int32, 4);
            
            return command;
        }

        public void SetNewID(Database db, DbCommand command, BEGaleriaArchivo bEGaleriaArchivo)
        {
            System.Int32 id1 = (System.Int32)(db.GetParameterValue(command, "arch_codi"));
            bEGaleriaArchivo.arch_codi = id1;

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
                case "arch_desc":
                    return "arch_desc";
                case "arch_titu":
                    return "arch_titu";
                case "padr_codi":
                    return "padr_codi";
                case "padr_tipo":
                    return "padr_tipo";
                case "arch_arch":
                    return "arch_arch";
                case "arch_tipo":
                    return "arch_tipo";
                case "arch_link":
                    return "arch_link";

                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }

}

