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
    /// A factory object that is responsible for taking a BEAgendaCultural
    /// and generating the corresponding SQL to insert that
    /// BEAgendaCultural into the database. It also includes a method
    /// to grab the returned ID from the call and updating the
    /// BEAgendaCultural object with it.
    /// </summary>
    internal class BEAgendaCulturalInsertFactory : IDbToBusinessEntityNameMapper, IInsertFactory<BEAgendaCultural>
    {
        /// <summary>
        /// Creates the BEAgendaCulturalInsertFactory to build an insert statement for
        /// the given BEAgendaCultural object.
        /// </summary>
        /// <param name="BEAgendaCultural">New BEAgendaCultural to insert into the database.</param>
        public BEAgendaCulturalInsertFactory()
        {
        }

        #region IInsertFactory<BEAgendaCultural> Members

        public DbCommand ConstructInsertCommand(Database db, BEAgendaCultural bEAgendaCultural)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMAgregarAgendaCultural");
            
            db.AddOutParameter(command, "agen_codi", DbType.Int32, 4); 

            if (bEAgendaCultural.agen_desc != null)
            {
                db.AddInParameter(command, "agen_desc", DbType.String, bEAgendaCultural.agen_desc);
            }
            db.AddInParameter(command, "agen_fech", DbType.DateTime, bEAgendaCultural.agen_fech);
            if (bEAgendaCultural.agen_imag != null)
            {
                db.AddInParameter(command, "agen_imag", DbType.String, bEAgendaCultural.agen_imag);
            }
            if (bEAgendaCultural.agen_titu != null)
            {
                db.AddInParameter(command, "agen_titu", DbType.String, bEAgendaCultural.agen_titu);
            }
       
            return command;
        }

        public void SetNewID(Database db, DbCommand command, BEAgendaCultural bEAgendaCultural)
        {
            System.Int32 id1 = (System.Int32)(db.GetParameterValue(command, "agen_codi"));
            bEAgendaCultural.agen_codi = id1;

           
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
                case "agen_codi":
                    return "agen_codi";
                case "agen_desc":
                    return "agen_desc";
                case "agen_fech":
                    return "agen_fech";
                case "agen_imag":
                    return "agen_imag";
                case "agen_titu":
                    return "agen_titu";
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }

}

