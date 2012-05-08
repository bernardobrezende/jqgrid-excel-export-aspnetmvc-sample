using System;
using System.Collections.Generic;
using System.Linq;

namespace Website.Utils
{
    public static class IEnumerableExtensions
    {
        public static object ToJsonForjqGrid<T>(this IEnumerable<T> list, string primaryKey, string[] columnNames)             
        {
            if (list == null || list.Count() == 0)
                throw new ArgumentException("Collection cannot be null or empty!");

            var jsonData = new
            {
                rows = (from p in list
                        select new
                        {
                            id = p.GetPropertyValue(primaryKey),
                            cell = p.GetPropertyValues(columnNames)
                        }).ToArray()
            };

            return jsonData;
        }

        #region Auxiliar methods

        private static object GetPropertyValue(this object o, string propertyName)
        {
            object objValue = null;

            var propertyInfo = o.GetType().GetProperty(propertyName);
            if (propertyInfo != null)
                objValue = propertyInfo.GetValue(o, null);

            return objValue;
        }

        private static string[] GetPropertyValues(this object o, IEnumerable<string> columnNames)
        {
            var list = new List<String>();

            foreach (string columnName in columnNames)
            {
                list.Add(o.GetPropertyValue(columnName).ToString());
            }

            return list.ToArray();
        }

        private static string[] GetPropertiesAsStringArray<T>(T o)
        {
            var properties = from p in o.GetType().GetProperties()
                             select p.Name;

            return properties.ToArray();
        }

        #endregion

    }
}