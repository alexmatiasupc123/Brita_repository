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
    internal class uspMValidaAccesoUsuarioSelectionFactory : ISelectionFactory<uspMValidaAccesoUsuarioIdentity>
    {
        /// <summary>
        /// Creates the uspMValidaAccesoUsuarioSelectionFactory to build a select statement for
        /// the given uspMValidaAccesoUsuarioIdentity.
        /// </summary>
        /// <param name="uspMValidaAccesoUsuarioIdentity">uspMValidaAccesoUsuarioIdentity to select from the database.</param>      
        public uspMValidaAccesoUsuarioSelectionFactory()
        {
        }

        #region ISelectionFactory<uspMValidaAccesoUsuarioIdentity> Members
        public DbCommand ConstructSelectCommand(Database db, uspMValidaAccesoUsuarioIdentity uspMValidaAccesoUsuarioIdentity)
        {

            DbCommand command = db.GetStoredProcCommand("dbo.uspMValidaAccesoUsuario");
           
            db.AddInParameter(command, "usuario", DbType.String, uspMValidaAccesoUsuarioIdentity.Usuario);
            db.AddInParameter(command, "clave", DbType.String, uspMValidaAccesoUsuarioIdentity.Clave);
          
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
          
                case "usuario":
                    return "usuario";
                case "clave":
                    return "clave";
               

             
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }
}

