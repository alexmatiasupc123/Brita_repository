using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Britanico.Web.BusinessEntities;

namespace Britanico.Web.DataAccess
{
    /// <summary>
    /// Construct a BESegmentoPublico object from a datareader.
    /// </summary>
    internal class uspMListarTodosSegmentoFactory : IDomainObjectFactory<BESegmentoPublico>
    {
        public BESegmentoPublico Construct(IDataReader reader)
        {
            BESegmentoPublico bESegmentoPublico = new BESegmentoPublico();

            int segm_codiIndex = reader.GetOrdinal("segm_codi");
            if (!reader.IsDBNull(segm_codiIndex))
            {
                bESegmentoPublico.segm_codi = reader.GetInt32(segm_codiIndex);

            }

            int segm_nombIndex = reader.GetOrdinal("segm_nomb");
            if (!reader.IsDBNull(segm_nombIndex))
            {
                bESegmentoPublico.segm_nomb = reader.GetString(segm_nombIndex);

            }


            return bESegmentoPublico;
        }
    }
}

