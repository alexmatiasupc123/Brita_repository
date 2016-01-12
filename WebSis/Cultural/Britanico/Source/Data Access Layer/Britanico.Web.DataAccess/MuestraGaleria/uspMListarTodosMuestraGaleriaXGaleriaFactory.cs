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
    internal class uspMListarTodosMuestraGaleriaXGaleriaFactory : IDomainObjectFactory<BEMuestraGaleria>
    {
        public BEMuestraGaleria Construct(IDataReader reader)
        {
            BEMuestraGaleria bEMuestraGaleria = new BEMuestraGaleria();

            int mues_codiIndex = reader.GetOrdinal("mues_codi");
            if (!reader.IsDBNull(mues_codiIndex))
            {
                bEMuestraGaleria.mues_codi = reader.GetInt32(mues_codiIndex);

            }

       
            int mues_descIndex = reader.GetOrdinal("mues_desc");
            if (!reader.IsDBNull(mues_descIndex))
            {
                bEMuestraGaleria.mues_desc = reader.GetString(mues_descIndex);

            }

            int gale_nombIndex = reader.GetOrdinal("gale_nomb");
            if (!reader.IsDBNull(gale_nombIndex))
            {
                bEMuestraGaleria.gale_nomb = reader.GetString(gale_nombIndex);

            }




            int mues_nombIndex = reader.GetOrdinal("mues_nomb");
            if (!reader.IsDBNull(mues_nombIndex))
            {
                bEMuestraGaleria.mues_nomb = reader.GetString(mues_nombIndex);

            }


            int gale_codiIndex = reader.GetOrdinal("gale_codi");
            if (!reader.IsDBNull(gale_codiIndex))
            {
                bEMuestraGaleria.gale_codi = reader.GetInt32(gale_codiIndex);

            }

            int mues_imagIndex = reader.GetOrdinal("mues_imag");
            if (!reader.IsDBNull(mues_imagIndex))
            {
                bEMuestraGaleria.mues_imag = reader.GetString(mues_imagIndex);

            }

            return bEMuestraGaleria;
        }
    }
}

