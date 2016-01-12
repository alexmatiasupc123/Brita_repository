using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Britanico.Web.BusinessEntities;

namespace Britanico.Web.DataAccess
{
    /// <summary>
    /// Construct a BEEvento object from a datareader.
    /// </summary>
    internal class uspMListarTodosEventosFactory : IDomainObjectFactory<BEEvento>
    {
        public BEEvento Construct(IDataReader reader)
        {
            BEEvento bEEvento = new BEEvento();

            int even_codiIndex = reader.GetOrdinal("even_codi");
            if (!reader.IsDBNull(even_codiIndex))
            {
                bEEvento.even_codi = reader.GetInt32(even_codiIndex);

            }

            int even_descIndex = reader.GetOrdinal("even_desc");
            if (!reader.IsDBNull(even_descIndex))
            {
                bEEvento.even_desc = reader.GetString(even_descIndex);

            }

            int even_finiIndex = reader.GetOrdinal("even_fini");
            if (!reader.IsDBNull(even_finiIndex))
            {
                bEEvento.even_fini = reader.GetDateTime(even_finiIndex);

            }

            int even_nombIndex = reader.GetOrdinal("even_nomb");
            if (!reader.IsDBNull(even_nombIndex))
            {
                bEEvento.even_nomb = reader.GetString(even_nombIndex);

            }

            int even_ffinIndex = reader.GetOrdinal("even_ffin");
            if (!reader.IsDBNull(even_ffinIndex))
            {
                bEEvento.even_ffin = reader.GetDateTime(even_ffinIndex);

            }

            int even_imagIndex = reader.GetOrdinal("even_imag");
            if (!reader.IsDBNull(even_imagIndex))
            {
                bEEvento.even_imag = reader.GetString(even_imagIndex);

            }

            int sede_codiIndex = reader.GetOrdinal("sede_codi");
            if (!reader.IsDBNull(sede_codiIndex))
            {
                bEEvento.sede_codi = reader.GetInt32(sede_codiIndex);

            }

            int even_codrIndex = reader.GetOrdinal("even_codr");
            if (!reader.IsDBNull(even_codrIndex))
            {
                bEEvento.even_codr = reader.GetInt32(even_codrIndex);

            }

            int even_tipoIndex = reader.GetOrdinal("even_tipo");
            if (!reader.IsDBNull(even_tipoIndex))
            {
                bEEvento.even_tipo = reader.GetInt32(even_tipoIndex);

            }


            int even_tempIndex = reader.GetOrdinal("even_temp");
            if (!reader.IsDBNull(even_tempIndex))
            {
                bEEvento.even_temp = reader.GetString(even_tempIndex);

            }

            int even_destIndex = reader.GetOrdinal("even_dest");
            if (!reader.IsDBNull(even_destIndex))
            {
                bEEvento.even_dest = reader.GetBoolean(even_destIndex);

            }

            return bEEvento;
        }
    }
}

