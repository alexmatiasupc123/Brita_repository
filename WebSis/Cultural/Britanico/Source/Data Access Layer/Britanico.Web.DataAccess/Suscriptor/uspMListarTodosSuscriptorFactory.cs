using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Britanico.Web.BusinessEntities;

namespace Britanico.Web.DataAccess
{
    /// <summary>
    /// Construct a BESuscriptor object from a datareader.
    /// </summary>
    internal class uspMListarTodosSuscriptorFactory : IDomainObjectFactory<BESuscriptor>
    {
        public BESuscriptor Construct(IDataReader reader)
        {
            BESuscriptor bESuscriptor = new BESuscriptor();

            int susc_codiIndex = reader.GetOrdinal("susc_codi");
            if (!reader.IsDBNull(susc_codiIndex))
            {
                bESuscriptor.susc_codi = reader.GetInt32(susc_codiIndex);

            }

            int susc_estaIndex = reader.GetOrdinal("susc_esta");
            if (!reader.IsDBNull(susc_estaIndex))
            {
                bESuscriptor.susc_esta = reader.GetInt32(susc_estaIndex);

            }

            int susc_fechIndex = reader.GetOrdinal("susc_fech");
            if (!reader.IsDBNull(susc_fechIndex))
            {
                bESuscriptor.susc_fech = reader.GetDateTime(susc_fechIndex);

            }

            int susc_mailIndex = reader.GetOrdinal("susc_mail");
            if (!reader.IsDBNull(susc_mailIndex))
            {
                bESuscriptor.susc_mail = reader.GetString(susc_mailIndex);

            }

            int susc_nombIndex = reader.GetOrdinal("susc_nomb");
            if (!reader.IsDBNull(susc_nombIndex))
            {
                bESuscriptor.susc_nomb = reader.GetString(susc_nombIndex);

            }


            return bESuscriptor;
        }
    }
}

