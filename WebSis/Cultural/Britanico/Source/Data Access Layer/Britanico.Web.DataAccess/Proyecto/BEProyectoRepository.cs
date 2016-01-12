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
    /// Respository that lets you find BEProyecto in the
    /// CRM database.
    /// </summary>
    public class BEProyectoRepository : Repository<BEProyecto>
    {
        private string databaseName;

        public BEProyectoRepository(string databaseName)
            : base(databaseName)
        {
            this.databaseName = databaseName;
        }


        public BEProyecto uspMListarRegistroProyecto(System.Int32 proy_codi)
        {
            ISelectionFactory<System.Int32> selectionFactory = new uspMListarRegistroProyectoSelectionFactory();

            try
            {
                return base.FindOne(selectionFactory, new uspMListarRegistroProyectoFactory(), proy_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new BEProyecto();
        }

        public List<BEProyecto> uspMListarTodosProyecto()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosProyectoSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosProyectoFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEProyecto>();
        }

        public void Add(BEProyecto bEProyecto)
        {
            BEProyectoInsertFactory insertFactory = new BEProyectoInsertFactory();
            try
            {
                base.Add(insertFactory, bEProyecto);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, insertFactory);
            }
        }

        public void Remove(System.Int32 proy_codi)
        {
            IDeleteFactory<System.Int32> deleteFactory = new BEProyectoDeleteFactory();

            try
            {
                base.Remove(deleteFactory, proy_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, deleteFactory);
            }
        }


        public void Save(BEProyecto bEProyecto)
        {
            BEProyectoUpdateFactory updateFactory = new BEProyectoUpdateFactory();
            try
            {
                base.Save(updateFactory, bEProyecto);
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

