using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Britanico.Web.BusinessEntities;

namespace Britanico.Web.DataAccess
{
    /// <summary>
    /// Construct a BEPlantillaPermiso object from a datareader.
    /// </summary>
    internal class uspMListarRegistroUsuarioFactory : IDomainObjectFactory<BEUsuario>
    {
        public BEUsuario Construct(IDataReader reader)
        {
            BEUsuario bEUsuario = new BEUsuario();

            int usua_amatIndex = reader.GetOrdinal("usua_amat");
            if (!reader.IsDBNull(usua_amatIndex))
            {
                bEUsuario.usua_amat = reader.GetString(usua_amatIndex);

            }

            int usua_apatIndex = reader.GetOrdinal("usua_apat");
            if (!reader.IsDBNull(usua_apatIndex))
            {
                bEUsuario.usua_apat = reader.GetString(usua_apatIndex);

            }

            int usua_mailIndex = reader.GetOrdinal("usua_mail");
            if (!reader.IsDBNull(usua_mailIndex))
            {
                bEUsuario.usua_mail = reader.GetString(usua_mailIndex);

            }

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

            int usua_nombIndex = reader.GetOrdinal("usua_nomb");
            if (!reader.IsDBNull(usua_nombIndex))
            {
                bEUsuario.usua_nomb = reader.GetString(usua_nombIndex);

            }

           

            int rol_codiIndex = reader.GetOrdinal("rol_codi");
            if (!reader.IsDBNull(rol_codiIndex))
            {
                bEUsuario.rol_codi = reader.GetInt32(rol_codiIndex);

            }


            return bEUsuario;
        }
    }
}

