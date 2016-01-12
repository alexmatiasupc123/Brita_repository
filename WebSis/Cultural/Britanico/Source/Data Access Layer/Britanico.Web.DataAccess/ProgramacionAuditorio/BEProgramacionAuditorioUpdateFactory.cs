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
    /// This factory class takes a BEProgramacionAuditorio object and generates
    /// the dbcommand object needed to call the underlying update
    /// stored proc.
    /// </summary>
    internal class BEProgramacionAuditorioUpdateFactory : IDbToBusinessEntityNameMapper, IUpdateFactory<BEProgramacionAuditorio>
    {
        /// <summary>
        /// Creates the BEProgramacionAuditorioUpdateFactory to build an update statement for
        /// the given BEProgramacionAuditorio object.
        /// </summary>
        /// <param name="BEProgramacionAuditorio">BEProgramacionAuditorio to update into the database.</param>
        public BEProgramacionAuditorioUpdateFactory()
        {
        }

        #region IUpdateFactory<BEProgramacionAuditorio> Members

        public DbCommand ConstructUpdateCommand(Database db, BEProgramacionAuditorio bEProgramacionAuditorio)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMModificarProgramacionAuditorio");

            db.AddInParameter(command, "prog_codi", DbType.Int32, bEProgramacionAuditorio.prog_codi);
            if (bEProgramacionAuditorio.prog_desc != null)
            {
                db.AddInParameter(command, "prog_desc", DbType.String, bEProgramacionAuditorio.prog_desc);
            }
            if (bEProgramacionAuditorio.prog_deta != null)
            {
                db.AddInParameter(command, "prog_deta", DbType.String, bEProgramacionAuditorio.prog_deta);
            }
            db.AddInParameter(command, "prog_fini", DbType.DateTime, bEProgramacionAuditorio.prog_fini);

            db.AddInParameter(command, "prog_ffin", DbType.DateTime, bEProgramacionAuditorio.prog_ffin);

            if (bEProgramacionAuditorio.prog_titu != null)
            {
                db.AddInParameter(command, "prog_titu", DbType.String, bEProgramacionAuditorio.prog_titu);
            }

            if (bEProgramacionAuditorio.prog_temp != null)
            {
                db.AddInParameter(command, "prog_temp", DbType.String, bEProgramacionAuditorio.prog_temp);
            }

            db.AddInParameter(command, "sede_codi", DbType.Int32, bEProgramacionAuditorio.sede_codi);

            if (bEProgramacionAuditorio.prog_imag != null)
            {
                db.AddInParameter(command, "prog_imag", DbType.String, bEProgramacionAuditorio.prog_imag);
            }

            db.AddInParameter(command, "prog_dest", DbType.Boolean, bEProgramacionAuditorio.prog_dest);

            if (bEProgramacionAuditorio.prog_aimg != null)
            {
                db.AddInParameter(command, "prog_aimg", DbType.String, bEProgramacionAuditorio.prog_aimg);
            }
            if (bEProgramacionAuditorio.prog_lfec != null)
            {
                db.AddInParameter(command, "prog_lfec", DbType.String, bEProgramacionAuditorio.prog_lfec);
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
                case "prog_codi":
                    return "prog_codi";
                case "prog_desc":
                    return "prog_desc";
                case "prog_deta":
                    return "prog_deta";
                case "prog_fini":
                    return "prog_fini";
                case "prog_ffin":
                    return "prog_ffin";
                case "prog_titu":
                    return "prog_titu";
                case "sede_codi":
                    return "sede_codi";

                case "prog_imag":
                    return "prog_imag";
                case "prog_dest":
                    return "prog_dest";
                case "prog_aimg":
                    return "prog_aimg";
                case "prog_lfec":
                    return "prog_lfec";
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }
}

