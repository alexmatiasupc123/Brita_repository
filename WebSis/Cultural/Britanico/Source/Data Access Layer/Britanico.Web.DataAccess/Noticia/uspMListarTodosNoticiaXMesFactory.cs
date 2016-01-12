using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Britanico.Web.BusinessEntities;

namespace Britanico.Web.DataAccess
{
    /// <summary>
    /// Construct a BENoticia object from a datareader.
    /// </summary>
    internal class uspMListarTodosNoticiaXMesFactory : IDomainObjectFactory<BENoticia>
    {
        public BENoticia Construct(IDataReader reader)
        {
            BENoticia bENoticia = new BENoticia();

            int noti_codiIndex = reader.GetOrdinal("noti_codi");
            if (!reader.IsDBNull(noti_codiIndex))
            {
                bENoticia.noti_codi = reader.GetInt32(noti_codiIndex);

            }

            int noti_descIndex = reader.GetOrdinal("noti_desc");
            if (!reader.IsDBNull(noti_descIndex))
            {
                bENoticia.noti_desc = reader.GetString(noti_descIndex);

            }

            int noti_fechIndex = reader.GetOrdinal("noti_fech");
            if (!reader.IsDBNull(noti_fechIndex))
            {
                bENoticia.noti_fech = reader.GetDateTime(noti_fechIndex);

            }

            int noti_imagIndex = reader.GetOrdinal("noti_imag");
            if (!reader.IsDBNull(noti_imagIndex))
            {
                bENoticia.noti_imag = reader.GetString(noti_imagIndex);

            }

            int noti_subtIndex = reader.GetOrdinal("noti_subt");
            if (!reader.IsDBNull(noti_subtIndex))
            {
                bENoticia.noti_subt = reader.GetString(noti_subtIndex);

            }

            int noti_tituIndex = reader.GetOrdinal("noti_titu");
            if (!reader.IsDBNull(noti_tituIndex))
            {
                bENoticia.noti_titu = reader.GetString(noti_tituIndex);

            }


            return bENoticia;
        }
    }
}

