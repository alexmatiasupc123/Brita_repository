using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Britanico.Web.BusinessEntities;

namespace Britanico.Web.DataAccess
{
    /// <summary>
    /// Construct a BEActividadTeatro object from a datareader.
    /// </summary>
    internal class uspMListarRegistroActividadFactory : IDomainObjectFactory<BEActividadTeatro>
    {
        public BEActividadTeatro Construct(IDataReader reader)
        {
            BEActividadTeatro bEActividadTeatro = new BEActividadTeatro();

            int sede_codiIndex = reader.GetOrdinal("sede_codi");
            if (!reader.IsDBNull(sede_codiIndex))
            {
                bEActividadTeatro.sede_codi = reader.GetInt32(sede_codiIndex);

            }

            int segm_codiIndex = reader.GetOrdinal("segm_codi");
            if (!reader.IsDBNull(segm_codiIndex))
            {
                bEActividadTeatro.segm_codi = reader.GetInt32(segm_codiIndex);

            }

            int teat_codiIndex = reader.GetOrdinal("teat_codi");
            if (!reader.IsDBNull(teat_codiIndex))
            {
                bEActividadTeatro.teat_codi = reader.GetInt32(teat_codiIndex);

            }

            int teat_descIndex = reader.GetOrdinal("teat_desc");
            if (!reader.IsDBNull(teat_descIndex))
            {
                bEActividadTeatro.teat_desc = reader.GetString(teat_descIndex);

            }

            int teat_fintIndex = reader.GetOrdinal("teat_fint");
            if (!reader.IsDBNull(teat_fintIndex))
            {
                bEActividadTeatro.teat_fint = reader.GetDateTime(teat_fintIndex);

            }

            int teat_initIndex = reader.GetOrdinal("teat_init");
            if (!reader.IsDBNull(teat_initIndex))
            {
                bEActividadTeatro.teat_init = reader.GetDateTime(teat_initIndex);

            }

            int teat_tituIndex = reader.GetOrdinal("teat_titu");
            if (!reader.IsDBNull(teat_tituIndex))
            {
                bEActividadTeatro.teat_titu = reader.GetString(teat_tituIndex);

            }


            int teat_tempIndex = reader.GetOrdinal("teat_temp");
            if (!reader.IsDBNull(teat_tempIndex))
            {
                bEActividadTeatro.teat_temp = reader.GetString(teat_tempIndex);

            }


            int teat_entrIndex = reader.GetOrdinal("teat_entr");
            if (!reader.IsDBNull(teat_entrIndex))
            {
                bEActividadTeatro.teat_entr = reader.GetString(teat_entrIndex);

            }


            int teat_imagIndex = reader.GetOrdinal("teat_imag");
            if (!reader.IsDBNull(teat_imagIndex))
            {
                bEActividadTeatro.teat_imag = reader.GetString(teat_imagIndex);

            }

            int teat_destIndex = reader.GetOrdinal("teat_dest");
            if (!reader.IsDBNull(teat_destIndex))
            {
                bEActividadTeatro.teat_dest = reader.GetBoolean(teat_destIndex);

            }

            int teat_subtIndex = reader.GetOrdinal("teat_subt");
            if (!reader.IsDBNull(teat_subtIndex))
            {
                bEActividadTeatro.teat_subt = reader.GetString(teat_subtIndex);

            }

            int teat_aimgIndex = reader.GetOrdinal("teat_aimg");
            if (!reader.IsDBNull(teat_aimgIndex))
            {
                bEActividadTeatro.teat_aimg = reader.GetString(teat_aimgIndex);

            }


            int teat_lfecIndex = reader.GetOrdinal("teat_lfec");
            if (!reader.IsDBNull(teat_lfecIndex))
            {
                bEActividadTeatro.teat_lfec = reader.GetString(teat_lfecIndex);

            }

            return bEActividadTeatro;
        }
    }
}

