using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Britanico.Web.BusinessEntities;

namespace Britanico.Web.DataAccess
{
    /// <summary>
    /// Construct a BECabecera object from a datareader.
    /// </summary>
    internal class uspMListarTodosCabeceraFactory : IDomainObjectFactory<BECabecera>
    {
        public BECabecera Construct(IDataReader reader)
        {
            BECabecera bECabecera = new BECabecera();

            int cabe_codiIndex = reader.GetOrdinal("cabe_codi");
            if (!reader.IsDBNull(cabe_codiIndex))
            {
                bECabecera.cabe_codi = reader.GetInt32(cabe_codiIndex);

            }

            int cabe_imagIndex = reader.GetOrdinal("cabe_imag");
            if (!reader.IsDBNull(cabe_imagIndex))
            {
                bECabecera.cabe_imag = reader.GetString(cabe_imagIndex);

            }
            int cabe_tituIndex = reader.GetOrdinal("cabe_titu");
            if (!reader.IsDBNull(cabe_tituIndex))
            {
                bECabecera.cabe_titu = reader.GetString(cabe_tituIndex);

            }

            
            return bECabecera;
        }
    }
}

