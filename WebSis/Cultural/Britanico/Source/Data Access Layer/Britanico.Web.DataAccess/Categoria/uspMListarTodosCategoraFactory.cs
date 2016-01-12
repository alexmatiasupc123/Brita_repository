using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Britanico.Web.BusinessEntities;

namespace Britanico.Web.DataAccess
{
    /// <summary>
    /// Construct a BECategoriaEvento object from a datareader.
    /// </summary>
    internal class uspMListarTodosCategoraFactory : IDomainObjectFactory<BECategoriaEvento>
    {
        public BECategoriaEvento Construct(IDataReader reader)
        {
            BECategoriaEvento bECategoriaEvento = new BECategoriaEvento();

            int cate_codiIndex = reader.GetOrdinal("cate_codi");
            if (!reader.IsDBNull(cate_codiIndex))
            {
                bECategoriaEvento.cate_codi = reader.GetInt32(cate_codiIndex);

            }

            int cate_nombIndex = reader.GetOrdinal("cate_nomb");
            if (!reader.IsDBNull(cate_nombIndex))
            {
                bECategoriaEvento.cate_nomb = reader.GetString(cate_nombIndex);

            }


            return bECategoriaEvento;
        }
    }
}

