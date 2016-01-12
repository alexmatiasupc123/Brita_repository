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
    /// Respository that lets you find BEConcursoTemporada in the
    /// CRM database.
    /// </summary>
    public class BEConcursoTemporadaRepository : Repository<BEConcursoTemporada>
    {
        private string databaseName;

        public BEConcursoTemporadaRepository(string databaseName)
            : base(databaseName)
        {
            this.databaseName = databaseName;
        }


        public List<BEConcursoTemporada> uspMListarTodosConcursoTemporadaXConcurso(System.Int32 conc_codi)
        {
            ISelectionFactory<System.Int32> selectionFactory = new uspMListarTodosConcursoTemporadaXConcursoSelectionFactory();

            try
            {
                return base.Find(selectionFactory, new uspMListarTodosConcursoTemporadaXConcursoFactory(), conc_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEConcursoTemporada>();
        }


        public BEConcursoTemporada uspMListarRegistroConcursoTemporadaXConcurso(System.Int32 conc_codi)
        {
            ISelectionFactory<System.Int32> selectionFactory = new uspMListarRegistroConcursoTemporadaXConcursoSelectionFactory();

            try
            {
                return base.FindOne(selectionFactory, new uspMListarRegistroConcursoTemporadaXConcursoFactory(), conc_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new BEConcursoTemporada();
        }


        public BEConcursoTemporada uspMListarRegistroConcursoTemporada(System.Int32 ctem_codi)
        {
            ISelectionFactory<System.Int32> selectionFactory = new uspMListarRegistroConcursoTemporadaSelectionFactory();

            try
            {
                return base.FindOne(selectionFactory, new uspMListarRegistroConcursoTemporadaFactory(), ctem_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new BEConcursoTemporada();
        }

        public List<BEConcursoTemporada> uspMListarTodosConcursoTemporada()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosConcursoTemporadaSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosConcursoTemporadaFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEConcursoTemporada>();
        }

        public void Add(BEConcursoTemporada bEConcursoTemporada)
        {
            BEConcursoTemporadaInsertFactory insertFactory = new BEConcursoTemporadaInsertFactory();
            try
            {
                base.Add(insertFactory, bEConcursoTemporada);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, insertFactory);
            }
        }

        public void Remove(System.Int32 ctem_codi)
        {
            IDeleteFactory<System.Int32> deleteFactory = new BEConcursoTemporadaDeleteFactory();

            try
            {
                base.Remove(deleteFactory, ctem_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, deleteFactory);
            }
        }


        public void Save(BEConcursoTemporada bEConcursoTemporada)
        {
            BEConcursoTemporadaUpdateFactory updateFactory = new BEConcursoTemporadaUpdateFactory();
            try
            {
                base.Save(updateFactory, bEConcursoTemporada);
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

