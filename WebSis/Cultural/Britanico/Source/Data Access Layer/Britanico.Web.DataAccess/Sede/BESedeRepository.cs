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
    /// Respository that lets you find BESede in the
    /// CRM database.
    /// </summary>
    public class BESedeRepository : Repository<BESede>
    {
        private string databaseName;

        public BESedeRepository(string databaseName)
            : base(databaseName)
        {
            this.databaseName = databaseName;
        }


        public BESede uspMListarRegistroSede(System.Int32 sede_codi)
        {
            ISelectionFactory<System.Int32> selectionFactory = new uspMListarRegistroSedeSelectionFactory();

            try
            {
                return base.FindOne(selectionFactory, new uspMListarRegistroSedeFactory(), sede_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new BESede();
        }

        public List<BESede> uspMListarTodosSede()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosSedeSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosSedeFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BESede>();
        }

        public List<BESede> uspMListarTodosSedesCursos()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosSedesCursosSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosSedesCursosFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BESede>();
        }

        public List<BESede> uspMListarTodosSedesAuditorios()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosSedesAuditoriosSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosSedesAuditoriosFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BESede>();
        }

        public void Add(BESede bESede)
        {
            BESedeInsertFactory insertFactory = new BESedeInsertFactory();
            try
            {
                base.Add(insertFactory, bESede);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, insertFactory);
            }
        }

        public void Remove(System.Int32 sede_codi)
        {
            IDeleteFactory<System.Int32> deleteFactory = new BESedeDeleteFactory();

            try
            {
                base.Remove(deleteFactory, sede_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, deleteFactory);
            }
        }


        public void Save(BESede bESede)
        {
            BESedeUpdateFactory updateFactory = new BESedeUpdateFactory();
            try
            {
                base.Save(updateFactory, bESede);
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

