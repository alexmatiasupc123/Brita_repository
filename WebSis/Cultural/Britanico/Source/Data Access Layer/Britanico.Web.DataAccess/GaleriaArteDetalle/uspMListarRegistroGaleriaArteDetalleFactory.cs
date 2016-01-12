using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Britanico.Web.BusinessEntities;

namespace Britanico.Web.DataAccess
{
    /// <summary>
    /// Construct a BEGaleriaArteDetalle object from a datareader.
    /// </summary>
    internal class uspMListarRegistroGaleriaArteDetalleFactory : IDomainObjectFactory<BEGaleriaArteDetalle>
    {
        public BEGaleriaArteDetalle Construct(IDataReader reader)
        {
            BEGaleriaArteDetalle bEGaleriaArteDetalle = new BEGaleriaArteDetalle();

            int gade_codiIndex = reader.GetOrdinal("gade_codi");
            if (!reader.IsDBNull(gade_codiIndex))
            {
                bEGaleriaArteDetalle.gade_codi = reader.GetInt32(gade_codiIndex);

            }

            int gade_descIndex = reader.GetOrdinal("gade_desc");
            if (!reader.IsDBNull(gade_descIndex))
            {
                bEGaleriaArteDetalle.gade_desc = reader.GetString(gade_descIndex);

            }

            int gade_ffinIndex = reader.GetOrdinal("gade_ffin");
            if (!reader.IsDBNull(gade_ffinIndex))
            {
                bEGaleriaArteDetalle.gade_ffin = reader.GetDateTime(gade_ffinIndex);

            }

            int gade_finiIndex = reader.GetOrdinal("gade_fini");
            if (!reader.IsDBNull(gade_finiIndex))
            {
                bEGaleriaArteDetalle.gade_fini = reader.GetDateTime(gade_finiIndex);

            }

            int gade_nombIndex = reader.GetOrdinal("gade_nomb");
            if (!reader.IsDBNull(gade_nombIndex))
            {
                bEGaleriaArteDetalle.gade_nomb = reader.GetString(gade_nombIndex);

            }

            int gade_tempIndex = reader.GetOrdinal("gade_temp");
            if (!reader.IsDBNull(gade_tempIndex))
            {
                bEGaleriaArteDetalle.gade_temp = reader.GetString(gade_tempIndex);

            }

            int gale_codiIndex = reader.GetOrdinal("gale_codi");
            if (!reader.IsDBNull(gale_codiIndex))
            {
                bEGaleriaArteDetalle.gale_codi = reader.GetInt32(gale_codiIndex);

            }

            int gade_imagIndex = reader.GetOrdinal("gade_imag");
            if (!reader.IsDBNull(gade_imagIndex))
            {
                bEGaleriaArteDetalle.gade_imag = reader.GetString(gade_imagIndex);

            }

            int gade_destIndex = reader.GetOrdinal("gade_dest");
            if (!reader.IsDBNull(gade_destIndex))
            {
                bEGaleriaArteDetalle.gade_dest = reader.GetBoolean(gade_destIndex);

            }

            int gade_aimgIndex = reader.GetOrdinal("gade_aimg");
            if (!reader.IsDBNull(gade_aimgIndex))
            {
                bEGaleriaArteDetalle.gade_aimg = reader.GetString(gade_aimgIndex);

            }

            int gade_lfecIndex = reader.GetOrdinal("gade_lfec");
            if (!reader.IsDBNull(gade_lfecIndex))
            {
                bEGaleriaArteDetalle.gade_lfec = reader.GetString(gade_lfecIndex);

            }

            return bEGaleriaArteDetalle;
        }
    }
}

