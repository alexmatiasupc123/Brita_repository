using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Britanico.Web.BusinessEntities;

namespace Britanico.Web.DataAccess
{
    /// <summary>
    /// Construct a BEProgramacionAuditorio object from a datareader.
    /// </summary>
    internal class uspMListarTodosConcursoTemporadaXConcursoFactory : IDomainObjectFactory<BEConcursoTemporada>
    {
        public BEConcursoTemporada Construct(IDataReader reader)
        {
            BEConcursoTemporada bEConcursoTemporada = new BEConcursoTemporada();

            int conc_codiIndex = reader.GetOrdinal("conc_codi");
            if (!reader.IsDBNull(conc_codiIndex))
            {
                bEConcursoTemporada.conc_codi = reader.GetInt32(conc_codiIndex);

            }

            int ctem_anioIndex = reader.GetOrdinal("ctem_anio");
            if (!reader.IsDBNull(ctem_anioIndex))
            {
                bEConcursoTemporada.ctem_anio = reader.GetString(ctem_anioIndex);

            }

            int ctem_baseIndex = reader.GetOrdinal("ctem_base");
            if (!reader.IsDBNull(ctem_baseIndex))
            {
                bEConcursoTemporada.ctem_base = reader.GetString(ctem_baseIndex);

            }

            int ctem_codiIndex = reader.GetOrdinal("ctem_codi");
            if (!reader.IsDBNull(ctem_codiIndex))
            {
                bEConcursoTemporada.ctem_codi = reader.GetInt32(ctem_codiIndex);

            }

            int ctem_juraIndex = reader.GetOrdinal("ctem_jura");
            if (!reader.IsDBNull(ctem_juraIndex))
            {
                bEConcursoTemporada.ctem_jura = reader.GetString(ctem_juraIndex);

            }

            int ctem_premIndex = reader.GetOrdinal("ctem_prem");
            if (!reader.IsDBNull(ctem_premIndex))
            {
                bEConcursoTemporada.ctem_prem = reader.GetString(ctem_premIndex);

            }

            int ctem_resultIndex = reader.GetOrdinal("ctem_result");
            if (!reader.IsDBNull(ctem_resultIndex))
            {
                bEConcursoTemporada.ctem_result = reader.GetString(ctem_resultIndex);

            }

            //

            int sede_codiIndex = reader.GetOrdinal("sede_codi");
            if (!reader.IsDBNull(sede_codiIndex))
            {
                bEConcursoTemporada.sede_codi = reader.GetInt32(sede_codiIndex);

            }

            int ctem_finiIndex = reader.GetOrdinal("ctem_fini");
            if (!reader.IsDBNull(ctem_finiIndex))
            {
                bEConcursoTemporada.ctem_fini = reader.GetDateTime(ctem_finiIndex);

            }

            int ctem_ffinIndex = reader.GetOrdinal("ctem_ffin");
            if (!reader.IsDBNull(ctem_ffinIndex))
            {
                bEConcursoTemporada.ctem_ffin = reader.GetDateTime(ctem_ffinIndex);

            }

            int ctem_tempIndex = reader.GetOrdinal("ctem_temp");
            if (!reader.IsDBNull(ctem_tempIndex))
            {
                bEConcursoTemporada.ctem_temp = reader.GetString(ctem_tempIndex);

            }

            int ctem_imagIndex = reader.GetOrdinal("ctem_imag");
            if (!reader.IsDBNull(ctem_imagIndex))
            {
                bEConcursoTemporada.ctem_imag = reader.GetString(ctem_imagIndex);

            }

            int ctem_destIndex = reader.GetOrdinal("ctem_dest");
            if (!reader.IsDBNull(ctem_destIndex))
            {
                bEConcursoTemporada.ctem_dest = reader.GetBoolean(ctem_destIndex);

            }

            return bEConcursoTemporada;
        }
    }
}

