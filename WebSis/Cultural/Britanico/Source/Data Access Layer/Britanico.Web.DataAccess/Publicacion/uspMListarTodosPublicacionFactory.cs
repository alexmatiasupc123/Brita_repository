using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Britanico.Web.BusinessEntities;

namespace Britanico.Web.DataAccess
{
    /// <summary>
    /// Construct a BEPublicaciones object from a datareader.
    /// </summary>
    internal class uspMListarTodosPublicacionFactory : IDomainObjectFactory<BEPublicaciones>
    {
        public BEPublicaciones Construct(IDataReader reader)
        {
            BEPublicaciones bEPublicaciones = new BEPublicaciones();

            int publ_codiIndex = reader.GetOrdinal("publ_codi");
            if (!reader.IsDBNull(publ_codiIndex))
            {
                bEPublicaciones.publ_codi = reader.GetInt32(publ_codiIndex);

            }

            int publ_descIndex = reader.GetOrdinal("publ_desc");
            if (!reader.IsDBNull(publ_descIndex))
            {
                bEPublicaciones.publ_desc = reader.GetString(publ_descIndex);

            }

            int publ_nombIndex = reader.GetOrdinal("publ_nomb");
            if (!reader.IsDBNull(publ_nombIndex))
            {
                bEPublicaciones.publ_nomb = reader.GetString(publ_nombIndex);

            }

            int publ_subtIndex = reader.GetOrdinal("publ_subt");
            if (!reader.IsDBNull(publ_subtIndex))
            {
                bEPublicaciones.publ_subt = reader.GetString(publ_subtIndex);

            }


            return bEPublicaciones;
        }
    }
}

