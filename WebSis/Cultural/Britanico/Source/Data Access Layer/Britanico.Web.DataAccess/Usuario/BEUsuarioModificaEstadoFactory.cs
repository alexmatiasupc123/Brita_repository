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
    /// This factory class takes a BEUsuario object and generates
    /// the dbcommand object needed to call the underlying update
    /// stored proc.
    /// </summary>
    internal class BEUsuarioModificaEstadoFactory : IDbToBusinessEntityNameMapper, IUpdateFactory<BEUsuario>
    {
        /// <summary>
        /// Creates the BEUsuarioModificaEstadoFactory to build an update statement for
        /// the given BEUsuario object.
        /// </summary>
        /// <param name="BEUsuario">BEUsuario to update into the database.</param>
        public BEUsuarioModificaEstadoFactory()
        {
        }

        #region IUpdateFactory<BEUsuario> Members

        public DbCommand ConstructUpdateCommand(Database db, BEUsuario BEUsuario)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMModificarEstadoUsuario");
           
            db.AddInParameter(command, "usua_codi", DbType.Int32, BEUsuario.usua_codi);
         
            db.AddInParameter(command, "usua_esta", DbType.Int32, BEUsuario.usua_esta);
         
           
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
               
                case "usua_codi":
                    return "usua_codi";
              
                case "usua_esta":
                    return "usua_esta";
              
               
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }
}

