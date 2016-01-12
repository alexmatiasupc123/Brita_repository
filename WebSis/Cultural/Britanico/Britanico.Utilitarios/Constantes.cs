using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Britanico.Utilitario
{
    public class Constantes
    {
        public static readonly string NOMBRECONEXION = "britanico";
        public static readonly string ERRORClient = "ErrorClient";
        public static readonly string ERRORServer = "ErrorServer";
        public static readonly string ERRORDB = "ErrorDB";

        public static readonly string PagERRORClient = "../Error/ErrorUI.aspx";
        public static readonly string PagERRORServer = "../Error/ErrorBack.aspx";

        public static readonly int NumIntervaloAnio = 5;

        public static readonly int TamañoPagina = 10;

    
        public static string CORREOENVIO = System.Configuration.ConfigurationSettings.AppSettings["CorreoEnvio"];
        public static string PUERTO = System.Configuration.ConfigurationSettings.AppSettings["port"];
        public static string HOST = System.Configuration.ConfigurationSettings.AppSettings["host"];
        public static string MENSAJETITULO = System.Configuration.ConfigurationSettings.AppSettings["CorreoTitulo"];
        public static string RESPUESTATITULO = System.Configuration.ConfigurationSettings.AppSettings["RespuestaTitulo"];
        public static string RESPUESTAMENSAJE = System.Configuration.ConfigurationSettings.AppSettings["RespuestaMensaje"];
        public static string CONTENIDOMENSAJE = System.Configuration.ConfigurationSettings.AppSettings["ContenidoMensaje"];

        public static string correoUSUARIO = System.Configuration.ConfigurationSettings.AppSettings["EMusuario"];
        public static string correoPASSWORD = System.Configuration.ConfigurationSettings.AppSettings["EMpassword"];
        public static string ssl = System.Configuration.ConfigurationSettings.AppSettings["ssl"];
             
    }

 
    public class SessionValores
    {
        public static readonly string SESSIONNumPagina = "numPag";
        public static readonly string SESSIONTotalImagenes = "totalImagenes";
        public static readonly string SESSIONTotalImagenesRecorridas = "totalImagenesRecorridas";
        public static readonly string SESSIONvTotalImagenes = "vtotalImagenes";

        public static readonly string SESSIONCNumPagina = "CNumPagina";



    }



  

}
