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
    /// A factory object that is responsible for taking a BEConcurso
    /// and generating the corresponding SQL to insert that
    /// BEConcurso into the database. It also includes a method
    /// to grab the returned ID from the call and updating the
    /// BEConcurso object with it.
    /// </summary>
    internal class BEConcursoInsertFactory : IDbToBusinessEntityNameMapper, IInsertFactory<BEConcurso>
    {
        /// <summary>
        /// Creates the BEConcursoInsertFactory to build an insert statement for
        /// the given BEConcurso object.
        /// </summary>
        /// <param name="BEConcurso">New BEConcurso to insert into the database.</param>
        public BEConcursoInsertFactory()
        {
        }

        #region IInsertFactory<BEConcurso> Members

        public DbCommand ConstructInsertCommand(Database db, BEConcurso bEConcurso)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMAgregarConcurso");

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
            db.AddOutParameter(command, "conc_codi", DbType.Int32, 4);
            return command;
        }

        public void SetNewID(Database db, DbCommand command, BEConcurso bEConcurso)
        {
            System.Int32 id1 = (System.Int32)(db.GetParameterValue(command, "conc_codi"));
            bEConcurso.conc_codi = id1;

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

