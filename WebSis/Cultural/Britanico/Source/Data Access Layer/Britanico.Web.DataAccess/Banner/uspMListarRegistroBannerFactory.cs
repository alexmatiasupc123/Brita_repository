﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Britanico.Web.BusinessEntities;

namespace Britanico.Web.DataAccess
{
    /// <summary>
    /// Construct a BEBanner object from a datareader.
    /// </summary>
    internal class uspMListarRegistroBannerFactory : IDomainObjectFactory<BEBanner>
    {
        public BEBanner Construct(IDataReader reader)
        {
            BEBanner bEBanner = new BEBanner();

            int bann_codiIndex = reader.GetOrdinal("bann_codi");
            if (!reader.IsDBNull(bann_codiIndex))
            {
                bEBanner.bann_codi = reader.GetInt32(bann_codiIndex);

            }

            int bann_estaIndex = reader.GetOrdinal("bann_esta");
            if (!reader.IsDBNull(bann_estaIndex))
            {
                bEBanner.bann_esta = reader.GetInt32(bann_estaIndex);

            }

            int bann_fechIndex = reader.GetOrdinal("bann_fech");
            if (!reader.IsDBNull(bann_fechIndex))
            {
                bEBanner.bann_fech = reader.GetDateTime(bann_fechIndex);

            }

            int bann_imagIndex = reader.GetOrdinal("bann_imag");
            if (!reader.IsDBNull(bann_imagIndex))
            {
                bEBanner.bann_imag = reader.GetString(bann_imagIndex);

            }

            int bann_tituIndex = reader.GetOrdinal("bann_titu");
            if (!reader.IsDBNull(bann_tituIndex))
            {
                bEBanner.bann_titu = reader.GetString(bann_tituIndex);

            }

            int bann_linkIndex = reader.GetOrdinal("bann_link");
            if (!reader.IsDBNull(bann_linkIndex))
            {
                bEBanner.bann_link = reader.GetString(bann_linkIndex);

            }

            int bann_dfecIndex = reader.GetOrdinal("bann_dfec");
            if (!reader.IsDBNull(bann_dfecIndex))
            {
                bEBanner.bann_dfec = reader.GetString(bann_dfecIndex);

            }

            int bann_fpriIndex = reader.GetOrdinal("bann_fpri");
            if (!reader.IsDBNull(bann_fpriIndex))
            {
                bEBanner.bann_fpri = reader.GetBoolean(bann_fpriIndex);

            }
            int bann_redsocialIndex = reader.GetOrdinal("bann_redsocial");
            if (!reader.IsDBNull(bann_redsocialIndex))
            {
                bEBanner.bann_redsocial = reader.GetBoolean(bann_redsocialIndex);

            }
            return bEBanner;
        }
    }
}
