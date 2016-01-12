﻿using System;
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
    /// This factory class takes a BECursoTaller object and generates
    /// the dbcommand object needed to call the underlying update
    /// stored proc.
    /// </summary>
    internal class BECursoTallerUpdateFactory : IDbToBusinessEntityNameMapper, IUpdateFactory<BECursoTaller>
    {
        /// <summary>
        /// Creates the BECursoTallerUpdateFactory to build an update statement for
        /// the given BECursoTaller object.
        /// </summary>
        /// <param name="BECursoTaller">BECursoTaller to update into the database.</param>
        public BECursoTallerUpdateFactory()
        {
        }

        #region IUpdateFactory<BECursoTaller> Members

        public DbCommand ConstructUpdateCommand(Database db, BECursoTaller bECursoTaller)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMModificarCurso");

            db.AddInParameter(command, "curs_codi", DbType.Int32, bECursoTaller.curs_codi);
            if (bECursoTaller.curs_desc != null)
            {
                db.AddInParameter(command, "curs_desc", DbType.String, bECursoTaller.curs_desc);
            }
            if (bECursoTaller.curs_diri != null)
            {
                db.AddInParameter(command, "curs_diri", DbType.String, bECursoTaller.curs_diri);
            }
            db.AddInParameter(command, "curs_fini", DbType.DateTime, bECursoTaller.curs_fini);
            if (bECursoTaller.curs_hora != null)
            {
                db.AddInParameter(command, "curs_hora", DbType.String, bECursoTaller.curs_hora);
            }
            if (bECursoTaller.curs_info != null)
            {
                db.AddInParameter(command, "curs_info", DbType.String, bECursoTaller.curs_info);
            }
            db.AddInParameter(command, "curs_prec", DbType.Decimal, bECursoTaller.curs_prec);
            if (bECursoTaller.curs_prev != null)
            {
                db.AddInParameter(command, "curs_prev", DbType.String, bECursoTaller.curs_prev);
            }
            if (bECursoTaller.curs_prof != null)
            {
                db.AddInParameter(command, "curs_prof", DbType.String, bECursoTaller.curs_prof);
            }
            if (bECursoTaller.curs_titu != null)
            {
                db.AddInParameter(command, "curs_titu", DbType.String, bECursoTaller.curs_titu);
            }
            db.AddInParameter(command, "sede_codi", DbType.Int32, bECursoTaller.sede_codi);
            db.AddInParameter(command, "segm_codi", DbType.Int32, bECursoTaller.segm_codi);

            if (bECursoTaller.curs_imag != null)
            {
                db.AddInParameter(command, "curs_imag", DbType.String, bECursoTaller.curs_imag);
            }

            db.AddInParameter(command, "curs_dest", DbType.Boolean, bECursoTaller.curs_dest);
            db.AddInParameter(command, "curs_ffin", DbType.DateTime, bECursoTaller.curs_ffin);

            if (bECursoTaller.curs_aimg != null)
            {
                db.AddInParameter(command, "curs_aimg", DbType.String, bECursoTaller.curs_aimg);
            }

            if (bECursoTaller.curs_lfec != null)
            {
                db.AddInParameter(command, "curs_lfec", DbType.String, bECursoTaller.curs_lfec);
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
                case "curs_codi":
                    return "curs_codi";
                case "curs_desc":
                    return "curs_desc";
                case "curs_diri":
                    return "curs_diri";
                case "curs_fini":
                    return "curs_fini";
                case "curs_hora":
                    return "curs_hora";
                case "curs_info":
                    return "curs_info";
                case "curs_prec":
                    return "curs_prec";
                case "curs_prev":
                    return "curs_prev";
                case "curs_prof":
                    return "curs_prof";
                case "curs_titu":
                    return "curs_titu";
                case "sede_codi":
                    return "sede_codi";
                case "segm_codi":
                    return "segm_codi";

                case "curs_imag":
                    return "curs_imag";

                case "curs_dest":
                    return "curs_dest";

                case "curs_ffin":
                    return "curs_ffin";

                case "curs_aimg":
                    return "curs_aimg";

                case "curs_lfec":
                    return "curs_lfec";
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }
}

