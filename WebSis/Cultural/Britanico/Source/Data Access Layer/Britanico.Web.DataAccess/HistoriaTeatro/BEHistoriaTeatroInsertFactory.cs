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
    /// A factory object that is responsible for taking a BEHistoriaTeatro
    /// and generating the corresponding SQL to insert that
    /// BEHistoriaTeatro into the database. It also includes a method
    /// to grab the returned ID from the call and updating the
    /// BEHistoriaTeatro object with it.
    /// </summary>
    internal class BEHistoriaTeatroInsertFactory : IDbToBusinessEntityNameMapper, IInsertFactory<BEHistoriaTeatro>
    {
        /// <summary>
        /// Creates the BEHistoriaTeatroInsertFactory to build an insert statement for
        /// the given BEHistoriaTeatro object.
        /// </summary>
        /// <param name="BEHistoriaTeatro">New BEHistoriaTeatro to insert into the database.</param>
        public BEHistoriaTeatroInsertFactory()
        {
        }

        #region IInsertFactory<BEHistoriaTeatro> Members

        public DbCommand ConstructInsertCommand(Database db, BEHistoriaTeatro bEHistoriaTeatro)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMAgregarHistoriaTeatro");
            
            db.AddOutParameter(command, "histo_codi", DbType.Int32, 4); 

            if (bEHistoriaTeatro.histo_desc != null)
            {
                db.AddInParameter(command, "histo_desc", DbType.String, bEHistoriaTeatro.histo_desc);
            }
            db.AddInParameter(command, "histo_fech", DbType.DateTime, bEHistoriaTeatro.histo_fech);
            if (bEHistoriaTeatro.histo_imag != null)
            {
                db.AddInParameter(command, "histo_imag", DbType.String, bEHistoriaTeatro.histo_imag);
            }
            if (bEHistoriaTeatro.histo_titu != null)
            {
                db.AddInParameter(command, "histo_titu", DbType.String, bEHistoriaTeatro.histo_titu);
            }
       
            return command;
        }

        public void SetNewID(Database db, DbCommand command, BEHistoriaTeatro bEHistoriaTeatro)
        {
            System.Int32 id1 = (System.Int32)(db.GetParameterValue(command, "histo_codi"));
            bEHistoriaTeatro.histo_codi = id1;

           
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
                case "histo_codi":
                    return "histo_codi";
                case "histo_desc":
                    return "histo_desc";
                case "histo_fech":
                    return "histo_fech";
                case "histo_imag":
                    return "histo_imag";
                case "histo_titu":
                    return "histo_titu";
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }

}

