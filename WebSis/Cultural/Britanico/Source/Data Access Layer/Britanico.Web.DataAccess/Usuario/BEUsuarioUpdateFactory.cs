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
    internal class BEUsuarioUpdateFactory : IDbToBusinessEntityNameMapper, IUpdateFactory<BEUsuario>
    {
        /// <summary>
        /// Creates the BEUsuarioUpdateFactory to build an update statement for
        /// the given BEUsuario object.
        /// </summary>
        /// <param name="BEUsuario">BEUsuario to update into the database.</param>
        public BEUsuarioUpdateFactory()
        {
        }

        #region IUpdateFactory<BEUsuario> Members

        public DbCommand ConstructUpdateCommand(Database db, BEUsuario BEUsuario)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMModificarUsuario");
           
            db.AddInParameter(command, "usua_codi", DbType.Int32, BEUsuario.usua_codi);
            db.AddInParameter(command, "usua_nomb", DbType.String, BEUsuario.usua_nomb);
            db.AddInParameter(command, "usua_login", DbType.String, BEUsuario.usua_login);
            db.AddInParameter(command, "usua_pass", DbType.String, BEUsuario.usua_pass);
            db.AddInParameter(command, "usua_apat", DbType.String, BEUsuario.usua_apat);
            db.AddInParameter(command, "usua_amat", DbType.String, BEUsuario.usua_amat);
            db.AddInParameter(command, "usua_mail", DbType.String, BEUsuario.usua_mail);
           
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
                case "usua_nomb":
                    return "usua_nomb";
                case "usua_login":
                    return "usua_login";
                case "usua_pass":
                    return "usua_pass";
                case "usua_apat":
                    return "usua_apat";
                case "usua_amat":
                    return "usua_amat";
                case "usua_mail":
                    return "usua_mail";
                case "cana_codi":
                    return "cana_codi";
               
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }
}

