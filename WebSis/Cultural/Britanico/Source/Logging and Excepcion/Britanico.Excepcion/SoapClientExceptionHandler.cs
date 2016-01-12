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
    public class SoapClientExceptionHandler : IExceptionHandler
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

        public SoapClientExceptionHandler(NameValueCollection ignore)
        {
        }

        public Exception HandleException(Exception exception, Guid handlingInstanceId)
        {
            SoapException soapEx = exception as SoapException;

            if (soapEx == null) return exception;

            Exception ex = null;
            XmlReader reader = null;
            XmlWriter writer = null;
            System.IO.MemoryStream stream = new System.IO.MemoryStream();

            try
            {
                SoapFormatter formatter = new SoapFormatter();
                reader = new XmlNodeReader(soapEx.Detail.ChildNodes[0]);

                writer = new XmlTextWriter(stream, System.Text.Encoding.UTF8);
                writer.WriteNode(reader, true);
                writer.Flush();

                stream.Position = 0;
                ex = formatter.Deserialize(stream) as Exception;                
            }
            catch (Exception ex1)
            {

            }
            finally
            {
                if (reader != null)
                    reader.Close();

                if (writer != null)
                    writer.Close();

                ((IDisposable)stream).Dispose();
            }

            if (ex == null) ex = exception;
            return ex;


        }

    }
}
