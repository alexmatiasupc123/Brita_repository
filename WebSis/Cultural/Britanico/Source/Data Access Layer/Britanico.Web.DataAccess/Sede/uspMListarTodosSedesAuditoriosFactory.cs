using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Britanico.Web.BusinessEntities;

namespace Britanico.Web.DataAccess
{
    /// <summary>
    /// Construct a BESede object from a datareader.
    /// </summary>
    internal class uspMListarTodosSedesAuditoriosFactory : IDomainObjectFactory<BESede>
    {
        public BESede Construct(IDataReader reader)
        {
            BESede bESede = new BESede();

            int sede_codiIndex = reader.GetOrdinal("sede_codi");
            if (!reader.IsDBNull(sede_codiIndex))
            {
                bESede.sede_codi = reader.GetInt32(sede_codiIndex);

            }

     

            int sede_nombIndex = reader.GetOrdinal("sede_nomb");
            if (!reader.IsDBNull(sede_nombIndex))
            {
                bESede.sede_nomb = reader.GetString(sede_nombIndex);

            }


            return bESede;
        }
    }
}

