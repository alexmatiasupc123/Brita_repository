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
    /// This factory class takes a BEActividadTeatro object and generates
    /// the dbcommand object needed to call the underlying update
    /// stored proc.
    /// </summary>
    internal class BEActividadTeatroUpdateFactory : IDbToBusinessEntityNameMapper, IUpdateFactory<BEActividadTeatro>
    {
        /// <summary>
        /// Creates the BEActividadTeatroUpdateFactory to build an update statement for
        /// the given BEActividadTeatro object.
        /// </summary>
        /// <param name="BEActividadTeatro">BEActividadTeatro to update into the database.</param>
        public BEActividadTeatroUpdateFactory()
        {
        }

        #region IUpdateFactory<BEActividadTeatro> Members

        public DbCommand ConstructUpdateCommand(Database db, BEActividadTeatro bEActividadTeatro)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMModificarActividad");

            db.AddInParameter(command, "sede_codi", DbType.Int32, bEActividadTeatro.sede_codi);
            db.AddInParameter(command, "segm_codi", DbType.Int32, bEActividadTeatro.segm_codi);
            db.AddInParameter(command, "teat_codi", DbType.Int32, bEActividadTeatro.teat_codi);
            if (bEActividadTeatro.teat_desc != null)
            {
                db.AddInParameter(command, "teat_desc", DbType.String, bEActividadTeatro.teat_desc);
            }
            db.AddInParameter(command, "teat_fint", DbType.DateTime, bEActividadTeatro.teat_fint);
            db.AddInParameter(command, "teat_init", DbType.DateTime, bEActividadTeatro.teat_init);
            if (bEActividadTeatro.teat_titu != null)
            {
                db.AddInParameter(command, "teat_titu", DbType.String, bEActividadTeatro.teat_titu);
            }

            if (bEActividadTeatro.teat_imag != null)
            {
                db.AddInParameter(command, "teat_imag", DbType.String, bEActividadTeatro.teat_imag);
            }
            db.AddInParameter(command, "teat_dest", DbType.Boolean, bEActividadTeatro.teat_dest);

            if (bEActividadTeatro.teat_temp != null)
            {
                db.AddInParameter(command, "teat_temp", DbType.String, bEActividadTeatro.teat_temp);
            }

            if (bEActividadTeatro.teat_subt != null)
            {
                db.AddInParameter(command, "teat_subt", DbType.String, bEActividadTeatro.teat_subt);
            }

            if (bEActividadTeatro.teat_aimg != null)
            {
                db.AddInParameter(command, "teat_aimg", DbType.String, bEActividadTeatro.teat_aimg);
            }

            if (bEActividadTeatro.teat_lfec != null)
            {
                db.AddInParameter(command, "teat_lfec", DbType.String, bEActividadTeatro.teat_lfec);
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
                case "sede_codi":
                    return "sede_codi";
                case "segm_codi":
                    return "segm_codi";
                case "teat_codi":
                    return "teat_codi";
                case "teat_desc":
                    return "teat_desc";
                case "teat_fint":
                    return "teat_fint";
                case "teat_init":
                    return "teat_init";
                case "teat_titu":
                    return "teat_titu";

                case "teat_imag":
                    return "teat_imag";
                case "teat_dest":
                    return "teat_dest";

                case "teat_subt":
                    return "teat_subt";

                case "teat_temp":
                    return "teat_temp";

                case "teat_aimg":
                    return "teat_aimg";

                case "teat_lfec":
                    return "teat_lfec";
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }
}

