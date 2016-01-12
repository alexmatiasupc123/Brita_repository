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
    /// Respository that lets you find BEBanner in the
    /// CRM database.
    /// </summary>
    public class BEBannerRepository : Repository<BEBanner>
    {
        private string databaseName;

        public BEBannerRepository(string databaseName)
            : base(databaseName)
        {
            this.databaseName = databaseName;
        }


        public BEBanner uspMListarRegistroBanner(System.Int32 bann_codi)
        {
            ISelectionFactory<System.Int32> selectionFactory = new uspMListarRegistroBannerSelectionFactory();

            try
            {
                return base.FindOne(selectionFactory, new uspMListarRegistroBannerFactory(), bann_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new BEBanner();
        }

        public List<BEBanner> uspMListarTodosBanner()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosBannerSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosBannerFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEBanner>();
        }

        public List<BEBanner> uspMListarTodosBannerSimples()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosBannerSimpleSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosBannerSimpleFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEBanner>();
        }


        public List<BEBanner> uspMListarTodosBannerPrincipal()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosBannerPrincipalSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosBannerPrincipalFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEBanner>();
        }

        public List<BEBanner> uspMListarTodosBannerRedSocial()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosBannerRedSocialSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosBannerRedSocialFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEBanner>();
        }

        public void Add(BEBanner bEBanner)
        {
            BEBannerInsertFactory insertFactory = new BEBannerInsertFactory();
            try
            {
                base.Add(insertFactory, bEBanner);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, insertFactory);
            }
        }

        public void Remove(System.Int32 bann_codi)
        {
            IDeleteFactory<System.Int32> deleteFactory = new BEBannerDeleteFactory();

            try
            {
                base.Remove(deleteFactory, bann_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, deleteFactory);
            }
        }


        public void Save(BEBanner bEBanner)
        {
            BEBannerUpdateFactory updateFactory = new BEBannerUpdateFactory();
            try
            {
                base.Save(updateFactory, bEBanner);
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

