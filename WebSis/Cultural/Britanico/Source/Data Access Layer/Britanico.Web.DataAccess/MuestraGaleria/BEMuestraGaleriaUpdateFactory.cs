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
    /// This factory class takes a BEMuestraGaleria object and generates
    /// the dbcommand object needed to call the underlying update
    /// stored proc.
    /// </summary>
    internal class BEMuestraGaleriaUpdateFactory : IDbToBusinessEntityNameMapper, IUpdateFactory<BEMuestraGaleria>
    {
        /// <summary>
        /// Creates the BEMuestraGaleriaUpdateFactory to build an update statement for
        /// the given BEMuestraGaleria object.
        /// </summary>
        /// <param name="BEMuestraGaleria">BEMuestraGaleria to update into the database.</param>
        public BEMuestraGaleriaUpdateFactory()
        {
        }

        #region IUpdateFactory<BEMuestraGaleria> Members

        public DbCommand ConstructUpdateCommand(Database db, BEMuestraGaleria bEMuestraGaleria)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMModificarMuestraGaleria");

            db.AddInParameter(command, "mues_codi", DbType.Int32, bEMuestraGaleria.mues_codi);
            db.AddInParameter(command, "mues_anio", DbType.Int32, bEMuestraGaleria.mues_anio);
            if (bEMuestraGaleria.mues_desc != null)
            {
                db.AddInParameter(command, "mues_desc", DbType.String, bEMuestraGaleria.mues_desc);
            }

            if (bEMuestraGaleria.mues_nomb != null)
            {
                db.AddInParameter(command, "mues_nomb", DbType.String, bEMuestraGaleria.mues_nomb);
            }


            if (bEMuestraGaleria.mues_imag != null)
            {
                db.AddInParameter(command, "mues_imag", DbType.String, bEMuestraGaleria.mues_imag);
            }


            db.AddInParameter(command, "gale_codi", DbType.Int32, bEMuestraGaleria.gale_codi);
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
                case "mues_codi":
                    return "mues_codi";

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

