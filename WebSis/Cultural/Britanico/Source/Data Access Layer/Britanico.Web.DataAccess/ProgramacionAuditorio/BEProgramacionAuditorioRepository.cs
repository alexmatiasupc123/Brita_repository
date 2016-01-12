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
    /// Respository that lets you find BEProgramacionAuditorio in the
    /// CRM database.
    /// </summary>
    public class BEProgramacionAuditorioRepository : Repository<BEProgramacionAuditorio>
    {
        private string databaseName;

        public BEProgramacionAuditorioRepository(string databaseName)
            : base(databaseName)
        {
            this.databaseName = databaseName;
        }

        public List<BEProgramacionAuditorio> uspMListarTodosXSede(System.Int32 sede)
        {
            ISelectionFactory<System.Int32> selectionFactory = new uspMListarTodosXSedeSelectionFactory();

            try
            {
                return base.Find(selectionFactory, new uspMListarTodosXSedeFactory(), sede);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEProgramacionAuditorio>();
        }


        public BEProgramacionAuditorio uspMListarRegistroAuditorio(System.Int32 prog_codi)
        {
            ISelectionFactory<System.Int32> selectionFactory = new uspMListarRegistroAuditorioSelectionFactory();

            try
            {
                return base.FindOne(selectionFactory, new uspMListarRegistroAuditorioFactory(), prog_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new BEProgramacionAuditorio();
        }

        public List<BEProgramacionAuditorio> uspMListarTodosProgramacionAuditorio()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosProgramacionAuditorioSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosProgramacionAuditorioFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEProgramacionAuditorio>();
        }

        public List<BEProgramacionAuditorio> uspMListarTodosProgramacionAuditorioDestacados()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosProgramacionAuditorioDestacadosSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosProgramacionAuditorioDestacadosFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEProgramacionAuditorio>();
        }



        public void Add(BEProgramacionAuditorio bEProgramacionAuditorio)
        {
            BEProgramacionAuditorioInsertFactory insertFactory = new BEProgramacionAuditorioInsertFactory();
            try
            {
                base.Add(insertFactory, bEProgramacionAuditorio);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, insertFactory);
            }
        }

        public void Remove(System.Int32 prog_codi)
        {
            IDeleteFactory<System.Int32> deleteFactory = new BEProgramacionAuditorioDeleteFactory();

            try
            {
                base.Remove(deleteFactory, prog_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, deleteFactory);
            }
        }


        public void Save(BEProgramacionAuditorio bEProgramacionAuditorio)
        {
            BEProgramacionAuditorioUpdateFactory updateFactory = new BEProgramacionAuditorioUpdateFactory();
            try
            {
                base.Save(updateFactory, bEProgramacionAuditorio);
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

