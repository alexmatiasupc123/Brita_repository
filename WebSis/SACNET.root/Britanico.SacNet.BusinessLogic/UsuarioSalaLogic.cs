using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Configuration;
using System.Transactions;
using System.Collections;

using Britanico.SacNet.BusinessEntities;
using Britanico.SacNet.DataAccess;
using Oxinet.Tools;
using System.Data;

namespace Britanico.SacNet.BusinessLogic
{
    public class UsuarioSalaLogic
    {
        private UsuarioSalaData oUsuarioSalaData = null;
        private ReturnValor oReturnValor = null;

        public UsuarioSalaLogic()
        {
            oUsuarioSalaData = new UsuarioSalaData();
            oReturnValor = new ReturnValor();
        }

        #region /* Proceso de SELECT ALL */

        public List<UsuarioSala> ListarUsuarioSala(string prm_sCodSac, Nullable<DateTime> prm_dFechaINI, Nullable<DateTime> prm_dFechaFIN, string prm_sCodUsuarioSAC, string prm_sCodUsuarioSACNombre)
        {
            List<UsuarioSala> miLista = new List<UsuarioSala>();
            List<UsuarioSala> miListaNueva = new List<UsuarioSala>();
            try
            {
                miLista = oUsuarioSalaData.ListarTodos(prm_sCodSac, HelpDates.FormatFechaYMD(prm_dFechaINI), HelpDates.FormatFechaYMD(prm_dFechaFIN), prm_sCodUsuarioSAC, prm_sCodUsuarioSACNombre);
                
                foreach (UsuarioSala xitem in miLista)
                {
                    miListaNueva.Add(xitem);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miListaNueva;
        }
        #endregion

        #region /* Proceso de SELECT BY ID CODE */

        public UsuarioSala BuscarRegistroUsuarioSala(string prm_sCodRegistro)
        {
            UsuarioSala miEntidad = new UsuarioSala();
            try
            {
                miEntidad = oUsuarioSalaData.BuscarRegistroUsuarioSala(prm_sCodRegistro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miEntidad;
        }

        public UsuarioSala BuscarRegistroUsuarioSala_x_Usuario(string prm_sCodUsuarioSac)
        {
            UsuarioSala miEntidad = new UsuarioSala();
            try
            {
                miEntidad = oUsuarioSalaData.BuscarRegistroUsuarioSala_x_Usuario(prm_sCodUsuarioSac);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return miEntidad;
        }

        #endregion

        #region /* Proceso de INSERT RECORD */

        public ReturnValor RegistrarUsuarioSala(UsuarioSala item)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.CodigoRetorno = oUsuarioSalaData.RegistrarUsuarioSala(item);

                    if (oReturnValor.CodigoRetorno != null)
                    {
                        oReturnValor.Exitosa = true;
                        oReturnValor.Message = HelpMessage.Message(HelpMessage.TMessage.Registrar);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpMessage.Message(ex);
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de UPDATE RECORD */

        public ReturnValor RegistrarUsuarioSala_Salida(UsuarioSala item)
        {
            try
            {
                using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
                {
                    oReturnValor.Exitosa = oUsuarioSalaData.RegistrarUsuarioSala_Salida(item);

                    if (oReturnValor.Exitosa)
                    {
                        oReturnValor.Message = HelpMessage.Message(HelpMessage.TMessage.Editar);
                        tx.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                oReturnValor = HelpMessage.Message(ex);
            }
            return oReturnValor;
        }

        #endregion

        #region /* Proceso de DELETE BY ID CODE */

        //public ReturnValor Eliminar(string prm_sCodPrestamo)
        //{
        //    try
        //    {
        //        using (TransactionScope tx = new TransactionScope(TransactionScopeOption.Required))
        //        {
        //            oReturnValor.Exitosa = oPrestamoData.Eliminar(prm_sCodPrestamo);
        //            if (oReturnValor.Exitosa)
        //            {
        //                oReturnValor.Message = HelpMessage.Message(HelpMessage.TMessage.Eliminar);
        //                tx.Complete();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        oReturnValor = HelpMessage.Message(ex);
        //    }
        //    return oReturnValor;
        //}

        #endregion

    }
} 
