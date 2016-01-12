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
    /// Respository that lets you find BEGaleriaArchivo in the
    /// CRM database.
    /// </summary>
    public class BEGaleriaArchivoRepository : Repository<BEGaleriaArchivo>
    {
        private string databaseName;

        public BEGaleriaArchivoRepository(string databaseName)
            : base(databaseName)
        {
            this.databaseName = databaseName;
        }


        public BEGaleriaArchivo uspMListarRegistroArchivo(System.Int32 arch_codi)
        {
            ISelectionFactory<System.Int32> selectionFactory = new uspMListarRegistroArchivoSelectionFactory();

            try
            {
                return base.FindOne(selectionFactory, new uspMListarRegistroArchivoFactory(), arch_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new BEGaleriaArchivo();
        }

        public List<BEGaleriaArchivo> uspMListarTodosArchivo()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosArchivoSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosArchivoFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEGaleriaArchivo>();
        }

        public List<BEGaleriaArchivo> uspMListarTodosArchivoXFiltros(System.Int32 idPadre, System.Int32 tipoEvento, System.String tipoArchivo, System.Int32 numPag)
        {
            ISelectionFactory<uspMListarTodosArchivoXFiltrosIdentity> selectionFactory = new uspMListarTodosArchivoXFiltrosSelectionFactory();

            try
            {

                uspMListarTodosArchivoXFiltrosIdentity uspMListarTodosArchivoXFiltrosIdentity = new uspMListarTodosArchivoXFiltrosIdentity(idPadre, tipoEvento, tipoArchivo, numPag);
                return base.Find(selectionFactory, new uspMListarTodosArchivoXFiltrosFactory(), uspMListarTodosArchivoXFiltrosIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEGaleriaArchivo>();
        }

        public List<BEGaleriaArchivo> uspMListarTodosArchivoXValores(System.Int32 idPadre, System.Int32 tipoEvento, System.String tipoArchivo)
        {
            ISelectionFactory<uspMListarTodosArchivoXValoresIdentity> selectionFactory = new uspMListarTodosArchivoXValoresSelectionFactory();

            try
            {

                uspMListarTodosArchivoXValoresIdentity uspMListarTodosArchivoXValoresIdentity = new uspMListarTodosArchivoXValoresIdentity(idPadre, tipoEvento, tipoArchivo);
                return base.Find(selectionFactory, new uspMListarTodosArchivoXValoresFactory(), uspMListarTodosArchivoXValoresIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEGaleriaArchivo>();
        }

        public List<BEGaleriaArchivo> uspMListarTodosArchivoGaleria(System.Int32 idPadre, System.Int32 tipoEvento)
        {
            ISelectionFactory<uspMListarTodosArchivoGaleriaIdentity> selectionFactory = new uspMListarTodosArchivoGaleriaSelectionFactory();

            try
            {

                uspMListarTodosArchivoGaleriaIdentity uspMListarTodosArchivoGaleriaIdentity = new uspMListarTodosArchivoGaleriaIdentity(idPadre, tipoEvento);
                return base.Find(selectionFactory, new uspMListarTodosArchivoGaleriaFactory(), uspMListarTodosArchivoGaleriaIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEGaleriaArchivo>();
        }



        public List<BEGaleriaArchivo> uspMListarTodosArchivoXGaleria(System.Int32 idPadre, System.Int32 tipoEvento, System.String tipoArchivo)
        {
            ISelectionFactory<uspMListarTodosArchivoXGaleriaIdentity> selectionFactory = new uspMListarTodosArchivoXGaleriaSelectionFactory();

            try
            {

                uspMListarTodosArchivoXGaleriaIdentity uspMListarTodosArchivoXGaleriaIdentity = new uspMListarTodosArchivoXGaleriaIdentity(idPadre, tipoEvento, tipoArchivo);
                return base.Find(selectionFactory, new uspMListarTodosArchivoXGaleriaFactory(), uspMListarTodosArchivoXGaleriaIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEGaleriaArchivo>();
        }

        public void Add(BEGaleriaArchivo bEGaleriaArchivo)
        {
            BEGaleriaArchivoInsertFactory insertFactory = new BEGaleriaArchivoInsertFactory();
            try
            {
                base.Add(insertFactory, bEGaleriaArchivo);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, insertFactory);
            }
        }

        public void Remove(System.Int32 arch_codi)
        {
            IDeleteFactory<System.Int32> deleteFactory = new BEGaleriaArchivoDeleteFactory();

            try
            {
                base.Remove(deleteFactory, arch_codi);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, deleteFactory);
            }
        }


        public void Save(BEGaleriaArchivo bEGaleriaArchivo)
        {
            BEGaleriaArchivoUpdateFactory updateFactory = new BEGaleriaArchivoUpdateFactory();
            try
            {
                base.Save(updateFactory, bEGaleriaArchivo);
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

