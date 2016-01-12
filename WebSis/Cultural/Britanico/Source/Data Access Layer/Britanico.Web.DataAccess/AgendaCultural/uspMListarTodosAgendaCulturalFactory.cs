using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Britanico.Web.BusinessEntities;

namespace Britanico.Web.DataAccess
{
    /// <summary>
    /// Construct a BEAgendaCultural object from a datareader.
    /// </summary>
    internal class uspMListarTodosAgendaCulturalFactory : IDomainObjectFactory<BEAgendaCultural>
    {
        public BEAgendaCultural Construct(IDataReader reader)
        {
            BEAgendaCultural bEAgendaCultural = new BEAgendaCultural();

            int agen_codiIndex = reader.GetOrdinal("agen_codi");
            if (!reader.IsDBNull(agen_codiIndex))
            {
                bEAgendaCultural.agen_codi = reader.GetInt32(agen_codiIndex);

            }

            int agen_descIndex = reader.GetOrdinal("agen_desc");
            if (!reader.IsDBNull(agen_descIndex))
            {
                bEAgendaCultural.agen_desc = reader.GetString(agen_descIndex);

            }

            int agen_fechIndex = reader.GetOrdinal("agen_fech");
            if (!reader.IsDBNull(agen_fechIndex))
            {
                bEAgendaCultural.agen_fech = reader.GetDateTime(agen_fechIndex);

            }

            int agen_imagIndex = reader.GetOrdinal("agen_imag");
            if (!reader.IsDBNull(agen_imagIndex))
            {
                bEAgendaCultural.agen_imag = reader.GetString(agen_imagIndex);

            }
            int agen_tituIndex = reader.GetOrdinal("agen_titu");
            if (!reader.IsDBNull(agen_tituIndex))
            {
                bEAgendaCultural.agen_titu = reader.GetString(agen_tituIndex);

            }

            
            return bEAgendaCultural;
        }
    }
}

