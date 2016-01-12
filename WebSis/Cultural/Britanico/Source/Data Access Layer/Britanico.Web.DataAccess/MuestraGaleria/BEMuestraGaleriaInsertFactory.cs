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
    /// A factory object that is responsible for taking a BEMuestraGaleria
    /// and generating the corresponding SQL to insert that
    /// BEMuestraGaleria into the database. It also includes a method
    /// to grab the returned ID from the call and updating the
    /// BEMuestraGaleria object with it.
    /// </summary>
    internal class BEMuestraGaleriaInsertFactory : IDbToBusinessEntityNameMapper, IInsertFactory<BEMuestraGaleria>
    {
        /// <summary>
        /// Creates the BEMuestraGaleriaInsertFactory to build an insert statement for
        /// the given BEMuestraGaleria object.
        /// </summary>
        /// <param name="BEMuestraGaleria">New BEMuestraGaleria to insert into the database.</param>
        public BEMuestraGaleriaInsertFactory()
        {
        }

        #region IInsertFactory<BEMuestraGaleria> Members

        public DbCommand ConstructInsertCommand(Database db, BEMuestraGaleria bEMuestraGaleria)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMAgregarMuestraGaleria");

            db.AddInParameter(command, "mues_anio", DbType.Int32, bEMuestraGaleria.mues_anio);

            if (bEMuestraGaleria.mues_desc != null)
            {
                db.AddInParameter(command, "mues_desc", DbType.String, bEMuestraGaleria.mues_desc);
            }

            if (bEMuestraGaleria.mues_nomb != null)
            {
                db.AddInParameter(command, "mues_nomb", DbType.String, bEMuestraGaleria.mues_nomb);
            }

            db.AddInParameter(command, "gale_codi", DbType.Int32, bEMuestraGaleria.gale_codi);

            if (bEMuestraGaleria.mues_imag != null)
            {
                db.AddInParameter(command, "mues_imag", DbType.String, bEMuestraGaleria.mues_imag);
            }




            db.AddOutParameter(command, "mues_codi", DbType.Int32, 4);
            return command;
        }

        public void SetNewID(Database db, DbCommand command, BEMuestraGaleria bEMuestraGaleria)
        {
            System.Int32 id1 = (System.Int32)(db.GetParameterValue(command, "mues_codi"));
            bEMuestraGaleria.mues_codi = id1;

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

                case "mues_anio":
                    return "mues_anio";

                case "mues_desc":
                    return "mues_desc";

                case "mues_nomb":
                    return "mues_nomb";

                case "gale_codi":
                    return "gale_codi";

                case "mues_imag":
                    return "mues_imag";

                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }

}

