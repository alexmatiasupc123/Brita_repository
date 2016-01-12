using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Britanico.Excepcion
{
	/// <summary>
    /// This exception is thrown when a concurrency
    /// violation is detected in the database.
    /// </summary>
    [Serializable]
    public class ConstraintException : RepositoryException
    {
        public ConstraintException()
        {
        }

        public ConstraintException(string message)
            : base(message)
        {
        }

        public ConstraintException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected ConstraintException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}

