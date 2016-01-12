using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Britanico.Web.BusinessEntities;

namespace Britanico.Web.DataAccess
{
    /// <summary>
    /// Construct a BEUsuario object from a datareader.
    /// </summary>
    internal class uspMValidaAccesoUsuarioFactory : IDomainObjectFactory<BEUsuario>
    {
        public BEUsuario Construct(IDataReader reader)
        {
            BEUsuario bEUsuario = new BEUsuario();

            int usua_codiIndex = reader.GetOrdinal("usua_codi");
            if (!reader.IsDBNull(usua_codiIndex))
            {
                bEUsuario.usua_codi = reader.GetInt32(usua_codiIndex);

            }

        

            int usua_loginIndex = reader.GetOrdinal("usua_login");
            if (!reader.IsDBNull(usua_loginIndex))
            {
                bEUsuario.usua_login = reader.GetString(usua_loginIndex);

            }

           

            return bEUsuario;
        }
    }
}

