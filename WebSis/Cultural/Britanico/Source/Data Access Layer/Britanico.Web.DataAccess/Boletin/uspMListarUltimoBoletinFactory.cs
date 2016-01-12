using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Britanico.Web.BusinessEntities;

namespace Britanico.Web.DataAccess
{
    /// <summary>
    /// Construct a BEBoletin object from a datareader.
    /// </summary>
    internal class uspMListarUltimoBoletinFactory : IDomainObjectFactory<BEBoletin>
    {
        public BEBoletin Construct(IDataReader reader)
        {
            BEBoletin bEBoletin = new BEBoletin();

            int bole_codiIndex = reader.GetOrdinal("bole_codi");
            if (!reader.IsDBNull(bole_codiIndex))
            {
                bEBoletin.bole_codi = reader.GetInt32(bole_codiIndex);

            }

            int bole_fechIndex = reader.GetOrdinal("bole_fech");
            if (!reader.IsDBNull(bole_fechIndex))
            {
                bEBoletin.bole_fech = reader.GetDateTime(bole_fechIndex);

            }

            int bole_nombIndex = reader.GetOrdinal("bole_nomb");
            if (!reader.IsDBNull(bole_nombIndex))
            {
                bEBoletin.bole_nomb = reader.GetString(bole_nombIndex);

            }

            int bole_publIndex = reader.GetOrdinal("bole_publ");
            if (!reader.IsDBNull(bole_publIndex))
            {
                bEBoletin.bole_publ = reader.GetBoolean(bole_publIndex);

            }

            int bole_tituIndex = reader.GetOrdinal("bole_titu");
            if (!reader.IsDBNull(bole_tituIndex))
            {
                bEBoletin.bole_titu = reader.GetString(bole_tituIndex);

            }


            return bEBoletin;
        }
    }
}

