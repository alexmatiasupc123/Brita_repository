using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Britanico.Web.DataAccess
{
    public interface IUpdateFactory< TDomainObject > : IDbToBusinessEntityNameMapper
    {
        DbCommand ConstructUpdateCommand(Database db, TDomainObject domainObject);
    }
}
