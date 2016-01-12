using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Britanico.Web.BusinessEntities;

namespace Britanico.Web.DataAccess
{
    /// <summary>
    /// Construct a BEProyecto object from a datareader.
    /// </summary>
    internal class uspMListarRegistroProyectoFactory : IDomainObjectFactory<BEProyecto>
    {
        public BEProyecto Construct(IDataReader reader)
        {
            BEProyecto bEProyecto = new BEProyecto();

            int proy_codiIndex = reader.GetOrdinal("proy_codi");
            if (!reader.IsDBNull(proy_codiIndex))
            {
                bEProyecto.proy_codi = reader.GetInt32(proy_codiIndex);

            }

            int proy_descIndex = reader.GetOrdinal("proy_desc");
            if (!reader.IsDBNull(proy_descIndex))
            {
                bEProyecto.proy_desc = reader.GetString(proy_descIndex);

            }

            int proy_nombIndex = reader.GetOrdinal("proy_nomb");
            if (!reader.IsDBNull(proy_nombIndex))
            {
                bEProyecto.proy_nomb = reader.GetString(proy_nombIndex);

            }

            int proy_subtIndex = reader.GetOrdinal("proy_subt");
            if (!reader.IsDBNull(proy_subtIndex))
            {
                bEProyecto.proy_subt = reader.GetString(proy_subtIndex);

            }

            int proy_imagIndex = reader.GetOrdinal("proy_imag");
            if (!reader.IsDBNull(proy_imagIndex))
            {
                bEProyecto.proy_imag = reader.GetString(proy_imagIndex);

            }

            return bEProyecto;
        }
    }
}

