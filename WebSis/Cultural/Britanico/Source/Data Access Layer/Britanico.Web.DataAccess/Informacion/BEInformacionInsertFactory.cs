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
    /// A factory object that is responsible for taking a BEInformacion
    /// and generating the corresponding SQL to insert that
    /// BEInformacion into the database. It also includes a method
    /// to grab the returned ID from the call and updating the
    /// BEInformacion object with it.
    /// </summary>
    internal class BEInformacionInsertFactory : IDbToBusinessEntityNameMapper, IInsertFactory<BEInformacion>
    {
        /// <summary>
        /// Creates the BEInformacionInsertFactory to build an insert statement for
        /// the given BEInformacion object.
        /// </summary>
        /// <param name="BEInformacion">New BEInformacion to insert into the database.</param>
        public BEInformacionInsertFactory()
        {
        }

        #region IInsertFactory<BEInformacion> Members

        public DbCommand ConstructInsertCommand(Database db, BEInformacion bEInformacion)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMAgregarInformacion");

            db.AddInParameter(command, "even_tipo", DbType.Int32, bEInformacion.even_tipo);  

            if (bEInformacion.info_titu != null)
            {
                db.AddInParameter(command, "info_titu", DbType.String, bEInformacion.info_titu);
            }
            if (bEInformacion.info_fech != null)
            {
                db.AddInParameter(command, "info_fech", DbType.String, bEInformacion.info_fech);
            }
            if (bEInformacion.info_desc != null)
            {
                db.AddInParameter(command, "info_desc", DbType.String, bEInformacion.info_desc);
            }
           
            db.AddOutParameter(command, "info_codi", DbType.Int32, 4);
            return command;
        }

        public void SetNewID(Database db, DbCommand command, BEInformacion bEInformacion)
        {
            System.Int32 id1 = (System.Int32)(db.GetParameterValue(command, "info_codi"));
            bEInformacion.info_codi = id1;

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
                case "info_titu":
                    return "info_titu";
                case "info_dec":
                    return "info_desc";
                case "info_fech":
                    return "info_fech";
                case "even_tipo":
                    return "even_tipo";
               
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }

}

