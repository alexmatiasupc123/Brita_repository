using System;
namespace Britanico.Web.DataAccess
{
    public interface IDbToBusinessEntityNameMapper
    {
        string MapDbParameterToBusinessEntityProperty(string dbParameter);
    }
}
