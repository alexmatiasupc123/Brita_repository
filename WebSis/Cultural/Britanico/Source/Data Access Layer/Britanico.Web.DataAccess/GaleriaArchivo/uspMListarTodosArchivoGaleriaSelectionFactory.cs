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
    internal class uspMListarTodosArchivoGaleriaSelectionFactory : ISelectionFactory<uspMListarTodosArchivoGaleriaIdentity>
    {
        /// <summary>
        /// Creates the uspMListarTodosArchivoXValoresSelectionFactory to build a select statement for
        /// the given uspMListarTodosArchivoXValoresIdentity.
        /// </summary>
        /// <param name="uspMListarTodosArchivoXValoresIdentity">uspMListarTodosArchivoXValoresIdentity to select from the database.</param>      
        public uspMListarTodosArchivoGaleriaSelectionFactory()
        {
        }

        #region ISelectionFactory<uspMListarTodosArchivoGaleriaIdentity> Members
        public DbCommand ConstructSelectCommand(Database db, uspMListarTodosArchivoGaleriaIdentity uspMListarTodosArchivoGaleriaIdentity)
        {

            DbCommand command = db.GetStoredProcCommand("dbo.uspMListarTodosGaleriaArchivoGaleria");
          
            db.AddInParameter(command, "idPadre", DbType.Int32, uspMListarTodosArchivoGaleriaIdentity.idPadre);
            db.AddInParameter(command, "tipoEvento", DbType.Int32, uspMListarTodosArchivoGaleriaIdentity.tipoEvento);

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
              
              
                case "idPadre":
                    return "idPadre";
                case "tipoEvento":
                    return "tipoEvento";
               

                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }
}

