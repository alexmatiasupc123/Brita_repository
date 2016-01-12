using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Britanico.Web.BusinessEntities;

namespace Britanico.Web.DataAccess
{
    /// <summary>
    /// Construct a BEConcurso object from a datareader.
    /// </summary>
    internal class uspMListarTodosConcursoFactory : IDomainObjectFactory<BEConcurso>
    {
        public BEConcurso Construct(IDataReader reader)
        {
            BEConcurso bEConcurso = new BEConcurso();

            int conc_codiIndex = reader.GetOrdinal("conc_codi");
            if (!reader.IsDBNull(conc_codiIndex))
            {
                bEConcurso.conc_codi = reader.GetInt32(conc_codiIndex);

            }

            int conc_descIndex = reader.GetOrdinal("conc_desc");
            if (!reader.IsDBNull(conc_descIndex))
            {
                bEConcurso.conc_desc = reader.GetString(conc_descIndex);

            }

            int conc_nombIndex = reader.GetOrdinal("conc_nomb");
            if (!reader.IsDBNull(conc_nombIndex))
            {
                bEConcurso.conc_nomb = reader.GetString(conc_nombIndex);

            }

            int conc_subtIndex = reader.GetOrdinal("conc_subt");
            if (!reader.IsDBNull(conc_subtIndex))
            {
                bEConcurso.conc_subt = reader.GetString(conc_subtIndex);

            }


            return bEConcurso;
        }
    }
}

