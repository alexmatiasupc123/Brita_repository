using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Britanico.Web.BusinessEntities;
using System.Data.SqlClient;
using System.Diagnostics;
using Britanico.Web.DataAccess.SQLServer;

namespace Britanico.Web.DataAccess
{
    /// <summary>
    /// Respository that lets you find BEHistoriaTeatro in the
    /// CRM database.
    /// </summary>
    public class BEHistoriaTeatroRepository : Repository<BEHistoriaTeatro>
    {
        private string databaseName;

        public BEHistoriaTeatroRepository(string databaseName)
            : base(databaseName)
        {
            this.databaseName = databaseName;
        }

       
        public List<BEHistoriaTeatro> uspMListarTodosHistoriaTeatro()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosHistoriaTeatroSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosHistoriaTeatroFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEHistoriaTeatro>();
        }

        public void Add(BEHistoriaTeatro bEHistoriaTeatro)
        {
            BEHistoriaTeatroInsertFactory insertFactory = new BEHistoriaTeatroInsertFactory();
            try
            {
                base.Add(insertFactory, bEHistoriaTeatro);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, insertFactory);
            }
        }

       
        public void Save(BEHistoriaTeatro bEHistoriaTeatro)
        {
            BEHistoriaTeatroUpdateFactory updateFactory = new BEHistoriaTeatroUpdateFactory();
            try
            {
                base.Save(updateFactory, bEHistoriaTeatro);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, updateFactory);
            }
        }

        private void HandleSqlException(SqlException ex, IDbToBusinessEntityNameMapper mapper)
        {
            if (ex.Number == ErrorCodes.SqlUserRaisedError)
            {
                switch (ex.State)
                {
                    case ErrorCodes.ValidationError:
                        string[] messageParts = ex.Errors[0].Message.Split(':');
                        throw new RepositoryValidationException(
                            mapper.MapDbParameterToBusinessEntityProperty(messageParts[0]),
                            messageParts[1], ex);

                    case ErrorCodes.ConcurrencyViolationError:
                        throw new ConcurrencyViolationException(ex.Message, ex);

                }
            }

            throw new RepositoryFailureException(ex);
        }
    }
}

