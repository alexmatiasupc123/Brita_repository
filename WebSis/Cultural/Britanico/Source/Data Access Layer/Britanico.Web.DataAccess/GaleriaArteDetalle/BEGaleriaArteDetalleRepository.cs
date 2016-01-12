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
    /// Respository that lets you find BEGaleriaArteDetalle in the
    /// CRM database.
    /// </summary>
    public class BEGaleriaArteDetalleRepository : Repository<BEGaleriaArteDetalle>
    {
        private string databaseName;

        public BEGaleriaArteDetalleRepository(string databaseName)
            : base(databaseName)
        {
            this.databaseName = databaseName;
        }


        public BEGaleriaArteDetalle uspMListarRegistroGaleriaArteDetalle(System.Int32 gade_codi)
        {
            ISelectionFactory<System.Int32> selectionFactory = new uspMListarRegistroGaleriaArteDetalleSelectionFactory();

            try
            {
                return base.FindOne(selectionFactory, new uspMListarRegistroGaleriaArteDetalleFactory(), gade_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new BEGaleriaArteDetalle();
        }

        public List<BEGaleriaArteDetalle> uspMListarTodosXGaleria(System.Int32 gale_codi)
        {
            ISelectionFactory<System.Int32> selectionFactory = new uspMListarTodosGaleriaArteDetalleXGaleriaSelectionFactory();

            try
            {
                return base.Find(selectionFactory, new uspMListarTodosGaleriaArteDetalleXGaleriaFactory(), gale_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEGaleriaArteDetalle>();
        }

        public List<BEGaleriaArteDetalle> uspMListarTodosDetalleXGaleria(System.Int32 gale_codi)
        {
            ISelectionFactory<System.Int32> selectionFactory = new uspMListarTodosGaleriaDetalleXGaleriaSelectionFactory();

            try
            {
                return base.Find(selectionFactory, new uspMListarTodosGaleriaDetalleXGaleriaFactory(), gale_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEGaleriaArteDetalle>();
        }

        public List<BEGaleriaArteDetalle> uspMListarTodosGaleriaArteDetalle()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosGaleriaArteDetalleSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosGaleriaArteDetalleFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEGaleriaArteDetalle>();
        }

        public List<BEGaleriaArteDetalle> uspMListarTodosGaleriaArteDetalleDestacados()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosGaleriaArteDetalleDestacadosSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosGaleriaArteDetalleDestacadosFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEGaleriaArteDetalle>();
        }



        public void Add(BEGaleriaArteDetalle bEGaleriaArteDetalle)
        {
            BEGaleriaArteDetalleInsertFactory insertFactory = new BEGaleriaArteDetalleInsertFactory();
            try
            {
                base.Add(insertFactory, bEGaleriaArteDetalle);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, insertFactory);
            }
        }

        public void Remove(System.Int32 gade_codi)
        {
            IDeleteFactory<System.Int32> deleteFactory = new BEGaleriaArteDetalleDeleteFactory();

            try
            {
                base.Remove(deleteFactory, gade_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, deleteFactory);
            }
        }


        public void Save(BEGaleriaArteDetalle bEGaleriaArteDetalle)
        {
            BEGaleriaArteDetalleUpdateFactory updateFactory = new BEGaleriaArteDetalleUpdateFactory();
            try
            {
                base.Save(updateFactory, bEGaleriaArteDetalle);
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

