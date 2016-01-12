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
    /// Respository that lets you find BEAgendaCultural in the
    /// CRM database.
    /// </summary>
    public class BEAgendaCulturalRepository : Repository<BEAgendaCultural>
    {
        private string databaseName;

        public BEAgendaCulturalRepository(string databaseName)
            : base(databaseName)
        {
            this.databaseName = databaseName;
        }

       
        public List<BEAgendaCultural> uspMListarTodosAgendaCultural()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosAgendaCulturalSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosAgendaCulturalFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEAgendaCultural>();
        }

        public void Add(BEAgendaCultural bEAgendaCultural)
        {
            BEAgendaCulturalInsertFactory insertFactory = new BEAgendaCulturalInsertFactory();
            try
            {
                base.Add(insertFactory, bEAgendaCultural);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, insertFactory);
            }
        }

       
        public void Save(BEAgendaCultural bEAgendaCultural)
        {
            BEAgendaCulturalUpdateFactory updateFactory = new BEAgendaCulturalUpdateFactory();
            try
            {
                base.Save(updateFactory, bEAgendaCultural);
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

