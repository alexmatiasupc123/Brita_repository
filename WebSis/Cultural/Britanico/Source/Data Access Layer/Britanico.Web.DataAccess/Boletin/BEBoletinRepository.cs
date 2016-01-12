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
    /// Respository that lets you find BEBoletin in the
    /// CRM database.
    /// </summary>
    public class BEBoletinRepository : Repository<BEBoletin>
    {
        private string databaseName;

        public BEBoletinRepository(string databaseName)
            : base(databaseName)
        {
            this.databaseName = databaseName;
        }


        public BEBoletin uspMListarRegistroBoletin(System.Int32 bole_codi)
        {
            ISelectionFactory<System.Int32> selectionFactory = new uspMListarRegistroBoletinSelectionFactory();

            try
            {
                return base.FindOne(selectionFactory, new uspMListarRegistroBoletinFactory(), bole_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new BEBoletin();
        }

        public List<BEBoletin> uspMListarTodosBoletin()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosBoletinSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosBoletinFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEBoletin>();
        }

        public BEBoletin uspMListarUltimoBoletin()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarUltimoBoletinSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.FindOne(selectionFactory, new uspMListarUltimoBoletinFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new BEBoletin();
        }

        public void Add(BEBoletin bEBoletin)
        {
            BEBoletinInsertFactory insertFactory = new BEBoletinInsertFactory();
            try
            {
                base.Add(insertFactory, bEBoletin);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, insertFactory);
            }
        }

        public void Remove(System.Int32 bole_codi)
        {
            IDeleteFactory<System.Int32> deleteFactory = new BEBoletinDeleteFactory();

            try
            {
                base.Remove(deleteFactory, bole_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, deleteFactory);
            }
        }


        public void Save(BEBoletin bEBoletin)
        {
            BEBoletinUpdateFactory updateFactory = new BEBoletinUpdateFactory();
            try
            {
                base.Save(updateFactory, bEBoletin);
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

