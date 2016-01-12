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
    /// This class is responsible for turning a selection criteria
    /// into a select statement and database query parameters.
    /// </summary>
    internal class uspMListarTodosSuscriptorXValoresSelectionFactory : ISelectionFactory<uspMListarTodosSuscriptorXValoresIdentity>
    {
        /// <summary>
        /// Creates the uspMListarTodosSuscriptorXValoresSelectionFactory to build a select statement for
        /// the given uspMListarTodosSuscriptorXValoresIdentity.
        /// </summary>
        /// <param name="uspMListarTodosSuscriptorXValoresIdentity">uspMListarTodosSuscriptorXValoresIdentity to select from the database.</param>      
        public uspMListarTodosSuscriptorXValoresSelectionFactory()
        {
        }

        #region ISelectionFactory<uspMListarTodosSuscriptorXValoresIdentity> Members
        public DbCommand ConstructSelectCommand(Database db, uspMListarTodosSuscriptorXValoresIdentity uspMListarTodosSuscriptorXValoresIdentity)
        {

            DbCommand command = db.GetStoredProcCommand("dbo.uspMListarTodosSuscriptoresXValores");
          
            db.AddInParameter(command, "inicio", DbType.DateTime, uspMListarTodosSuscriptorXValoresIdentity.inicio);
            db.AddInParameter(command, "fin", DbType.DateTime, uspMListarTodosSuscriptorXValoresIdentity.fin);
            db.AddInParameter(command, "estado", DbType.Int32, uspMListarTodosSuscriptorXValoresIdentity.estado);

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
              
              
                case "inicio":
                    return "inicio";
                case "fin":
                    return "fin";
                case "estado":
                    return "estado";

                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }
}

