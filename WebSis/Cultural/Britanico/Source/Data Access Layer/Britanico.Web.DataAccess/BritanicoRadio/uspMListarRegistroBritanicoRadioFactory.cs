using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Britanico.Web.BusinessEntities;

namespace Britanico.Web.DataAccess
{
    /// <summary>
    /// Construct a BEBritanicoRadio object from a datareader.
    /// </summary>
    internal class uspMListarRegistroBritanicoRadioFactory : IDomainObjectFactory<BEBritanicoRadio>
    {
        public BEBritanicoRadio Construct(IDataReader reader)
        {
            BEBritanicoRadio bEBritanicoRadio = new BEBritanicoRadio();

            int brad_codiIndex = reader.GetOrdinal("brad_codi");
            if (!reader.IsDBNull(brad_codiIndex))
            {
                bEBritanicoRadio.brad_codi = reader.GetInt32(brad_codiIndex);

            }

            int brad_condIndex = reader.GetOrdinal("brad_cond");
            if (!reader.IsDBNull(brad_condIndex))
            {
                bEBritanicoRadio.brad_cond = reader.GetString(brad_condIndex);

            }

            int brad_descIndex = reader.GetOrdinal("brad_desc");
            if (!reader.IsDBNull(brad_descIndex))
            {
                bEBritanicoRadio.brad_desc = reader.GetString(brad_descIndex);

            }

            int brad_horaIndex = reader.GetOrdinal("brad_hora");
            if (!reader.IsDBNull(brad_horaIndex))
            {
                bEBritanicoRadio.brad_hora = reader.GetString(brad_horaIndex);

            }

            int brad_nombIndex = reader.GetOrdinal("brad_nomb");
            if (!reader.IsDBNull(brad_nombIndex))
            {
                bEBritanicoRadio.brad_nomb = reader.GetString(brad_nombIndex);

            }

            int brad_radioIndex = reader.GetOrdinal("brad_radio");
            if (!reader.IsDBNull(brad_radioIndex))
            {
                bEBritanicoRadio.brad_radio = reader.GetString(brad_radioIndex);

            }


            return bEBritanicoRadio;
        }
    }
}

