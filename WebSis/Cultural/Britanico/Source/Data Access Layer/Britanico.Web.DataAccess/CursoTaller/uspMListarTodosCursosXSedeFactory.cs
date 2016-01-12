using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Britanico.Web.BusinessEntities;

namespace Britanico.Web.DataAccess
{
    /// <summary>
    /// Construct a bECursoTaller object from a datareader.
    /// </summary>
    internal class uspMListarTodosCursosXSedeFactory : IDomainObjectFactory<BECursoTaller>
    {
        public BECursoTaller Construct(IDataReader reader)
        {
            BECursoTaller bECursoTaller = new BECursoTaller();

            int curs_codiIndex = reader.GetOrdinal("curs_codi");
            if (!reader.IsDBNull(curs_codiIndex))
            {
                bECursoTaller.curs_codi = reader.GetInt32(curs_codiIndex);

            }

            int curs_descIndex = reader.GetOrdinal("curs_desc");
            if (!reader.IsDBNull(curs_descIndex))
            {
                bECursoTaller.curs_desc = reader.GetString(curs_descIndex);

            }

            int curs_diriIndex = reader.GetOrdinal("curs_diri");
            if (!reader.IsDBNull(curs_diriIndex))
            {
                bECursoTaller.curs_diri = reader.GetString(curs_diriIndex);

            }

            int curs_finiIndex = reader.GetOrdinal("curs_fini");
            if (!reader.IsDBNull(curs_finiIndex))
            {
                bECursoTaller.curs_fini = reader.GetDateTime(curs_finiIndex);

            }

            int curs_horaIndex = reader.GetOrdinal("curs_hora");
            if (!reader.IsDBNull(curs_horaIndex))
            {
                bECursoTaller.curs_hora = reader.GetString(curs_horaIndex);

            }

            int curs_infoIndex = reader.GetOrdinal("curs_info");
            if (!reader.IsDBNull(curs_infoIndex))
            {
                bECursoTaller.curs_info = reader.GetString(curs_infoIndex);

            }

            int curs_precIndex = reader.GetOrdinal("curs_prec");
            if (!reader.IsDBNull(curs_precIndex))
            {
                bECursoTaller.curs_prec = reader.GetDecimal(curs_precIndex);

            }

            int curs_prevIndex = reader.GetOrdinal("curs_prev");
            if (!reader.IsDBNull(curs_prevIndex))
            {
                bECursoTaller.curs_prev = reader.GetString(curs_prevIndex);

            }

            int curs_profIndex = reader.GetOrdinal("curs_prof");
            if (!reader.IsDBNull(curs_profIndex))
            {
                bECursoTaller.curs_prof = reader.GetString(curs_profIndex);

            }

            int curs_tituIndex = reader.GetOrdinal("curs_titu");
            if (!reader.IsDBNull(curs_tituIndex))
            {
                bECursoTaller.curs_titu = reader.GetString(curs_tituIndex);

            }

            int sede_codiIndex = reader.GetOrdinal("sede_codi");
            if (!reader.IsDBNull(sede_codiIndex))
            {
                bECursoTaller.sede_codi = reader.GetInt32(sede_codiIndex);

            }

            int segm_codiIndex = reader.GetOrdinal("segm_codi");
            if (!reader.IsDBNull(segm_codiIndex))
            {
                bECursoTaller.segm_codi = reader.GetInt32(segm_codiIndex);

            }


            int curs_imagIndex = reader.GetOrdinal("curs_imag");
            if (!reader.IsDBNull(curs_imagIndex))
            {
                bECursoTaller.curs_imag = reader.GetString(curs_imagIndex);

            }


            int curs_ffinIndex = reader.GetOrdinal("curs_ffin");
            if (!reader.IsDBNull(curs_ffinIndex))
            {
                bECursoTaller.curs_ffin = reader.GetDateTime(curs_ffinIndex);

            }

            return bECursoTaller;
        }
    }
}

