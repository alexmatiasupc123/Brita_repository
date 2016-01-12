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
    /// Respository that lets you find BECursoTaller in the
    /// CRM database.
    /// </summary>
    public class BECursoTallerRepository : Repository<BECursoTaller>
    {
        private string databaseName;

        public BECursoTallerRepository(string databaseName)
            : base(databaseName)
        {
            this.databaseName = databaseName;
        }


        public List<BECursoTaller> uspMListarTodosCursosXSede(System.Int32 sede)
        {
            ISelectionFactory<System.Int32> selectionFactory = new uspMListarTodosCursosXSedeSelectionFactory();

            try
            {
                return base.Find(selectionFactory, new uspMListarTodosCursosXSedeFactory(), sede);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BECursoTaller>();
        }

        public BECursoTaller uspMListarRegistroCurso(System.Int32 prog_codi)
        {
            ISelectionFactory<System.Int32> selectionFactory = new uspMListarRegistroCursoSelectionFactory();

            try
            {
                return base.FindOne(selectionFactory, new uspMListarRegistroCursoFactory(), prog_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new BECursoTaller();
        }

        public List<BECursoTaller> uspMListarTodosCursoTaller()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosCursoSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosCursoFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BECursoTaller>();
        }


        public List<BECursoTaller> uspMListarTodosCursoTallerDestacados()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosCursoDestacadosSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosCursoDestacadosFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BECursoTaller>();
        }


        public void Add(BECursoTaller bECursoTaller)
        {
            BECursoTallerInsertFactory insertFactory = new BECursoTallerInsertFactory();
            try
            {
                base.Add(insertFactory, bECursoTaller);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, insertFactory);
            }
        }


        public void Save(BECursoTaller bECursoTaller)
        {
            BECursoTallerUpdateFactory updateFactory = new BECursoTallerUpdateFactory();
            try
            {
                base.Save(updateFactory, bECursoTaller);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, updateFactory);
            }
        }

        public void Remove(System.Int32 curs_codi)
        {
            IDeleteFactory<System.Int32> deleteFactory = new BECursoTallerDeleteFactory();

            try
            {
                base.Remove(deleteFactory, curs_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, deleteFactory);
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

