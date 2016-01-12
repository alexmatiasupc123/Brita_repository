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
    /// A factory object that is responsible for taking a BEProducciones
    /// and generating the corresponding SQL to insert that
    /// BEProducciones into the database. It also includes a method
    /// to grab the returned ID from the call and updating the
    /// BEProducciones object with it.
    /// </summary>
    internal class BEProduccionesInsertFactory : IDbToBusinessEntityNameMapper, IInsertFactory<BEProducciones>
    {
        /// <summary>
        /// Creates the BEProduccionesInsertFactory to build an insert statement for
        /// the given BEProducciones object.
        /// </summary>
        /// <param name="BEProducciones">New BEProducciones to insert into the database.</param>
        public BEProduccionesInsertFactory()
        {
        }

        #region IInsertFactory<BEProducciones> Members

        public DbCommand ConstructInsertCommand(Database db, BEProducciones bEProducciones)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMAgregarProducciones");

            if (bEProducciones.prod_anio != null)
            {
                db.AddInParameter(command, "prod_anio", DbType.String, bEProducciones.prod_anio);
            }
            if (bEProducciones.prod_desc != null)
            {
                db.AddInParameter(command, "prod_desc", DbType.String, bEProducciones.prod_desc);
            }
            if (bEProducciones.prod_nomb != null)
            {
                db.AddInParameter(command, "prod_nomb", DbType.String, bEProducciones.prod_nomb);
            }
            db.AddOutParameter(command, "prod_codi", DbType.Int32, 4);
            return command;
        }

        public void SetNewID(Database db, DbCommand command, BEProducciones bEProducciones)
        {
            System.Int32 id1 = (System.Int32)(db.GetParameterValue(command, "prod_codi"));
            bEProducciones.prod_codi = id1;

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

