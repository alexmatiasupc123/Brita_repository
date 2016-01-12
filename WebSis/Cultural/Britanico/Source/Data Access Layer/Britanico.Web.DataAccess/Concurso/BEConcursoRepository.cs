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
    /// Respository that lets you find BEConcurso in the
    /// CRM database.
    /// </summary>
    public class BEConcursoRepository : Repository<BEConcurso>
    {
        private string databaseName;

        public BEConcursoRepository(string databaseName)
            : base(databaseName)
        {
            this.databaseName = databaseName;
        }


        public BEConcurso uspMListarRegistroConcurso(System.Int32 conc_codi)
        {
            ISelectionFactory<System.Int32> selectionFactory = new uspMListarRegistroConcursoSelectionFactory();

            try
            {
                return base.FindOne(selectionFactory, new uspMListarRegistroConcursoFactory(), conc_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new BEConcurso();
        }

        public List<BEConcurso> uspMListarTodosConcurso()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosConcursoSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosConcursoFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEConcurso>();
        }

        public void Add(BEConcurso bEConcurso)
        {
            BEConcursoInsertFactory insertFactory = new BEConcursoInsertFactory();
            try
            {
                base.Add(insertFactory, bEConcurso);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, insertFactory);
            }
        }

        public void Remove(System.Int32 conc_codi)
        {
            IDeleteFactory<System.Int32> deleteFactory = new BEConcursoDeleteFactory();

            try
            {
                base.Remove(deleteFactory, conc_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, deleteFactory);
            }
        }


        public void Save(BEConcurso bEConcurso)
        {
            BEConcursoUpdateFactory updateFactory = new BEConcursoUpdateFactory();
            try
            {
                base.Save(updateFactory, bEConcurso);
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

