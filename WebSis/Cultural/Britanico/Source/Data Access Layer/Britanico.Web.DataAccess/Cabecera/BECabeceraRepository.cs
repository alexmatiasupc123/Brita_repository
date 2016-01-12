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
    /// Respository that lets you find BECabecera in the
    /// CRM database.
    /// </summary>
    public class BECabeceraRepository : Repository<BECabecera>
    {
        private string databaseName;

        public BECabeceraRepository(string databaseName)
            : base(databaseName)
        {
            this.databaseName = databaseName;
        }

       
        public List<BECabecera> uspMListarTodosCabecera()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosCabeceraSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosCabeceraFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BECabecera>();
        }
        
        public BECabecera uspMListarXTituloCabecera(System.String cabe_titu)
        {
            ISelectionFactory<System.String> selectionFactory = new uspMListarXTituloCabeceraSelectionFactory();

            try
            {
                return base.FindOne(selectionFactory, new uspMListarXTituloCabeceraFactory(), cabe_titu);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new BECabecera();
        }

        public void Add(BECabecera bECabecera)
        {
            BECabeceraInsertFactory insertFactory = new BECabeceraInsertFactory();
            try
            {
                base.Add(insertFactory, bECabecera);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, insertFactory);
            }
        }

       
        public void Save(BECabecera bECabecera)
        {
            BECabeceraUpdateFactory updateFactory = new BECabeceraUpdateFactory();
            try
            {
                base.Save(updateFactory, bECabecera);
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

