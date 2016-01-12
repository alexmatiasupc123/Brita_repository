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
    /// Respository that lets you find BEBritanicoRadio in the
    /// CRM database.
    /// </summary>
    public class BEBritanicoRadioRepository : Repository<BEBritanicoRadio>
    {
        private string databaseName;

        public BEBritanicoRadioRepository(string databaseName)
            : base(databaseName)
        {
            this.databaseName = databaseName;
        }


        public BEBritanicoRadio uspMListarRegistroBritanicoRadio(System.Int32 brad_codi)
        {
            ISelectionFactory<System.Int32> selectionFactory = new uspMListarRegistroBritanicoRadioSelectionFactory();

            try
            {
                return base.FindOne(selectionFactory, new uspMListarRegistroBritanicoRadioFactory(), brad_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new BEBritanicoRadio();
        }

        public List<BEBritanicoRadio> uspMListarTodosBritanicoRadio()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosBritanicoRadioSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosBritanicoRadioFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEBritanicoRadio>();
        }

        public void Add(BEBritanicoRadio bEBritanicoRadio)
        {
            BEBritanicoRadioInsertFactory insertFactory = new BEBritanicoRadioInsertFactory();
            try
            {
                base.Add(insertFactory, bEBritanicoRadio);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, insertFactory);
            }
        }

        public void Remove(System.Int32 brad_codi)
        {
            IDeleteFactory<System.Int32> deleteFactory = new BEBritanicoRadioDeleteFactory();

            try
            {
                base.Remove(deleteFactory, brad_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, deleteFactory);
            }
        }


        public void Save(BEBritanicoRadio bEBritanicoRadio)
        {
            BEBritanicoRadioUpdateFactory updateFactory = new BEBritanicoRadioUpdateFactory();
            try
            {
                base.Save(updateFactory, bEBritanicoRadio);
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

