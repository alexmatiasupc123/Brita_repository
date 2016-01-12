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
    /// This factory class takes a BEGaleriaArteDetalle object and generates
    /// the dbcommand object needed to call the underlying update
    /// stored proc.
    /// </summary>
    internal class BEGaleriaArteDetalleUpdateFactory : IDbToBusinessEntityNameMapper, IUpdateFactory<BEGaleriaArteDetalle>
    {
        /// <summary>
        /// Creates the BEGaleriaArteDetalleUpdateFactory to build an update statement for
        /// the given BEGaleriaArteDetalle object.
        /// </summary>
        /// <param name="BEGaleriaArteDetalle">BEGaleriaArteDetalle to update into the database.</param>
        public BEGaleriaArteDetalleUpdateFactory()
        {
        }

        #region IUpdateFactory<BEGaleriaArteDetalle> Members

        public DbCommand ConstructUpdateCommand(Database db, BEGaleriaArteDetalle bEGaleriaArteDetalle)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMModificarGaleriaArteDetalle");

            db.AddInParameter(command, "gade_codi", DbType.Int32, bEGaleriaArteDetalle.gade_codi);
            if (bEGaleriaArteDetalle.gade_desc != null)
            {
                db.AddInParameter(command, "gade_desc", DbType.String, bEGaleriaArteDetalle.gade_desc);
            }
            db.AddInParameter(command, "gade_ffin", DbType.DateTime, bEGaleriaArteDetalle.gade_ffin);
            db.AddInParameter(command, "gade_fini", DbType.DateTime, bEGaleriaArteDetalle.gade_fini);
            if (bEGaleriaArteDetalle.gade_nomb != null)
            {
                db.AddInParameter(command, "gade_nomb", DbType.String, bEGaleriaArteDetalle.gade_nomb);
            }
            if (bEGaleriaArteDetalle.gade_temp != null)
            {
                db.AddInParameter(command, "gade_temp", DbType.String, bEGaleriaArteDetalle.gade_temp);
            }

            if (bEGaleriaArteDetalle.gade_imag != null)
            {
                db.AddInParameter(command, "gade_imag", DbType.String, bEGaleriaArteDetalle.gade_imag);
            }
            db.AddInParameter(command, "gade_dest", DbType.Boolean, bEGaleriaArteDetalle.gade_dest);

            if (bEGaleriaArteDetalle.gade_aimg != null)
            {
                db.AddInParameter(command, "gade_aimg", DbType.String, bEGaleriaArteDetalle.gade_aimg);
            }

            if (bEGaleriaArteDetalle.gade_lfec != null)
            {
                db.AddInParameter(command, "gade_lfec", DbType.String, bEGaleriaArteDetalle.gade_lfec);
            }

            db.AddInParameter(command, "gale_codi", DbType.Int32, bEGaleriaArteDetalle.gale_codi);
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
                case "gade_codi":
                    return "gade_codi";
                case "gade_desc":
                    return "gade_desc";
                case "gade_ffin":
                    return "gade_ffin";
                case "gade_fini":
                    return "gade_fini";
                case "gade_nomb":
                    return "gade_nomb";
                case "gade_temp":
                    return "gade_temp";
                case "gale_codi":
                    return "gale_codi";

                case "gade_imag":
                    return "gade_imag";

                case "gade_dest":
                    return "gade_dest";
                case "gade_aimg":
                    return "gade_aimg";
                case "gade_lfec":
                    return "gade_lfec";
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }
}

