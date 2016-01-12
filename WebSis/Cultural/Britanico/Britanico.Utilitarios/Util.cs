using System;
using System.Collections.Generic;
using System.Text;

namespace Britanico.Utilitario
{
    public sealed class Util
    {
        /// <summary>
        /// Helper method, to cast a potentially NULL database value into a Nullable data type
        /// </summary>
        /// <typeparam name="T">.NET structure data type</typeparam>
        /// <param name="dbValue">Value obtained from a database (might be a NULL value)</param>
        /// <returns>Nullable value containing either the value passed in, or null</returns>
        public static Nullable<T> DbValueToNullable<T>(object dbValue) where T : struct
        {
            Nullable<T> returnValue = null;

            if ((dbValue != null) && (dbValue != DBNull.Value))
            {
                returnValue = (T)dbValue;
            }

            return returnValue;
        }

        public static object DbNullableToValue<T>(Nullable<T> dbValue) where T : struct
        {

            T returnValue = dbValue.GetValueOrDefault();
            
            if (dbValue.HasValue) //&& (dbValue != DBNull.Value))
            {
                returnValue = (T)dbValue;
            }

            return (T)returnValue;
        }
    }
}
