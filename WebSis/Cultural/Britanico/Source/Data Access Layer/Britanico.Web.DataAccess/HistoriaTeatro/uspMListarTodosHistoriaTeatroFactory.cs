using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Britanico.Web.BusinessEntities;

namespace Britanico.Web.DataAccess
{
    /// <summary>
    /// Construct a BEHistoriaTeatro object from a datareader.
    /// </summary>
    internal class uspMListarTodosHistoriaTeatroFactory : IDomainObjectFactory<BEHistoriaTeatro>
    {
        public BEHistoriaTeatro Construct(IDataReader reader)
        {
            BEHistoriaTeatro bEHistoriaTeatro = new BEHistoriaTeatro();

            int histo_codiIndex = reader.GetOrdinal("histo_codi");
            if (!reader.IsDBNull(histo_codiIndex))
            {
                bEHistoriaTeatro.histo_codi = reader.GetInt32(histo_codiIndex);

            }

            int histo_descIndex = reader.GetOrdinal("histo_desc");
            if (!reader.IsDBNull(histo_descIndex))
            {
                bEHistoriaTeatro.histo_desc = reader.GetString(histo_descIndex);

            }

            int histo_fechIndex = reader.GetOrdinal("histo_fech");
            if (!reader.IsDBNull(histo_fechIndex))
            {
                bEHistoriaTeatro.histo_fech = reader.GetDateTime(histo_fechIndex);

            }

            int histo_imagIndex = reader.GetOrdinal("histo_imag");
            if (!reader.IsDBNull(histo_imagIndex))
            {
                bEHistoriaTeatro.histo_imag = reader.GetString(histo_imagIndex);

            }
            int histo_tituIndex = reader.GetOrdinal("histo_titu");
            if (!reader.IsDBNull(histo_tituIndex))
            {
                bEHistoriaTeatro.histo_titu = reader.GetString(histo_tituIndex);

            }

            
            return bEHistoriaTeatro;
        }
    }
}

