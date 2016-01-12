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
    /// Respository that lets you find BENoticia in the
    /// CRM database.
    /// </summary>
    public class BENoticiaRepository : Repository<BENoticia>
    {
        private string databaseName;

        public BENoticiaRepository(string databaseName)
            : base(databaseName)
        {
            this.databaseName = databaseName;
        }

        public List<BENoticia> uspMListarTodosNoticiaXMes()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosNoticiaXMesSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosNoticiaXMesFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BENoticia>();
        }


        public BENoticia uspMListarRegistroNoticia(System.Int32 noti_codi)
        {
            ISelectionFactory<System.Int32> selectionFactory = new uspMListarRegistroNoticiaSelectionFactory();

            try
            {
                return base.FindOne(selectionFactory, new uspMListarRegistroNoticiaFactory(), noti_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new BENoticia();
        }

        public List<BENoticia> uspMListarTodosNoticia()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosNoticiaSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosNoticiaFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BENoticia>();
        }

        public void Add(BENoticia bENoticia)
        {
            BENoticiaInsertFactory insertFactory = new BENoticiaInsertFactory();
            try
            {
                base.Add(insertFactory, bENoticia);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, insertFactory);
            }
        }

        public void Remove(System.Int32 noti_codi)
        {
            IDeleteFactory<System.Int32> deleteFactory = new BENoticiaDeleteFactory();

            try
            {
                base.Remove(deleteFactory, noti_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, deleteFactory);
            }
        }


        public void Save(BENoticia bENoticia)
        {
            BENoticiaUpdateFactory updateFactory = new BENoticiaUpdateFactory();
            try
            {
                base.Save(updateFactory, bENoticia);
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

