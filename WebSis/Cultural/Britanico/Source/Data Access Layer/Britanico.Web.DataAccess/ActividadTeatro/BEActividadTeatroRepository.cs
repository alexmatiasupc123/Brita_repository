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
    /// Respository that lets you find BEActividadTeatro in the
    /// CRM database.
    /// </summary>
    public class BEActividadTeatroRepository : Repository<BEActividadTeatro>
    {
        private string databaseName;

        public BEActividadTeatroRepository(string databaseName)
            : base(databaseName)
        {
            this.databaseName = databaseName;
        }


        public BEActividadTeatro uspMListarRegistroActividad(System.Int32 teat_codi)
        {
            ISelectionFactory<System.Int32> selectionFactory = new uspMListarRegistroActividadSelectionFactory();

            try
            {
                return base.FindOne(selectionFactory, new uspMListarRegistroActividadFactory(), teat_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new BEActividadTeatro();
        }

        public List<BEActividadTeatro> uspMListarTodosActividad()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosActividadSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosActividadFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEActividadTeatro>();
        }

        public List<BEActividadTeatro> uspMListarTodosActividadDestacados()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosActividadDestacadosSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosActividadDestacadosFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEActividadTeatro>();
        }


        public List<BEActividadTeatro> uspMListarTodosActividadResumen()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosActividadResumenSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosActividadResumenFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEActividadTeatro>();
        }

        public void Add(BEActividadTeatro bEActividadTeatro)
        {
            BEActividadTeatroInsertFactory insertFactory = new BEActividadTeatroInsertFactory();
            try
            {
                base.Add(insertFactory, bEActividadTeatro);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, insertFactory);
            }
        }

        public void Remove(System.Int32 teat_codi)
        {
            IDeleteFactory<System.Int32> deleteFactory = new BEActividadTeatroDeleteFactory();

            try
            {
                base.Remove(deleteFactory, teat_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, deleteFactory);
            }
        }


        public void Save(BEActividadTeatro bEActividadTeatro)
        {
            BEActividadTeatroUpdateFactory updateFactory = new BEActividadTeatroUpdateFactory();
            try
            {
                base.Save(updateFactory, bEActividadTeatro);
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

