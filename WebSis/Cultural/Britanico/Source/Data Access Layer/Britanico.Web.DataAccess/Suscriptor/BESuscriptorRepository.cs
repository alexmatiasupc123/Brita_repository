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
    /// Respository that lets you find BESuscriptor in the
    /// CRM database.
    /// </summary>
    public class BESuscriptorRepository : Repository<BESuscriptor>
    {
        private string databaseName;

        public BESuscriptorRepository(string databaseName)
            : base(databaseName)
        {
            this.databaseName = databaseName;
        }


        public BESuscriptor uspMListarRegistroSuscriptor(System.Int32 susc_codi)
        {
            ISelectionFactory<System.Int32> selectionFactory = new uspMListarRegistroSuscriptorSelectionFactory();

            try
            {
                return base.FindOne(selectionFactory, new uspMListarRegistroSuscriptorFactory(), susc_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new BESuscriptor();
        }

        public List<BESuscriptor> uspMListarTodosSuscriptoresXValores(System.DateTime inicio, System.DateTime fin, System.Int32 estado)
        {
            ISelectionFactory<uspMListarTodosSuscriptorXValoresIdentity> selectionFactory = new uspMListarTodosSuscriptorXValoresSelectionFactory();

            try
            {

                uspMListarTodosSuscriptorXValoresIdentity uspMListarTodosSuscriptorXValoresIdentity = new uspMListarTodosSuscriptorXValoresIdentity(inicio,fin, estado);
                return base.Find(selectionFactory, new uspMListarTodosSuscriptorXValoresFactory(), uspMListarTodosSuscriptorXValoresIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BESuscriptor>();
        }


        public List<BESuscriptor> uspMListarTodosSuscriptor()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosSuscriptorSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosSuscriptorFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BESuscriptor>();
        }

        public void Add(BESuscriptor bESuscriptor)
        {
            BESuscriptorInsertFactory insertFactory = new BESuscriptorInsertFactory();
            try
            {
                base.Add(insertFactory, bESuscriptor);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, insertFactory);
            }
        }

        public void Remove(System.Int32 susc_codi)
        {
            IDeleteFactory<System.Int32> deleteFactory = new BESuscriptorDeleteFactory();

            try
            {
                base.Remove(deleteFactory, susc_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, deleteFactory);
            }
        }


        public void Save(BESuscriptor bESuscriptor)
        {
            BESuscriptorUpdateFactory updateFactory = new BESuscriptorUpdateFactory();
            try
            {
                base.Save(updateFactory, bESuscriptor);
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

