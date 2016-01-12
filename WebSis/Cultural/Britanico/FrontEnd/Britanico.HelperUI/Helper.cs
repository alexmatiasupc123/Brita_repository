using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Services.Protocols;
using Britanico.Utilitario;
using Britanico.Excepcion;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace Britanico.HelperUI
{
    public class Helper
    {
        public static void RegistrarError(Exception ex)
        {
            //try
            //{
            //    ExceptionPolicy.HandleException(ex, "Exception Policy");
            //}
            //catch (Excepcion.ConstraintException exD)
            //{
            //    //System.Web.HttpContext.Current.Request.Params.Add("Error Constraint", "lblError");
            //    System.Web.HttpContext.Current.Session.Add(Constantes.ERRORDB, MensajesError.EliminarCONSTRAINT);                    
            //}
            //catch (SoapException exD)
            //{
            //    System.Web.HttpContext.Current.Session.Add(Constantes.ERRORServer, exD.Detail);
            //    System.Web.HttpContext.Current.Response.Redirect(Constantes.PagERRORServer);
            //}
            //catch (Exception exD)
            //{
            //    System.Web.HttpContext.Current.Session.Add(Constantes.ERRORClient, exD.Message);
            //    System.Web.HttpContext.Current.Response.Redirect(Constantes.PagERRORClient);
            //}
                        
        }
                
    }
}
