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
    /// Respository that lets you find BECategoriaEvento in the
    /// CRM database.
    /// </summary>
    public class BECategoriaEventoRepository : Repository<BECategoriaEvento>
    {
        private string databaseName;

        public BECategoriaEventoRepository(string databaseName)
            : base(databaseName)
        {
            this.databaseName = databaseName;
        }


        public BECategoriaEvento uspMListarRegistroCategoria(System.Int32 cate_codi)
        {
            ISelectionFactory<System.Int32> selectionFactory = new uspMListarRegistroCategoriaSelectionFactory();

            try
            {
                return base.FindOne(selectionFactory, new uspMListarRegistroCategoriaFactory(), cate_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new BECategoriaEvento();
        }

        public List<BECategoriaEvento> uspMListarTodosCategora()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosCategoraSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosCategoraFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BECategoriaEvento>();
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

