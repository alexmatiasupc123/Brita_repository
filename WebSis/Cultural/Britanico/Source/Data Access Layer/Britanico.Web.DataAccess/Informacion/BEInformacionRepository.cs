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
    /// Respository that lets you find BEInformacion in the
    /// CRM database.
    /// </summary>
    public class BEInformacionRepository : Repository<BEInformacion>
    {
        private string databaseName;

        public BEInformacionRepository(string databaseName)
            : base(databaseName)
        {
            this.databaseName = databaseName;
        }

        public BEInformacion uspMListarRegistroInformacion(System.Int32 info_codi)
        {
            ISelectionFactory<System.Int32> selectionFactory = new uspMListarRegistroInformacionSelectionFactory();

            try
            {
                return base.FindOne(selectionFactory, new uspMListarRegistroInformacionFactory(), info_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new BEInformacion();
        }
     
        public List<BEInformacion> uspMListarTodosProximamente()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosProximamenteSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosProximamenteFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEInformacion>();
        }

        public List<BEInformacion> uspMListarTodosInformacionXEvento(System.Int32 even_codi)
        {
            ISelectionFactory<System.Int32> selectionFactory = new uspMListarTodosInformacionXEventoSelectionFactory();

            try
            {
                return base.Find(selectionFactory, new uspMListarTodosInformacionXEventoFactory(), even_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEInformacion>();
        }



        public void Add(BEInformacion bEInformacion)
        {
            BEInformacionInsertFactory insertFactory = new BEInformacionInsertFactory();
            try
            {
                base.Add(insertFactory, bEInformacion);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, insertFactory);
            }
        }

        public void Remove(System.Int32 brad_codi)
        {
            IDeleteFactory<System.Int32> deleteFactory = new BEInformacionDeleteFactory();

            try
            {
                base.Remove(deleteFactory, brad_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, deleteFactory);
            }
        }


        public void Save(BEInformacion bEInformacion)
        {
            BEInformacionUpdateFactory updateFactory = new BEInformacionUpdateFactory();
            try
            {
                base.Save(updateFactory, bEInformacion);
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

