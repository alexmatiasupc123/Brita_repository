using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Britanico.Web.BusinessEntities;

namespace Britanico.Web.DataAccess
{
    /// <summary>
    /// Construct a BEProducciones object from a datareader.
    /// </summary>
    internal class uspMListarRegistroProduccionesFactory : IDomainObjectFactory<BEProducciones>
    {
        public BEProducciones Construct(IDataReader reader)
        {
            BEProducciones bEProducciones = new BEProducciones();

            int prod_anioIndex = reader.GetOrdinal("prod_anio");
            if (!reader.IsDBNull(prod_anioIndex))
            {
                bEProducciones.prod_anio = reader.GetString(prod_anioIndex);

            }

            int prod_codiIndex = reader.GetOrdinal("prod_codi");
            if (!reader.IsDBNull(prod_codiIndex))
            {
                bEProducciones.prod_codi = reader.GetInt32(prod_codiIndex);

            }

            int prod_descIndex = reader.GetOrdinal("prod_desc");
            if (!reader.IsDBNull(prod_descIndex))
            {
                bEProducciones.prod_desc = reader.GetString(prod_descIndex);

            }

            int prod_nombIndex = reader.GetOrdinal("prod_nomb");
            if (!reader.IsDBNull(prod_nombIndex))
            {
                bEProducciones.prod_nomb = reader.GetString(prod_nombIndex);

            }


            return bEProducciones;
        }
    }
}

