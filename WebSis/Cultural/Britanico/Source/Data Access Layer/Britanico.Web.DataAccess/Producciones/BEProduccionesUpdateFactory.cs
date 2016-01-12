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
    /// This factory class takes a BEProducciones object and generates
    /// the dbcommand object needed to call the underlying update
    /// stored proc.
    /// </summary>
    internal class BEProduccionesUpdateFactory : IDbToBusinessEntityNameMapper, IUpdateFactory<BEProducciones>
    {
        /// <summary>
        /// Creates the BEProduccionesUpdateFactory to build an update statement for
        /// the given BEProducciones object.
        /// </summary>
        /// <param name="BEProducciones">BEProducciones to update into the database.</param>
        public BEProduccionesUpdateFactory()
        {
        }

        #region IUpdateFactory<BEProducciones> Members

        public DbCommand ConstructUpdateCommand(Database db, BEProducciones bEProducciones)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMModificarProducciones");

            if (bEProducciones.prod_anio != null)
            {
                db.AddInParameter(command, "prod_anio", DbType.String, bEProducciones.prod_anio);
            }
            db.AddInParameter(command, "prod_codi", DbType.Int32, bEProducciones.prod_codi);
            if (bEProducciones.prod_desc != null)
            {
                db.AddInParameter(command, "prod_desc", DbType.String, bEProducciones.prod_desc);
            }
            if (bEProducciones.prod_nomb != null)
            {
                db.AddInParameter(command, "prod_nomb", DbType.String, bEProducciones.prod_nomb);
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
                case "prod_anio":
                    return "prod_anio";
                case "prod_codi":
                    return "prod_codi";
                case "prod_desc":
                    return "prod_desc";
                case "prod_nomb":
                    return "prod_nomb";
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }
}

