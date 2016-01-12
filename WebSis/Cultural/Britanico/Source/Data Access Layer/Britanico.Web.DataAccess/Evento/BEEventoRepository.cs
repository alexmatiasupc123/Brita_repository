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
    /// Respository that lets you find BEEvento in the
    /// CRM database.
    /// </summary>
    public class BEEventoRepository : Repository<BEEvento>
    {
        private string databaseName;

        public BEEventoRepository(string databaseName)
            : base(databaseName)
        {
            this.databaseName = databaseName;
        }

        public BEEvento uspMListarRegistroEventosDestacado(System.Int32 even_dest)
        {
            ISelectionFactory<System.Int32> selectionFactory = new uspMListarRegistroEventosDestacadoSelectionFactory();

            try
            {
                return base.FindOne(selectionFactory, new uspMListarRegistroEventosDestacadoFactory(), even_dest);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new BEEvento();
        }

        public List<BEEvento> uspMListarTodosEventosXSede(System.Int32 sede_codi)
        {
            ISelectionFactory<System.Int32> selectionFactory = new uspMListarTodosEventosXSedeSelectionFactory();

            try
            {
                return base.Find(selectionFactory, new uspMListarTodosEventosXSedeFactory(), sede_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEEvento>();
        }


        public List<BEEvento> uspMListarTodosEventosXFecha(System.DateTime fecha)
        {
            ISelectionFactory<System.DateTime> selectionFactory = new uspMListarTodosEventosXFechaSelectionFactory();

            try
            {
                return base.Find(selectionFactory, new uspMListarTodosEventosXFechaFactory(), fecha);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEEvento>();
        }


        public List<BEEvento> uspMListarTodosEventosXstrFecha(System.String fecha)
        {
            ISelectionFactory<System.String> selectionFactory = new uspMListarTodosEventosXstrFechaSelectionFactory();

            try
            {
                return base.Find(selectionFactory, new uspMListarTodosEventosXstrFechaFactory(), fecha);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEEvento>();
        }


        public List<BEEvento> uspMListarTodosEventosXPalabra(System.String criterio)
        {
            ISelectionFactory<System.String> selectionFactory = new uspMListarTodosEventosXPalabraSelectionFactory();

            try
            {
                return base.Find(selectionFactory, new uspMListarTodosEventosXPalabraFactory(), criterio);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEEvento>();
        }



       public List<BEEvento> uspMListarTodosEventos()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosEventosSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosEventosFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEEvento>();
        }

        public List<BEEvento> uspMListarTodosEventosProximos()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosEventosProximosSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosEventosProximosFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEEvento>();
        }



        public List<BEEvento> uspMListarTodosEventosDestacados()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosEventosDestacadosSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosEventosDestacadosFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEEvento>();
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

