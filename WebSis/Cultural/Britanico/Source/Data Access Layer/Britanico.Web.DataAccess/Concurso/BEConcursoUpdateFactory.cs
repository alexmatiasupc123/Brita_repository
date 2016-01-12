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
    /// This factory class takes a BEConcurso object and generates
    /// the dbcommand object needed to call the underlying update
    /// stored proc.
    /// </summary>
    internal class BEConcursoUpdateFactory : IDbToBusinessEntityNameMapper, IUpdateFactory<BEConcurso>
    {
        /// <summary>
        /// Creates the BEConcursoUpdateFactory to build an update statement for
        /// the given BEConcurso object.
        /// </summary>
        /// <param name="BEConcurso">BEConcurso to update into the database.</param>
        public BEConcursoUpdateFactory()
        {
        }

        #region IUpdateFactory<BEConcurso> Members

        public DbCommand ConstructUpdateCommand(Database db, BEConcurso bEConcurso)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMModificarConcurso");

            db.AddInParameter(command, "conc_codi", DbType.Int32, bEConcurso.conc_codi);
            if (bEConcurso.conc_desc != null)
            {
                db.AddInParameter(command, "conc_desc", DbType.String, bEConcurso.conc_desc);
            }
            if (bEConcurso.conc_nomb != null)
            {
                db.AddInParameter(command, "conc_nomb", DbType.String, bEConcurso.conc_nomb);
            }
            if (bEConcurso.conc_subt != null)
            {
                db.AddInParameter(command, "conc_subt", DbType.String, bEConcurso.conc_subt);
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
                case "conc_desc":
                    return "conc_desc";
                case "conc_nomb":
                    return "conc_nomb";
                case "conc_subt":
                    return "conc_subt";
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }
}

