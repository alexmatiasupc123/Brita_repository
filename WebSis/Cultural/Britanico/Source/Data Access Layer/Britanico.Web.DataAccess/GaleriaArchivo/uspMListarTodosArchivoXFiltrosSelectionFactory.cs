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
    internal class uspMListarTodosArchivoXFiltrosSelectionFactory : ISelectionFactory<uspMListarTodosArchivoXFiltrosIdentity>
    {
        /// <summary>
        /// Creates the uspMListarTodosArchivoXFiltrosSelectionFactory to build a select statement for
        /// the given uspMListarTodosArchivoXFiltrosIdentity.
        /// </summary>
        /// <param name="uspMListarTodosArchivoXFiltrosIdentity">uspMListarTodosArchivoXFiltrosIdentity to select from the database.</param>      
        public uspMListarTodosArchivoXFiltrosSelectionFactory()
        {
        }

        #region ISelectionFactory<uspMListarTodosArchivoXFiltrosIdentity> Members
        public DbCommand ConstructSelectCommand(Database db, uspMListarTodosArchivoXFiltrosIdentity uspMListarTodosArchivoXFiltrosIdentity)
        {

            DbCommand command = db.GetStoredProcCommand("dbo.uspMListarTodosGaleriaArchivoXFiltro");
          
            db.AddInParameter(command, "idPadre", DbType.Int32, uspMListarTodosArchivoXFiltrosIdentity.idPadre);
            db.AddInParameter(command, "tipoEvento", DbType.Int32, uspMListarTodosArchivoXFiltrosIdentity.tipoEvento);
            db.AddInParameter(command, "tipoArchivo", DbType.String, uspMListarTodosArchivoXFiltrosIdentity.tipoArchivo);
            db.AddInParameter(command, "numPag", DbType.Int32, uspMListarTodosArchivoXFiltrosIdentity.numPag);

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
                case "tipoArchivo":
                    return "tipoArchivo";
                case "numPag":
                    return "numPag";
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }
}

