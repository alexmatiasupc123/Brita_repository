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
    /// Respository that lets you find BEGaleriaArte in the
    /// CRM database.
    /// </summary>
    public class BEGaleriaArteRepository : Repository<BEGaleriaArte>
    {
        private string databaseName;

        public BEGaleriaArteRepository(string databaseName)
            : base(databaseName)
        {
            this.databaseName = databaseName;
        }


        public BEGaleriaArte uspMListarRegistroGaleria(System.Int32 gale_codi)
        {
            ISelectionFactory<System.Int32> selectionFactory = new uspMListarRegistroGaleriaSelectionFactory();

            try
            {
                return base.FindOne(selectionFactory, new uspMListarRegistroGaleriaFactory(), gale_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new BEGaleriaArte();
        }

        public List<BEGaleriaArte> uspMListarTodosGaleria()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosGaleriaSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosGaleriaFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEGaleriaArte>();
        }

        public void Add(BEGaleriaArte bEGaleriaArte)
        {
            BEGaleriaArteInsertFactory insertFactory = new BEGaleriaArteInsertFactory();
            try
            {
                base.Add(insertFactory, bEGaleriaArte);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, insertFactory);
            }
        }

        public void Remove(System.Int32 gale_codi)
        {
            IDeleteFactory<System.Int32> deleteFactory = new BEGaleriaArteDeleteFactory();

            try
            {
                base.Remove(deleteFactory, gale_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, deleteFactory);
            }
        }


        public void Save(BEGaleriaArte bEGaleriaArte)
        {
            BEGaleriaArteUpdateFactory updateFactory = new BEGaleriaArteUpdateFactory();
            try
            {
                base.Save(updateFactory, bEGaleriaArte);
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

