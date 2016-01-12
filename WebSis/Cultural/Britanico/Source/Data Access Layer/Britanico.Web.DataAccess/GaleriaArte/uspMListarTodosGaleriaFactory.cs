using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Britanico.Web.BusinessEntities;

namespace Britanico.Web.DataAccess
{
    /// <summary>
    /// Construct a BEGaleriaArte object from a datareader.
    /// </summary>
    internal class uspMListarTodosGaleriaFactory : IDomainObjectFactory<BEGaleriaArte>
    {
        public BEGaleriaArte Construct(IDataReader reader)
        {
            BEGaleriaArte bEGaleriaArte = new BEGaleriaArte();

            int gale_codiIndex = reader.GetOrdinal("gale_codi");
            if (!reader.IsDBNull(gale_codiIndex))
            {
                bEGaleriaArte.gale_codi = reader.GetInt32(gale_codiIndex);

            }


            int sede_codiIndex = reader.GetOrdinal("sede_codi");
            if (!reader.IsDBNull(sede_codiIndex))
            {
                bEGaleriaArte.sede_codi = reader.GetInt32(sede_codiIndex);

            }

            int gale_descIndex = reader.GetOrdinal("gale_desc");
            if (!reader.IsDBNull(gale_descIndex))
            {
                bEGaleriaArte.gale_desc = reader.GetString(gale_descIndex);

            }

            int gale_nombIndex = reader.GetOrdinal("gale_nomb");
            if (!reader.IsDBNull(gale_nombIndex))
            {
                bEGaleriaArte.gale_nomb = reader.GetString(gale_nombIndex);

            }

            int sede_nombIndex = reader.GetOrdinal("sede_nomb");
            if (!reader.IsDBNull(sede_nombIndex))
            {
                bEGaleriaArte.sede_nomb = reader.GetString(sede_nombIndex);

            }


            return bEGaleriaArte;
        }
    }
}

