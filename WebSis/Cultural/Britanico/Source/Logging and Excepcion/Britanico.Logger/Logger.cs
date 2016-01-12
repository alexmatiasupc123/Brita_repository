using System;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Web;
using System.Data.SqlClient;

namespace Britanico.Logger
{
    
        public sealed class Logger
        {
            /// <summary>
            /// Logs an exception message or an information message to the trace log.
            /// </summary>
            /// <param name="message">The message to be logged</param>
            /// <param name="isException">Boolean flag, indicates whether this is an exception message (as opposed to an information message)</param>
            private static void LogMessage(string message, bool isException)
            {
                if (message == null) message = string.Empty;

                message =
                    Environment.NewLine +
                    DateTime.Now.ToString() +
                    Environment.NewLine +
                    message +
                    Environment.NewLine;

                TraceContext webTrace = HttpContext.Current.Trace;
                if (isException)
                {
                    webTrace.Warn(message);
                    Trace.TraceError(message);
                }
                else
                {
                    webTrace.Write(message);
                    Trace.TraceInformation(message);
                }
                Trace.Close();
            }

            /// <summary>
            /// Logs an information message to the trace log.
            /// </summary>
            /// <param name="message">The message to be logged</param>
            public static void LogMessage(string message)
            {
                LogMessage(message, false);
            }

            /// <summary>
            /// Logs an exception to the trace log.
            /// </summary>
            /// <param name="ex">The exception to be logged</param>
            public static void LogException(Exception ex)
            {
                try
                {
                    SqlException sqlEx = ex as SqlException;
                    if (sqlEx != null)
                    {
                        StringBuilder builder = new StringBuilder();
                        builder.Append(sqlEx.ToString());

                        builder.Append(Environment.NewLine);
                        builder.Append("   Severity: ");
                        builder.Append(sqlEx.Class);

                        builder.Append(Environment.NewLine);
                        builder.Append("   Message: ");
                        builder.Append(sqlEx.Message);

                        LogMessage(builder.ToString(), true);

                        LogSqlErrors("SqlErrors: ", sqlEx.Errors);
                    }
                    else
                    {
                        LogMessage(ex.ToString(), true);
                    }
                }
                catch
                {
                    // Exceptions thrown during exception logging are suppressed
                    // since they cannot be logged.
                }
            }

            /// <summary>
            /// Logs a collection of SQL errors to the trace log.
            /// </summary>
            /// <param name="message">Introductory message</param>
            /// <param name="errors">Collection of SQL errors to be logged</param>
            public static void LogSqlErrors(string message, SqlErrorCollection errors)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(message);

                foreach (SqlError error in errors)
                {
                    builder.Append(Environment.NewLine);
                    builder.Append("   Procedure: ");
                    builder.Append(error.Procedure);

                    builder.Append(Environment.NewLine);
                    builder.Append("   Line number: ");
                    builder.Append(error.LineNumber);

                    builder.Append(Environment.NewLine);
                    builder.Append("   Severity level: ");
                    builder.Append(error.Class);

                    builder.Append(Environment.NewLine);
                    builder.Append("   Message: ");
                    builder.Append(error.Message);

                    builder.Append(Environment.NewLine);
                    builder.Append("   Server: ");
                    builder.Append(error.Server);

                    builder.Append(Environment.NewLine);
                    builder.Append("   State: ");
                    builder.Append(error.State);
                }

                LogMessage(builder.ToString());
            }

            /// <summary>
            /// Logs connection StateChange events to the trace log.
            /// </summary>
            /// <param name="sender">Object that raised the event</param>
            /// <param name="args">Event context information</param>
            public static void LogConnectionStateChange(Object sender, StateChangeEventArgs args)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append("Connection StateChange event:");
                builder.Append(Environment.NewLine);
                builder.Append("   OriginalState: " + args.OriginalState);
                builder.Append("   CurrentState:  " + args.CurrentState);

                LogMessage(builder.ToString());
            }

            /// <summary>
            /// Logs connection InfoMessage events to the trace log.
            /// </summary>
            /// <param name="sender">Object that raised the event</param>
            /// <param name="args">Event context information</param>
            public static void LogConnectionInfoMessage(Object sender, SqlInfoMessageEventArgs args)
            {
                LogSqlErrors("Connection InfoMessage event, SQL errors: ", args.Errors);
            }

        }
 
}