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
    /// This factory class takes a BEConcursoTemporada object and generates
    /// the dbcommand object needed to call the underlying update
    /// stored proc.
    /// </summary>
    internal class BEConcursoTemporadaUpdateFactory : IDbToBusinessEntityNameMapper, IUpdateFactory<BEConcursoTemporada>
    {
        /// <summary>
        /// Creates the BEConcursoTemporadaUpdateFactory to build an update statement for
        /// the given BEConcursoTemporada object.
        /// </summary>
        /// <param name="BEConcursoTemporada">BEConcursoTemporada to update into the database.</param>
        public BEConcursoTemporadaUpdateFactory()
        {
        }

        #region IUpdateFactory<BEConcursoTemporada> Members

        public DbCommand ConstructUpdateCommand(Database db, BEConcursoTemporada bEConcursoTemporada)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMModificarConcursoTemporada");

            db.AddInParameter(command, "conc_codi", DbType.Int32, bEConcursoTemporada.conc_codi);
            if (bEConcursoTemporada.ctem_anio != null)
            {
                db.AddInParameter(command, "ctem_anio", DbType.String, bEConcursoTemporada.ctem_anio);
            }
            if (bEConcursoTemporada.ctem_base != null)
            {
                db.AddInParameter(command, "ctem_base", DbType.String, bEConcursoTemporada.ctem_base);
            }
            db.AddInParameter(command, "ctem_codi", DbType.Int32, bEConcursoTemporada.ctem_codi);
            if (bEConcursoTemporada.ctem_jura != null)
            {
                db.AddInParameter(command, "ctem_jura", DbType.String, bEConcursoTemporada.ctem_jura);
            }
            if (bEConcursoTemporada.ctem_prem != null)
            {
                db.AddInParameter(command, "ctem_prem", DbType.String, bEConcursoTemporada.ctem_prem);
            }
            if (bEConcursoTemporada.ctem_result != null)
            {
                db.AddInParameter(command, "ctem_result", DbType.String, bEConcursoTemporada.ctem_result);
            }
            db.AddInParameter(command, "ctem_dest", DbType.Boolean, bEConcursoTemporada.ctem_dest);
            //
            db.AddInParameter(command, "sede_codi", DbType.Int32, bEConcursoTemporada.sede_codi);
            db.AddInParameter(command, "ctem_fini", DbType.Date, bEConcursoTemporada.ctem_fini);
            db.AddInParameter(command, "ctem_ffin", DbType.DateTime, bEConcursoTemporada.ctem_ffin);
            if (bEConcursoTemporada.ctem_temp != null)
            {
                db.AddInParameter(command, "ctem_temp", DbType.String, bEConcursoTemporada.ctem_temp);
            }
            if (bEConcursoTemporada.ctem_imag != null)
            {
                db.AddInParameter(command, "ctem_imag", DbType.String, bEConcursoTemporada.ctem_imag);
            }

            if (bEConcursoTemporada.ctem_aimg!= null)
            {
                db.AddInParameter(command, "ctem_aimg", DbType.String, bEConcursoTemporada.ctem_aimg);
            }

            if (bEConcursoTemporada.ctem_lfec != null)
            {
                db.AddInParameter(command, "ctem_lfec", DbType.String, bEConcursoTemporada.ctem_lfec);
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
                case "conc_codi":
                    return "conc_codi";
                case "ctem_anio":
                    return "ctem_anio";
                case "ctem_base":
                    return "ctem_base";
                case "ctem_codi":
                    return "ctem_codi";
                case "ctem_jura":
                    return "ctem_jura";
                case "ctem_prem":
                    return "ctem_prem";
                case "ctem_result":
                    return "ctem_result";
                case "ctem_dest":
                    return "ctem_dest";

                    //

                case "sede_codi":
                    return "sede_codi";
                case "ctem_fini":
                    return "ctem_fini";
                case "ctem_ffin":
                    return "ctem_ffin";
                case "ctem_temp":
                    return "ctem_temp";
                case "ctem_imag":
                    return "ctem_imag";
                case "ctem_aimg":
                    return "ctem_aimg";
                case "ctem_lfec":
                    return "ctem_lfec";
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }
}

