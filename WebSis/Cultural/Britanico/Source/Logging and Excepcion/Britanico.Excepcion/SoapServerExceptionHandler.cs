using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System.Web.Services.Protocols;
using System.Xml;
using System.Runtime.Serialization.Formatters.Soap;
using System.Collections.Specialized;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling.Configuration;

namespace Britanico.Excepcion
{

    [ConfigurationElementType(typeof(CustomHandlerData))]
    public class SoapServerExceptionHandler : IExceptionHandler
    {
        private static int _eventId = 0;
        /// <summary>
        /// The synchronization object for the event Id
        /// </summary>
        private object _syncEventId = new object();

        private int GetNextEventId()
        {
            lock (_syncEventId)
            {
                return _eventId++;
            }
        }

        public SoapServerExceptionHandler(NameValueCollection ignore)
        {
        }             
     
        public Exception HandleException(Exception exception, Guid handlingInstanceId)
        {            
            SoapException soapEx = exception as SoapException;

            if (soapEx == null)
            {
                XmlNode detail = this.SerializeException(exception);
                string actor = System.Web.HttpContext.Current.Request.Url.ToString();
                XmlQualifiedName qualifiedName;
                if (exception is Excepcion.ConstraintException)
                    qualifiedName = SoapException.ClientFaultCode;
                else
                    qualifiedName = SoapException.ServerFaultCode;

                soapEx = new SoapException(exception.Message, qualifiedName, actor, detail, exception);
            }

            return soapEx;

        }

        private XmlElement SerializeException(Exception exception)
        {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            SoapFormatter formatter = new SoapFormatter();
                        
            System.IO.TextReader reader = null;

            try
            {
                formatter.Serialize(stream, exception);
                stream.Position = 0;

                XmlDocument dom = new XmlDocument();
                dom.AppendChild(dom.CreateElement("detail"));

                reader = new System.IO.StreamReader(stream);
                string datos = reader.ReadToEnd();
                dom.DocumentElement.InnerXml = datos;

                XmlNamespaceManager nsmgr = new XmlNamespaceManager(dom.NameTable);
                this.ClearElementContent(dom.DocumentElement, "//StackTraceString", nsmgr);
                this.ClearElementContent(dom.DocumentElement, "//RemoteStackTraceString", nsmgr);
                this.ClearElementContent(dom.DocumentElement, "//ExceptionMethod", nsmgr);

                return dom.DocumentElement;
            }
            catch (Exception ex1)
            {
                return null;
            }
            finally
            {
                if (reader != null)
                    reader.Close();

                ((IDisposable)stream).Dispose();
            }
        }
        private void ClearElementContent(XmlElement el, string xpath, XmlNamespaceManager nsmgr)
        {
            XmlNodeList nodes = el.SelectNodes(xpath, nsmgr);
            if (nodes != null)
                foreach (XmlNode node in nodes)
                    node.InnerXml = "";
        }



    }
}
