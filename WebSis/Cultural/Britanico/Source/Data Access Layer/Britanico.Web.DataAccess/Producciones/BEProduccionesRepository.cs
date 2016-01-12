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
    /// Respository that lets you find BEProducciones in the
    /// CRM database.
    /// </summary>
    public class BEProduccionesRepository : Repository<BEProducciones>
    {
        private string databaseName;

        public BEProduccionesRepository(string databaseName)
            : base(databaseName)
        {
            this.databaseName = databaseName;
        }


        public BEProducciones uspMListarRegistroProducciones(System.Int32 prod_codi)
        {
            ISelectionFactory<System.Int32> selectionFactory = new uspMListarRegistroProduccionesSelectionFactory();

            try
            {
                return base.FindOne(selectionFactory, new uspMListarRegistroProduccionesFactory(), prod_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new BEProducciones();
        }

        public List<BEProducciones> uspMListarTodosProducciones()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosProduccionesSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosProduccionesFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEProducciones>();
        }

        public void Add(BEProducciones bEProducciones)
        {
            BEProduccionesInsertFactory insertFactory = new BEProduccionesInsertFactory();
            try
            {
                base.Add(insertFactory, bEProducciones);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, insertFactory);
            }
        }

        public void Remove(System.Int32 prod_codi)
        {
            IDeleteFactory<System.Int32> deleteFactory = new BEProduccionesDeleteFactory();

            try
            {
                base.Remove(deleteFactory, prod_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, deleteFactory);
            }
        }


        public void Save(BEProducciones bEProducciones)
        {
            BEProduccionesUpdateFactory updateFactory = new BEProduccionesUpdateFactory();
            try
            {
                base.Save(updateFactory, bEProducciones);
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

