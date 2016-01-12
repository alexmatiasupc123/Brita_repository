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
    /// A factory object that is responsible for taking a BEGaleriaArte
    /// and generating the corresponding SQL to insert that
    /// BEGaleriaArte into the database. It also includes a method
    /// to grab the returned ID from the call and updating the
    /// BEGaleriaArte object with it.
    /// </summary>
    internal class BEGaleriaArteInsertFactory : IDbToBusinessEntityNameMapper, IInsertFactory<BEGaleriaArte>
    {
        /// <summary>
        /// Creates the BEGaleriaArteInsertFactory to build an insert statement for
        /// the given BEGaleriaArte object.
        /// </summary>
        /// <param name="BEGaleriaArte">New BEGaleriaArte to insert into the database.</param>
        public BEGaleriaArteInsertFactory()
        {
        }

        #region IInsertFactory<BEGaleriaArte> Members

        public DbCommand ConstructInsertCommand(Database db, BEGaleriaArte bEGaleriaArte)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMAgregarGaleria");

            if (bEGaleriaArte.gale_desc != null)
            {
                db.AddInParameter(command, "gale_desc", DbType.String, bEGaleriaArte.gale_desc);
            }
            if (bEGaleriaArte.gale_nomb != null)
            {
                db.AddInParameter(command, "gale_nomb", DbType.String, bEGaleriaArte.gale_nomb);
            }

            db.AddInParameter(command, "sede_codi", DbType.Int32, bEGaleriaArte.sede_codi);

            db.AddOutParameter(command, "gale_codi", DbType.Int32, 4);
            return command;
        }

        public void SetNewID(Database db, DbCommand command, BEGaleriaArte bEGaleriaArte)
        {
            System.Int32 id1 = (System.Int32)(db.GetParameterValue(command, "gale_codi"));
            bEGaleriaArte.gale_codi = id1;

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

