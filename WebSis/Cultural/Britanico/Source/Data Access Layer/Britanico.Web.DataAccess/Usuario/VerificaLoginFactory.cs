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
    internal class VerificaLoginFactory : IDomainObjectFactory<BEUsuario>
    {
        public BEUsuario Construct(IDataReader reader)
        {
            BEUsuario bEUsuario = new BEUsuario();
         
            int usua_codiIndex = reader.GetOrdinal("usua_codi");
            if (!reader.IsDBNull(usua_codiIndex))
            {
                bEUsuario.usua_codi = reader.GetInt32(usua_codiIndex);

            }

            return bEUsuario;
        }
    }
}

