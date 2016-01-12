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
    /// A factory object that is responsible for taking a BEUsuario
    /// and generating the corresponding SQL to insert that
    /// BEUsuario into the database. It also includes a method
    /// to grab the returned ID from the call and updating the
    /// BEUsuario object with it.
    /// </summary>
    internal class BEUsuarioInsertFactory : IDbToBusinessEntityNameMapper, IInsertFactory<BEUsuario>
    {
        /// <summary>
        /// Creates the BEUsuarioInsertFactory to build an insert statement for
        /// the given BEUsuario object.
        /// </summary>
        /// <param name="BEUsuario">New BEUsuario to insert into the database.</param>
        public BEUsuarioInsertFactory()
        {
        }

        #region IInsertFactory<BEUsuario> Members

        public DbCommand ConstructInsertCommand(Database db, BEUsuario BEUsuario)
        {
            DbCommand command = db.GetStoredProcCommand("dbo.uspMAgregaUsuario");

            db.AddInParameter(command, "usua_nomb", DbType.String, BEUsuario.usua_nomb);
            db.AddInParameter(command, "usua_login", DbType.String, BEUsuario.usua_login);
            db.AddInParameter(command, "usua_pass", DbType.String, BEUsuario.usua_pass);
            db.AddInParameter(command, "usua_apat", DbType.String, BEUsuario.usua_apat);
            db.AddInParameter(command, "usua_amat", DbType.String, BEUsuario.usua_amat);
            db.AddInParameter(command, "usua_mail", DbType.String, BEUsuario.usua_mail);
            db.AddInParameter(command, "rol_codi", DbType.Int32, BEUsuario.rol_codi);
            db.AddInParameter(command, "usua_esta", DbType.Int32, BEUsuario.usua_esta);
          

            return command;
        }

        public void SetNewID(Database db, DbCommand command, BEUsuario BEUsuario)
        {
            //TODO: Provide set mapping
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
              
                case "rol_codi":
                    return "rol_codi";
                case "usua_esta":
                    return "usua_esta";
                default:
                    throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, GenericResources.InvalidParameterName), dbParameter);
            }
        }
        #endregion
    }

}

