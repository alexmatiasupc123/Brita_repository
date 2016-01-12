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
    /// Respository that lets you find BEUsuario in the
    /// CRM database.
    /// </summary>
    public class BEUsuarioRepository : Repository<BEUsuario>
    {
        private string databaseName;

        public BEUsuarioRepository(string databaseName)
            : base(databaseName)
        {
            this.databaseName = databaseName;
        }

      
           

        public List<BEUsuario> uspMListarTodosUsuario()
        {
            ISelectionFactory<NullableIdentity> selectionFactory = new uspMListarTodosUsuarioSelectionFactory();

            try
            {
                NullableIdentity nullableIdentity = new NullableIdentity();
                return base.Find(selectionFactory, new uspMListarTodosUsuarioFactory(), nullableIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new List<BEUsuario>();
        }

        public BEUsuario uspMValidaAccesoUsuario(System.String usuario, System.String clave)
        {
            ISelectionFactory<uspMValidaAccesoUsuarioIdentity> selectionFactory = new uspMValidaAccesoUsuarioSelectionFactory();

            try
            {

                uspMValidaAccesoUsuarioIdentity uspMValidaAccesoUsuarioIdentity = new uspMValidaAccesoUsuarioIdentity(usuario,clave);
                return base.FindOne(selectionFactory, new uspMValidaAccesoUsuarioFactory(), uspMValidaAccesoUsuarioIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new BEUsuario();
        }

        public BEUsuario VerificaLogin(System.String usuario)
        {
            ISelectionFactory<VerificaLoginIdentity> selectionFactory = new VerificaLoginSelectionFactory();

            try
            {

                VerificaLoginIdentity VerificaLoginIdentity = new VerificaLoginIdentity(usuario);
                return base.FindOne(selectionFactory, new VerificaLoginFactory(), VerificaLoginIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new BEUsuario();
        }



        public BEUsuario VerificaModificaLogin(System.Int32 codigo, System.String usuario)
        {
            ISelectionFactory<VerificaModificaLoginIdentity> selectionFactory = new VerificaModificaLoginSelectionFactory();

            try
            {

                VerificaModificaLoginIdentity VerificaModificaLoginIdentity = new VerificaModificaLoginIdentity(codigo,usuario);
                return base.FindOne(selectionFactory, new VerificaModificaLoginFactory(), VerificaModificaLoginIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new BEUsuario();
        }


        public BEUsuario uspMListarRegistroUsuario(System.Int32 user)
        {
            ISelectionFactory<uspMListarRegistroUsuarioIdentity> selectionFactory = new uspMListarRegistroUsuarioSelectionFactory();

            try
            {

                uspMListarRegistroUsuarioIdentity uspMListarRegistroUsuarioIdentity = new uspMListarRegistroUsuarioIdentity(user);
                return base.FindOne(selectionFactory, new uspMListarRegistroUsuarioFactory(), uspMListarRegistroUsuarioIdentity);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, selectionFactory);
            }

            return new BEUsuario();
        }


        public void Add(BEUsuario BEUsuario)
        {
            BEUsuarioInsertFactory insertFactory = new BEUsuarioInsertFactory();
            try
            {
                base.Add(insertFactory, BEUsuario);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, insertFactory);
            }
        }


        public void GuardarLogin(BEUsuario BEUsuario)
        {
            BEUsuarioModificaLoginFactory updateFactory = new BEUsuarioModificaLoginFactory();
            try
            {
                base.Save(updateFactory, BEUsuario);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, updateFactory);
            }
        }


        public void GuardarEmail(BEUsuario BEUsuario)
        {
            BEUsuarioModificaEmailFactory updateFactory = new BEUsuarioModificaEmailFactory();
            try
            {
                base.Save(updateFactory, BEUsuario);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, updateFactory);
            }
        }


        public void GuardarEstado(BEUsuario BEUsuario)
        {
            BEUsuarioModificaEstadoFactory updateFactory = new BEUsuarioModificaEstadoFactory();
            try
            {
                base.Save(updateFactory, BEUsuario);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, updateFactory);
            }
        }


        public void GuardarClave(BEUsuario BEUsuario)
        {
            BEUsuarioModificaClaveFactory updateFactory = new BEUsuarioModificaClaveFactory();
            try
            {
                base.Save(updateFactory, BEUsuario);
            }
            catch (SqlException ex)
            {
                HandleSqlException(ex, updateFactory);
            }
        }

        public void Remove(System.Int32 usua_codi)
        {
            IDeleteFactory<System.Int32> deleteFactory = new BEUsuarioDeleteFactory();

            try
            {
                base.Remove(deleteFactory, usua_codi);
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




