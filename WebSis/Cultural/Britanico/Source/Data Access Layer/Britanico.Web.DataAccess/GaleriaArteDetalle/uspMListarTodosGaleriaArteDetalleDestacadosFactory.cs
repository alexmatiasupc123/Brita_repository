using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Britanico.Web.BusinessEntities;

namespace Britanico.Web.DataAccess
{
    /// <summary>
    /// Construct a BEGaleriaArteDetalle object from a datareader.
    /// </summary>
    internal class uspMListarTodosGaleriaArteDetalleDestacadosFactory : IDomainObjectFactory<BEGaleriaArteDetalle>
    {
        public BEGaleriaArteDetalle Construct(IDataReader reader)
        {
            BEGaleriaArteDetalle bEGaleriaArteDetalle = new BEGaleriaArteDetalle();

            int gade_codiIndex = reader.GetOrdinal("gade_codi");
            if (!reader.IsDBNull(gade_codiIndex))
            {
                bEGaleriaArteDetalle.gade_codi = reader.GetInt32(gade_codiIndex);

            }

            int gade_descIndex = reader.GetOrdinal("gade_desc");
            if (!reader.IsDBNull(gade_descIndex))
            {
                bEGaleriaArteDetalle.gade_desc = reader.GetString(gade_descIndex);

            }

            int gade_ffinIndex = reader.GetOrdinal("gade_ffin");
            if (!reader.IsDBNull(gade_ffinIndex))
            {
                bEGaleriaArteDetalle.gade_ffin = reader.GetDateTime(gade_ffinIndex);

            }

            int gade_finiIndex = reader.GetOrdinal("gade_fini");
            if (!reader.IsDBNull(gade_finiIndex))
            {
                bEGaleriaArteDetalle.gade_fini = reader.GetDateTime(gade_finiIndex);

            }

            int gade_nombIndex = reader.GetOrdinal("gade_nomb");
            if (!reader.IsDBNull(gade_nombIndex))
            {
                bEGaleriaArteDetalle.gade_nomb = reader.GetString(gade_nombIndex);

            }

            int gade_tempIndex = reader.GetOrdinal("gade_temp");
            if (!reader.IsDBNull(gade_tempIndex))
            {
                bEGaleriaArteDetalle.gade_temp = reader.GetString(gade_tempIndex);

            }

            int gale_codiIndex = reader.GetOrdinal("gale_codi");
            if (!reader.IsDBNull(gale_codiIndex))
            {
                bEGaleriaArteDetalle.gale_codi = reader.GetInt32(gale_codiIndex);

            }

         
            
            return bEGaleriaArteDetalle;
        }
    }
}

