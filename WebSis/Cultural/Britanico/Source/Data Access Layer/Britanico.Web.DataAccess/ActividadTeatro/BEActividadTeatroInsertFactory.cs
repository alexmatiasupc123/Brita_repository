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
    /// A factory object that is responsible for taking a BEActividadTeatro
    /// and generating the corresponding SQL to insert that
    /// BEActividadTeatro into the database. It also includes a method
    /// to grab the returned ID from the call and updating the
    /// BEActividadTeatro object with it.
    /// </summary>
    internal class BEActividadTeatroInsertFactory : IDbToBusinessEntityNameMapper, IInsertFactory<BEActividadTeatro>
    {
        /// <summary>
        /// Creates the BEActividadTeatroInsertFactory to build an insert statement for
        /// the given BEActividadTeatro object.
        /// </summary>
        /// <param name="BEActividadTeatro">New BEActividadTeatro to insert into the database.</param>
        public BEActividadTeatroInsertFactory()
        {
        }

        #region IInsertFactory<BEActividadTeatro> Members

        public DbCommand ConstructInsertCommand(Database db, BEActividadTeatro bEActividadTeatro)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMAgregarActividad");

            db.AddInParameter(command, "sede_codi", DbType.Int32, bEActividadTeatro.sede_codi);
            db.AddInParameter(command, "segm_codi", DbType.Int32, bEActividadTeatro.segm_codi);
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

            if (bEActividadTeatro.teat_subt != null)
            {
                db.AddInParameter(command, "teat_subt", DbType.String, bEActividadTeatro.teat_subt);
            }

            if (bEActividadTeatro.teat_temp != null)
            {
                db.AddInParameter(command, "teat_temp", DbType.String, bEActividadTeatro.teat_temp);
            }

            if (bEActividadTeatro.teat_aimg != null)
            {
                db.AddInParameter(command, "teat_aimg", DbType.String, bEActividadTeatro.teat_aimg);
            }

            if (bEActividadTeatro.teat_lfec != null)
            {
                db.AddInParameter(command, "teat_lfec", DbType.String, bEActividadTeatro.teat_lfec);
            }

            db.AddOutParameter(command, "teat_codi", DbType.Int32, 4);
            return command;
        }

        public void SetNewID(Database db, DbCommand command, BEActividadTeatro bEActividadTeatro)
        {
            System.Int32 id1 = (System.Int32)(db.GetParameterValue(command, "teat_codi"));
            bEActividadTeatro.teat_codi = id1;

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

