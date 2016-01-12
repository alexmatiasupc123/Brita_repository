using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Britanico.Web.BusinessEntities;


namespace Britanico.Web.DataAccess
{
    /// <summary>
    /// Construct a BEPrestamoConceptoGasto object from a datareader.
    /// </summary>
    internal class uspMListarTodosArchivoXFiltrosFactory : IDomainObjectFactory<BEGaleriaArchivo>
    {
        public BEGaleriaArchivo Construct(IDataReader reader)
        {
            BEGaleriaArchivo bEGaleriaArchivo = new BEGaleriaArchivo();

            int arch_codiIndex = reader.GetOrdinal("arch_codi");
            if (!reader.IsDBNull(arch_codiIndex))
            {
                bEGaleriaArchivo.arch_codi = reader.GetInt32(arch_codiIndex);

            }

            int arch_descIndex = reader.GetOrdinal("arch_desc");
            if (!reader.IsDBNull(arch_descIndex))
            {
                bEGaleriaArchivo.arch_desc = reader.GetString(arch_descIndex);

            }

            int arch_tituIndex = reader.GetOrdinal("arch_titu");
            if (!reader.IsDBNull(arch_tituIndex))
            {
                bEGaleriaArchivo.arch_titu = reader.GetString(arch_tituIndex);

            }

            int padr_codiIndex = reader.GetOrdinal("padr_codi");
            if (!reader.IsDBNull(padr_codiIndex))
            {
                bEGaleriaArchivo.padr_codi = reader.GetInt32(padr_codiIndex);

            }

            int padr_tipoIndex = reader.GetOrdinal("padr_tipo");
            if (!reader.IsDBNull(padr_tipoIndex))
            {
                bEGaleriaArchivo.padr_tipo = reader.GetInt32(padr_tipoIndex);

            }

            int arch_archIndex = reader.GetOrdinal("arch_arch");
            if (!reader.IsDBNull(arch_archIndex))
            {
                bEGaleriaArchivo.arch_arch = reader.GetString(arch_archIndex);

            }

            int arch_tipoIndex = reader.GetOrdinal("arch_tipo");
            if (!reader.IsDBNull(arch_tipoIndex))
            {
                bEGaleriaArchivo.arch_tipo = reader.GetString(arch_tipoIndex);

            }

            int arch_linkIndex = reader.GetOrdinal("arch_link");
            if (!reader.IsDBNull(arch_linkIndex))
            {
                bEGaleriaArchivo.arch_link = reader.GetString(arch_linkIndex);

            }

            return bEGaleriaArchivo;
        }
    }
}

