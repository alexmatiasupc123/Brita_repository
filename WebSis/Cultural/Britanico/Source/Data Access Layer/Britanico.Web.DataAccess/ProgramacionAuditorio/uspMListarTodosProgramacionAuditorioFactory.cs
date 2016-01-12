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
    internal class uspMListarTodosProgramacionAuditorioFactory : IDomainObjectFactory<BEProgramacionAuditorio>
    {
        public BEProgramacionAuditorio Construct(IDataReader reader)
        {
            BEProgramacionAuditorio bEProgramacionAuditorio = new BEProgramacionAuditorio();

            int prog_codiIndex = reader.GetOrdinal("prog_codi");
            if (!reader.IsDBNull(prog_codiIndex))
            {
                bEProgramacionAuditorio.prog_codi = reader.GetInt32(prog_codiIndex);

            }

            int prog_descIndex = reader.GetOrdinal("prog_desc");
            if (!reader.IsDBNull(prog_descIndex))
            {
                bEProgramacionAuditorio.prog_desc = reader.GetString(prog_descIndex);

            }

            int prog_detaIndex = reader.GetOrdinal("prog_deta");
            if (!reader.IsDBNull(prog_detaIndex))
            {
                bEProgramacionAuditorio.prog_deta = reader.GetString(prog_detaIndex);

            }

            int prog_finiIndex = reader.GetOrdinal("prog_fini");
            if (!reader.IsDBNull(prog_finiIndex))
            {
                bEProgramacionAuditorio.prog_fini = reader.GetDateTime(prog_finiIndex);

            }

            int prog_tituIndex = reader.GetOrdinal("prog_titu");
            if (!reader.IsDBNull(prog_tituIndex))
            {
                bEProgramacionAuditorio.prog_titu = reader.GetString(prog_tituIndex);

            }

            int prog_ffinIndex = reader.GetOrdinal("prog_ffin");
            if (!reader.IsDBNull(prog_ffinIndex))
            {
                bEProgramacionAuditorio.prog_ffin = reader.GetDateTime(prog_ffinIndex);

            }

            int prog_imagIndex = reader.GetOrdinal("prog_imag");
            if (!reader.IsDBNull(prog_imagIndex))
            {
                bEProgramacionAuditorio.prog_imag = reader.GetString(prog_imagIndex);

            }

            int sede_codiIndex = reader.GetOrdinal("sede_codi");
            if (!reader.IsDBNull(sede_codiIndex))
            {
                bEProgramacionAuditorio.sede_codi = reader.GetInt32(sede_codiIndex);

            }

            int prog_tempIndex = reader.GetOrdinal("prog_temp");
            if (!reader.IsDBNull(prog_tempIndex))
            {
                bEProgramacionAuditorio.prog_temp = reader.GetString(prog_tempIndex);

            }

            int prog_destIndex = reader.GetOrdinal("prog_dest");
            if (!reader.IsDBNull(prog_destIndex))
            {
                bEProgramacionAuditorio.prog_dest = reader.GetBoolean(prog_destIndex);

            }


            int sede_nombIndex = reader.GetOrdinal("sede_nomb");
            if (!reader.IsDBNull(sede_nombIndex))
            {
                bEProgramacionAuditorio.sede_nomb = reader.GetString(sede_nombIndex);

            }

            return bEProgramacionAuditorio;
        }
    }
}

