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
    internal class uspMListarTodosProximamenteFactory : IDomainObjectFactory<BEInformacion>
    {
        public BEInformacion Construct(IDataReader reader)
        {
            BEInformacion bEInformacion = new BEInformacion();

            int info_codiIndex = reader.GetOrdinal("info_codi");
            if (!reader.IsDBNull(info_codiIndex))
            {
                bEInformacion.info_codi = reader.GetInt32(info_codiIndex);

            }

            int info_tituIndex = reader.GetOrdinal("info_titu");
            if (!reader.IsDBNull(info_tituIndex))
            {
                bEInformacion.info_titu = reader.GetString(info_tituIndex);

            }

            int info_descIndex = reader.GetOrdinal("info_desc");
            if (!reader.IsDBNull(info_descIndex))
            {
                bEInformacion.info_desc = reader.GetString(info_descIndex);

            }

            int info_fechIndex = reader.GetOrdinal("info_fech");
            if (!reader.IsDBNull(info_fechIndex))
            {
                bEInformacion.info_fech = reader.GetString(info_fechIndex);

            }

            

            return bEInformacion;
        }
    }
}

