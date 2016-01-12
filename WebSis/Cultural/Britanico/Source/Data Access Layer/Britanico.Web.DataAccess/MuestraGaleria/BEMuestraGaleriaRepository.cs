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
    /// Respository that lets you find BEMuestraGaleria in the
    /// CRM database.
    /// </summary>
    public class BEMuestraGaleriaRepository : Repository<BEMuestraGaleria>
    {
        private string databaseName;

        public BEMuestraGaleriaRepository(string databaseName)
            : base(databaseName)
        {
            this.databaseName = databaseName;
        }


        public BEMuestraGaleria uspMListarRegistroMuestraGaleria(System.Int32 mues_codi)
        {
            ISelectionFactory<System.Int32> selectionFactory = new uspMListarRegistroMuestraGaleriaSelectionFactory();

            try
            {
                return base.FindOne(selectionFactory, new uspMListarRegistroMuestraGaleriaFactory(), mues_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new BEMuestraGaleria();
        }

        public List<BEMuestraGaleria> uspMListarTodosMuestraGaleriaXGaleria(System.Int32 gale_codi)
        {
            ISelectionFactory<System.Int32> selectionFactory = new uspMListarTodosMuestraGaleriaXGaleriaSelectionFactory();

            try
            {
                return base.Find(selectionFactory, new uspMListarTodosMuestraGaleriaXGaleriaFactory(), gale_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEMuestraGaleria>();
        }


        public List<BEMuestraGaleria> uspMListarTodosMuestraGaleria()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosMuestraGaleriaSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosMuestraGaleriaFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEMuestraGaleria>();
        }

       



        public void Add(BEMuestraGaleria bEMuestraGaleria)
        {
            BEMuestraGaleriaInsertFactory insertFactory = new BEMuestraGaleriaInsertFactory();
            try
            {
                base.Add(insertFactory, bEMuestraGaleria);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, insertFactory);
            }
        }

        public void Remove(System.Int32 mues_codi)
        {
            IDeleteFactory<System.Int32> deleteFactory = new BEMuestraGaleriaDeleteFactory();

            try
            {
                base.Remove(deleteFactory, mues_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, deleteFactory);
            }
        }


        public void Save(BEMuestraGaleria bEMuestraGaleria)
        {
            BEMuestraGaleriaUpdateFactory updateFactory = new BEMuestraGaleriaUpdateFactory();
            try
            {
                base.Save(updateFactory, bEMuestraGaleria);
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

