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
    /// This factory class takes a BEGaleriaArte object and generates
    /// the dbcommand object needed to call the underlying update
    /// stored proc.
    /// </summary>
    internal class BEGaleriaArteUpdateFactory : IDbToBusinessEntityNameMapper, IUpdateFactory<BEGaleriaArte>
    {
        /// <summary>
        /// Creates the BEGaleriaArteUpdateFactory to build an update statement for
        /// the given BEGaleriaArte object.
        /// </summary>
        /// <param name="BEGaleriaArte">BEGaleriaArte to update into the database.</param>
        public BEGaleriaArteUpdateFactory()
        {
        }

        #region IUpdateFactory<BEGaleriaArte> Members

        public DbCommand ConstructUpdateCommand(Database db, BEGaleriaArte bEGaleriaArte)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMModificarGaleria");

            db.AddInParameter(command, "gale_codi", DbType.Int32, bEGaleriaArte.gale_codi);
            if (bEGaleriaArte.gale_desc != null)
            {
                db.AddInParameter(command, "gale_desc", DbType.String, bEGaleriaArte.gale_desc);
            }
            if (bEGaleriaArte.gale_nomb != null)
            {
                db.AddInParameter(command, "gale_nomb", DbType.String, bEGaleriaArte.gale_nomb);
            }
            db.AddInParameter(command, "sede_codi", DbType.Int32, bEGaleriaArte.sede_codi);

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
                case "gale_codi":
                    return "gale_codi";
                case "gale_desc":
                    return "gale_desc";
                case "gale_nomb":
                    return "gale_nomb";

                case "sede_codi":
                    return "sede_codi";
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }
}

