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
    /// A factory object that is responsible for taking a BEConcursoTemporada
    /// and generating the corresponding SQL to insert that
    /// BEConcursoTemporada into the database. It also includes a method
    /// to grab the returned ID from the call and updating the
    /// BEConcursoTemporada object with it.
    /// </summary>
    internal class BEConcursoTemporadaInsertFactory : IDbToBusinessEntityNameMapper, IInsertFactory<BEConcursoTemporada>
    {
        /// <summary>
        /// Creates the BEConcursoTemporadaInsertFactory to build an insert statement for
        /// the given BEConcursoTemporada object.
        /// </summary>
        /// <param name="BEConcursoTemporada">New BEConcursoTemporada to insert into the database.</param>
        public BEConcursoTemporadaInsertFactory()
        {
        }

        #region IInsertFactory<BEConcursoTemporada> Members

        public DbCommand ConstructInsertCommand(Database db, BEConcursoTemporada bEConcursoTemporada)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMAgregarConcursoTemporada");

            db.AddInParameter(command, "conc_codi", DbType.Int32, bEConcursoTemporada.conc_codi);
            if (bEConcursoTemporada.ctem_anio != null)
            {
                db.AddInParameter(command, "ctem_anio", DbType.String, bEConcursoTemporada.ctem_anio);
            }
            if (bEConcursoTemporada.ctem_base != null)
            {
                db.AddInParameter(command, "ctem_base", DbType.String, bEConcursoTemporada.ctem_base);
            }
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

            if (bEConcursoTemporada.ctem_aimg != null)
            {
                db.AddInParameter(command, "ctem_aimg", DbType.String, bEConcursoTemporada.ctem_aimg);
            }

            if (bEConcursoTemporada.ctem_lfec != null)
            {
                db.AddInParameter(command, "ctem_lfec", DbType.String, bEConcursoTemporada.ctem_lfec);
            }

            db.AddOutParameter(command, "ctem_codi", DbType.Int32, 4);
            return command;
        }

        public void SetNewID(Database db, DbCommand command, BEConcursoTemporada bEConcursoTemporada)
        {
            System.Int32 id1 = (System.Int32)(db.GetParameterValue(command, "ctem_codi"));
            bEConcursoTemporada.ctem_codi = id1;

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

