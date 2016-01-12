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
    /// Respository that lets you find BEPublicaciones in the
    /// CRM database.
    /// </summary>
    public class BEPublicacionesRepository : Repository<BEPublicaciones>
    {
        private string databaseName;

        public BEPublicacionesRepository(string databaseName)
            : base(databaseName)
        {
            this.databaseName = databaseName;
        }


        public BEPublicaciones uspMListarRegistroPublicacion(System.Int32 publ_codi)
        {
            ISelectionFactory<System.Int32> selectionFactory = new uspMListarRegistroPublicacionSelectionFactory();

            try
            {
                return base.FindOne(selectionFactory, new uspMListarRegistroPublicacionFactory(), publ_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new BEPublicaciones();
        }

        public List<BEPublicaciones> uspMListarTodosPublicacion()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosPublicacionSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosPublicacionFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEPublicaciones>();
        }

        public void Add(BEPublicaciones bEPublicaciones)
        {
            BEPublicacionesInsertFactory insertFactory = new BEPublicacionesInsertFactory();
            try
            {
                base.Add(insertFactory, bEPublicaciones);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, insertFactory);
            }
        }

        public void Remove(System.Int32 publ_codi)
        {
            IDeleteFactory<System.Int32> deleteFactory = new BEPublicacionesDeleteFactory();

            try
            {
                base.Remove(deleteFactory, publ_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, deleteFactory);
            }
        }


        public void Save(BEPublicaciones bEPublicaciones)
        {
            BEPublicacionesUpdateFactory updateFactory = new BEPublicacionesUpdateFactory();
            try
            {
                base.Save(updateFactory, bEPublicaciones);
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

