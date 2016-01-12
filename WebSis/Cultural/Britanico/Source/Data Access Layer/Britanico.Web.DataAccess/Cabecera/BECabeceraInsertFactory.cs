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
    /// A factory object that is responsible for taking a BECabecera
    /// and generating the corresponding SQL to insert that
    /// BECabecera into the database. It also includes a method
    /// to grab the returned ID from the call and updating the
    /// BECabecera object with it.
    /// </summary>
    internal class BECabeceraInsertFactory : IDbToBusinessEntityNameMapper, IInsertFactory<BECabecera>
    {
        /// <summary>
        /// Creates the BECabeceraInsertFactory to build an insert statement for
        /// the given BECabecera object.
        /// </summary>
        /// <param name="BECabecera">New BECabecera to insert into the database.</param>
        public BECabeceraInsertFactory()
        {
        }

        #region IInsertFactory<BECabecera> Members

        public DbCommand ConstructInsertCommand(Database db, BECabecera bECabecera)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMAgregarCabecera");
            
            db.AddOutParameter(command, "cabe_codi", DbType.Int32, 4); 

            if (bECabecera.cabe_imag != null)
            {
                db.AddInParameter(command, "cabe_imag", DbType.String, bECabecera.cabe_imag);
            }
            if (bECabecera.cabe_titu != null)
            {
                db.AddInParameter(command, "cabe_titu", DbType.String, bECabecera.cabe_titu);
            }
       
            return command;
        }

        public void SetNewID(Database db, DbCommand command, BECabecera bECabecera)
        {
            System.Int32 id1 = (System.Int32)(db.GetParameterValue(command, "cabe_codi"));
            bECabecera.cabe_codi = id1;

           
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
                case "cabe_codi":
                    return "cabe_codi";
                    return "cabe_imag";
                case "cabe_titu":
                    return "cabe_titu";
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }

}

